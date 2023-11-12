(function (){

    let home = document.getElementById('home');
    let about = document.getElementById('about');
    let skills = document.getElementById('skills');
    let clients = document.getElementById('clients');
    let contact = document.getElementById('contact');

    let navHome = document.getElementById('navHome');
    let navAbout = document.getElementById('navAbout');
    let navSkills = document.getElementById('navSkills');
    let navClients = document.getElementById('navClients');
    let navContact = document.getElementById('navContact');

    let hdnContact = document.getElementById('hdnContactSubmitted');

    hideAll();
    show(home);

    navHome.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(home);
        disableAllActiveNavs();
        navHome.classList.add("active");
    });

    navAbout.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(about);
        disableAllActiveNavs();
        navAbout.classList.add("active");
    });

    navSkills.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(skills);
        disableAllActiveNavs();
        navSkills.classList.add("active");
    });

    navClients.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(clients);
        disableAllActiveNavs();
        navClients.classList.add("active");
    });

    navContact.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(contact);
        disableAllActiveNavs();
        navContact.classList.add("active");
    });

    function hideAll(){
        home.setAttribute('hidden', null);
        about.setAttribute('hidden', null);
        skills.setAttribute('hidden', null);
        clients.setAttribute('hidden', null);
        contact.setAttribute('hidden', null);

        home.classList.remove('active')
        about.classList.remove('active')
        skills.classList.remove('active')
        clients.classList.remove('active')
        contact.classList.remove('active')
    }

    function disableAllActiveNavs()
    {
        navHome.classList.remove('active');
        navAbout.classList.remove('active');
        navSkills.classList.remove('active');
        navClients.classList.remove('active');
        navContact.classList.remove('active');
    }

    function show(element){
        element.removeAttribute('hidden');
    }

    if (hdnContact.value === "True"){
        console.log("Showing Modal");
        let elem = document.getElementById('mdlContactRequest')
        let modal = new bootstrap.Modal(elem)
        modal.show()
    }

})();

