$(document).ready(function () {
    var notificationsHub = $.connection.notificationsHub;
    
    $.connection.hub.start();

    notificationsHub.client.addNewInfoMessageToPage(function (message) {
        $("div.notifications").html
        .append(
        "<div> class='alert alert-info fade in'" +
            "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>" +
            "<strong>Info!</strong>" + message +
        "</div>");
    });
    
});
