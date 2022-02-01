// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

tinymce.init({
    selector: '#Body',
    height: 400
});

function onDeleteNote(e) {
    if (confirm("Are you sure you want to delete this note?"))
        return true;

    return false;
}

function doSearch() {

    let filters = [];
    let sort = document.getElementById("sort").value;
    let search = document.getElementById("search").value;

    if (sort) {
        filters.push(`sort=${sort}`);
    }

    if (search) {
        filters.push(`search=${search}`);
    }

    window.location = window.location.origin + `?${filters.join('&')}`;
}

$("#sort").change(e => {
    doSearch();
});

$("#searchbar").submit(e => {
    doSearch();
});

$("button.searchbar__button").click(e => {
    const input = document.getElementById("searchbar");

    if (input.classList.contains("show")) {
        input.classList.remove("show");
    } else {
        input.classList.add("show");
        input.focus();
    }
});