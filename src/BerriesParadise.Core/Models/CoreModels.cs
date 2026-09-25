namespace BerriesParadise.Core.Models;

/// <summary>
/// Represents a fruit type in the Berries Paradise family (Arándanos, Frambuesas, Zarzamoras, Fresas).
/// </summary>
public record Berry(
    string Id,
    string Name,
    string ScientificName,
    string Description,
    string ImageUrl,
    string AccentColor,
    string GradientColor,
    List<string> KeyCharacteristics,
    string Seasonality,
    string HealthBenefits
);

/// <summary>
/// Represents product lines such as Clásica, Big Delight, Orgánica, Legacy.
/// </summary>
public record ProductCategory(
    string Id,
    string Name,
    string Tagline,
    string Description,
    string BadgeText,
    string ThemeColor
);

/// <summary>
/// Specific commercial SKU or retail package.
/// </summary>
public record Product(
    string Id,
    string Name,
    string BerryId,
    string BerryName,
    string CategoryId,
    string CategoryName,
    string ImageUrl,
    string ClamshellMockupUrl,
    string Badge,
    string Description,
    string SizeMetric,
    string FlavorMetric,
    string PackagingMetric,
    string Brix,
    string Firmness,
    string ShelfLife,
    string Caliber,
    bool IsFeatured = false,
    string Line = "",
    string Fruit = "",
    string Url = ""
);

/// <summary>
/// Patented varietal genetic program (Amalia®, Eréndira, Sekoya Beauty™, Sekoya Pop™).
/// </summary>
public record GeneticVariety(
    string Id,
    string Name,
    string BerryType,
    string ImageUrl,
    string Description,
    List<string> KeyTraits,
    string Caliber,
    string BrixRating,
    string FirmnessScore,
    string ShelfLifeDays,
    string HarvestWindow,
    string LicensingType
);

/// <summary>
/// Quality and cold chain integrated process stage (Del Campo al Mundo).
/// </summary>
public record QualityStep(
    int StepNumber,
    string Key,
    string Title,
    string Subtitle,
    string Description,
    string ImageUrl,
    string Highlight,
    string TemperatureSpec,
    string CertificationStandard
);

/// <summary>
/// Culinary inspiration recipe with ingredients checklist and step-by-step cooking directions.
/// </summary>
public record Recipe(
    string Id,
    string Title,
    string Category,
    int PrepTimeMinutes,
    int CookTimeMinutes,
    int Servings,
    int Calories,
    string Description,
    string ImageUrl,
    List<string> Ingredients,
    List<string> Instructions
);

/// <summary>
/// Key corporate metrics and impact statistics (42+ SKUs, 19+ Países).
/// </summary>
public record CompanyStat(
    string Id,
    int TargetNumber,
    string Prefix,
    string Suffix,
    string Label,
    string Subtext,
    string IconSvg,
    string? DisplayValue = null
)
{
    public string FormattedValue => DisplayValue ?? $"{Prefix}{TargetNumber}{Suffix}";
}

/// <summary>
/// Navigation item for desktop header, mobile drawer, and footer site map.
/// </summary>
public record NavigationItem(
    string Id,
    string Title,
    string TargetUrl,
    bool IsExternal = false,
    int Order = 0,
    string? Badge = null
);
