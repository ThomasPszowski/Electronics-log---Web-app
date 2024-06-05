
function saveContentToLocalStorage() {
    var nameContent = document.getElementById('nameDiv').innerText;
    var descriptionContent = document.getElementById('descriptionDiv').innerText;
    var idContent = document.getElementById('divId').innerText;
    localStorage.setItem('nameContent', nameContent);
    localStorage.setItem('descriptionContent', descriptionContent);
    localStorage.setItem('divId', idContent);
}
function saveContentToLocalStorage_Create() {
    var nameContent = document.getElementById('nameDiv').innerText;
    var descriptionContent = document.getElementById('descriptionDiv').innerText;
    
    localStorage.setItem('nameContent', nameContent);
    localStorage.setItem('descriptionContent', descriptionContent);
    
}



function loadContentFromLocalStorage() {
    var nameContent = localStorage.getItem('nameContent');
    var descriptionContent = localStorage.getItem('descriptionContent');
    var idContent = localStorage.getItem('divId');

    if (nameContent) {
        document.getElementById('nameDiv').innerText = nameContent;
    }
    if (descriptionContent) {
        document.getElementById('descriptionDiv').innerText = descriptionContent;
    }
    if (idContent) {
        document.getElementById('divId').innerText = idContent;
    }
}
function loadContentFromLocalStorage_Create() {
    var nameContent = localStorage.getItem('nameContent');
    var descriptionContent = localStorage.getItem('descriptionContent');

    if (nameContent) {
        document.getElementById('nameDiv').innerText = nameContent;
    }
    if (descriptionContent) {
        document.getElementById('descriptionDiv').innerText = descriptionContent;
    }
}

function clearContentFromLocalStorage() {
    localStorage.removeItem('nameContent');
    localStorage.removeItem('descriptionContent');
    localStorage.removeItem('divId')
}


window.onload = function () {

    if (window.location.pathname.endsWith("/Create")) {
        loadContentFromLocalStorage_Create();
    }
    else if (window.location.pathname.endsWith("/Update")) {
        loadContentFromLocalStorage();
    }
    else {
        clearContentFromLocalStorage();
    }
};


window.onbeforeunload = function () {
    if (window.location.pathname.endsWith("/Create")) {
        saveContentToLocalStorage_Create();
    }
    saveContentToLocalStorage();
};