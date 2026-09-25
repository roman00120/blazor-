/**
 * Berries Paradise - Brand Video Player Controller
 * Handles autoplay policies, graceful fallback to muted playback,
 * unmuting on user interaction, and error diagnostics.
 */
window.bpVideoController = {
    init: function (videoId) {
        const video = document.getElementById(videoId);
        if (!video) return;

        // Reset display states
        const unmuteHint = document.getElementById("bp-video-unmute-hint");
        const errorNotice = document.getElementById("bp-video-error-notice");
        if (unmuteHint) unmuteHint.style.display = "none";
        if (errorNotice) errorNotice.style.display = "none";

        // Listen for error
        video.onerror = function (e) {
            console.error("[BP Video] Playback error encountered:", video.error);
            if (errorNotice) {
                errorNotice.style.display = "flex";
            }
        };

        // Attempt playback with audio first
        const playPromise = video.play();
        if (playPromise !== undefined) {
            playPromise.then(() => {
                // Played successfully (with sound or browser allowed it)
                if (video.muted && unmuteHint) {
                    unmuteHint.style.display = "inline-flex";
                }
            }).catch(err => {
                console.warn("[BP Video] Unmuted autoplay blocked by browser policy, falling back to muted:", err.message);
                // Mute and retry immediately so user sees motion immediately
                video.muted = true;
                video.play().then(() => {
                    if (unmuteHint) {
                        unmuteHint.style.display = "inline-flex";
                    }
                }).catch(retryErr => {
                    console.error("[BP Video] Autoplay completely blocked:", retryErr);
                });
            });
        }
    },

    unmute: function (videoId) {
        const video = document.getElementById(videoId);
        if (video) {
            video.muted = false;
            video.volume = 1.0;
            const unmuteHint = document.getElementById("bp-video-unmute-hint");
            if (unmuteHint) unmuteHint.style.display = "none";
        }
    },

    pause: function (videoId) {
        const video = document.getElementById(videoId);
        if (video && !video.paused) {
            video.pause();
        }
    }
};
