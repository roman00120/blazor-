using BerriesParadise.Core.Models;

namespace BerriesParadise.Content.Catalogs;

public class RecipeCatalog
{
    private static readonly List<Recipe> Recipes = new()
    {
        new(
            Id: "pancakes-berries-mixtos",
            Title: "Pancakes de Berries Mixtos",
            Category: "Desayuno",
            PrepTimeMinutes: 15,
            CookTimeMinutes: 10,
            Servings: 4,
            Calories: 320,
            Description: "Esponjosos, llenos de sabor y con el balance perfecto entre dulzura y frescura. Coronado con frutos recién cosechados y miel tibia de maple.",
            ImageUrl: "images/recipes/pancakes.jpg",
            Ingredients: new()
            {
                "1 taza de arándanos Big Delight Berries Paradise",
                "1/2 taza de frambuesas Amalia® frescas",
                "1/2 taza de zarzamoras Legacy",
                "2 tazas de harina integral de trigo o avena",
                "2 cucharaditas de polvo para hornear",
                "2 huevos de granja",
                "1 1/2 tazas de leche de almendras o leche entera",
                "2 cucharadas de mantequilla fundida o aceite de coco",
                "Miel de maple pura de grado A"
            },
            Instructions: new()
            {
                "En un tazón grande, tamiza la harina junto con el polvo para hornear y una pizca de sal marina.",
                "En otro recipiente, bate los huevos junto con la leche y la mantequilla derretida hasta emulsionar.",
                "Vierte los ingredientes líquidos sobre los secos y dobla con espátula suavemente sin batir en exceso para mantener la esponjosidad.",
                "Calienta una sartén antiadherente a fuego medio y engrasa ligeramente. Vierte 1/4 de taza de mezcla por pancake.",
                "Cocina hasta que surjan burbujas en la superficie (aprox. 2 minutos), dale la vuelta y cocina 1 minuto más hasta dorar.",
                "Sirve apilando las piezas, decora generosamente con las berries frescas de Berries Paradise y corona con un hilo de miel tibia."
            }
        ),
        new(
            Id: "smoothie-bowl-antioxidante",
            Title: "Super Smoothie Bowl de Berries",
            Category: "Energía & Salud",
            PrepTimeMinutes: 10,
            CookTimeMinutes: 0,
            Servings: 2,
            Calories: 260,
            Description: "Un festín concentrado de polifenoles, fibra y antioxidantes naturales para iniciar el día con vitalidad y frescura inigualable.",
            ImageUrl: "images/recipes/smoothie.jpg",
            Ingredients: new()
            {
                "1 1/2 tazas de arándanos congelados Berries Paradise",
                "1 taza de frambuesas y zarzamoras mixtas",
                "1 plátano maduro congelado en rodajas",
                "1/2 taza de leche de coco o yogur griego natural",
                "1 cucharada de semillas de chía",
                "Topping: arándanos frescos, láminas de almendra tostada y flores comestibles"
            },
            Instructions: new()
            {
                "Coloca en la licuadora los frutos rojos congelados, el plátano y la base láctea o vegetal.",
                "Licúa a velocidad baja usando el prensador hasta lograr una consistencia espesa similar a un helado cremoso.",
                "Vierte en tazones hondos y alisa la superficie suavemente.",
                "Decora con líneas artísticas de arándanos frescos Big Delight, frambuesas, semillas de chía y almendras tostadas."
            }
        ),
        new(
            Id: "tartaleta-frambuesas-crema-mascarpone",
            Title: "Tartaleta de Frambuesas & Mascarpone",
            Category: "Repostería Fina",
            PrepTimeMinutes: 25,
            CookTimeMinutes: 15,
            Servings: 6,
            Calories: 340,
            Description: "Costra sablée crujiente con suave crema batida de mascarpone a la vainilla de Papantla y corona de frambuesas Amalia® recién cortadas.",
            ImageUrl: "images/recipes/tartaleta.jpg",
            Ingredients: new()
            {
                "2 tazas de frambuesas frescas Amalia®",
                "250g de queso mascarpone artesanal",
                "1/2 taza de crema para batir 35% grasa",
                "1 base de tarta sablée horneada",
                "Vaina de vainilla natural y ralladura de lima"
            },
            Instructions: new()
            {
                "Bate el mascarpone con la crema, vainilla y azúcar glass hasta formar picos firmes aterciopelados.",
                "Rellena la base de masa fría de forma uniforme.",
                "Coloca las frambuesas una a una con la base hacia abajo y abrillanta con un toque de miel de agave."
            }
        ),
        new(
            Id: "parfait-arandanos-chia-granola",
            Title: "Parfait de Chía, Yogur & Arándanos",
            Category: "Desayuno Ligero",
            PrepTimeMinutes: 10,
            CookTimeMinutes: 0,
            Servings: 2,
            Calories: 210,
            Description: "Capas alternadas de pudín de chía hidratado en leche de coco, yogur estilo griego sin azúcar y compota rústica de arándanos jumbo.",
            ImageUrl: "images/recipes/parfait.jpg",
            Ingredients: new()
            {
                "1 1/2 tazas de arándanos frescos Berries Paradise",
                "1 taza de yogur griego natural",
                "3 cucharadas de chía orgánica hidratada",
                "Granola artesanal de semillas de calabaza y avena"
            },
            Instructions: new()
            {
                "Cocina brevemente la mitad de los arándanos a fuego bajo con un toque de limón hasta que revienten formando una compota brillante.",
                "En copas de vidrio, alterna capas de compota, chía, yogur y granola.",
                "Termina con arándanos frescos enteros crujientes."
            }
        ),
        new(
            Id: "cheesecake-zarzamora-legacy",
            Title: "Cheesecake Horneado con Zarzamora",
            Category: "Postres Gourmet",
            PrepTimeMinutes: 20,
            CookTimeMinutes: 50,
            Servings: 8,
            Calories: 390,
            Description: "Cremosa textura horneada lentamente al baño maría cubierta con glaseado brillante de zarzamoras Legacy y notas de limón amarillo.",
            ImageUrl: "images/recipes/cheesecake.jpg",
            Ingredients: new()
            {
                "2 tazas de zarzamoras Legacy Berries Paradise",
                "400g de queso crema a temperatura ambiente",
                "3 huevos enteros de rancho",
                "1 taza de galletas integrales molidas",
                "Jugo y ralladura de 1 limón eureka"
            },
            Instructions: new()
            {
                "Forma la costra con galleta y mantequilla en un molde desmontable.",
                "Bate el queso crema, huevos y limón. Vierte sobre la base y hornea a 160°C por 50 minutos.",
                "Enfría por 4 horas y cubre con reducción espesa de zarzamoras enteras."
            }
        ),
        new(
            Id: "ensalada-fresas-espinaca-queso-cabra",
            Title: "Ensalada de Espinaca, Fresas & Nueces",
            Category: "Almuerzo Fresco",
            PrepTimeMinutes: 12,
            CookTimeMinutes: 0,
            Servings: 4,
            Calories: 195,
            Description: "Frescura vibrante de fresas recién fileteadas sobre hojas tiernas de espinaca baby, queso de cabra cenizo y reducción de vinagre balsámico de Módena.",
            ImageUrl: "images/recipes/ensalada.jpg",
            Ingredients: new()
            {
                "2 tazas de fresas Berries Paradise en láminas",
                "4 tazas de espinaca baby orgánica lavada",
                "100g de queso de cabra en medallones",
                "1/2 taza de nueces pecanas tostadas al sartén",
                "Vinagreta: aceite de oliva virgen extra, balsámico y miel"
            },
            Instructions: new()
            {
                "En una ensaladera amplia distribuye las hojas de espinaca baby.",
                "Agrega las láminas de fresa, las nueces tostadas y los medallones de queso de cabra.",
                "Emulsiona la vinagreta y rocía justo antes de servir para conservar la textura crocante."
            }
        ),
        new(
            Id: "muffins-avena-arandanos-limon",
            Title: "Muffins Rústicos de Avena & Arándanos",
            Category: "Snack Saludable",
            PrepTimeMinutes: 15,
            CookTimeMinutes: 20,
            Servings: 6,
            Calories: 230,
            Description: "Muffins horneados sin azúcar refinada cargados de arándanos enteros que estallan en el horno brindando dulzura jugosa en cada bocado.",
            ImageUrl: "images/recipes/muffins.jpg",
            Ingredients: new()
            {
                "1 1/2 tazas de arándanos frescos Berries Paradise",
                "2 tazas de harina de avena integral",
                "1 taza de puré de manzana sin endulzar",
                "2 huevos enteros",
                "1 cucharada de canela molida y ralladura de naranja"
            },
            Instructions: new()
            {
                "Mezcla los ingredientes secos en un tazón y los húmedos en otro.",
                "Une con espátula e incorpora los arándanos espolvoreados con un poco de harina para que no se vayan al fondo.",
                "Distribuye en moldes de silicón y hornea a 180°C durante 20 minutos."
            }
        ),
        new(
            Id: "galette-rustica-multi-berries",
            Title: "Galette Rústica de Tres Berries",
            Category: "Panadería Rústica",
            PrepTimeMinutes: 20,
            CookTimeMinutes: 30,
            Servings: 6,
            Calories: 310,
            Description: "Masa hojaldrada abierta y doblada a mano que envuelve una explosión de frambuesas, arándanos y zarzamoras horneadas con azúcar mascabado.",
            ImageUrl: "images/recipes/galette.jpg",
            Ingredients: new()
            {
                "1 taza de arándanos, 1 taza de frambuesas y 1 taza de zarzamoras",
                "1 disco de masa quebrada de mantequilla fría",
                "2 cucharadas de fécula de maíz",
                "2 cucharadas de azúcar mascabado o piloncillo granulado",
                "1 huevo batido para barnizar los bordes"
            },
            Instructions: new()
            {
                "Mezcla suavemente los tres frutos rojos con la fécula y el azúcar mascabado.",
                "Extiende la masa sobre papel encerado y vierte la fruta dejando un borde libre de 4 cm.",
                "Pliega los bordes sobre la fruta, barniza con huevo y hornea a 190°C hasta dorar intensamente."
            }
        )
    };

    public IReadOnlyList<Recipe> GetAll() => Recipes;

    public Recipe GetFeatured() => Recipes.First();

    public Recipe? GetById(string id) =>
        Recipes.FirstOrDefault(r => r.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
}
