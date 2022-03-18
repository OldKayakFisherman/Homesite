enum TargetPage {
    Home,
    About,
    Skills,
    Clients,
    Projects,
    Contact
}


class MenuResolver {
    resolve(page: TargetPage): void {
        this.inactivateNavigationElements();
        this.activateNavElement(page);
    }

    inactivateNavigationElements(): void {

        let navs: NodeListOf<HTMLAnchorElement> = document.querySelectorAll(".nav-link");

        if (navs != null && navs.length > 0) {
            navs.forEach(elem => {
                elem.classList.remove("active");

                if (elem.attributes.getNamedItem("aria-current")) {
                    elem.attributes.removeNamedItem("aria-current");
                }
            });

        }
    }

    activateNavElement(page: TargetPage) {

        let nav: HTMLAnchorElement = document.querySelector(`a[nav-name='${this.translatePageToString(page)}']`);


        if (nav) {
            nav.classList.add("active");
            nav.setAttribute("aria-current", "page");
        }
    }

    translatePageToString(page: TargetPage): string {

        let retval = "";

        switch (page) {
            case TargetPage.About:
                retval = "about";
                break;
            case TargetPage.Clients:
                retval = "clients";
                break;
            case TargetPage.Contact:
                retval = "contact";
                break;
            case TargetPage.Home:
                retval = "index";
                break;
            case TargetPage.Projects:
                retval = "projects";
                break;
            case TargetPage.Skills:
                retval = "skills";
                break;
 
        }

        return retval;
    }

}