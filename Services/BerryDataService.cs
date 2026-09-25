using BerriesParadise.Models;

namespace BerriesParadise.Services;

public class BerryDataService
{
    public List<BerryCategory> GetCategories() => new()
    {
        new(
            Id: "arandanos",
            Name: "ARÁNDANOS",
            NameEn: "BLUEBERRIES",
            NameFr: "MYRTILLES",
            Subtitle: "Dulces, crujientes y con alta concentración de antioxidantes naturales.",
            SubtitleEn: "Sweet, crunchy and rich in natural antioxidants.",
            SubtitleFr: "Douces, croquantes et riches en antioxydants naturels.",
            ImageUrl: "images/categories/arandanos.jpg",
            AccentColor: "#00b4d8",
            Gradient: "linear-gradient(135deg, #023e8a, #0077b6)",
            Season: "Todo el año / All year",
            NutritionInfo: "84 cal/taza, Vitamina C (16%), Vitamina K (36%), Manganeso (25%)",
            KeyFeatures: new() { "Calibres Jumbo 18mm+", "Floración cerosa natural intacta", "Firmeza superior 220+ g/mm" }
        ),
        new(
            Id: "frambuesas",
            Name: "FRAMBUESAS",
            NameEn: "RASPBERRIES",
            NameFr: "FRAMBOISES",
            Subtitle: "Aroma envolvente, textura aterciopelada y un balance perfecto entre acidez y dulzor.",
            SubtitleEn: "Delicate aroma, velvety texture, and perfect sweet-tart balance.",
            SubtitleFr: "Arôme délicat, texture veloutée et parfait équilibre acidulé.",
            ImageUrl: "images/categories/frambuesas.jpg",
            AccentColor: "#e6195e",
            Gradient: "linear-gradient(135deg, #9d0208, #d00000)",
            Season: "Septiembre a Junio",
            NutritionInfo: "64 cal/taza, Fibra dietética 8g, Vitamina C (54%)",
            KeyFeatures: new() { "Color rojo rubí brillante", "Cavidad compacta anticolapso", "Vida de anaquel extendida a 18 días" }
        ),
        new(
            Id: "zarzamoras",
            Name: "ZARZAMORAS",
            NameEn: "BLACKBERRIES",
            NameFr: "MÛRES",
            Subtitle: "Brillo intenso, notas aromáticas profundas y drupas carnosas llenas de jugo.",
            SubtitleEn: "Intense gloss, deep aromatic notes, and plump juicy drupelets.",
            SubtitleFr: "Éclat intense, notes aromatiques profondes et drupes juteuses.",
            ImageUrl: "images/categories/zarzamoras.jpg",
            AccentColor: "#7209b7",
            Gradient: "linear-gradient(135deg, #240046, #3c096c)",
            Season: "Octubre a Mayo",
            NutritionInfo: "62 cal/taza, Vitamina C (50%), Antocianinas potentes",
            KeyFeatures: new() { "Sin espinas en cosecha", "Sabor dulce sin astringencia", "Brix superior a 11.5°" }
        ),
        new(
            Id: "fresas",
            Name: "FRESAS",
            NameEn: "STRAWBERRIES",
            NameFr: "FRAISES",
            Subtitle: "Rojas de corazón, dulces por naturaleza y seleccionadas en su punto óptimo de maduración.",
            SubtitleEn: "Ruby red to the core, naturally sweet, harvested at peak ripeness.",
            SubtitleFr: "Rouges à cœur, naturellement sucrées, récoltées à pleine maturité.",
            ImageUrl: "images/categories/fresas.jpg",
            AccentColor: "#e63946",
            Gradient: "linear-gradient(135deg, #b5179e, #7209b7)",
            Season: "Noviembre a Mayo",
            NutritionInfo: "49 cal/taza, Vitamina C (140%), Folato esencial",
            KeyFeatures: new() { "Forma cónica uniforme", "Brillo natural sin ceras artificiales", "Aroma frutal penetrante" }
        )
    };

