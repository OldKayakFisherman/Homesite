﻿
function toggleAllProjects() {
    let chks: NodeListOf<HTMLInputElement> = document.querySelectorAll("input[data-delete-id]");

    if (chks != null && chks.length > 0) {
        chks.forEach(elem => {
            console.log(elem.checked);
            elem.checked = !elem.checked;
        });
    }

}