/**
 * Berries Paradise - Premium Three.js Visual Layer Manager
 * 
 * Strict Performance Guidelines:
 * - Enhances the website, does NOT dominate it.
 * - Respects prefers-reduced-motion.
 * - Detects WebGL availability with CSS fallback.
 * - Disposes geometries, materials, textures, renderers, RAF and event listeners upon component unmount.
 * - Disables / simplifies heavy rendering on mobile viewports (< 768px).
 * - Target 60fps with low polygon count and lightweight materials.
 * 
 * 3 Controlled Effects:
 * 1. HERO: Subtle depth & camera parallax with crystalline morning mist & dew droplets.
 * 2. FLOATING BERRIES: Deterministic micro-floating suspended berries with randomized seed angles, gently responding to mouse move.
 * 3. GLOBAL PRESENCE: Interactive 3D globe representing real international export routes and hubs (Mexico, USA, Canada, UK, Netherlands, Japan, UAE, Singapore).
 */
(function () {
    window.berriesThreeManager = {
        scenes: {},
        threePromise: null,

        loadThreeJs: function () {
            if (window.THREE) {
                return Promise.resolve(window.THREE);
            }
            if (this.threePromise) {
                return this.threePromise;
            }
            this.threePromise = new Promise(function (resolve, reject) {
                var script = document.createElement('script');
                script.src = 'https://cdnjs.cloudflare.com/ajax/libs/three.js/r128/three.min.js';
                script.async = true;
                script.onload = function () {
                    resolve(window.THREE);
                };
                script.onerror = function (err) {
                    reject(err);
                };
                document.head.appendChild(script);
            });
            return this.threePromise;
        },

        isWebGLAvailable: function () {
            try {
                var canvas = document.createElement('canvas');
                return !!(window.WebGLRenderingContext && 
                    (canvas.getContext('webgl') || canvas.getContext('experimental-webgl')));
            } catch (e) {
                return false;
            }
        },

        prefersReducedMotion: function () {
            return window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches;
        },

        isMobile: function () {
            return window.innerWidth < 768;
        },

        initScene: function (containerId, effectType, options) {
            var self = this;
            var container = document.getElementById(containerId);
            if (!container) return;

            // If user prefers reduced motion, gracefully exit
            if (this.prefersReducedMotion()) {
                container.classList.add('three-disabled-motion');
                return;
            }

            if (!this.isWebGLAvailable()) {
                container.classList.add('three-fallback-active');
                return;
            }

            // On mobile viewports, disable heavy WebGL globe/floating berries to conserve GPU and battery
            if (this.isMobile() && (effectType === 'floating-berries' || effectType === 'globe')) {
                container.classList.add('three-fallback-active');
                return;
            }

            // Dynamically load Three.js on-demand only when a scene is initialized
            this.loadThreeJs().then(function (THREE) {
                if (!container.isConnected) return; // if component unmounted while loading

                // Cleanup any existing instance
                if (self.scenes[containerId]) {
                    self.destroyScene(containerId);
                }

                switch (effectType) {
                    case 'hero':
                        self.initHeroEffect(containerId, container, options);
                        break;
                    case 'floating-berries':
                        self.initFloatingBerriesEffect(containerId, container, options);
                        break;
                    case 'globe':
                        self.initGlobeEffect(containerId, container, options);
                        break;
                    default:
                        console.warn('BerriesParadise ThreeManager: Unknown effect type', effectType);
                }
            }).catch(function (err) {
                console.warn('BerriesParadise ThreeManager: Failed to load Three.js dynamically, using fallback', err);
                container.classList.add('three-fallback-active');
            });
        },

        /* =========================================================================
           EFFECT 1 — HERO: Subtle Depth & Parallax
           ========================================================================= */
        initHeroEffect: function (containerId, container, options) {
            var isMob = this.isMobile();
            var width = container.clientWidth || window.innerWidth;
            var height = container.clientHeight || window.innerHeight;

            var scene = new THREE.Scene();
            var camera = new THREE.PerspectiveCamera(50, width / height, 0.1, 500);
            camera.position.set(0, 0, 24);

            var renderer;
            try {
                renderer = new THREE.WebGLRenderer({
                    alpha: true,
                    antialias: !isMob,
                    powerPreference: 'high-performance'
                });
                renderer.setSize(width, height);
                renderer.setPixelRatio(Math.min(window.devicePixelRatio || 1, isMob ? 1 : 1.75));
                container.appendChild(renderer.domElement);
            } catch (err) {
                container.classList.add('three-fallback-active');
                return;
            }

            // Dew droplets count: fewer on mobile
            var dropletCount = isMob ? 10 : 26;
            var sphereGeo = new THREE.SphereGeometry(0.3, 14, 14);
            var dropletMat = new THREE.MeshPhysicalMaterial({
                color: 0x9ddcf5,
                roughness: 0.15,
                transmission: 0.82,
                transparent: true,
                opacity: 0.75,
                reflectivity: 0.9,
                clearcoat: 1.0,
                clearcoatRoughness: 0.12
            });

            var droplets = [];
            for (var i = 0; i < dropletCount; i++) {
                var mesh = new THREE.Mesh(sphereGeo, dropletMat);
                mesh.position.x = (Math.random() - 0.25) * 34;
                mesh.position.y = (Math.random() - 0.5) * 20;
                mesh.position.z = (Math.random() - 0.5) * 14;

                var sc = 0.35 + Math.random() * 0.65;
                mesh.scale.set(sc, sc * 1.12, sc);

                mesh.userData = {
                    speedY: 0.003 + Math.random() * 0.007,
                    wobbleSpeed: 0.015 + Math.random() * 0.025,
                    wobbleOffset: Math.random() * Math.PI * 2,
                    speedZ: (Math.random() - 0.5) * 0.002
                };

                scene.add(mesh);
                droplets.push(mesh);
            }

            // Controlled subtle ambient lighting
            var ambientLight = new THREE.AmbientLight(0xffffff, 0.85);
            scene.add(ambientLight);

            var cyanLight = new THREE.PointLight(0x08b8e8, 1.4, 60);
            cyanLight.position.set(12, 10, 14);
            scene.add(cyanLight);

            var creamLight = new THREE.PointLight(0xf4ef9a, 0.6, 45);
            creamLight.position.set(-14, -8, 10);
            scene.add(creamLight);

            var mouseX = 0, mouseY = 0;
            var targetX = 0, targetY = 0;

            var onMouseMove = function (e) {
                var w = window.innerWidth;
                var h = window.innerHeight;
                mouseX = (e.clientX / w) * 2 - 1;
                mouseY = -(e.clientY / h) * 2 + 1;
            };

            window.addEventListener('mousemove', onMouseMove, { passive: true });

            var onResize = function () {
                if (!container) return;
                var w = container.clientWidth || window.innerWidth;
                var h = container.clientHeight || window.innerHeight;
                camera.aspect = w / h;
                camera.updateProjectionMatrix();
                renderer.setSize(w, h);
            };

            window.addEventListener('resize', onResize, { passive: true });

            var animId;
            var clock = new THREE.Clock();

            var animate = function () {
                animId = requestAnimationFrame(animate);

                // Very subtle easing towards mouse (clamped)
                targetX += (mouseX * 1.0 - targetX) * 0.035;
                targetY += (mouseY * 0.6 - targetY) * 0.035;

                camera.position.x = targetX;
                camera.position.y = targetY;
                camera.lookAt(0, 0, 0);

                var elapsed = clock.getElapsedTime();

                for (var j = 0; j < droplets.length; j++) {
                    var d = droplets[j];
                    d.position.y += d.userData.speedY;
                    d.position.x += Math.sin(elapsed * d.userData.wobbleSpeed + d.userData.wobbleOffset) * 0.0035;
                    d.rotation.y += 0.006;

                    if (d.position.y > 11) {
                        d.position.y = -11;
                    }
                }

                renderer.render(scene, camera);
            };

            animate();

            this.scenes[containerId] = {
                renderer: renderer,
                scene: scene,
                camera: camera,
                geometries: [sphereGeo],
                materials: [dropletMat],
                lights: [ambientLight, cyanLight, creamLight],
                animId: animId,
                listeners: [
                    { target: window, event: 'mousemove', handler: onMouseMove },
                    { target: window, event: 'resize', handler: onResize }
                ]
            };
        },

        /* =========================================================================
           EFFECT 2 — FLOATING BERRIES: Deterministic Micro-Floating Motion
           ========================================================================= */
        initFloatingBerriesEffect: function (containerId, container, options) {
            var isMob = this.isMobile();
            var width = container.clientWidth || 400;
            var height = container.clientHeight || 400;

            var scene = new THREE.Scene();
            var camera = new THREE.PerspectiveCamera(45, width / height, 0.1, 100);
            camera.position.set(0, 0, 18);

            var renderer;
            try {
                renderer = new THREE.WebGLRenderer({
                    alpha: true,
                    antialias: !isMob,
                    powerPreference: 'high-performance'
                });
                renderer.setSize(width, height);
                renderer.setPixelRatio(Math.min(window.devicePixelRatio || 1, 1.5));
                container.appendChild(renderer.domElement);
            } catch (err) {
                container.classList.add('three-fallback-active');
                return;
            }

            // Spherical berry representations (Blueberry blue, Raspberry crimson, Blackberry deep indigo)
            var sphereGeo = new THREE.SphereGeometry(0.75, 18, 18);
            var blueMat = new THREE.MeshStandardMaterial({
                color: 0x1d3557,
                roughness: 0.35,
                metalness: 0.15,
                transparent: true,
                opacity: 0.92
            });
            var raspMat = new THREE.MeshStandardMaterial({
                color: 0x9b111e,
                roughness: 0.45,
                metalness: 0.1,
                transparent: true,
                opacity: 0.88
            });
            var blackMat = new THREE.MeshStandardMaterial({
                color: 0x0f141d,
                roughness: 0.28,
                metalness: 0.3,
                transparent: true,
                opacity: 0.92
            });

            // 5 subtle micro floating spheres around product perimeter
            var berryConfigs = [
                { mat: blueMat, x: -5.2, y: 3.2, z: 1.5, scale: 0.85, seed: 1.2 },
                { mat: blueMat, x: 5.4, y: 2.8, z: -1.2, scale: 0.72, seed: 2.4 },
                { mat: raspMat, x: 4.8, y: -3.8, z: 2.1, scale: 0.95, seed: 3.7 },
                { mat: blackMat, x: -4.9, y: -2.9, z: -0.8, scale: 0.8, seed: 4.9 },
                { mat: blueMat, x: 0.4, y: -5.4, z: 1.0, scale: 0.65, seed: 5.6 }
            ];

            // If mobile, keep only 3
            if (isMob) {
                berryConfigs = berryConfigs.slice(0, 3);
            }

            var berryMeshes = [];
            berryConfigs.forEach(function (cfg) {
                var mesh = new THREE.Mesh(sphereGeo, cfg.mat);
                mesh.position.set(cfg.x, cfg.y, cfg.z);
                mesh.scale.setScalar(cfg.scale);
                mesh.userData = {
                    initialX: cfg.x,
                    initialY: cfg.y,
                    initialZ: cfg.z,
                    seed: cfg.seed,
                    floatSpeed: 0.8 + (cfg.seed % 0.5),
                    rotSpeedX: 0.005 + (cfg.seed % 0.004),
                    rotSpeedY: 0.006 + (cfg.seed % 0.005)
                };
                scene.add(mesh);
                berryMeshes.push(mesh);
            });

            // Subtle lights
            var amb = new THREE.AmbientLight(0xffffff, 0.9);
            scene.add(amb);

            var dir = new THREE.DirectionalLight(0x08b8e8, 1.2);
            dir.position.set(5, 10, 7);
            scene.add(dir);

            var clock = new THREE.Clock();
            var animId;

            var animate = function () {
                animId = requestAnimationFrame(animate);
                var t = clock.getElapsedTime();

                for (var i = 0; i < berryMeshes.length; i++) {
                    var b = berryMeshes[i];
                    var u = b.userData;
                    // Deterministic sine & cosine floating
                    b.position.y = u.initialY + Math.sin(t * u.floatSpeed + u.seed) * 0.28;
                    b.position.x = u.initialX + Math.cos(t * (u.floatSpeed * 0.7) + u.seed) * 0.16;
                    b.rotation.x += u.rotSpeedX;
                    b.rotation.y += u.rotSpeedY;
                }

                renderer.render(scene, camera);
            };

            animate();

            var onResize = function () {
                if (!container) return;
                var w = container.clientWidth || 400;
                var h = container.clientHeight || 400;
                camera.aspect = w / h;
                camera.updateProjectionMatrix();
                renderer.setSize(w, h);
            };

            window.addEventListener('resize', onResize, { passive: true });

            this.scenes[containerId] = {
                renderer: renderer,
                scene: scene,
                camera: camera,
                geometries: [sphereGeo],
                materials: [blueMat, raspMat, blackMat],
                lights: [amb, dir],
                animId: animId,
                listeners: [
                    { target: window, event: 'resize', handler: onResize }
                ]
            };
        },

        /* =========================================================================
           EFFECT 3 — GLOBAL PRESENCE: Lightweight 3D Earth & Export Arc Lines
           ========================================================================= */
        initGlobeEffect: function (containerId, container, options) {
            var isMob = this.isMobile();
            var width = container.clientWidth || 500;
            var height = container.clientHeight || 450;

            var scene = new THREE.Scene();
            var camera = new THREE.PerspectiveCamera(40, width / height, 0.1, 100);
            camera.position.set(0, 0, 16);

            var renderer;
            try {
                renderer = new THREE.WebGLRenderer({
                    alpha: true,
                    antialias: !isMob,
                    powerPreference: 'high-performance'
                });
                renderer.setSize(width, height);
                renderer.setPixelRatio(Math.min(window.devicePixelRatio || 1, 1.5));
                container.appendChild(renderer.domElement);
            } catch (err) {
                container.classList.add('three-fallback-active');
                return;
            }

            var globeGroup = new THREE.Group();
            scene.add(globeGroup);

            // Globe Wireframe / Point Sphere for clean editorial look
            var globeRadius = 5.2;
            var sphereSegments = isMob ? 24 : 36;
            var globeGeo = new THREE.SphereGeometry(globeRadius, sphereSegments, sphereSegments);
            var globeWireMat = new THREE.MeshBasicMaterial({
                color: 0x003b52,
                wireframe: true,
                transparent: true,
                opacity: 0.28
            });
            var globeMesh = new THREE.Mesh(globeGeo, globeWireMat);
            globeGroup.add(globeMesh);

            // Inner core glow sphere
            var innerGeo = new THREE.SphereGeometry(globeRadius * 0.985, 20, 20);
            var innerMat = new THREE.MeshBasicMaterial({
                color: 0x001724,
                transparent: true,
                opacity: 0.85
            });
            var innerMesh = new THREE.Mesh(innerGeo, innerMat);
            globeGroup.add(innerMesh);

            // Helper to convert Lat / Lon to 3D Cartesian coordinates on sphere
            function latLonToVector3(lat, lon, radius) {
                var phi = (90 - lat) * (Math.PI / 180);
                var theta = (lon + 180) * (Math.PI / 180);
                var x = -(radius * Math.sin(phi) * Math.cos(theta));
                var z = radius * Math.sin(phi) * Math.sin(theta);
                var y = radius * Math.cos(phi);
                return new THREE.Vector3(x, y, z);
            }

            // Verified Berries Paradise hubs & verified international destinations:
            // Guadalajara/Jalisco, Mexico (Primary Origin Hub: 20.65, -103.35)
            // Destination Hubs: Los Angeles, New York, Toronto, London, Rotterdam, Tokyo, Dubai, Singapore
            var originHub = { name: "Jalisco, MX (HQ)", lat: 20.65, lon: -103.35 };
            var destinations = [
                { name: "Los Angeles, USA", lat: 34.05, lon: -118.24 },
                { name: "New York, USA", lat: 40.71, lon: -74.00 },
                { name: "Toronto, Canada", lat: 43.65, lon: -79.38 },
                { name: "Rotterdam / EU", lat: 51.92, lon: 4.47 },
                { name: "London, UK", lat: 51.50, lon: -0.12 },
                { name: "Tokyo, Japan", lat: 35.67, lon: 139.65 },
                { name: "Dubai, UAE", lat: 25.20, lon: 55.27 },
                { name: "Singapore", lat: 1.35, lon: 103.81 }
            ];

            var hubMarkerGeo = new THREE.SphereGeometry(0.18, 10, 10);
            var originMat = new THREE.MeshBasicMaterial({ color: 0xf4ef9a }); // Cream yellow marker
            var destMat = new THREE.MeshBasicMaterial({ color: 0x08b8e8 });   // Cyan marker

            var originPos = latLonToVector3(originHub.lat, originHub.lon, globeRadius);
            var originMesh = new THREE.Mesh(hubMarkerGeo, originMat);
            originMesh.position.copy(originPos);
            originMesh.scale.set(1.4, 1.4, 1.4);
            globeGroup.add(originMesh);

            // Export Arc lines from Origin to Dest
            var curveGeos = [];
            var curveMat = new THREE.LineBasicMaterial({
                color: 0x08b8e8,
                transparent: true,
                opacity: 0.75,
                linewidth: 1.5
            });

            destinations.forEach(function (dest) {
                var destPos = latLonToVector3(dest.lat, dest.lon, globeRadius);
                var destMesh = new THREE.Mesh(hubMarkerGeo, destMat);
                destMesh.position.copy(destPos);
                globeGroup.add(destMesh);

                // Create elevated bezier curve
                var mid = new THREE.Vector3().addVectors(originPos, destPos).multiplyScalar(0.5);
                var distance = originPos.distanceTo(destPos);
                mid.normalize().multiplyScalar(globeRadius + distance * 0.22);

                var curve = new THREE.QuadraticBezierCurve3(originPos, mid, destPos);
                var points = curve.getPoints(isMob ? 16 : 28);
                var lineGeo = new THREE.BufferGeometry().setFromPoints(points);
                curveGeos.push(lineGeo);

                var line = new THREE.Line(lineGeo, curveMat);
                globeGroup.add(line);
            });

            // Gentle initial tilt
            globeGroup.rotation.x = 0.25;
            globeGroup.rotation.y = -1.2;

            // Interactive gentle dragging or auto-rotation
            var isDragging = false;
            var previousMouseX = 0;
            var previousMouseY = 0;

            var onMouseDown = function (e) {
                isDragging = true;
                previousMouseX = e.clientX;
                previousMouseY = e.clientY;
            };

            var onMouseMove = function (e) {
                if (!isDragging) return;
                var deltaX = e.clientX - previousMouseX;
                var deltaY = e.clientY - previousMouseY;

                globeGroup.rotation.y += deltaX * 0.004;
                globeGroup.rotation.x = Math.max(-0.6, Math.min(0.6, globeGroup.rotation.x + deltaY * 0.003));

                previousMouseX = e.clientX;
                previousMouseY = e.clientY;
            };

            var onMouseUp = function () {
                isDragging = false;
            };

            container.addEventListener('mousedown', onMouseDown);
            window.addEventListener('mousemove', onMouseMove, { passive: true });
            window.addEventListener('mouseup', onMouseUp, { passive: true });

            var onResize = function () {
                if (!container) return;
                var w = container.clientWidth || 500;
                var h = container.clientHeight || 450;
                camera.aspect = w / h;
                camera.updateProjectionMatrix();
                renderer.setSize(w, h);
            };

            window.addEventListener('resize', onResize, { passive: true });

            var animId;
            var animate = function () {
                animId = requestAnimationFrame(animate);

                // Auto-rotate slowly when not dragging
                if (!isDragging) {
                    globeGroup.rotation.y += 0.0018;
                }

                renderer.render(scene, camera);
            };

            animate();

            this.scenes[containerId] = {
                renderer: renderer,
                scene: scene,
                camera: camera,
                geometries: [globeGeo, innerGeo, hubMarkerGeo].concat(curveGeos),
                materials: [globeWireMat, innerMat, originMat, destMat, curveMat],
                lights: [],
                animId: animId,
                listeners: [
                    { target: container, event: 'mousedown', handler: onMouseDown },
                    { target: window, event: 'mousemove', handler: onMouseMove },
                    { target: window, event: 'mouseup', handler: onMouseUp },
                    { target: window, event: 'resize', handler: onResize }
                ]
            };
        },

        /* =========================================================================
           DISPOSAL: Completely Clean Up WebGL & DOM Resources
           ========================================================================= */
        destroyScene: function (containerId) {
            var inst = this.scenes[containerId];
            if (!inst) return;

            // Stop requestAnimationFrame
            if (inst.animId) {
                cancelAnimationFrame(inst.animId);
            }

            // Remove event listeners
            if (inst.listeners && inst.listeners.length) {
                inst.listeners.forEach(function (l) {
                    l.target.removeEventListener(l.event, l.handler);
                });
            }

            // Dispose Geometries
            if (inst.geometries) {
                inst.geometries.forEach(function (g) {
                    if (g && g.dispose) g.dispose();
                });
            }

            // Dispose Materials
            if (inst.materials) {
                inst.materials.forEach(function (m) {
                    if (m && m.dispose) m.dispose();
                });
            }

            // Remove and dispose WebGL Renderer
            if (inst.renderer) {
                if (inst.renderer.domElement && inst.renderer.domElement.parentNode) {
                    inst.renderer.domElement.parentNode.removeChild(inst.renderer.domElement);
                }
                if (inst.renderer.dispose) {
                    inst.renderer.dispose();
                }
            }

            delete this.scenes[containerId];
        }
    };
})();