    public List<ProductItem> GetProducts() => new()
    {
        new(
            Id: "clasica-arandanos",
            Name: "CLÁSICA",
            Subtitle: "Arándanos Frescos de Selección",
            BerryType: "Arándanos",
            ClamshellImage: "images/products/big-delight-pack.png",
            BadgeText: "Clásica",
            Description: "Nuestra línea insignia que llega a millones de familias en Norteamérica, Europa y Asia con calibre uniforme y frescura garantizada.",
            DescriptionEn: "Our flagship line delivered to millions of families across North America, Europe, and Asia with uniform caliber and guaranteed freshness.",
            DescriptionFr: "Notre gamme emblématique livrée à des millions de foyers avec un calibre uniforme et une fraîcheur garantie.",
            SizeMetric: "Calibre Estándar (14-16mm)",
            FlavorMetric: "Equilibrado y fresco",
            PackagingMetric: "Clamshell 170g / 310g 100% rPET",
            Brix: "12.0° Brix",
            Firmness: "200 g/mm",
            ShelfLife: "18 días",
            Caliber: "14 - 16 mm"
        ),
        new(
            Id: "big-delight-arandanos",
            Name: "BIG DELIGHT",
            Subtitle: "Arándanos Jumbo Seleccionados",
            BerryType: "Arándanos",
            ClamshellImage: "images/products/big-delight-pack.png",
            BadgeText: "Big Delight",
            Description: "Una experiencia de mayor tamaño, presencia y detalle. Blueberries seleccionadas a mano para quienes buscan algo verdaderamente especial, con crujido inconfundible y jugo abundante.",
            DescriptionEn: "A grander experience in size, presence, and detail. Hand-selected jumbo blueberries crafted for those seeking an elevated crunch and bursting sweetness.",
            DescriptionFr: "Une expérience supérieure de taille, d'allure et de goût. Des myrtilles jumbo sélectionnées à la main pour un croquant d'exception.",
            SizeMetric: "Mayor tamaño (18mm+)",
            FlavorMetric: "Sabor excepcional",
            PackagingMetric: "Presentación premium rPET",
            Brix: "14.5° Brix",
            Firmness: "245 g/mm",
            ShelfLife: "24 días",
            Caliber: "18 - 22 mm",
            IsActive: true
        ),
        new(
            Id: "organica-frambuesas",
            Name: "ORGÁNICA",
            Subtitle: "Frambuesas Certificadas USDA & EU",
            BerryType: "Frambuesas",
            ClamshellImage: "images/categories/frambuesas.jpg",
            BadgeText: "Orgánica",
            Description: "Cultivadas bajo los más estrictos estándares agroecológicos con composta orgánica propia y control biológico de plagas sin pesticidas sintéticos.",
            DescriptionEn: "Grown under strict agroecological standards using in-house organic compost and biological pest control without synthetic pesticides.",
            DescriptionFr: "Cultivées selon les normes agroécologiques les plus strictes avec compost maison et lutte biologique sans pesticides.",
            SizeMetric: "Calibre Premium (16mm+)",
            FlavorMetric: "Dulzura silvestre intensa",
            PackagingMetric: "Bio-Packaging biodegradable",
            Brix: "11.8° Brix",
            Firmness: "185 g/mm",
            ShelfLife: "16 días",
            Caliber: "16 - 19 mm"
        ),
        new(
            Id: "legacy-zarzamoras",
            Name: "LEGACY",
            Subtitle: "Zarzamoras Dulces Sin Espinas",
            BerryType: "Zarzamoras",
            ClamshellImage: "images/categories/zarzamoras.jpg",
            BadgeText: "Legacy",
            Description: "Variedad de linaje refinado con drupas robustas y negras como el ónix que nunca desarrollan acidez amarga ni sangrado en empaque.",
            DescriptionEn: "A refined legacy cultivar featuring onyx-black robust drupelets that eliminate bitterness and resist packaging bleed.",
            DescriptionFr: "Variété d'élite aux drupes fermes noir d'ébène, douce, sans amertume et à tenue exceptionnelle.",
            SizeMetric: "Calibre Extra Grande (18mm+)",
            FlavorMetric: "Notas florales y caramelo",
            PackagingMetric: "Clamshell ventilado premium",
            Brix: "12.5° Brix",
            Firmness: "210 g/mm",
            ShelfLife: "19 días",
            Caliber: "18 - 24 mm"
        ),
        new(
            Id: "legacy-jumbo-blues",
            Name: "LEGACY JUMBO BLUES",
            Subtitle: "Arándanos Gigantes de Cosecha Tardía",
            BerryType: "Arándanos",
            ClamshellImage: "images/genetica/sekoya-pop.jpg",
            BadgeText: "Legacy Jumbo Blues",
            Description: "El pináculo de nuestro programa genético: bayas masivas con piel sedosa, floración plateada y un bocado que estalla con néctar fresco.",
            DescriptionEn: "The pinnacle of our breeding program: massive berries with silky skin, silver bloom, and an explosion of nectar.",
            DescriptionFr: "Le summum de notre recherche variétale: des baies géantes à floraison argentée et explosion de saveur.",
            SizeMetric: "Calibre Colosal (22mm+)",
            FlavorMetric: "Explosión dulce concentrada",
            PackagingMetric: "Edición Limitada Colección Oro",
            Brix: "15.2° Brix",
            Firmness: "260 g/mm",
            ShelfLife: "28 días",
            Caliber: "22 - 26 mm"
        )
    };

