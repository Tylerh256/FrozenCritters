﻿$('.navPhone').on('click', function (e) {
    // Prevent link from jumping to the top of the page
    e.preventDefault();
    // If menu is already showing, slide it up. Otherwise, slide it down.
    $('.ulnavbar').toggle();
});

$(window).resize(function () {

    if ($(".ulnavbar").is(":hidden") && $(window).innerWidth() > 999) {
        $(".ulnavbar").removeAttr("style");
        $('.ulnavbar').show();
    }
    else if ($(window).width() <= 983) {
        $(".ulnavbar").hide();
    }
});

