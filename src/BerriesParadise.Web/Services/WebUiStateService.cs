using BerriesParadise.Core.Models;
using BerriesParadise.Content.Catalogs;

namespace BerriesParadise.Web.Services;

public class WebUiStateService
{
    private readonly BerryCatalog _berryCatalog;
    private readonly ProductCatalog _productCatalog;
    private readonly GeneticsCatalog _geneticsCatalog;
    private readonly QualityCatalog _qualityCatalog;
    private readonly RecipeCatalog _recipeCatalog;
    private readonly LocalizationService _loc;

    public WebUiStateService(
        BerryCatalog berryCatalog,
        ProductCatalog productCatalog,
        GeneticsCatalog geneticsCatalog,
        QualityCatalog qualityCatalog,
        RecipeCatalog recipeCatalog,
        LocalizationService loc)
    {
        _berryCatalog = berryCatalog;
        _productCatalog = productCatalog;
        _geneticsCatalog = geneticsCatalog;
        _qualityCatalog = qualityCatalog;
        _recipeCatalog = recipeCatalog;
        _loc = loc;
        SelectedProduct = GetLocalizedProduct(_productCatalog.GetFeatured());
        ActiveProcessStep = 1;
        ActiveRecipeIndex = 0;
    }

    public string CurrentLanguage { get; private set; } = "ES";

    public string T(string key) => _loc.T(key, CurrentLanguage);
    public Product SelectedProduct { get; private set; }
    public Product? SelectedProductModal { get; private set; }
    public Berry? SelectedBerryModal { get; private set; }
    public GeneticVariety? SelectedGeneticsModal { get; private set; }
    public Recipe? SelectedRecipeModal { get; private set; }
    public int ActiveProcessStep { get; private set; }
    public int ActiveRecipeIndex { get; private set; }
    public string ActiveFacilityKey { get; private set; } = "campo";

    public bool IsContactModalOpen { get; private set; }
    public bool IsVideoModalOpen { get; private set; }
    public bool IsSearchModalOpen { get; private set; }
    public string SearchQuery { get; private set; } = "";

    public event Action? OnChange;

    public void SetLanguage(string lang)
    {
        if (lang is "ES" or "EN" or "FR")
        {
            CurrentLanguage = lang;
            SelectedProduct = GetLocalizedProduct(_productCatalog.GetById(SelectedProduct.Id) ?? _productCatalog.GetFeatured());
            if (SelectedProductModal != null)
            {
                SelectedProductModal = GetLocalizedProduct(_productCatalog.GetById(SelectedProductModal.Id) ?? SelectedProductModal);
            }
            if (SelectedBerryModal != null)
            {
                SelectedBerryModal = GetLocalizedBerry(_berryCatalog.GetById(SelectedBerryModal.Id) ?? SelectedBerryModal);
            }
            if (SelectedGeneticsModal != null)
            {
                SelectedGeneticsModal = GetLocalizedVariety(_geneticsCatalog.GetById(SelectedGeneticsModal.Id) ?? SelectedGeneticsModal);
            }
            if (SelectedRecipeModal != null)
            {
                SelectedRecipeModal = GetLocalizedRecipe(_recipeCatalog.GetById(SelectedRecipeModal.Id) ?? SelectedRecipeModal);
            }
            Notify();
        }
    }

    public Berry GetLocalizedBerry(Berry b)
    {
        return b with
        {
            Name = T($"berry.{b.Id}.name"),
            Description = T($"berry.{b.Id}.desc"),
            Seasonality = T($"berry.{b.Id}.season"),
            HealthBenefits = T($"berry.{b.Id}.health"),
            KeyCharacteristics = new List<string>
            {
                T($"berry.{b.Id}.c1"),
                T($"berry.{b.Id}.c2"),
                T($"berry.{b.Id}.c3"),
                T($"berry.{b.Id}.c4")
            }
        };
    }

