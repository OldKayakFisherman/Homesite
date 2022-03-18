var TargetPage;
(function (TargetPage) {
    TargetPage[TargetPage["Home"] = 0] = "Home";
    TargetPage[TargetPage["About"] = 1] = "About";
    TargetPage[TargetPage["Skills"] = 2] = "Skills";
    TargetPage[TargetPage["Clients"] = 3] = "Clients";
    TargetPage[TargetPage["Projects"] = 4] = "Projects";
    TargetPage[TargetPage["Contact"] = 5] = "Contact";
})(TargetPage || (TargetPage = {}));
var MenuResolver = /** @class */ (function () {
    function MenuResolver() {
    }
    MenuResolver.prototype.resolve = function (page) {
        this.inactivateNavigationElements();
        this.activateNavElement(page);
    };
    MenuResolver.prototype.inactivateNavigationElements = function () {
        var navs = document.querySelectorAll(".nav-link");
        if (navs != null && navs.length > 0) {
            navs.forEach(function (elem) {
                elem.classList.remove("active");
                if (elem.attributes.getNamedItem("aria-current")) {
                    elem.attributes.removeNamedItem("aria-current");
                }
            });
        }
    };
    MenuResolver.prototype.activateNavElement = function (page) {
        var nav = document.querySelector("a[nav-name='".concat(this.translatePageToString(page), "']"));
        if (nav) {
            nav.classList.add("active");
            nav.setAttribute("aria-current", "page");
        }
    };
    MenuResolver.prototype.translatePageToString = function (page) {
        var retval = "";
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
    };
    return MenuResolver;
}());
//# sourceMappingURL=menuResolver.js.map