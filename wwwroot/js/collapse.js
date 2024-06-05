collapsed_size = "1.7em"
last_state="wide"

document.addEventListener("DOMContentLoaded", function () {
    btn = document.getElementById("show_side_btn");
    btn.style.visibility = "hidden";
    var width = window.innerWidth;
    if (width < 768) {
        CollapseSideSection();
        last_state = "narrow"
    }
    UpdateChevrons();
})



window.addEventListener("resize", function () {
    var width = window.innerWidth;
    if (width < 768 && last_state == "wide") {
        last_state = "narrow";
        CollapseSideSection();
    }
    if (width > 768 && last_state == "narrow") {
        last_state = "wide";
        ExpandSideSection();
    }
    UpdateChevrons();
})
    
function UpdateChevrons() {
   /* $('[id^="down_chevron"]').each(function () {
        
        var id = $(this).attr('id').replace("down_chevron", "");
        desc = document.getElementById("description" + id);
        down = document.getElementById("down_chevron" + id);
        up = document.getElementById("up_chevron" + id);
        
        expanded = desc.scrollHeight;
        current = desc.clientHeight;
        if (current < expanded) {
            down.style.display = "content";
        }
        else {
            down.style.display = "none";
        }
        if (current > collapsed_size) {
            up.style.display = "content";
        }
        else {
            up.style.display = "none";
        }
        
        

    });*/

}
function CollapseCardDesc(id) {
        desc = document.getElementById("description" + id);
        expanded = desc.clientHeight;
        /*desc.style.maxHeight = expanded + "px";*/

        desc.style.maxHeight = collapsed_size;
    UpdateChevrons();

    }
function ExpandCardDesc(id) {
        desc = document.getElementById("description" + id);
        expanded = desc.scrollHeight;
        desc.style.maxHeight = expanded + "px";
        /*desc.addEventListener("transitionend", () => {
            document.getElementById("description" + id).style.maxHeight = "none";
        });
        desc.removeEventListener("transitionend");*/
    UpdateChevrons();
    }

function CollapseSideSection() {
        document.documentElement.style.setProperty('--side-width', 0);
        side = document.getElementById("side_content");

        side.style.marginLeft = "20px";
        btn = document.getElementById("show_side_btn");
        btn.style.visibility = "visible";
        side.style.visibility = "visible";
    }

function ExpandSideSection() {
        document.documentElement.style.setProperty('--side-width', "300px");
        side = document.getElementById("side_content");
        btn = document.getElementById("show_side_btn");
        btn.style.visibility = "hidden";
        if (last_state == "wide") {
            side.style.marginLeft = "320px";
            side.style.visibility = "visible";
        }
        else {
            side.style.visibility = "hidden";
        }
    }