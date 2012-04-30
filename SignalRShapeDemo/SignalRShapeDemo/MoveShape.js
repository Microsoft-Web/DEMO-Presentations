/// <reference path="Scripts/jquery-1.6.4.js" />
/// <reference path="Scripts/jquery.signalR.js" />
/// <reference path="Scripts/jquery-ui-1.8.18.js" />

$(function () {
    // Get a refeerence to the server-side moveShape() class.
    var hub = $.connection.moveShape,
    // Get a reference to the shape div in the html
    $shape = $("#shape");
    // Use extend to move the shape object (if we are not the sender)
    $.extend(hub, {

        // Use css to move the shape object

        shapeMoved: function (cid, x, y) {
            if ($.connection.hub.id !== cid) {
                $shape.css({ left: x, top: y });
                $("p:last").text("left: " + x + ", top: " + y);
            }
        }
    });
    // Wire up the draggable behavior (when hub is done starting)
    // "done" is a jquery deferred method
    $.connection.hub.start().done(function () {
        $shape.draggable({
            // Implement draggable effect for jquery
            drag: function () {
                // Tell the server that the shape was just dragged
                hub.moveShape(this.offsetLeft, this.offsetTop);
            }
        });
    })
});
