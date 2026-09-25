using BerriesParadise.Core.Models;

namespace BerriesParadise.Content.Catalogs;

public class ProductCatalog
{
    private static readonly List<ProductCategory> Categories = new()
    {
        new(
            Id: "clasica",
            Name: "Clásica",
            Tagline: "Calidad y consistencia en anaquel 365 días",
            Description: "Nuestra línea insignia que abastece a las principales cadenas de retail globales con calibre uniforme y frescura garantizada.",
            BadgeText: "clásica",
            ThemeColor: "#0077b6"
        ),
        new(
            Id: "big-delight",
            Name: "Big Delight",
            Tagline: "La experiencia de mayor tamaño y sabor",
            Description: "Una experiencia de mayor tamaño, presencia y detalle. Blueberries seleccionadas a mano para quienes buscan algo más especial.",
            BadgeText: "big delight",
            ThemeColor: "#00c2ff"
        ),
        new(
            Id: "organica",
            Name: "Orgánica",
            Tagline: "Agricultura regenerativa certificada",
            Description: "Cosechadas sin químicos sintéticos, con prácticas agroecológicas que cuidan el suelo y respetan los ciclos sagrados de la naturaleza.",
            BadgeText: "orgánica",
            ThemeColor: "#2a9d8f"
        ),
        new(
            Id: "legacy",
            Name: "Legacy",
            Tagline: "Genética superior y sabor concentrado",
            Description: "Nuestra oferta más exclusiva: berries con una genética superior que brindan un sabor más intenso y consistente, un color más profundo y una firmeza perfecta.",
            BadgeText: "legacy",
            ThemeColor: "#7209b7"
        ),
        new(
            Id: "legacy-jumbo-blues",
            Name: "Legacy Jumbo Blues",
            Tagline: "La cumbre de los arándanos colosales",
            Description: "La experiencia superior de Legacy en arándanos jumbo, combinando calibres superiores a 22mm con crocancia inolvidable.",
            BadgeText: "legacy jumbo blues",
            ThemeColor: "#3a0ca3"
        )
    };

