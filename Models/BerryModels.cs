namespace BerriesParadise.Models;

public record BerryCategory(
    string Id,
    string Name,
    string NameEn,
    string NameFr,
    string Subtitle,
    string SubtitleEn,
    string SubtitleFr,
    string ImageUrl,
    string AccentColor,
    string Gradient,
    string Season,
    string NutritionInfo,
    List<string> KeyFeatures
);

public record ProductItem(
    string Id,
    string Name,
    string Subtitle,
    string BerryType,
    string ClamshellImage,
    string BadgeText,
    string Description,
    string DescriptionEn,
    string DescriptionFr,
    string SizeMetric,
    string FlavorMetric,
    string PackagingMetric,
    string Brix,
    string Firmness,
    string ShelfLife,
    string Caliber,
    bool IsActive = false
);

public record GeneticsVariety(
    string Id,
    string Name,
    string BerryType,
    string ImageUrl,
    string Description,
    string DescriptionEn,
    string DescriptionFr,
    string Caliber,
    string BrixRating,
    string Firmness,
    string ShelfLife,
    string HarvestWindow,
    string GlobalLicensing
);

public record ProcessStep(
    int Number,
    string StepKey,
    string Title,
    string TitleEn,
    string TitleFr,
    string ShortDesc,
    string FullDesc,
    string Highlight,
    string TempRange,
    string Standard
);

public record QualityFacility(
    int Number,
    string Code,
    string Title,
    string TitleEn,
    string TitleFr,
    string ImageUrl,
    string Description,
    string DescriptionEn,
    string DescriptionFr,
    string Capacity,
    string Certification
);

public record RecipeItem(
    string Id,
    string Title,
    string TitleEn,
    string TitleFr,
    string CategoryTag,
    string CategoryTagEn,
    string CategoryTagFr,
    string Description,
    string DescriptionEn,
    string DescriptionFr,
    string ImageUrl,
    string PrepTime,
    string CookTime,
    int Servings,
    int Calories,
    List<string> Ingredients,
    List<string> IngredientsEn,
    List<string> IngredientsFr,
    List<string> Steps,
    List<string> StepsEn,
    List<string> StepsFr
);

public record MarketItem(
    string Region,
    string Country,
    double Lat,
    double Lng,
    string Volume,
    string KeyHub
);
