using BerriesParadise.Core.Models;

namespace BerriesParadise.Content.Catalogs;

public class CompanyInformation
{
    private static readonly List<CompanyStat> Stats = new()
    {
        new(
            Id: "skus",
            TargetNumber: 42,
            Prefix: "",
            Suffix: "+",
            Label: "SKUs para retail",
            Subtext: "Formatos comerciales clamshell y granel listos para anaquel",
            IconSvg: "berry"
        ),
        new(
            Id: "countries",
            TargetNumber: 19,
            Prefix: "",
            Suffix: "+",
            Label: "Países a los que exportamos",
            Subtext: "Norteamérica, Europa, Asia-Pacífico y Medio Oriente",
            IconSvg: "globe"
        ),
        new(
            Id: "genetics",
            TargetNumber: 100,
            Prefix: "",
            Suffix: "",
            Label: "Genética",
            Subtext: "Variedades patentadas exclusivas de alta firmeza y sabor",
            IconSvg: "dna",
            DisplayValue: "Premium"
        )
    };

    private static readonly List<NavigationItem> NavItems = new()
    {
        new("productos", "Productos", "#productos", Order: 1),
        new("calidad", "Excelencia y calidad", "#calidad", Order: 2),
        new("proceso", "Del campo al mundo", "#proceso", Order: 3),
        new("genetica", "Genética", "#genetica", Order: 4),
        new("inspiracion", "Inspiración", "#inspiracion", Order: 5),
        new("contacto", "Contacto", "#contacto", Order: 6)
    };

    public IReadOnlyList<CompanyStat> GetStats() => Stats;

    public IReadOnlyList<NavigationItem> GetNavigation() => NavItems;

    public string CompanyName => "Berries Paradise";
    public string Slogan => "Berries Grown with Purpose.";
    public string Subtitle => "Cultivamos berries excepcionales para un mundo más saludable y delicioso.";
    public string CtaHeading => "LLEVAMOS BERRIES DE CALIDAD A TU MERCADO";
    public string CtaSubheading => "¿Buscas un socio confiable para tu cadena de suministro? Hablemos sobre cómo llevar lo mejor de nuestros campos a tu negocio.";
    public string Hashtag => "#BerriesParadise";
    public string Copyright => "©2026 Berries Paradise. Todos los derechos reservados.";
}
