let bg_dark = '#222222';
let bg_bright = '#DDDDDD';
let fg_bright = '#111111';
let fg_dark = '#DDDDDD';
let alt_bg_dark = '#2e2635';
let alt_bg_bright = '#cec7d9';
let alt_fg_bright = '#2e2635';
let alt_fg_dark = '#d8c5f3';
let a_bright = '#000';
let a_dark = '#d4cddc';
let btn_dark = '#000';
let btn_bright = '#fff';
let brighter_bg_dark = '#252525';
let brighter_bg_bright = '#BBB';

let dot_right = "0px";
let dot_middle_right = "-4px";
let dot_middle = "-11px";
let dot_middle_left = "-18px";
let dot_left = "-22px";



if (getCookie("theme") == "") {
    document.cookie = "theme=dark";
}

if (getCookie("theme") == "dark") {
    document.documentElement.style.setProperty('--brighter-bg', brighter_bg_dark);
    document.documentElement.style.setProperty('--btn-color', btn_dark);
    document.documentElement.style.setProperty('--a-color', a_dark);
    document.documentElement.style.setProperty('--alt-fg-color', alt_fg_dark);
    document.documentElement.style.setProperty('--alt-bg-color', alt_bg_dark);
    document.documentElement.style.setProperty('--fg-color', fg_dark);
    document.documentElement.style.setProperty('--bg-color', bg_dark);
}
else {
    document.documentElement.style.setProperty('--brighter-bg', brighter_bg_bright);
    document.documentElement.style.setProperty('--btn-color', btn_bright);
    document.documentElement.style.setProperty('--a-color', a_bright);
    document.documentElement.style.setProperty('--alt-fg-color', alt_fg_bright);
    document.documentElement.style.setProperty('--alt-bg-color', alt_bg_bright);
    document.documentElement.style.setProperty('--fg-color', fg_bright);
    document.documentElement.style.setProperty('--bg-color', bg_bright);
}


function SwitchTheme() {
    current = getCookie("theme");
    if (current == "dark") {
        document.documentElement.style.setProperty('--btn-color', btn_bright);
        document.documentElement.style.setProperty('--brighter-bg', brighter_bg_bright);
        document.cookie = "theme=bright";
        document.documentElement.style.setProperty('--a-color', a_bright);
        document.documentElement.style.setProperty('--alt-fg-color', alt_fg_bright);
        document.documentElement.style.setProperty('--alt-bg-color', alt_bg_bright);
        document.documentElement.style.setProperty('--fg-color', fg_bright);
        document.documentElement.style.setProperty('--bg-color', bg_bright);
        dot.style.marginLeft = dot_right;
    }
    else {
        document.documentElement.style.setProperty('--brighter-bg', brighter_bg_dark);
        document.cookie = "theme=dark";
        document.documentElement.style.setProperty('--btn-color', btn_dark);
        document.documentElement.style.setProperty('--a-color', a_dark);
        document.documentElement.style.setProperty('--alt-fg-color', alt_fg_dark);
        document.documentElement.style.setProperty('--alt-bg-color', alt_bg_dark);
        document.documentElement.style.setProperty('--fg-color', fg_dark);
        document.documentElement.style.setProperty('--bg-color', bg_dark);
       
        dot.style.marginLeft = dot_left;
    }

    
}

function MoveTogglerDot() {
    current = getCookie("theme");
    dot = document.getElementById("dot");
    if (current == "dark") {
        
        dot.style.marginLeft = dot_left;
    }
    else {
        
        dot.style.marginLeft = dot_right;
    }
}

function NudgeToggler() {
    current = getCookie("theme");
    dot = document.getElementById("dot");
    if (current == "dark") {

        dot.style.marginLeft = dot_middle_left;
    }
    else {

        dot.style.marginLeft = dot_middle_right;
    }
}
function SettleToggler() {
    current = getCookie("theme");
    dot = document.getElementById("dot");
    if (current == "dark") {

        dot.style.marginLeft = dot_left;
    }
    else {

        dot.style.marginLeft = dot_right;
    }
}

document.addEventListener("DOMContentLoaded", function () {

    MoveTogglerDot();
});

