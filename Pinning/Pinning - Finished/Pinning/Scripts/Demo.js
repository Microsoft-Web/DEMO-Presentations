$(function () {
    try {
        if (window.external.msIsSiteMode()) {
            window.external.msSiteModeClearJumpList();

            window.external.msSiteModeCreateJumpList("My Custom List");

            window.external.msSiteModeAddJumpListItem("Task 1", "/", "/images/ico/heart.ico", "self");
            window.external.msSiteModeAddJumpListItem("Task 2", "/", "/images/ico/ring.ico", "self");
        }
    } catch (e) { }
});