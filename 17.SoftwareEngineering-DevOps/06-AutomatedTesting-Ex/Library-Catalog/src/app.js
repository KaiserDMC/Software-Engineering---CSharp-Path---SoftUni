import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';


import { logout as apiLogout } from './api/api.js';




import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { createPage } from './views/create.js';
import { catalogPage } from './views/catalog.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { profilePage } from './views/profile.js';


const main = document.querySelector('main');
setUserNav();
document.getElementById('logoutBtn').addEventListener('click', logout);

page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/create', decorateContext, createPage);
page('/catalog', decorateContext, catalogPage);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);
page('/profile', decorateContext, profilePage);


page.start();
function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}



function setUserNav() {
    const email = sessionStorage.getItem('email');
    if (email) {
        document.getElementById('user').style.display = '';
        document.getElementById('guest').style.display = 'none';
        document.querySelector('#user > span').textContent = `Welcome, ${email}`;
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = '';
    }
}


async function logout() {
    await apiLogout();
    setUserNav();
    page.redirect('/');
}