    public IReadOnlyList<Berry> GetLocalizedBerries() =>
        _berryCatalog.GetAll().Select(GetLocalizedBerry).ToList();

    public Product GetLocalizedProduct(Product p)
    {
        var lineName = p.CategoryId switch
        {
            "clasica" => T("line.clasica"),
            "big-delight" => T("line.big-delight"),
            "organica" => T("line.organica"),
            "legacy" => T("line.legacy"),
            "legacy-jumbo" or "legacy-jumbo-blues" => T("line.legacy-jumbo"),
            _ => p.Name
        };

        var fruitName = T($"fruit.{p.BerryId}");

        return p with
        {
            Name = lineName,
            Fruit = fruitName.ToUpperInvariant(),
            BerryName = fruitName,
            Line = lineName.ToUpperInvariant(),
            Badge = lineName,
            Description = T($"prod.{p.Id}.desc"),
            SizeMetric = T($"prod.{p.Id}.size"),
            FlavorMetric = T($"prod.{p.Id}.flavor"),
            PackagingMetric = T($"prod.{p.Id}.pack"),
            ShelfLife = T($"prod.{p.Id}.shelf")
        };
    }

    public IReadOnlyList<Product> GetLocalizedProducts() =>
        _productCatalog.GetAll().Select(GetLocalizedProduct).ToList();

    public GeneticVariety GetLocalizedVariety(GeneticVariety v)
    {
        var berryType = v.BerryType switch
        {
            "Frambuesa" => T("genetics.type.raspberry"),
            "Zarzamora" => T("genetics.type.blackberry"),
            "Arándano" => T("genetics.type.blueberry"),
            _ => v.BerryType
        };

        return v with
        {
            BerryType = berryType,
            Description = T($"genetics.{v.Id}.desc"),
            KeyTraits = new List<string>
            {
                T($"genetics.{v.Id}.t1"),
                T($"genetics.{v.Id}.t2"),
                T($"genetics.{v.Id}.t3"),
                T($"genetics.{v.Id}.t4")
            },
            ShelfLifeDays = T($"genetics.{v.Id}.shelf"),
            HarvestWindow = T($"genetics.{v.Id}.harvest"),
            LicensingType = T($"genetics.{v.Id}.license")
        };
    }

    public IReadOnlyList<GeneticVariety> GetLocalizedVarieties() =>
        _geneticsCatalog.GetAll().Select(GetLocalizedVariety).ToList();

    public QualityStep GetLocalizedProcessStep(QualityStep s)
    {
        return s with
        {
            Title = T($"field.step.{s.StepNumber}.title"),
            Subtitle = T($"field.step.{s.StepNumber}.sub"),
            Description = T($"field.step.{s.StepNumber}.desc"),
            Highlight = T($"field.step.{s.StepNumber}.high"),
            TemperatureSpec = T($"field.step.{s.StepNumber}.temp")
        };
    }

    public IReadOnlyList<QualityStep> GetLocalizedProcessSteps() =>
        _qualityCatalog.GetProcessSteps().Select(GetLocalizedProcessStep).ToList();

    public QualityStep GetLocalizedFacility(QualityStep s)
    {
        return s with
        {
            Title = T($"quality.fac.{s.StepNumber}.title"),
            Subtitle = T($"quality.fac.{s.StepNumber}.sub"),
            Description = T($"quality.fac.{s.StepNumber}.desc"),
            Highlight = T($"quality.fac.{s.StepNumber}.high"),
            TemperatureSpec = T($"quality.fac.{s.StepNumber}.temp")
        };
    }

    public IReadOnlyList<QualityStep> GetLocalizedFacilities() =>
        _qualityCatalog.GetFacilities().Select(GetLocalizedFacility).ToList();

    public Recipe GetLocalizedRecipe(Recipe r)
    {
        return r with
        {
            Title = T($"recipe.{r.Id}.title"),
            Category = T($"recipe.{r.Id}.cat"),
            Description = T($"recipe.{r.Id}.desc")
        };
    }

