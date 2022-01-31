// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
tinymce.init({
    selector: '#Body',
    height: 400
});

$(".card__button-delete").click(e => {
    e.preventDefault();

    if (confirm("Are you sure you want to delete this note?")) {
        window.location = e.target.href;
    }
});

$("#sort").change(e => {    
    window.location = window.location.origin + `?sort=${e.target.value}`;
});