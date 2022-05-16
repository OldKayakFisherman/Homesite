
function toggleAllProjects() {
    let chks: NodeListOf<HTMLInputElement> = document.querySelectorAll("input[data-delete-id]");

    if (chks != null && chks.length > 0) {
        chks.forEach(elem => {
            elem.checked = !elem.checked;
        });
    }

}


async function deleteProjects() {
    let chks: NodeListOf<HTMLInputElement> = document.querySelectorAll("input[data-delete-id]");

    let ids = [];

    if (chks != null && chks.length > 0) {
        chks.forEach(elem => {
            if (elem.checked) {
                ids.push(elem.attributes.getNamedItem("data-delete-id").value);
            }
        });
    }

    if (ids.length > 0) {
        try {
            const response = await fetch('/Manage/DeleteProjects', {
                method: 'POST',
                body: JSON.stringify(ids),
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json',
                },
            });

            if (!response.ok) {
                throw new Error(`Error! status: ${response.status}`);
            } else {
                if (chks != null && chks.length > 0) {
                    chks.forEach(elem => {
                        let tr: HTMLTableRowElement = <HTMLTableRowElement>elem.parentNode.parentNode; 

                        tr.parentNode.removeChild(tr);
                    });
                }
            }

        }
        catch (error) {
            if (error instanceof Error) {
                console.log('error message: ', error.message);
                return error.message;
            } else {
                console.log('unexpected error: ', error);
                return 'An unexpected error occurred';
            }
        }

    };


}