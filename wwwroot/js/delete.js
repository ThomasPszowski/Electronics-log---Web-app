
var modal = document.getElementById("myModal");
var span = document.getElementsByClassName("close")[0];

/*function AttemptDelete() {

    if (confirm('Are you sure you want to delete this item?')) {
        var deleteform = document.getElementById("deleteForm");
        deleteform.submit();
        window.location.href = '/Index';
        
    }
    else {
           
    }
    *//*modal.style.display = "block";*//*
}*/

function AttemptDelete(Id) {
    if (confirm('Are you sure you want to delete this item?')) {
        var deleteform = document.getElementById("deleteForm" + Id);
        deleteform.submit();
    }
}
/*function AttemptDelete_View() {
    if (confirm('Are you sure you want to delete this item?')) {
        var deleteform = document.getElementById("deleteForm");
        deleteform.submit();
    }
}*/

span.onclick = function () {
    modal.style.display = "none";
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}



