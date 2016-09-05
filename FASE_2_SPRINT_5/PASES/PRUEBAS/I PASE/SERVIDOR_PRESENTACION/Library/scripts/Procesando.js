function onUpdating() {
    // make it visible
    updateProgressDiv.style.display = '';

    var gridViewBounds = Sys.UI.DomElement.getBounds('GridViewData');
    var updateProgressDivBounds = Sys.UI.DomElement.getBounds('updateProgressDiv');

    //  center of gridview
    var x = gridViewBounds.x + Math.round(gridViewBounds.width / 2) - Math.round(updateProgressDivBounds.width / 2);
    var y = gridViewBounds.y + Math.round(gridViewBounds.height / 2) - Math.round(updateProgressDivBounds.height / 2);

    //	set the progress element to this position
    Sys.UI.DomElement.setLocation(updateProgressDiv, x, y);
}

function onUpdated() {
    // get the update progress div
    var updateProgressDiv = $get('updateProgressDiv');
    // make it invisible
    updateProgressDiv.style.display = 'none';
}

function showPos(event, text) {
    var el, x, y;

    el = document.getElementById('PopUp');

    if (el.style.display == 'none') {
        var obj;
        obj = document.getElementById('PopUpPosition');

        var curleft = curtop = 0;
        if (obj && obj.offsetParent) {
            do {
                curleft += obj.offsetLeft;
                curtop += obj.offsetTop;
            } while (obj = obj.offsetParent);
        }

        curtop = curtop + 11;
        el.style.left = curleft + "px";
        el.style.top = curtop + "px";

        el.style.display = "block";
    }
    else {
        el.style.display = 'none';
    }
}

function llamaralancla() {
    document.location.href = "#ancla";
}