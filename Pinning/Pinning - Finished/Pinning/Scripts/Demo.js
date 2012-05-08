$(function () {
    //try {
    //    if (window.external.msIsSiteMode()) {
    //        window.external.msSiteModeClearJumpList();

    //        window.external.msSiteModeCreateJumpList("My Custom List");

    //        window.external.msSiteModeAddJumpListItem("Task 1", "/", "/images/ico/heart.ico", "self");
    //        window.external.msSiteModeAddJumpListItem("Task 2", "/", "/images/ico/ring.ico", "self");
    //    }
    //} catch (e) { }


    $.pinify.addJumpList({
        title: "WebCamps Taks",
        items: [{
            name: "Task 3",
            url: "/",
            icon: "/images/ico/attn.ico"
        }, {
            name: "Task 4",
            url: "/",
            icon: "/images/ico/right.ico"
        }]
    });


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