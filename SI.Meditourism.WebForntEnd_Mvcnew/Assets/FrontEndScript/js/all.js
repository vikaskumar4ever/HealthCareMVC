'use strict', // Start of use strict
 
/* ---------------------------------------------
animating
 --------------------------------------------- */
wow = new WOW({
    animateClass: 'animated',
    offset: 0,
    callback: function(box) {
        console.log("WOW: animating <" + box.tagName.toLowerCase() + ">")
    }
});


/* ---------------------------------------------
Portfolio mixItUp
 --------------------------------------------- */

$(function() {

    var filterList = {

        init: function() {

            // MixItUp plugin
            // http://mixitup.io
            $('#portfoliolist').mixItUp({
                selectors: {
                    target: '.portfolio',
                    filter: '.filter'
                },
                load: {
                    filter: '.app'
                }
            });

        }

    };

    // Run the show!
    filterList.init();


});

/* ---------------------------------------------
collapse
 --------------------------------------------- */

$('.closeall').on("click", function() {
    $('.panel-collapse.in')
        .collapse('hide');
});
$('.openall').on("click", function() {
    $('.panel-collapse:not(".in")')
        .collapse('show');
});




/* ---------------------------------------------
Preloader - Home page
 --------------------------------------------- */
    "use strict";
jQuery(window).on('load', function() {

    // will first fade out the loading animation
    jQuery("#status").fadeOut();
    // will fade out the whole DIV that covers the website.
    jQuery("#preloader").delay(500).fadeOut("slow");

})
