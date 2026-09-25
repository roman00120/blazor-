using BerriesParadise.Core.Models;
using BerriesParadise.Content.Catalogs;

namespace BerriesParadise.Web.Services;

public class WebUiStateService
{
    private readonly ProductCatalog _productCatalog;
    private readonly RecipeCatalog _recipeCatalog;
    private readonly LocalizationService _loc;

    public WebUiStateService(ProductCatalog productCatalog, RecipeCatalog recipeCatalog, LocalizationService loc)
    {
        _productCatalog = productCatalog;
        _recipeCatalog = recipeCatalog;
        _loc = loc;
        SelectedProduct = _productCatalog.GetFeatured();
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
            Notify();
        }
    }

    public void SetSelectedProduct(Product product)
    {
        SelectedProduct = product;
        Notify();
    }

    public void SetSelectedProductById(string id)
    {
        var prod = _productCatalog.GetById(id);
        if (prod != null)
        {
            SelectedProduct = prod;
            Notify();
        }
    }

    public void NextProduct()
    {
        var list = _productCatalog.GetAll();
        var idx = list.ToList().FindIndex(p => p.Id == SelectedProduct.Id);
        var next = (idx + 1) % list.Count;
        SelectedProduct = list[next];
        Notify();
    }

    public void PrevProduct()
    {
        var list = _productCatalog.GetAll();
        var idx = list.ToList().FindIndex(p => p.Id == SelectedProduct.Id);
        var prev = (idx - 1 + list.Count) % list.Count;
        SelectedProduct = list[prev];
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
        SelectedProductModal = product;
        Notify();
    }

    public void CloseProductModal()
    {
        SelectedProductModal = null;
        Notify();
    }

    public void OpenBerryModal(Berry berry)
    {
        SelectedBerryModal = berry;
        Notify();
    }

    public void CloseBerryModal()
    {
        SelectedBerryModal = null;
        Notify();
    }

    public void OpenGeneticsModal(GeneticVariety variety)
    {
        SelectedGeneticsModal = variety;
        Notify();
    }

    public void CloseGeneticsModal()
    {
        SelectedGeneticsModal = null;
        Notify();
    }

    public void OpenRecipeModal(Recipe recipe)
    {
        SelectedRecipeModal = recipe;
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
