$(function () {
    $.pinify.createThumbbarButtons({
        buttons: [{
            icon: "/images/ico/twitter.ico",
            name: "Share on Twitter!",
            click: function () {
                alert("I see you want to share on Twitter.");
            }
        }, {
            icon: "/images/ico/facebook.ico",
            name: "Share on Facebook!",
            click: function () {
                alert("I see you want to share on Facebook.");
            }
        }]
    });
});