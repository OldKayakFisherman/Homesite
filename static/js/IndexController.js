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


    hideAll();
    show(home);

    navHome.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(home);
    });

    navAbout.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(about);
    });

    navSkills.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(skills);
    });

    navClients.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(clients);
    });

    navContact.addEventListener("click", (evt) => {
        evt.preventDefault();
        hideAll();
        show(contact);
    });

    //Handle Scroll Events


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

    function show(element){
        element.removeAttribute('hidden');
        element.classList.add('active');
    }


})();