    public List<GeneticsVariety> GetGenetics() => new()
    {
        new(
            Id: "amalia",
            Name: "AMALIA®",
            BerryType: "Frambuesa / Raspberry",
            ImageUrl: "images/genetica/amalia.jpg",
            Description: "Genética patentada de frambuesa caracterizada por su color rojo carmesí brillante, receptáculo cerrado que evita desmoronamiento y firmeza inigualable.",
            DescriptionEn: "Patented raspberry variety celebrated for glowing crimson color, closed receptacle preventing collapse, and exceptional shelf firmness.",
            DescriptionFr: "Variété brevetée réputée pour sa couleur pourpre lumineuse, sa fermeté et sa remarquable résistance.",
            Caliber: "18 - 20 mm",
            BrixRating: "12.2° Brix",
            Firmness: "9.2/10",
            ShelfLife: "18+ días refrigerada",
            HarvestWindow: "Octubre - Mayo",
            GlobalLicensing: "Exclusiva Berries Paradise"
        ),
        new(
            Id: "erendira",
            Name: "ERÉNDIRA",
            BerryType: "Zarzamora / Blackberry",
            ImageUrl: "images/genetica/erendira.jpg",
            Description: "Zarzamora de porte erecto sin espinas, de drupas grandes con nula reversión a rojo (red cell) postcosecha y alta productividad homogénea.",
            DescriptionEn: "Erect thornless blackberry featuring uniform drupelets, zero post-harvest red drupelet reversion, and exceptional yield consistency.",
            DescriptionFr: "Mûre sans épines à port érigé, zéro réversion rouge après récolte et excellente productivité.",
            Caliber: "20 - 24 mm",
            BrixRating: "13.0° Brix",
            Firmness: "8.9/10",
            ShelfLife: "20+ días refrigerada",
            HarvestWindow: "Noviembre - Junio",
            GlobalLicensing: "Desarrollo Colaborativo"
        ),
        new(
            Id: "sekoya-beauty",
            Name: "SEKOYA BEAUTY™",
            BerryType: "Arándano / Blueberry",
            ImageUrl: "images/genetica/sekoya-beauty.jpg",
            Description: "Variedad de bajo requerimiento de frío con calibre gigante, textura crocante tipo uva de mesa y floración natural cerosa de máxima protección.",
            DescriptionEn: "Low-chill jumbo blueberry cultivar delivering table-grape crunch, intense natural bloom, and high-impact retail presence.",
            DescriptionFr: "Myrtille géante croquante comme un raisin de table, pruine protectrice et éclat remarquable en rayon.",
            Caliber: "18 - 22 mm",
            BrixRating: "14.8° Brix",
            Firmness: "9.7/10",
            ShelfLife: "25+ días refrigerada",
            HarvestWindow: "Septiembre - Marzo",
            GlobalLicensing: "Sekoya™ Club Member"
        ),
        new(
            Id: "sekoya-pop",
            Name: "SEKOYA POP™",
            BerryType: "Arándano / Blueberry",
            ImageUrl: "images/genetica/sekoya-pop.jpg",
            Description: "Reconocida mundialmente por su distintivo 'pop' sonoro al morder, calibre super-jumbo persistente durante toda la temporada y dulzor aromático constante.",
            DescriptionEn: "Globally acclaimed for its audible snappy 'pop', persistent super-jumbo sizing throughout the season, and reliable flavor profile.",
            DescriptionFr: "Mondialement reconnue pour son croquant 'pop' éclatant, sa taille super-jumbo et sa douceur aromatique.",
            Caliber: "20 - 26 mm",
            BrixRating: "15.5° Brix",
            Firmness: "9.9/10",
            ShelfLife: "30+ días refrigerada",
            HarvestWindow: "Noviembre - Mayo",
            GlobalLicensing: "Sekoya™ Club Member"
        )
    };

