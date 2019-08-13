let showFormLogin = document.querySelector('.btn__login')
let formLogin = document.querySelector('.popup__login')
let formLoginClose = formLogin.querySelector('.popup__close')

showFormLogin.addEventListener('click', function() {
    toggleClass(formLogin)
})
formLoginClose.addEventListener('click', function() {
    toggleClass(formLogin)
})

function toggleClass(elem) {
    elem.classList.toggle('active')
}