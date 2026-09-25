# 🍓 Berries Paradise — Experiencia Web Editorial & Agroindustrial en Blazor WebAssembly (.NET 10)

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Blazor WebAssembly](https://img.shields.io/badge/Blazor-WebAssembly-512BD4?style=for-the-badge&logo=blazor&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![Three.js](https://img.shields.io/badge/Three.js-r128-black?style=for-the-badge&logo=three.js&logoColor=white)](https://threejs.org/)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=for-the-badge)](LICENSE)
[![Status](https://img.shields.io/badge/Status-Production%20Ready-brightgreen?style=for-the-badge)]()

> **Desarrollado por:** Román Velasco Moctezuma ([@roman00120](https://github.com/roman00120))  
> 🌐 **Demo en Producción:** [https://berrys.chambapp.com.mx/](https://berrys.chambapp.com.mx/)

---

## 📌 Sobre el Proyecto

Diseñé y construí **Berries Paradise** como una plataforma web editorial y comercial de vanguardia para la industria agroalimentaria internacional. El objetivo principal fue alejarme de los sitios web corporativos tradicionales y crear una experiencia inmersiva que transmita frescura, calidad de exportación y rigor tecnológico.

La aplicación está desarrollada con **Blazor WebAssembly en .NET 10**, complementada con gráficos 3D interactivos en **Three.js / WebGL**, un sistema de diseño propio en **Vanilla CSS** con estética editorial (glassmorphism, paletas HSL, tipografías display) y una arquitectura limpia y desacoplada en C#.

---

## 🚀 Características Principales

### 1. Hero 3D Interactivo & Cinemático
- Integración de **Three.js** con partículas volumétricas y elementos botánicos en 3D que reaccionan al movimiento del cursor del usuario o acelerómetro en móviles.
- Animaciones fluidas a 60 FPS mediante `requestAnimationFrame` y shaders optimizados para GPU.
- Tipografía display audaz con eslogan corporativo dinámico y transiciones suaves.

### 2. Catálogo Editorial Asimétrico de Productos
- Navegación visual fluida entre las 4 categorías insignia: **Arándanos**, **Frambuesas**, **Zarzamoras** y **Fresas**.
- Grid asimétrico que destaca presentaciones premium como **Big Delight** junto con líneas Clásica, Orgánica, Legacy y Jumbo Blues.
- Cambio de fruta y filtrado reactivo instantáneo gestionado mediante el estado de la aplicación sin recargas de página.

### 3. Modales y Fichas Técnicas Responsive
- Sistema unificado de ventanas modales con información detallada de producto, genética varietal, recetas culinarias y contacto comercial.
- Fichas agronómicas completas con especificaciones comerciales: grados Brix (°Bx), firmeza ($g/mm$), calibres y vida de anaquel.
- Diseño **100% adaptable** que colapsa a una columna elegante en pantallas móviles (`320px` a `768px`) con scroll vertical nativo y protección total contra desbordes horizontales.

### 4. Sistema Multi-Idioma Reactivo (ES / EN / FR)
- Selector de idiomas premium tipo dropdown con banderas e indicador de estado activo.
- Soporte para **Español**, **English** y **Français**.
- Motor de localización desacoplado conectado a `WebUiStateService` con notificación reactiva de cambios en tiempo real a todos los componentes Razor.

### 5. Storytelling Editorial "Del Campo al Mundo"
- Timeline interactivo y tarjetas editoriales que documentan la cadena de valor: campos protegidos, cosecha manual selectiva, selección por inteligencia óptica y trazabilidad de frío.
- Reproductor de video de marca integrado con modal cinematográfico y control de audio inteligente.

### 6. Optimización Mobile-First Exhaustiva
- Auditado y probado en resoluciones compactas reales: **320px** (iPhone SE 1st gen), **375px**, **390px** (iPhone 14/15), **430px** (Pro Max), **768px** (Tablets) y **1280px+** (Desktop).
- Sin barras de desplazamiento horizontal (`overflow-x: hidden`), botones de cierre y cotización perfectamente delimitados dentro del viewport.

---

## 🏗️ Arquitectura de la Solución

Estructuré la solución siguiendo principios de **Clean Architecture** y modularidad en carpetas independientes bajo `src/`:

```text
Paradise/
├── BerriesParadise.slnx              # Solución moderna de .NET
├── src/
│   ├── BerriesParadise.Core/         # Modelos de dominio y entidades base
│   │   └── Models/                   # Product, Berry, GeneticVariety, Recipe, etc.
│   │
│   ├── BerriesParadise.Content/      # Catálogos estáticos y servicio de localización
│   │   ├── Catalogs/                 # ProductCatalog, BerryCatalog, GeneticsCatalog, RecipeCatalog
│   │   └── Localization/             # LocalizationService (diccionarios ES/EN/FR)
│   │
│   ├── BerriesParadise.Mobile/       # Modelos y utilidades para clientes móviles
│   │
│   └── BerriesParadise.Web/          # Aplicación principal Blazor WebAssembly (.NET 10)
│       ├── Components/               # Componentes UI (Hero, ProductCard, ProductShowcase, etc.)
│       │   └── Modals/               # Modales de detalle (Product, Berry, Genetics, Recipe, Sales, Video)
│       ├── Layout/                   # MainLayout, MainNavigation, SiteFooter
│       ├── Pages/                    # Home.razor
│       ├── Services/                 # WebUiStateService (State container para Blazor)
│       └── wwwroot/                  # Assets estáticos
│           ├── css/                  # paradise.css (Design System completo en Vanilla CSS)
│           ├── js/                   # three.js, berries-three-manager.js, hero-parallax.js
│           ├── images/               # Fotografía editorial, mockups clamshell HD y logos
│           ├── videos/               # Video corporativo en MP4
│           ├── .htaccess             # Configuración Apache para SPA routing, compresión y MIME types
│           └── index.html            # Entrypoint HTML con preloads de LCP y bootstrap de Blazor
```

---

## 🛠️ Stack Tecnológico

| Capa | Tecnología | Propósito |
| :--- | :--- | :--- |
| **Framework Web** | [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) (.NET 10) | Single Page Application (SPA) compilada en WebAssembly para máxima velocidad |
| **Lenguaje** | C# 13 | Tipado estricto, pattern matching y records inmutables |
| **Gráficos 3D** | [Three.js](https://threejs.org/) / WebGL | Renderizado 3D en tiempo real de berries y partículas interactivas |
| **Estilos & UI** | Vanilla CSS Moderno | Variables CSS (Design Tokens), Flexbox, CSS Grid, Glassmorphism, animaciones fluidas |
| **Tipografía** | Google Fonts | *Barlow Condensed* (Display), *Outfit* y *Plus Jakarta Sans* (Lectura editorial) |
| **Interoperabilidad** | JavaScript Interop (IJSRuntime) | Conexión bidireccional entre eventos Blazor y APIs del navegador |
| **Hosting & Servidor** | Apache / Hostinger | Configuración `.htaccess` con rewrites SPA, headers de caché y MIME types para `.wasm` |

---

## 💻 Instalación y Ejecución Local

### Prerrequisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) instalado en tu equipo.
- Navegador moderno con soporte para WebAssembly y WebGL (Chrome, Edge, Firefox, Safari).

### Pasos

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/roman00120/blazor-.git
   cd blazor-
   ```

2. **Restaurar dependencias y compilar:**
   ```bash
   dotnet restore
   dotnet build
   ```

3. **Ejecutar el proyecto web localmente:**
   ```bash
   dotnet run --project src/BerriesParadise.Web
   ```

4. **Abrir en tu navegador:**
   Navega a `http://localhost:5000` o la URL indicada en la consola.

---

## 📦 Publicación y Despliegue

Para generar el bundle optimizado para servidores web estáticos (como Apache, Nginx o Azure Static Web Apps):

```bash
dotnet publish src/BerriesParadise.Web/BerriesParadise.Web.csproj -c Release -o publish_out
```

El script de automatización `deploy_mobile_fix.ps1` incluido en la raíz permite empaquetar y transferir automáticamente los ensamblados actualizados y assets estáticos vía SCP/SSH.

---

## 👨‍💻 Autor

**Román Velasco Moctezuma**
- GitHub: [@roman00120](https://github.com/roman00120)
- Proyecto: [Berries Paradise Web](https://berrys.chambapp.com.mx/)

---

## 📄 Licencia

Este proyecto se encuentra bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.