    public List<ProcessStep> GetProcessSteps() => new()
    {
        new(
            Number: 1,
            StepKey: "cultivo",
            Title: "Cultivo",
            TitleEn: "Cultivation",
            TitleFr: "Culture",
            ShortDesc: "Nutrición vegetal de precisión y microclimas ideales en valles altos.",
            FullDesc: "Nuestros campos se ubican en valles protegidos a más de 1,500 msnm, combinando sustratos balanceados, riego por goteo computarizado y abejas polinizadoras nativas para un desarrollo armónico de la fruta.",
            Highlight: "100% agua de pozo profundo filtrada",
            TempRange: "18°C - 24°C ambiental",
            Standard: "GlobalG.A.P. & PrimusGFS"
        ),
        new(
            Number: 2,
            StepKey: "cosecha",
            Title: "Cosecha",
            TitleEn: "Harvest",
            TitleFr: "Récolte",
            ShortDesc: "Cosecha manual experta al amanecer para proteger la floración natural.",
            FullDesc: "Cada fruto es recolectado a mano por personal altamente capacitado en las primeras horas de la mañana, cuando la fruta mantiene su turgencia natural. Se sujeta únicamente del pedúnculo para no alterar la floración cerosa.",
            Highlight: "Cosecha 100% artesanal a mano",
            TempRange: "12°C - 16°C matutino",
            Standard: "Fair Trade & SMETA Certified"
        ),
        new(
            Number: 3,
            StepKey: "seleccion",
            Title: "Selección y empaque",
            TitleEn: "Selection & Packaging",
            TitleFr: "Tri et Emballage",
            ShortDesc: "Clasificación óptica computarizada y empaque en campo con atmósfera controlada.",
            FullDesc: "En nuestras salas limpias con filtración HEPA, sensores de visión artificial calibran en 360 grados el calibre, colorimetría, índice de firmeza y defectos mínimos, clasificando hasta 12 toneladas por hora.",
            Highlight: "Visión espectral 360° en tiempo real",
            TempRange: "10°C en sala de selección",
            Standard: "BRCGS Food Safety Grade AA"
        ),
        new(
            Number: 4,
            StepKey: "frio",
            Title: "Cadena de frío",
            TitleEn: "Cold Chain",
            TitleFr: "Chaîne du Froid",
            ShortDesc: "Túneles de preenfriado por aire forzado en menos de 60 minutos.",
            FullDesc: "La clave de la frescura: en menos de 1 hora desde el corte, la fruta entra a túneles de aire forzado reduciendo su calor de campo a 1.5°C exactos, deteniendo el envejecimiento celular y sellando azúcares y nutrientes.",
            Highlight: "Choque térmico a 1.5°C en < 60 min",
            TempRange: "1.0°C - 2.0°C constante",
            Standard: "Telemetría IoT en tiempo real 24/7"
        ),
        new(
            Number: 5,
            StepKey: "mundo",
            Title: "Al mundo",
            TitleEn: "To the World",
            TitleFr: "Vers le Monde",
            ShortDesc: "Logística multimodal express por aire y tierra a más de 19 países.",
            FullDesc: "Nuestra flota de camiones frigoríficos inteligentes y despachos aéreos directos garantizan que las berries cosechadas hoy se exhiban en los anaqueles más exclusivos de Nueva York, Tokio, Londres y Madrid en cuestión de horas.",
            Highlight: "Entrega express en < 48 horas",
            TempRange: "Cadena ininterrumpida a 1.5°C",
            Standard: "C-TPAT & OEA Certified"
        )
    };

