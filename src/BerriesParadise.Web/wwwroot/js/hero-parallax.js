/**
 * Berries Paradise - Hero Interactive Parallax & Navbar Scroll Controller
 * Smooth lerp parallax depth system matching 2026 international brand standard.
 */
(function () {
    window.berriesHero = {
        activeInstances: {},

        initParallax: function (heroId) {
            var hero = document.getElementById(heroId);
            if (!hero) return;

            // Teardown any existing instance on re-render
            if (this.activeInstances[heroId]) {
                this.destroyParallax(heroId);
            }

            if (window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches) {
                return;
            }

            var layers = hero.querySelectorAll('[data-depth]');
            if (!layers.length) return;

            var mouseX = 0, mouseY = 0;
            var currentX = 0, currentY = 0;
            var isHovering = false;

            var onMouseMove = function (e) {
                var rect = hero.getBoundingClientRect();
                var relX = (e.clientX - rect.left) / rect.width - 0.5;
                var relY = (e.clientY - rect.top) / rect.height - 0.5;
                // Clamped normalized coords -1 to 1
                mouseX = Math.max(-1, Math.min(1, relX * 2));
                mouseY = Math.max(-1, Math.min(1, relY * 2));
                isHovering = true;
            };

            var onMouseLeave = function () {
                isHovering = false;
                mouseX = 0;
                mouseY = 0;
            };

            hero.addEventListener('mousemove', onMouseMove, { passive: true });
            hero.addEventListener('mouseleave', onMouseLeave, { passive: true });

            var rafId;
            var update = function () {
                rafId = requestAnimationFrame(update);

                // Smooth organic lerp interpolation
                currentX += (mouseX - currentX) * 0.055;
                currentY += (mouseY - currentY) * 0.055;

                for (var i = 0; i < layers.length; i++) {
                    var el = layers[i];
                    var depth = parseFloat(el.getAttribute('data-depth')) || 0.3;
                    
                    // Specific movement amplitude:
                    // Foreground: depth ~ 0.5-0.6 -> ~ 15-20px
                    // Midground: depth ~ 0.25-0.3 -> ~ 7-10px
                    // Background: depth ~ 0.1 -> ~ 3-5px
                    var moveX = currentX * depth * 32;
                    var moveY = currentY * depth * 22;
                    var rot = currentX * depth * 2.5;

                    el.style.transform = 'translate3d(' + moveX.toFixed(2) + 'px, ' + moveY.toFixed(2) + 'px, 0px) rotate(' + rot.toFixed(2) + 'deg)';
                }
            };

            update();

            this.activeInstances[heroId] = {
                hero: hero,
                rafId: rafId,
                onMouseMove: onMouseMove,
                onMouseLeave: onMouseLeave
            };
        },

        destroyParallax: function (heroId) {
            var inst = this.activeInstances[heroId];
            if (!inst) return;
            if (inst.rafId) cancelAnimationFrame(inst.rafId);
            if (inst.hero) {
                inst.hero.removeEventListener('mousemove', inst.onMouseMove);
                inst.hero.removeEventListener('mouseleave', inst.onMouseLeave);
            }
            delete this.activeInstances[heroId];
        },

        initNavbarScroll: function (navSelector) {
            var nav = document.querySelector(navSelector);
            if (!nav) return;

            var onScroll = function () {
                if (window.scrollY > 40) {
                    nav.classList.add('scrolled');
                } else {
                    nav.classList.remove('scrolled');
                }
            };

            window.addEventListener('scroll', onScroll, { passive: true });
            onScroll(); // initial state check
        }
    };

    // Auto-init navbar scroll listener on document ready
    document.addEventListener('DOMContentLoaded', function () {
        window.berriesHero.initNavbarScroll('.bp-navbar-wrapper');
    });
})();

/**
 * Berries Navigation - Mobile Drawer Controller
 * Handles body scroll locking for the mobile drawer panel.
 */
(function () {
    window.berriesNav = {
        setBodyScrollLock: function (locked) {
            if (locked) {
                document.documentElement.classList.add('bp-menu-locked');
                document.body.classList.add('bp-menu-locked');
            } else {
                document.documentElement.classList.remove('bp-menu-locked');
                document.body.classList.remove('bp-menu-locked');
            }
        }
    };
})();
