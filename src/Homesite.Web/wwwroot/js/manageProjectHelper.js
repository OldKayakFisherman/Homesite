function toggleAllProjects() {
    var chks = document.querySelectorAll("input[data-delete-id]");
    if (chks != null && chks.length > 0) {
        chks.forEach(function (elem) {
            console.log(elem.checked);
            elem.checked = !elem.checked;
        });
    }
}
//# sourceMappingURL=manageProjectHelper.js.map