    public IReadOnlyList<Recipe> GetLocalizedRecipes() =>
        _recipeCatalog.GetAll().Select(GetLocalizedRecipe).ToList();

    public void SetSelectedProduct(Product product)
    {
        SelectedProduct = GetLocalizedProduct(product);
        Notify();
    }

    public void SetSelectedProductById(string id)
    {
        var prod = _productCatalog.GetById(id);
        if (prod != null)
        {
            SelectedProduct = GetLocalizedProduct(prod);
            Notify();
        }
    }

    public void NextProduct()
    {
        var list = _productCatalog.GetAll();
        var idx = list.ToList().FindIndex(p => p.Id == SelectedProduct.Id);
        var next = (idx + 1) % list.Count;
        SelectedProduct = GetLocalizedProduct(list[next]);
        Notify();
    }

    public void PrevProduct()
    {
        var list = _productCatalog.GetAll();
        var idx = list.ToList().FindIndex(p => p.Id == SelectedProduct.Id);
        var prev = (idx - 1 + list.Count) % list.Count;
        SelectedProduct = GetLocalizedProduct(list[prev]);
        Notify();
    }

    public void SetActiveProcessStep(int step)
    {
        ActiveProcessStep = Math.Clamp(step, 1, 5);
        Notify();
    }

    public void SetActiveFacilityKey(string key)
    {
        ActiveFacilityKey = key;
        Notify();
    }

    public void NextRecipe()
    {
        var list = _recipeCatalog.GetAll();
        ActiveRecipeIndex = (ActiveRecipeIndex + 1) % list.Count;
        Notify();
    }

    public void PrevRecipe()
    {
        var list = _recipeCatalog.GetAll();
        ActiveRecipeIndex = (ActiveRecipeIndex - 1 + list.Count) % list.Count;
        Notify();
    }

    public void SetActiveRecipeIndex(int index)
    {
        var list = _recipeCatalog.GetAll();
        if (list.Count > 0)
        {
            ActiveRecipeIndex = Math.Clamp(index, 0, list.Count - 1);
            Notify();
        }
    }

    public void OpenProductModal(Product product)
    {
        SelectedProductModal = GetLocalizedProduct(product);
        Notify();
    }

    public void CloseProductModal()
    {
        SelectedProductModal = null;
        Notify();
    }

    public void OpenBerryModal(Berry berry)
    {
        SelectedBerryModal = GetLocalizedBerry(berry);
        Notify();
    }

    public void CloseBerryModal()
    {
        SelectedBerryModal = null;
        Notify();
    }

    public void OpenGeneticsModal(GeneticVariety variety)
    {
        SelectedGeneticsModal = GetLocalizedVariety(variety);
        Notify();
    }

    public void CloseGeneticsModal()
    {
        SelectedGeneticsModal = null;
        Notify();
    }

    public void OpenRecipeModal(Recipe recipe)
    {
        SelectedRecipeModal = GetLocalizedRecipe(recipe);
        Notify();
    }

    public void CloseRecipeModal()
    {
        SelectedRecipeModal = null;
        Notify();
    }

    public void OpenContactModal()
    {
        IsContactModalOpen = true;
        Notify();
    }

    public void CloseContactModal()
    {
        IsContactModalOpen = false;
        Notify();
    }

    public void OpenVideoModal()
    {
        IsVideoModalOpen = true;
        Notify();
    }

    public void CloseVideoModal()
    {
        IsVideoModalOpen = false;
        Notify();
    }

    public void OpenSearchModal()
    {
        IsSearchModalOpen = true;
        Notify();
    }

    public void CloseSearchModal()
    {
        IsSearchModalOpen = false;
        SearchQuery = "";
        Notify();
    }

    public void SetSearchQuery(string q)
    {
        SearchQuery = q;
        Notify();
    }

    private void Notify() => OnChange?.Invoke();
}
