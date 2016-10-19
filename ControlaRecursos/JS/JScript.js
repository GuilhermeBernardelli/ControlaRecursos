function removeViewState() {
    var viewstate = document.getElementById('__VIEWSTATE');
    viewstate.parentNode.removeChild(viewstate);
    document.forms["form1"].submit();
}

function removeViewState2() {
    var viewstate = document.getElementById('__VIEWSTATE');
    viewstate.parentNode.removeChild(viewstate);
}