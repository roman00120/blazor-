/**
 * Berries Paradise - Isolated Three.js Hero Ambient Effect
 * Graceful degradation if WebGL is unavailable or user prefers reduced motion.
 */
(function () {
    window.berriesHeroThree = {
        instances: {},

        isWebGLAvailable: function () {
            try {
                var canvas = document.createElement('canvas');
                return !!(window.WebGLRenderingContext && (canvas.getContext('webgl') || canvas.getContext('experimental-webgl')));
            } catch (e) {
                return false;
            }
        },

        init: function (containerId) {
            var container = document.getElementById(containerId);
            if (!container) return;

            // Check if reduced motion is requested
            if (window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches) {
                return;
            }

            // Graceful degradation: Check Three.js and WebGL
            if (!window.THREE || !this.isWebGLAvailable()) {
                console.info('BerriesParadise: Three.js or WebGL not available, falling back gracefully to static/CSS presentation.');
                return;
            }

            // Prevent duplicate initialization
            if (this.instances[containerId]) {
                this.destroy(containerId);
            }

            var width = container.clientWidth || window.innerWidth;
            var height = container.clientHeight || window.innerHeight;

            var scene = new THREE.Scene();
            var camera = new THREE.PerspectiveCamera(55, width / height, 0.1, 1000);
            camera.position.z = 24;

            var renderer;
            try {
                renderer = new THREE.WebGLRenderer({ alpha: true, antialias: true, powerPreference: 'high-performance' });
                renderer.setSize(width, height);
                renderer.setPixelRatio(Math.min(window.devicePixelRatio || 1, 2));
                container.appendChild(renderer.domElement);
            } catch (err) {
                console.warn('BerriesParadise: WebGL initialization failed:', err);
                return;
            }

            // Create crystalline water droplets
            var dropletCount = 28;
            var geometry = new THREE.SphereGeometry(0.32, 16, 16);
            var material = new THREE.MeshPhysicalMaterial({
                color: 0x8fe3ff,
                transparent: true,
                opacity: 0.8,
                roughness: 0.12,
                transmission: 0.85,
                reflectivity: 0.9,
                clearcoat: 1.0,
                clearcoatRoughness: 0.1
            });

            var droplets = [];
            for (var i = 0; i < dropletCount; i++) {
                var mesh = new THREE.Mesh(geometry, material);
                // Distribute around center and right berry zone
                mesh.position.x = (Math.random() - 0.25) * 36;
                mesh.position.y = (Math.random() - 0.5) * 22;
                mesh.position.z = (Math.random() - 0.5) * 16;

                var scale = 0.35 + Math.random() * 0.75;
                mesh.scale.set(scale, scale * 1.15, scale);

                mesh.userData = {
                    speedY: 0.004 + Math.random() * 0.009,
                    speedX: (Math.random() - 0.5) * 0.003,
                    wobbleSpeed: 0.02 + Math.random() * 0.03,
                    wobbleOffset: Math.random() * Math.PI * 2,
                    initialY: mesh.position.y
                };
                scene.add(mesh);
                droplets.push(mesh);
            }

            // Soft lighting for droplets
            var ambientLight = new THREE.AmbientLight(0xffffff, 0.75);
            scene.add(ambientLight);

            var cyanLight = new THREE.PointLight(0x08b8e8, 1.6, 60);
            cyanLight.position.set(10, 8, 12);
            scene.add(cyanLight);

            var creamLight = new THREE.PointLight(0xf4ef9a, 0.8, 50);
            creamLight.position.set(-12, -8, 8);
            scene.add(creamLight);

            var mouseX = 0, mouseY = 0;
            var targetX = 0, targetY = 0;

            var onMouseMove = function (e) {
                mouseX = (e.clientX / window.innerWidth) * 2 - 1;
                mouseY = -(e.clientY / window.innerHeight) * 2 + 1;
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

            var animId = null;
            var clock = new THREE.Clock();

            var animate = function () {
                animId = requestAnimationFrame(animate);

                targetX += (mouseX * 1.2 - targetX) * 0.04;
                targetY += (mouseY * 0.8 - targetY) * 0.04;

                camera.position.x = targetX;
                camera.position.y = targetY;
                camera.lookAt(0, 0, 0);

                var elapsedTime = clock.getElapsedTime();

                for (var j = 0; j < droplets.length; j++) {
                    var d = droplets[j];
                    d.position.y += d.userData.speedY;
                    d.position.x += Math.sin(elapsedTime * d.userData.wobbleSpeed + d.userData.wobbleOffset) * 0.005;
                    d.rotation.y += 0.008;

                    if (d.position.y > 12) {
                        d.position.y = -12;
                    }
                }

                renderer.render(scene, camera);
            };

            animate();

            // Store instance for clean disposal
            this.instances[containerId] = {
                renderer: renderer,
                scene: scene,
                camera: camera,
                geometry: geometry,
                material: material,
                animId: animId,
                onMouseMove: onMouseMove,
                onResize: onResize
            };
        },

        destroy: function (containerId) {
            var inst = this.instances[containerId];
            if (!inst) return;

            if (inst.animId) cancelAnimationFrame(inst.animId);
            window.removeEventListener('mousemove', inst.onMouseMove);
            window.removeEventListener('resize', inst.onResize);

            if (inst.geometry) inst.geometry.dispose();
            if (inst.material) inst.material.dispose();
            if (inst.renderer) {
                if (inst.renderer.domElement && inst.renderer.domElement.parentNode) {
                    inst.renderer.domElement.parentNode.removeChild(inst.renderer.domElement);
                }
                inst.renderer.dispose();
            }

            delete this.instances[containerId];
        }
    };
})();
