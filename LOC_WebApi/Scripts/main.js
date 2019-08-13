let toggleFormLogin = document.querySelectorAll('.btn__login')
let popup = document.querySelector('.popup')
let popupTitle = document.querySelector('.popup__title')
let popupClose = document.querySelectorAll('.popup__close')

let popupRegister = document.querySelector('.popup__wrapper.regiser')
let popupLogin = document.querySelector('.popup__wrapper.login')

toggleFormLogin.forEach(item => {
    item.addEventListener('click', function() {
        popup.classList.add('active')

        if (item.dataset.value == 'register') {
            popupLogin.classList.add('hidden')
        } if (item.dataset.value == 'login') {
            popupRegister.classList.add('hidden')
        }

    })
})

popupClose.forEach(item => {
    item.addEventListener('click', function() {
        popup.classList.remove('active')
        try {
            popupLogin.classList.remove('hidden')
        } catch (error) {
            
        }
        try {
            popupRegister.classList.remove('hidden')
        } catch (error) {
            
        }
    })
})
