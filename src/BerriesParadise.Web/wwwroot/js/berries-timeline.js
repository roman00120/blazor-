/**
 * Berries Paradise - Field To World Scroll Observer
 * Uses lightweight IntersectionObserver / scroll listener to advance the timeline
 * without heavy scripts or page performance degradation.
 */
(function () {
    window.berriesTimeline = {
        observers: {},

        initScrollObserver: function (sectionId, dotNetRef) {
            var section = document.getElementById(sectionId);
            if (!section) return;

            // Check prefers-reduced-motion
            if (window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches) {
                return;
            }

            // On mobile, observe each vertical card
            var isMobile = window.innerWidth <= 860;

            if (isMobile && 'IntersectionObserver' in window) {
                var cards = section.querySelectorAll('.bp-mobile-story-card');
                if (!cards.length) return;

                var observer = new IntersectionObserver(function (entries) {
                    entries.forEach(function (entry) {
                        if (entry.isIntersecting && entry.intersectionRatio >= 0.5) {
                            var id = entry.target.id;
                            if (id && id.indexOf('mobile-step-') !== -1) {
                                var stepNum = parseInt(id.replace('mobile-step-', ''), 10);
                                if (!isNaN(stepNum) && dotNetRef) {
                                    dotNetRef.invokeMethodAsync('OnScrollStepChanged', stepNum);
                                }
                            }
                        }
                    });
                }, {
                    threshold: 0.5,
                    rootMargin: '-10% 0px -10% 0px'
                });

                cards.forEach(function (card) {
                    observer.observe(card);
                });

                this.observers[sectionId] = {
                    type: 'intersection',
                    observer: observer
                };
            }
        },

        destroyScrollObserver: function (sectionId) {
            var item = this.observers[sectionId];
            if (!item) return;

            if (item.observer) {
                item.observer.disconnect();
            }

            delete this.observers[sectionId];
        }
    };
})();
