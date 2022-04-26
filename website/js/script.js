/* js file */

(function(window, undefined) {


    $.fn.YouTubePopUp = function(options) {

        var YouTubePopUpOptions = $.extend({
            autoplay: 1
        }, options);

        $(this).on('click', function(e) {

            var youtubeLink = $(this).attr("href");

            if (youtubeLink.match(/(youtube.com)/)) {
                var split_c = "v=";
                var split_n = 1;
            }

            if (youtubeLink.match(/(youtu.be)/) || youtubeLink.match(/(vimeo.com\/)+[0-9]/)) {
                var split_c = "/";
                var split_n = 3;
            }

            if (youtubeLink.match(/(vimeo.com\/)+[a-zA-Z]/)) {
                var split_c = "/";
                var split_n = 5;
            }

            var getYouTubeVideoID = youtubeLink.split(split_c)[split_n];

            var cleanVideoID = getYouTubeVideoID.replace(/(&)+(.*)/, "");

            if (youtubeLink.match(/(youtu.be)/) || youtubeLink.match(/(youtube.com)/)) {
                var videoEmbedLink = "https://www.youtube.com/embed/" + cleanVideoID + "?autoplay=" + YouTubePopUpOptions.autoplay + "";
            }

            if (youtubeLink.match(/(vimeo.com\/)+[0-9]/) || youtubeLink.match(/(vimeo.com\/)+[a-zA-Z]/)) {
                var videoEmbedLink = "https://player.vimeo.com/video/" + cleanVideoID + "?autoplay=" + YouTubePopUpOptions.autoplay + "";
            }

            $("body").append('<div class="YouTubePopUp-Wrap"><div class="YouTubePopUp-Content"><span class="YouTubePopUp-Close"></span><iframe src="' + videoEmbedLink + '" allowfullscreen></iframe></div></div>');


            $(".YouTubePopUp-Wrap, .YouTubePopUp-Close").click(function() {
                $(".YouTubePopUp-Wrap").addClass("YouTubePopUp-Hide").delay(515).queue(function() {
                    $(this).remove();
                });
            });

            e.preventDefault();

        });

        $(document).keyup(function(e) {

            if (e.keyCode == 27) {
                $('.YouTubePopUp-Wrap, .YouTubePopUp-Close').click();
            }

        });
    };

    $(".demo").YouTubePopUp(); //This runs the function and shows class of "Demo"

    $(function() {
        $('a[href*="#"]:not([href="#"])').click(function() {
            if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
                var target = $(this.hash);
                target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                if (target.length) {
                    $('html, body').animate({
                        scrollTop: target.offset().top
                    }, 1000);
                    return false;
                }
            }
        });
    });

})(window, undefined);