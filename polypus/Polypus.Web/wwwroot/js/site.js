// ============================================================================
// Polypus - site.js
// ----------------------------------------------------------------------------
// Progressive enhancement only. Every page renders, is readable and is fully
// navigable with JavaScript switched off; this file adds two cosmetic touches:
//
//   1. A border + shadow under the sticky header once the page is scrolled.
//   2. A fade-and-rise reveal for elements marked with [data-reveal].
//
// WHY THIS FILE LOOKS DEFENSIVE
// Blazor's interactive circuit (Home, Plans, Contact and Help are
// @rendermode InteractiveServer) re-renders its components after the initial
// server HTML arrives and REPLACES those DOM nodes. Anything attached to the
// original nodes - event listeners, IntersectionObserver registrations - then
// points at detached elements and silently does nothing.
//
// So the rule here is: never hold on to an element. Look the current node up at
// the moment it is needed, and re-scan whenever the DOM changes.
//
// The reveal effect is deliberately cosmetic and fail-safe: app.css never hides
// a [data-reveal] element, it only *animates* one when this file adds
// .is-visible. If the script never runs - disabled, blocked, network failure, or
// Blazor replacing these nodes during hydration - the sections are simply
// visible with no animation. A broken animation must never hide content.
// ============================================================================

(function () {
    'use strict';

    var REVEAL_SELECTOR = '[data-reveal]';
    var HEADER_SELECTOR = '.site-header';

    // ------------------------------------------------------------------------
    // Sticky header shadow
    // ------------------------------------------------------------------------

    var scrollTicking = false;

    /** Paints the current scroll state onto whichever header element exists now. */
    function paintHeader() {
        var header = document.querySelector(HEADER_SELECTOR);
        if (header) {
            header.classList.toggle('is-stuck', window.scrollY > 8);
        }
        scrollTicking = false;
    }

    function onScroll() {
        if (!scrollTicking) {
            scrollTicking = true;
            window.requestAnimationFrame(paintHeader);
        }
    }

    // One delegated listener for the lifetime of the document, so replacing the
    // header during a Blazor re-render cannot leave a stale listener behind.
    window.addEventListener('scroll', onScroll, { passive: true });

    // ------------------------------------------------------------------------
    // Reveal on scroll
    // ------------------------------------------------------------------------

    var prefersReducedMotion = window.matchMedia
        && window.matchMedia('(prefers-reduced-motion: reduce)').matches;

    var canObserve = !prefersReducedMotion && typeof IntersectionObserver !== 'undefined';
    var observer = null;

    /** Reveals everything at once. Used for reduced-motion and old browsers. */
    function revealEverything() {
        var pending = document.querySelectorAll(REVEAL_SELECTOR + ':not(.is-visible)');
        for (var i = 0; i < pending.length; i += 1) {
            pending[i].classList.add('is-visible');
        }
    }

    /**
     * Registers any [data-reveal] element that is not already revealed.
     * Called on startup, after every Blazor enhanced navigation, and after any
     * DOM mutation, so freshly rendered nodes are always picked up.
     *
     * The observer is rebuilt each time rather than reused: Blazor discards
     * nodes, and an observer keeps a strong reference to everything it watches.
     */
    function sweepReveal() {
        if (!canObserve) {
            revealEverything();
            return;
        }

        var pending = document.querySelectorAll(REVEAL_SELECTOR + ':not(.is-visible)');

        if (observer) {
            observer.disconnect();
        }

        if (!pending.length) {
            return;
        }

        observer = new IntersectionObserver(function (entries) {
            for (var i = 0; i < entries.length; i += 1) {
                if (entries[i].isIntersecting) {
                    entries[i].target.classList.add('is-visible');
                    observer.unobserve(entries[i].target);
                }
            }
        }, { rootMargin: '0px 0px -8% 0px', threshold: 0.06 });

        for (var j = 0; j < pending.length; j += 1) {
            observer.observe(pending[j]);
        }
    }

    /**
     * Watches for nodes Blazor adds or swaps in and re-runs the sweep.
     * Coalesced through requestAnimationFrame so a burst of mutations from one
     * render costs a single re-scan.
     */
    var mutationQueued = false;

    function queueSweep() {
        if (mutationQueued) {
            return;
        }
        mutationQueued = true;
        window.requestAnimationFrame(function () {
            mutationQueued = false;
            sweepReveal();
        });
    }

    function init() {
        paintHeader();
        sweepReveal();
    }

    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', init);
    } else {
        init();
    }

    // Blazor enhanced navigation swapped the page content - rebuild everything.
    if (window.Blazor && typeof window.Blazor.addEventListener === 'function') {
        window.Blazor.addEventListener('enhancedload', init);
    }

    // Any later DOM change, including the interactive circuit taking over from
    // the server-rendered HTML, brings new [data-reveal] nodes into the page.
    if (typeof MutationObserver !== 'undefined' && document.body) {
        new MutationObserver(queueSweep).observe(document.body, {
            childList: true,
            subtree: true
        });
    }
})();
