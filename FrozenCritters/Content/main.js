$('.navPhone').on('click', function (e) {
    // Prevent link from jumping to the top of the page
    e.preventDefault();
    // If menu is already showing, slide it up. Otherwise, slide it down.
    $('.ulnavbar').slideToggle();
});

$(window).resize(function () {

    if ($(".ulnavbar").is(":hidden") && $(window).innerWidth() > 983) {
        $(".ulnavbar").removeAttr("style");
        $('.ulnavbar').show();
    }
    else if($(window).innerWidth() > 1000){
        $(".ulnavbar").css("display", "initial");
    }
    else if ($(window).width() <= 983) {
        $(".ulnavbar").hide();
    }
});

