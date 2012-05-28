$(function () {
    var pins = new Array();

    $('ul#menu a').each(function (i, item) {
        pins.push({
            name: $(item).text(),
            url: $(item).attr('href'),
            icon: '/images/ico/attn.ico'
        });
    });

    $.pinify.clearJumpList();
    $.pinify.addJumpList({
        title: 'Site Navigation',
        items: pins
    });
});