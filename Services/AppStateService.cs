using BerriesParadise.Models;

namespace BerriesParadise.Services;

public class AppStateService
{
    private readonly BerryDataService _dataService;

    public AppStateService(BerryDataService dataService)
    {
        _dataService = dataService;
        var products = _dataService.GetProducts();
        SelectedProduct = products.FirstOrDefault(p => p.Id == "big-delight-arandanos") ?? products.First();
        ActiveProcessStep = 1;
        ActiveQualityCode = "campo";
        ActiveRecipeIndex = 0;
    }

    public string CurrentLanguage { get; private set; } = "ES";
    public ProductItem SelectedProduct { get; private set; }
    public BerryCategory? SelectedCategoryModal { get; private set; }
    public GeneticsVariety? SelectedGeneticsModal { get; private set; }
    public RecipeItem? SelectedRecipeModal { get; private set; }
    public int ActiveProcessStep { get; private set; }
    public string ActiveQualityCode { get; private set; }
    public int ActiveRecipeIndex { get; private set; }

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
            NotifyStateChanged();
        }
    }

    public void SetSelectedProduct(ProductItem product)
    {
        SelectedProduct = product;
        NotifyStateChanged();
    }

    public void SetSelectedProductById(string id)
    {
        var product = _dataService.GetProducts().FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            SelectedProduct = product;
            NotifyStateChanged();
        }
    }

    public void NextProduct()
    {
        var products = _dataService.GetProducts();
        var index = products.FindIndex(p => p.Id == SelectedProduct.Id);
        var nextIndex = (index + 1) % products.Count;
        SelectedProduct = products[nextIndex];
        NotifyStateChanged();
    }

    public void PrevProduct()
    {
        var products = _dataService.GetProducts();
        var index = products.FindIndex(p => p.Id == SelectedProduct.Id);
        var prevIndex = (index - 1 + products.Count) % products.Count;
        SelectedProduct = products[prevIndex];
        NotifyStateChanged();
    }

    public void SetActiveProcessStep(int step)
    {
        ActiveProcessStep = Math.Clamp(step, 1, 5);
        NotifyStateChanged();
    }

    public void SetActiveQualityCode(string code)
    {
        ActiveQualityCode = code;
        NotifyStateChanged();
    }

    public void SetActiveRecipeIndex(int index)
    {
        var recipes = _dataService.GetRecipes();
        ActiveRecipeIndex = Math.Clamp(index, 0, Math.Max(0, recipes.Count - 1));
        NotifyStateChanged();
    }

    public void NextRecipe()
    {
        var recipes = _dataService.GetRecipes();
        ActiveRecipeIndex = (ActiveRecipeIndex + 1) % recipes.Count;
        NotifyStateChanged();
    }

    public void PrevRecipe()
    {
        var recipes = _dataService.GetRecipes();
        ActiveRecipeIndex = (ActiveRecipeIndex - 1 + recipes.Count) % recipes.Count;
        NotifyStateChanged();
    }

    public void OpenCategoryModal(BerryCategory category)
    {
        SelectedCategoryModal = category;
        NotifyStateChanged();
    }

    public void CloseCategoryModal()
    {
        SelectedCategoryModal = null;
        NotifyStateChanged();
    }

    public void OpenGeneticsModal(GeneticsVariety variety)
    {
        SelectedGeneticsModal = variety;
        NotifyStateChanged();
    }

    public void CloseGeneticsModal()
    {
        SelectedGeneticsModal = null;
        NotifyStateChanged();
    }

    public void OpenRecipeModal(RecipeItem recipe)
    {
        SelectedRecipeModal = recipe;
        NotifyStateChanged();
    }

    public void CloseRecipeModal()
    {
        SelectedRecipeModal = null;
        NotifyStateChanged();
    }

    public void OpenContactModal()
    {
        IsContactModalOpen = true;
        NotifyStateChanged();
    }

    public void CloseContactModal()
    {
        IsContactModalOpen = false;
        NotifyStateChanged();
    }

    public void OpenVideoModal()
    {
        IsVideoModalOpen = true;
        NotifyStateChanged();
    }

    public void CloseVideoModal()
    {
        IsVideoModalOpen = false;
        NotifyStateChanged();
    }

    public void OpenSearchModal()
    {
        IsSearchModalOpen = true;
        NotifyStateChanged();
    }

    public void CloseSearchModal()
    {
        IsSearchModalOpen = false;
        SearchQuery = "";
        NotifyStateChanged();
    }

    public void SetSearchQuery(string query)
    {
        SearchQuery = query;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
