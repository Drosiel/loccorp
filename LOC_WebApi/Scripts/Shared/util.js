$(function () {

    // Ссылка на автоматически-сгенерированный прокси хаба
    var chat = $.connection.chatHub;

    // Объявление функции, которая хаб вызывает при получении сообщений
    chat.client.addMessage = function (name, message) {
        // Добавление сообщений на веб-страницу 
        $('#chatroom').append('<li class="chatroom-tite">' + htmlEncode(chatUserName)
            + ': ' + '<span class="chatroom-box">' + htmlEncode(message) + '</span></li>');
    };

    // Функция, вызываемая при подключении нового пользователя
    chat.client.onConnected = function (id, userName, Users) {

        // установка в скрытых полях имени и id текущего пользователя
        $('#hdId').val(id);
        $('#username').val(userName);
        $('#header').html('<h3>Добро пожаловать, ' + userName + '</h3>');

        // Добавление всех пользователей
        for (i = 0; i < Users.length; i++) {

            AddUser(Users[i].ConnectionId, Users[i].Name);
        }
    }

    // Добавляем нового пользователя
    chat.client.onNewUserConnected = function (id, chatUserName) {

        AddUser(id, chatUserName);
    }

    // Удаляем пользователя
    chat.client.onUserDisconnected = function (id) {

        $('#' + id).remove();
    }

    // Открываем соединение
    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
            var msg = document.getElementById('message').value;

            if (msg == "") { return false; };
            // Вызываем у хаба метод Send
            chat.server.send($('#username').val(), $('#message').val());
            $('#message').val('');
        });

        $('input[type=text]').on('keydown', function (e) {
            if (e.which == 13) {
                e.preventDefault();
                var msg = document.getElementById('message').value;
                if (msg == "") { return false; };  
                // Вызываем у хаба метод Send
                chat.server.send($('#username').val(), $('#message').val());
                $('#message').val('');            
            };
        });

        //вход в чат
        $("#nav-chat").click(function () {
            console.log;

            alert('Привет!');

            if (chatUserName != "") {
                chat.server.connect(chatUserName);
                alert('вы вошли');
            }
            else {
                alert('Зарегистрируйтесь');
            }
        });




        
    });
});


// Кодирование тегов
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
//Добавление нового пользователя
function AddUser(id, name) {

    var userId = $('#hdId').val();

    if (userId != id) {

        $("#chatusers").append('<p id="' + id + '"><b>' + name + '</b></p>');
    }
}