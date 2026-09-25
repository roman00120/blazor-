using BerriesParadise.Core.Models;

namespace BerriesParadise.Content.Catalogs;

public class BerryCatalog
{
    private static readonly List<Berry> Berries = new()
    {
        new(
            Id: "arandanos",
            Name: "Arándanos",
            ScientificName: "Vaccinium corymbosum",
            Description: "Fruta firme, con sabor equilibrado, textura increíble, floración cerosa natural (bloom) y calidad constante durante todo el año.",
            ImageUrl: "images/categories/arandanos.jpg",
            AccentColor: "#00b4d8",
            GradientColor: "linear-gradient(135deg, #023e8a, #0077b6)",
            KeyCharacteristics: new() { "Calibres estándar a Jumbo (14mm - 26mm)", "Bloom natural protector intacto", "Firmeza superior a 220 g/mm", "Brix equilibrado 12.0° - 15.5°" },
            Seasonality: "Producción continua 52 semanas al año",
            HealthBenefits: "Rico en antocianinas, flavonoides bioactivos, vitamina C (16% IDR), vitamina K (36% IDR) y manganeso esencial para la salud celular."
        ),
        new(
            Id: "frambuesas",
            Name: "Frambuesas",
            ScientificName: "Rubus idaeus",
            Description: "El balance perfecto de color rojo rubí, textura aterciopelada y un sabor delicado para darte un fruto naturalmente versátil y aromático.",
            ImageUrl: "images/categories/frambuesas.jpg",
            AccentColor: "#e6195e",
            GradientColor: "linear-gradient(135deg, #9d0208, #d00000)",
            KeyCharacteristics: new() { "Receptáculo cerrado resistente", "Color rojo rubí brillante", "Acidez equilibrada con dulzor natural", "Vida de anaquel refrigerada hasta 18 días" },
            Seasonality: "Septiembre a Junio (Pico en invierno y primavera)",
            HealthBenefits: "Extraordinaria fuente de fibra dietética (8g por taza), ácido elágico, vitamina C (54% IDR) y antioxidantes que protegen la salud cardiovascular."
        ),
        new(
            Id: "zarzamoras",
            Name: "Zarzamoras",
            ScientificName: "Rubus fruticosus",
            Description: "Sabor intenso, drupas carnosas con brillo negro profundo y frescura insuperable para recetas gourmet, snacks saludables y consumo diario.",
            ImageUrl: "images/categories/zarzamoras.jpg",
            AccentColor: "#7209b7",
            GradientColor: "linear-gradient(135deg, #240046, #3c096c)",
            KeyCharacteristics: new() { "Variedades cultivadas 100% sin espinas", "Nula reversión a rojo (red drupelet)", "Dulzura pura sin amargor", "Calibre grande y uniforme" },
            Seasonality: "Octubre a Mayo",
            HealthBenefits: "Excelente aporte de vitamina C, vitamina K, folato y luteína para la protección ocular y el refuerzo del sistema inmune."
        ),
        new(
            Id: "fresas",
            Name: "Fresas",
            ScientificName: "Fragaria ananassa",
            Description: "Una fruta familiar, vibrante, con aroma penetrante y dulzor natural cosechada en su punto óptimo de maduración para deleitar a familias enteras.",
            ImageUrl: "images/categories/fresas.jpg",
            AccentColor: "#e63946",
            GradientColor: "linear-gradient(135deg, #b5179e, #7209b7)",
            KeyCharacteristics: new() { "Forma cónica homogénea", "Rojo carmesí de corazón a piel", "Brillo natural sin ceras químicas", "Calibre selecto para retail" },
            Seasonality: "Noviembre a Mayo",
            HealthBenefits: "Aporta más del 140% de la ingesta diaria recomendada de vitamina C por porción, promoviendo la producción de colágeno y vitalidad."
        )
    };

    public IReadOnlyList<Berry> GetAll() => Berries;

    public Berry? GetById(string id) =>
        Berries.FirstOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
}
