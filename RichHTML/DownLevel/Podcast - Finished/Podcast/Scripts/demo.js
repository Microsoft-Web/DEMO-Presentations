/// <reference path="jquery-1.7.2.js" />
/// <reference path="modernizr-2.5.3.js" />

$(function () {
    if (!Modernizr.audio) {
        $("audio").hide();
    }
});

