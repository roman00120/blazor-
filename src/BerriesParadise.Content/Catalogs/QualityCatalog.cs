using BerriesParadise.Core.Models;

namespace BerriesParadise.Content.Catalogs;

public class QualityCatalog
{
    private static readonly List<QualityStep> ProcessSteps = new()
    {
        new(
            StepNumber: 1,
            Key: "cultivo",
            Title: "Cultivo",
            Subtitle: "Nutrición vegetal de precisión y microclimas ideales",
            Description: "Campos ubicados en valles protegidos de Jalisco y Michoacán a más de 1,500 msnm. Riego computarizado por goteo, nutrición orgánica balanceada y polinización natural por abejorros nativos.",
            ImageUrl: "images/process/hd-campo.jpg",
            Highlight: "100% agua de pozo profundo analizada",
            TemperatureSpec: "18°C - 24°C ambiental",
            CertificationStandard: "GlobalG.A.P. & PrimusGFS"
        ),
        new(
            StepNumber: 2,
            Key: "cosecha",
            Title: "Cosecha",
            Subtitle: "Cosecha manual experta al alba",
            Description: "Cosechada a mano en las primeras horas frescas de la mañana cuando la fruta mantiene su turgencia natural. Se sujeta cuidadosamente del pedúnculo para no alterar la capa cerosa protectora (bloom).",
            ImageUrl: "images/process/hd-cosecha.jpg",
            Highlight: "Recolección artesanal 100% a mano",
            TemperatureSpec: "12°C - 16°C matutino",
            CertificationStandard: "Fair Trade & SMETA Sedex"
        ),
        new(
            StepNumber: 3,
            Key: "seleccion",
            Title: "Selección y empaque",
            Subtitle: "Clasificación óptica espectral y salas limpias",
            Description: "En salas con aire filtrado y presión positiva, cámaras espectrales de visión computarizada 360° analizan calibre milimétrico, colorimetría, brix y textura a velocidades de hasta 12 toneladas por hora.",
            ImageUrl: "images/process/hd-seleccion.jpg",
            Highlight: "Visión computarizada espectral 360°",
            TemperatureSpec: "10°C en salas de empaque",
            CertificationStandard: "BRCGS Food Safety Grado AA"
        ),
        new(
            StepNumber: 4,
            Key: "frio",
            Title: "Cadena de frío",
            Subtitle: "Túneles de choque térmico por aire forzado",
            Description: "En menos de 60 minutos desde el corte, la fruta entra a túneles de aire forzado reduciendo el calor metabólico de campo a 1.5°C exactos, sellando los azúcares naturales y frenando el envejecimiento celular.",
            ImageUrl: "images/process/hd-preenfriado.jpg",
            Highlight: "Reducción térmica a 1.5°C en < 60 min",
            TemperatureSpec: "1.0°C - 2.0°C ininterrumpida",
            CertificationStandard: "Monitoreo telemétrico IoT 24/7"
        ),
        new(
            StepNumber: 5,
            Key: "mundo",
            Title: "Al mundo",
            Subtitle: "Logística multimodal express terrestre y aérea",
            Description: "Despachos directos refrigerados a más de 19 países. Rutas terrestres express hacia Estados Unidos y Canadá, y vuelos de carga directa hacia Europa, Japón, Singapur y Emiratos Árabes.",
            ImageUrl: "images/process/hd-envio.jpg",
            Highlight: "Llegada a anaquel internacional en < 48 hrs",
            TemperatureSpec: "Cadena de frío continua a 1.5°C",
            CertificationStandard: "C-TPAT Tier 3 & Operador OEA"
        )
    };

    private static readonly List<QualityStep> FacilityStages = new()
    {
        new(1, "campo", "Campo", "Valles Fértiles", "Más de 3,000 hectáreas de macrotúneles y casas sombra con monitoreo climático satelital y estaciones meteorológicas propias.", "images/process/hd-campo.jpg", "3,000+ Hectáreas", "Ambiente", "GlobalG.A.P. IFA v6"),
        new(2, "preenfriado", "Preenfriado", "Túneles de Choque", "Túneles de preenfriado por aire forzado a contracorriente con humedad relativa controlada al 95%.", "images/process/hd-preenfriado.jpg", "80 Tons / Turno", "1.5°C", "HACCP Certified"),
        new(3, "seleccion", "Selección y empaque", "Líneas Automatizadas", "Líneas de selección óptica automatizadas con cámaras multiespectrales para evaluación de defectos microscópicos.", "images/process/hd-seleccion.jpg", "120 Tons / Día", "10°C", "BRCGS Food Safety AA"),
        new(4, "almacenamiento", "Almacenamiento", "Cámaras Inteligentes", "Cámaras de frío con control de etileno y atmósfera ozonificada para prolongar la vitalidad de la fruta.", "images/process/hd-preenfriado.jpg", "500 Pallets estáticos", "1.0°C - 1.5°C", "ISO 22000"),
        new(5, "envio", "Envío", "Flota Refrigerada", "Camiones inteligentes y contenedores refrigerados conectados a la nube con alertas de variación de 0.5°C.", "images/process/hd-envio.jpg", "40+ Cargas Diarias", "1.5°C", "C-TPAT & OEA")
    };

    public IReadOnlyList<QualityStep> GetProcessSteps() => ProcessSteps;

    public IReadOnlyList<QualityStep> GetFacilities() => FacilityStages;

    public QualityStep? GetStepByNumber(int number) =>
        ProcessSteps.FirstOrDefault(s => s.StepNumber == number);
}
