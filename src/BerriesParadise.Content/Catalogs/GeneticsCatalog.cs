using BerriesParadise.Core.Models;

namespace BerriesParadise.Content.Catalogs;

public class GeneticsCatalog
{
    private static readonly List<GeneticVariety> Varieties = new()
    {
        new(
            Id: "amalia",
            Name: "Amalia®",
            BerryType: "Frambuesa",
            ImageUrl: "images/genetica/amalia.jpg",
            Description: "Variedad registrada con maduración homogénea que garantiza lotes uniformes para exportación de calidad superior. Su receptáculo cerrado evita el colapso poscosecha.",
            KeyTraits: new() { "Madurez uniforme", "Calibre consistente", "Bajo chill requerido", "Alta tasa de exportación" },
            Caliber: "18 - 20 mm",
            BrixRating: "12.2° Brix",
            FirmnessScore: "9.2 / 10",
            ShelfLifeDays: "18+ días",
            HarvestWindow: "Octubre - Mayo",
            LicensingType: "Patente Exclusiva Berries Paradise"
        ),
        new(
            Id: "erendira",
            Name: "Eréndira",
            BerryType: "Zarzamora",
            ImageUrl: "images/genetica/erendira.jpg",
            Description: "Variedad mexicana de alto rendimiento, desarrollada para condiciones climáticas locales con excelente perfil organoléptico y plantas libres de espinas.",
            KeyTraits: new() { "Resistencia climática", "Cosecha extendida", "Perfil aromático único", "Adaptabilidad regional" },
            Caliber: "20 - 24 mm",
            BrixRating: "13.0° Brix",
            FirmnessScore: "8.9 / 10",
            ShelfLifeDays: "20+ días",
            HarvestWindow: "Noviembre - Junio",
            LicensingType: "Variedad Protegida Nacional"
        ),
        new(
            Id: "sekoya-beauty",
            Name: "Sekoya Beauty™",
            BerryType: "Arándano",
            ImageUrl: "images/genetica/sekoya-beauty.jpg",
            Description: "Arándano de belleza excepcional con bloom natural preservado, textura crocante y calibre jumbo persistente, ideal para presentación en retail premium internacional.",
            KeyTraits: new() { "Color azul intenso", "Bloom perfecto", "Firmeza superior", "Versatilidad culinaria" },
            Caliber: "18 - 22 mm",
            BrixRating: "14.8° Brix",
            FirmnessScore: "9.7 / 10",
            ShelfLifeDays: "25+ días",
            HarvestWindow: "Septiembre - Marzo",
            LicensingType: "Sekoya™ Club Member Variety"
        ),
        new(
            Id: "sekoya-pop",
            Name: "Sekoya Pop™",
            BerryType: "Arándano",
            ImageUrl: "images/genetica/sekoya-pop.jpg",
            Description: "Variedad premium de arándanos desarrollada para mercados de alta exigencia, con equilibrio óptimo entre dulzura y acidez, y su célebre 'pop' acústico al morder.",
            KeyTraits: new() { "Sabor excepcional", "Tamaño uniforme", "Larga vida de anaquel", "Alta productividad" },
            Caliber: "20 - 26 mm",
            BrixRating: "15.5° Brix",
            FirmnessScore: "9.9 / 10",
            ShelfLifeDays: "30+ días",
            HarvestWindow: "Noviembre - Mayo",
            LicensingType: "Sekoya™ Club Member Variety"
        )
    };

    public IReadOnlyList<GeneticVariety> GetAll() => Varieties;

    public GeneticVariety? GetById(string id) =>
        Varieties.FirstOrDefault(v => v.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
}
