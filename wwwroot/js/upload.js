const fileInput = document.getElementById("fileInput");
const uploadForm = document.getElementById("uploadForm");
document.getElementById("uploadButton").addEventListener("click", function () {
    fileInput.click();
});
fileInput.addEventListener("change", function () {
    uploadForm.submit();
});

function SaveToDB() {
    var nameDiv = document.getElementById("nameDiv").innerText;
    var nameInput = document.getElementById("divNameInput");
    nameInput.value = nameDiv;

    var descriptionDiv = document.getElementById("descriptionDiv").innerText;
    var descriptionInput = document.getElementById("divDescriptionInput");
    descriptionInput.value = descriptionDiv;

    var datasheetDiv = document.getElementById("divDatasheet").innerText;
    var datasheetInput = document.getElementById("divDatasheetInput");
    datasheetInput.value = datasheetDiv;

    var idDiv = document.getElementById("divId").innerText;
    var idInput = document.getElementById("divIdInput");
    idInput.value = idDiv;
    

    var form = document.getElementById("SaveForm");
    form.submit();
}
function SaveToDB_Create() {
    var nameDiv = document.getElementById("nameDiv").innerText;
    var nameInput = document.getElementById("divNameInput");
    nameInput.value = nameDiv;

    var descriptionDiv = document.getElementById("descriptionDiv").innerText;
    var descriptionInput = document.getElementById("divDescriptionInput");
    descriptionInput.value = descriptionDiv;

    var datasheetDiv = document.getElementById("divDatasheet").innerText;
    var datasheetInput = document.getElementById("divDatasheetInput");
    datasheetInput.value = datasheetDiv;

    var form = document.getElementById("SaveForm");
    form.submit();
}