    private static readonly List<Product> Products = new()
    {
        // ----------------------------------------------------
        // PRODUCT 01 - CLÁSICA ARÁNDANOS
        // ----------------------------------------------------
        new(
            Id: "clasica-arandanos",
            Name: "Clásica",
            BerryId: "arandanos",
            BerryName: "Arándanos",
            CategoryId: "clasica",
            CategoryName: "Clásica",
            ImageUrl: "images/products/clasica-blueberries-cinematic.jpg",
            ClamshellMockupUrl: "images/products/clasica-blueberries-cinematic.jpg",
            Badge: "Clásica",
            Description: "Fruta firme, con sabor equilibrado, textura increíble y calidad constante durante todo el año.",
            SizeMetric: "Calibre uniforme (14mm - 16mm)",
            FlavorMetric: "Sabor equilibrado",
            PackagingMetric: "Presentación clamshell retail",
            Brix: "12.0° Brix",
            Firmness: "210 g/mm",
            ShelfLife: "21 días refrigerada",
            Caliber: "14 - 16 mm",
            IsFeatured: false,
            Line: "CLÁSICA",
            Fruit: "ARÁNDANOS",
            Url: "https://www.berriesparadise.com/es/frutas/arandanos"
        ),

        // ----------------------------------------------------
        // PRODUCT 02 - BIG DELIGHT ARÁNDANOS (FEATURED)
        // ----------------------------------------------------
        new(
            Id: "big-delight-arandanos",
            Name: "Big Delight",
            BerryId: "arandanos",
            BerryName: "Arándanos",
            CategoryId: "big-delight",
            CategoryName: "Big Delight",
            ImageUrl: "images/products/big-delight-clamshell-hd.png",
            ClamshellMockupUrl: "images/products/big-delight-clamshell-hd.png",
            Badge: "Big Delight",
            Description: "Una experiencia de mayor tamaño, presencia y detalle. Blueberries seleccionadas para quienes buscan algo más especial.",
            SizeMetric: "Mayor tamaño (18mm - 24mm)",
            FlavorMetric: "Sabor excepcional dulce y aromático",
            PackagingMetric: "Presentación premium rPET 100% reciclable",
            Brix: "14.5° Brix",
            Firmness: "245 g/mm",
            ShelfLife: "24 días refrigerada",
            Caliber: "18 - 24 mm",
            IsFeatured: true,
            Line: "BIG DELIGHT",
            Fruit: "ARÁNDANOS",
            Url: "https://www.berriesparadise.com/es/frutas/arandanos"
        ),

        // ----------------------------------------------------
        // PRODUCT 03 - CLÁSICA FRAMBUESAS
        // ----------------------------------------------------
        new(
            Id: "clasica-frambuesas",
            Name: "Clásica",
            BerryId: "frambuesas",
            BerryName: "Frambuesas",
            CategoryId: "clasica",
            CategoryName: "Clásica",
            ImageUrl: "images/categories/frambuesas.jpg",
            ClamshellMockupUrl: "images/categories/frambuesas.jpg",
            Badge: "Clásica",
            Description: "El balance perfecto de color, textura y un sabor delicado para darte un fruto naturalmente versátil.",
            SizeMetric: "Calibre estándar (14mm - 16mm)",
            FlavorMetric: "Sabor delicado agridulce",
            PackagingMetric: "Clamshell 170g ventilado",
            Brix: "10.8° Brix",
            Firmness: "175 g/mm",
            ShelfLife: "14 días refrigerada",
            Caliber: "14 - 16 mm",
            IsFeatured: false,
            Line: "CLÁSICA",
            Fruit: "FRAMBUESAS",
            Url: "https://www.berriesparadise.com/es/frutas/frambuesas"
        ),

        // ----------------------------------------------------
        // PRODUCT 04 - CLÁSICA ZARZAMORAS
        // ----------------------------------------------------
        new(
            Id: "clasica-zarzamoras",
            Name: "Clásica",
            BerryId: "zarzamoras",
            BerryName: "Zarzamoras",
            CategoryId: "clasica",
            CategoryName: "Clásica",
            ImageUrl: "images/categories/zarzamoras.jpg",
            ClamshellMockupUrl: "images/categories/zarzamoras.jpg",
            Badge: "Clásica",
            Description: "Sabor intenso, apariencia profunda y frescura para recetas, snacks y consumo diario.",
            SizeMetric: "Calibre estándar (15mm - 18mm)",
            FlavorMetric: "Sabor intenso y frutal",
            PackagingMetric: "Clamshell 170g / 340g",
            Brix: "11.2° Brix",
            Firmness: "190 g/mm",
            ShelfLife: "15 días refrigerada",
            Caliber: "15 - 18 mm",
            IsFeatured: false,
            Line: "CLÁSICA",
            Fruit: "ZARZAMORAS",
            Url: "https://www.berriesparadise.com/es/frutas/zarzamoras"
        ),

        // ----------------------------------------------------
        // PRODUCT 05 - CLÁSICA FRESAS
        // ----------------------------------------------------
        new(
            Id: "clasica-fresas",
            Name: "Clásica",
            BerryId: "fresas",
            BerryName: "Fresas",
            CategoryId: "clasica",
            CategoryName: "Clásica",
            ImageUrl: "images/categories/fresas.jpg",
            ClamshellMockupUrl: "images/categories/fresas.jpg",
            Badge: "Clásica",
            Description: "Una fruta familiar, vibrante y naturalmente dulce para compartir.",
            SizeMetric: "Calibre uniforme mediano a grande",
            FlavorMetric: "Naturalmente dulce y fragante",
            PackagingMetric: "Clamshell 454g (1 lb) y 907g (2 lb)",
            Brix: "9.5° Brix",
            Firmness: "190 g/mm",
            ShelfLife: "12 días refrigerada",
            Caliber: "25 - 35 mm",
            IsFeatured: false,
            Line: "CLÁSICA",
            Fruit: "FRESAS",
            Url: "https://www.berriesparadise.com/es/frutas/fresas"
        ),

        // ----------------------------------------------------
        // PRODUCT 06 - ORGÁNICA ARÁNDANOS
        // ----------------------------------------------------
        new(
            Id: "organica-arandanos",
            Name: "Orgánica",
            BerryId: "arandanos",
            BerryName: "Arándanos",
            CategoryId: "organica",
            CategoryName: "Orgánica",
            ImageUrl: "images/products/organica-blueberries-cinematic.jpg",
            ClamshellMockupUrl: "images/products/organica-blueberries-cinematic.jpg",
            Badge: "Orgánica",
            Description: "Cosechadas sin químicos sintéticos, con prácticas que cuidan la tierra y respetan los ciclos de la naturaleza.",
            SizeMetric: "Calibre orgánico certificado",
            FlavorMetric: "Dulzura pura natural",
            PackagingMetric: "Clamshell rPET 100% reciclable",
            Brix: "12.5° Brix",
            Firmness: "215 g/mm",
            ShelfLife: "20 días refrigerada",
            Caliber: "14 - 18 mm",
            IsFeatured: false,
            Line: "ORGÁNICA",
            Fruit: "ARÁNDANOS",
            Url: "https://www.berriesparadise.com/es/frutas/arandanos"
        ),

        // ----------------------------------------------------
        // PRODUCT 07 - ORGÁNICA FRAMBUESAS
        // ----------------------------------------------------
        new(
            Id: "organica-frambuesas",
            Name: "Orgánica",
            BerryId: "frambuesas",
            BerryName: "Frambuesas",
            CategoryId: "organica",
            CategoryName: "Orgánica",
            ImageUrl: "images/categories/frambuesas.jpg",
            ClamshellMockupUrl: "images/categories/frambuesas.jpg",
            Badge: "Orgánica",
            Description: "Cosechadas sin químicos sintéticos, con prácticas que cuidan el suelo y respetan los ciclos de la naturaleza.",
            SizeMetric: "Calibre premium (16mm+)",
            FlavorMetric: "Dulzura silvestre pura",
            PackagingMetric: "Bio-Pack de fibra compostable",
            Brix: "11.8° Brix",
            Firmness: "185 g/mm",
            ShelfLife: "16 días refrigerada",
            Caliber: "16 - 19 mm",
            IsFeatured: false,
            Line: "ORGÁNICA",
            Fruit: "FRAMBUESAS",
            Url: "https://www.berriesparadise.com/es/frutas/frambuesas"
        ),

        // ----------------------------------------------------
        // PRODUCT 08 - ORGÁNICA ZARZAMORAS
        // ----------------------------------------------------
        new(
            Id: "organica-zarzamoras",
            Name: "Orgánica",
            BerryId: "zarzamoras",
            BerryName: "Zarzamoras",
            CategoryId: "organica",
            CategoryName: "Orgánica",
            ImageUrl: "images/categories/zarzamoras.jpg",
            ClamshellMockupUrl: "images/categories/zarzamoras.jpg",
            Badge: "Orgánica",
            Description: "Cosechadas sin químicos sintéticos, con prácticas que cuidan el suelo y respetan los ciclos de la naturaleza.",
            SizeMetric: "Calibre orgánico selecto",
            FlavorMetric: "Notas frutales profundas",
            PackagingMetric: "Clamshell reciclable ventilado",
            Brix: "11.5° Brix",
            Firmness: "195 g/mm",
            ShelfLife: "15 días refrigerada",
            Caliber: "16 - 20 mm",
            IsFeatured: false,
            Line: "ORGÁNICA",
            Fruit: "ZARZAMORAS",
            Url: "https://www.berriesparadise.com/es/frutas/zarzamoras"
        ),

        // ----------------------------------------------------
        // PRODUCT 09 - LEGACY ARÁNDANOS
        // ----------------------------------------------------
        new(
            Id: "legacy-arandanos",
            Name: "Legacy",
            BerryId: "arandanos",
            BerryName: "Arándanos",
            CategoryId: "legacy",
            CategoryName: "Legacy",
            ImageUrl: "images/genetica/sekoya-beauty.jpg",
            ClamshellMockupUrl: "images/genetica/sekoya-beauty.jpg",
            Badge: "Legacy",
            Description: "Nuestra oferta más exclusiva: berries con una genética superior que brindan un sabor más intenso y consistente, un color más profundo y una firmeza perfecta.",
            SizeMetric: "Genética superior seleccionada",
            FlavorMetric: "Sabor más intenso y consistente",
            PackagingMetric: "Presentación exclusiva Legacy",
            Brix: "14.8° Brix",
            Firmness: "250 g/mm",
            ShelfLife: "25 días refrigerada",
            Caliber: "18 - 22 mm",
            IsFeatured: false,
            Line: "LEGACY",
            Fruit: "ARÁNDANOS",
            Url: "https://www.berriesparadise.com/es/frutas/arandanos"
        ),

        // ----------------------------------------------------
        // PRODUCT 10 - LEGACY JUMBO BLUES ARÁNDANOS
        // ----------------------------------------------------
        new(
            Id: "legacy-jumbo-blues-arandanos",
            Name: "Legacy Jumbo Blues",
            BerryId: "arandanos",
            BerryName: "Arándanos",
            CategoryId: "legacy-jumbo-blues",
            CategoryName: "Legacy Jumbo Blues",
            ImageUrl: "images/genetica/sekoya-pop.jpg",
            ClamshellMockupUrl: "images/genetica/sekoya-pop.jpg",
            Badge: "Legacy Jumbo Blues",
            Description: "La experiencia superior de Legacy en arándanos jumbo.",
            SizeMetric: "Calibre jumbo colosal (22mm+)",
            FlavorMetric: "Explosión crocante super dulce",
            PackagingMetric: "Edición limitada coleccionable",
            Brix: "15.5° Brix",
            Firmness: "260 g/mm",
            ShelfLife: "28 días refrigerada",
            Caliber: "22 - 26 mm",
            IsFeatured: false,
            Line: "LEGACY JUMBO BLUES",
            Fruit: "ARÁNDANOS",
            Url: "https://www.berriesparadise.com/es/frutas/arandanos"
        ),

        // ----------------------------------------------------
        // PRODUCT 11 - LEGACY FRAMBUESAS
        // ----------------------------------------------------
        new(
            Id: "legacy-frambuesas",
            Name: "Legacy",
            BerryId: "frambuesas",
            BerryName: "Frambuesas",
            CategoryId: "legacy",
            CategoryName: "Legacy",
            ImageUrl: "images/genetica/amalia.jpg",
            ClamshellMockupUrl: "images/genetica/amalia.jpg",
            Badge: "Legacy",
            Description: "Nuestra oferta más exclusiva: berries con una genética superior que brindan un sabor más intenso y consistente, un color más profundo y una firmeza perfecta.",
            SizeMetric: "Genética superior exclusiva",
            FlavorMetric: "Sabor más intenso y consistente",
            PackagingMetric: "Clamshell ventilado alta gama",
            Brix: "12.5° Brix",
            Firmness: "210 g/mm",
            ShelfLife: "18 días refrigerada",
            Caliber: "18 - 22 mm",
            IsFeatured: false,
            Line: "LEGACY",
            Fruit: "FRAMBUESAS",
            Url: "https://www.berriesparadise.com/es/frutas/frambuesas"
        ),

        // ----------------------------------------------------
        // PRODUCT 12 - LEGACY ZARZAMORAS
        // ----------------------------------------------------
        new(
            Id: "legacy-zarzamoras",
            Name: "Legacy",
            BerryId: "zarzamoras",
            BerryName: "Zarzamoras",
            CategoryId: "legacy",
            CategoryName: "Legacy",
            ImageUrl: "images/genetica/erendira.jpg",
            ClamshellMockupUrl: "images/genetica/erendira.jpg",
            Badge: "Legacy",
            Description: "Nuestra oferta más exclusiva: berries con una genética superior que brindan un sabor más intenso y consistente, un color más profundo y una firmeza perfecta.",
            SizeMetric: "Calibre extra grande (18mm - 24mm)",
            FlavorMetric: "Sabor más intenso y consistente",
            PackagingMetric: "Clamshell ventilado de alta protección",
            Brix: "12.8° Brix",
            Firmness: "215 g/mm",
            ShelfLife: "20 días refrigerada",
            Caliber: "18 - 24 mm",
            IsFeatured: false,
            Line: "LEGACY",
            Fruit: "ZARZAMORAS",
            Url: "https://www.berriesparadise.com/es/frutas/zarzamoras"
        )
    };

    public IReadOnlyList<ProductCategory> GetCategories() => Categories;

    public IReadOnlyList<Product> GetAll() => Products;

    public Product GetFeatured() =>
        Products.FirstOrDefault(p => p.IsFeatured) ?? Products.First();

    public IReadOnlyList<Product> GetByBerry(string berryId) =>
        Products.Where(p => p.BerryId.Equals(berryId, StringComparison.OrdinalIgnoreCase)).ToList();

    public IReadOnlyList<Product> GetByCategory(string categoryId) =>
        Products.Where(p => p.CategoryId.Equals(categoryId, StringComparison.OrdinalIgnoreCase)).ToList();

    public Product? GetById(string id) =>
        Products.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
}