    public List<QualityFacility> GetQualityFacilities() => new()
    {
        new(
            Number: 1,
            Code: "campo",
            Title: "Campo",
            TitleEn: "Fields",
            TitleFr: "Champs",
            ImageUrl: "images/process/campo.png",
            Description: "Más de 3,000 hectáreas de macrotúneles y casas sombra con monitoreo climático satelital y estaciones meteorológicas propias.",
            DescriptionEn: "Over 3,000 hectares of high-tunnels with satellite climate intelligence and on-site weather stations.",
            DescriptionFr: "Plus de 3 000 hectares sous abris surveillés par satellite et stations météo dédiées.",
            Capacity: "3,000+ Hectáreas",
            Certification: "GlobalG.A.P. IFA v6"
        ),
        new(
            Number: 2,
            Code: "preenfriado",
            Title: "Preenfriado",
            TitleEn: "Pre-cooling",
            TitleFr: "Préréfrigération",
            ImageUrl: "images/process/preenfriado.png",
            Description: "Túneles de choque de aire forzado a contracorriente con deshumectación controlada para remover el calor metabólico sin deshidratar la piel.",
            DescriptionEn: "Counter-current forced-air cooling tunnels with humidity control to remove field heat without skin moisture loss.",
            DescriptionFr: "Tunnels de froid à air pulsé et hygrométrie contrôlée pour figer la fraîcheur sans déshydratation.",
            Capacity: "80 Tons / Turno",
            Certification: "HACCP Certified"
        ),
        new(
            Number: 3,
            Code: "seleccion",
            Title: "Selección y empaque",
            TitleEn: "Sorting & Packing",
            TitleFr: "Sélection et Emballage",
            ImageUrl: "images/process/seleccion.png",
            Description: "Líneas automatizadas Ellips TrueSort con cámaras multiespectrales para detección de azúcar interno, defectos y calibración milimétrica.",
            DescriptionEn: "Automated Ellips TrueSort optical grading lines with multispectral NIR cameras for internal brix and surface evaluation.",
            DescriptionFr: "Lignes de calibrage optique haute cadence pour analyse du taux de sucre et tri au millimètre.",
            Capacity: "120 Tons / Día",
            Certification: "BRCGS Food Safety"
        ),
        new(
            Number: 4,
            Code: "almacenamiento",
            Title: "Almacenamiento",
            TitleEn: "Cold Storage",
            TitleFr: "Stockage Frigorifique",
            ImageUrl: "images/process/almacenamiento.png",
            Description: "Cámaras frigoríficas inteligentes con ozonificación aérea antimicrobiana y sensores de etileno para preservar la frescura absoluta.",
            DescriptionEn: "Smart cold rooms equipped with gaseous ozone disinfection and precision ethylene scrubbers for pristine freshness.",
            DescriptionFr: "Chambres froides intelligentes avec ozonolyse atmosphérique et absorption continue de l'éthylène.",
            Capacity: "500 Pallets estáticos",
            Certification: "ISO 22000"
        ),
        new(
            Number: 5,
            Code: "envio",
            Title: "Envío",
            TitleEn: "Shipping & Logistics",
            TitleFr: "Expédition Logistique",
            ImageUrl: "images/process/envio.png",
            Description: "Flota refrigerada con sensores GPS y termógrafos en la nube con alertas automáticas ante variaciones térmicas superiores a 0.5°C.",
            DescriptionEn: "Refrigerated logistics fleet backed by cloud-connected IoT thermographs and instantaneous ±0.5°C thermal deviation alerts.",
            DescriptionFr: "Flotte thermo-régulée connectée par satellite avec alertes instantanées de température au dixième de degré.",
            Capacity: "40+ Cargas diarias",
            Certification: "C-TPAT Tier 3"
        )
    };

