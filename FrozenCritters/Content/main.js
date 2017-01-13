function msieversion() {

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))  // If Internet Explorer, return version number
    {
        alert(parseInt(ua.substring(msie + 5, ua.indexOf(".", msie))));
    }
    else  // If another browser, return 0
    {
        alert('otherbrowser');
    }

    return false;
}

msieversion();

$('.navPhone').on('click', function (e) {
    // Prevent link from jumping to the top of the page
    e.preventDefault();
    // If menu is already showing, slide it up. Otherwise, slide it down.
    $('.ulnavbar').slideToggle();
});

$(window).resize(function () {

    if ($('.ulnavbar').is(":hidden") && $(window).innerWidth() > 983) {
        $('.ulnavbar').removeAttr('style');
        $('.ulnavbar').show();
    }
    else if ($(window).width() <= 983) {
        $('.ulnavbar').hide();
    }
});