    public List<RecipeItem> GetRecipes() => new()
    {
        new(
            Id: "pancakes-berries",
            Title: "Pancakes de Berries Mixtos",
            TitleEn: "Mixed Berries Artisan Pancakes",
            TitleFr: "Pancakes Moelleux aux Baies Fraîches",
            CategoryTag: "DESAYUNO",
            CategoryTagEn: "BREAKFAST",
            CategoryTagFr: "PETIT-DÉJEUNER",
            Description: "Esponjosos, llenos de sabor y con el balance perfecto entre dulzura y frescura. Decorados con frutos recién cortados y miel tibia.",
            DescriptionEn: "Fluffy, rich in flavor, and perfectly balanced between sweetness and fruit acidity. Crowned with fresh berries and warm pure syrup.",
            DescriptionFr: "Moelleux, gourmands et harmonieux entre fraîcheur et douceur. Garnis de baies fraîchement récoltées et sirop chaud.",
            ImageUrl: "images/recipes/pancakes.jpg",
            PrepTime: "15 min",
            CookTime: "10 min",
            Servings: 4,
            Calories: 320,
            Ingredients: new()
            {
                "1 taza de arándanos Big Delight Berries Paradise",
                "1/2 taza de frambuesas Amalia®",
                "1/2 taza de zarzamoras Legacy",
                "2 tazas de harina integral de trigo o avena",
                "2 cucharaditas de polvo para hornear",
                "2 huevos de granja",
                "1 1/2 tazas de leche de almendras o entera",
                "2 cucharadas de mantequilla fundida o aceite de coco",
                "Miel de abeja pura o jarabe de maple orgánico"
            },
            IngredientsEn: new()
            {
                "1 cup Berries Paradise Big Delight Blueberries",
                "1/2 cup Amalia® fresh raspberries",
                "1/2 cup Legacy sweet blackberries",
                "2 cups whole wheat or oat flour",
                "2 tsp baking powder",
                "2 pasture-raised eggs",
                "1 1/2 cups almond or whole milk",
                "2 tbsp melted butter or coconut oil",
                "Pure maple syrup or organic wildflower honey"
            },
            IngredientsFr: new()
            {
                "1 tasse de myrtilles Big Delight Berries Paradise",
                "1/2 tasse de framboises fraîches Amalia®",
                "1/2 tasse de mûres Legacy",
                "2 tasses de farine complète ou d'avoine",
                "2 c. à café de levure chimique",
                "2 œufs fermiers",
                "1 1/2 tasse de lait d'amande",
                "2 c. à soupe de beurre fondu",
                "Sirop d'érable pur du Canada"
            },
            Steps: new()
            {
                "En un tazón amplio, tamiza la harina junto con el polvo para hornear y una pizca de sal marina.",
                "En otro recipiente, bate los huevos con la leche y la mantequilla derretida hasta obtener una mezcla homogénea.",
                "Integra suavemente los ingredientes húmedos con los secos; dobla con una espátula sin sobrebatir para mantener el volumen esponjoso.",
                "Calienta una sartén antiadherente a fuego medio y vierte 1/4 de taza por pancake. Deja cocinar hasta que aparezcan burbujas en la superficie (aprox. 2 minutos).",
                "Voltea y cocina 1 minuto más por el reverso hasta que adquieran un color dorado apetecible.",
                "Sirve apilados, corona generosamente con la mezcla de berries frescas de Berries Paradise y baña con miel tibia de maple."
            },
            StepsEn: new()
            {
                "Sift flour, baking powder, and a pinch of fine sea salt into a large bowl.",
                "Whisk eggs with milk and melted butter until smoothly emulsified.",
                "Gently fold wet mixture into dry ingredients using a spatula—do not overmix to preserve fluffiness.",
                "Heat a lightly oiled griddle over medium heat. Pour 1/4 cup batter per pancake.",
                "Cook until bubbles form on top (approx. 2 minutes), flip and cook until golden brown.",
                "Stack high, generously top with fresh Berries Paradise berries, and drizzle warm maple syrup."
            },
            StepsFr: new()
            {
                "Tamiser la farine avec la levure et une pincée de sel.",
                "Battre les œufs avec le lait et le beurre fondu.",
                "Incorporer délicatement les liquides aux poudres sans trop mélanger.",
                "Cuire sur une poêle chaude 2 min par face jusqu'à coloration dorée.",
                "Empiler et napper généreusement de baies fraîches Berries Paradise et sirop chaud."
            }
        ),
        new(
            Id: "smoothie-antioxidante",
            Title: "Super Smoothie Bowl de Berries",
            TitleEn: "Antioxidant Super Berry Smoothie Bowl",
            TitleFr: "Smoothie Bowl Énergétique aux Fruits Rouges",
            CategoryTag: "ENERGÍA",
            CategoryTagEn: "WELLNESS",
            CategoryTagFr: "ÉNERGIE & SANTÉ",
            Description: "Un festín cargado de vitaminas, antioxidantes y grasas saludables para iniciar el día con máxima vitalidad y enfoque mental.",
            DescriptionEn: "A vibrant powerhouse of polyphenols, vitamins, and clean nutrients to supercharge morning vitality.",
            DescriptionFr: "Un concentré d'antioxydants et vitamines naturelles pour démarrer la journée en pleine vitalité.",
            ImageUrl: "images/recipes/smoothie.jpg",
            PrepTime: "10 min",
            CookTime: "0 min",
            Servings: 2,
            Calories: 260,
            Ingredients: new()
            {
                "1 1/2 tazas de arándanos congelados Berries Paradise",
                "1 taza de frambuesas y zarzamoras congeladas",
                "1 plátano maduro congelado en rodajas",
                "1/2 taza de leche de coco o yogur griego natural",
                "1 cucharada de semillas de chía",
                "Topping: arándanos frescos, coco rallado, almendras tostadas y flores comestibles"
            },
            IngredientsEn: new()
            {
                "1 1/2 cups frozen Berries Paradise blueberries",
                "1 cup frozen raspberries and blackberries",
                "1 frozen sliced banana",
                "1/2 cup coconut milk or plain Greek yogurt",
                "1 tbsp chia seeds",
                "Topping: fresh jumbo blueberries, toasted almond slivers, coconut flakes"
            },
            IngredientsFr: new()
            {
                "1 1/2 tasse de myrtilles surgelées Berries Paradise",
                "1 tasse de framboises et mûres surgelées",
                "1 banane surgelée en rondelles",
                "1/2 tasse de yaourt grec ou lait de coco",
                "1 c. à soupe de graines de chia",
                "Garniture: baies fraîches, amandes effilées et copeaux de coco"
            },
            Steps: new()
            {
                "Agrega a la licuadora potente los frutos rojos congelados junto con el plátano y la base de yogur o leche vegetal.",
                "Licúa a velocidad baja usando el prensador hasta lograr una consistencia ultra espesa y cremosa como helado artesanal.",
                "Vierte en tu tazón favorito y alisa la superficie con el dorso de una cuchara.",
                "Decora con líneas artísticas de arándanos frescos Big Delight, frambuesas Amalia, semillas de chía y láminas de coco tostado."
            },
            StepsEn: new()
            {
                "Add frozen berries, banana slices, and coconut milk or Greek yogurt into a high-speed blender.",
                "Blend on low using a tamper until an ultra-thick, creamy soft-serve texture is achieved.",
                "Pour into chilled bowls and smooth the surface.",
                "Artfully garnish with fresh Berries Paradise fruit, chia seeds, and toasted coconut."
            },
            StepsFr: new()
            {
                "Placer les fruits congelés et le yaourt dans un blender puissant.",
                "Mixer jusqu'à consistance onctueuse et très épaisse.",
                "Verser dans un bol et décorer de baies fraîches et graines de chia."
            }
        )
    };

    public List<MarketItem> GetMarkets() => new()
    {
        new("América del Norte", "Estados Unidos", 37.0902, -95.7129, "45,000 Tons/año", "McAllen / Nogales / Philadelphia"),
        new("América del Norte", "Canadá", 56.1304, -106.3468, "12,000 Tons/año", "Toronto / Vancouver / Montreal"),
        new("Europa", "Reino Unido", 55.3781, -3.4360, "8,500 Tons/año", "London Heathrow Air Hub"),
        new("Europa", "Países Bajos / Unión Europea", 52.1326, 5.2913, "15,000 Tons/año", "Rotterdam Port & Amsterdam Schiphol"),
        new("Asia-Pacífico", "Japón", 36.2048, 138.2529, "4,200 Tons/año", "Tokyo Narita Express Cargo"),
        new("Medio Oriente", "Emiratos Árabes Unidos", 23.4241, 53.8478, "2,100 Tons/año", "Dubai International Freight"),
        new("América Latina", "México (Mercado Nacional)", 23.6345, -102.5528, "22,000 Tons/año", "Guadalajara / CDMX / Monterrey")
    };
}
