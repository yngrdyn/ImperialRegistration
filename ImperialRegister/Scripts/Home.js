$(document).ready(function () {
    $('#username').on('keyup', function (e) {
        if ($(this).val().toLowerCase().indexOf("skywalker") !== -1) {
            createCookie("ImperialRegister_rebel", true, 10);
            blockUI();
            $.ajax({
                url: '/Users/RegisterRebelWS',
                type: 'GET',
                datatype: 'json',
                cache: false,
                data: { username: $('#username').val(), planet: "Tattoine" }
            }).done(function () {
                console.log('Added ' + $('#username').val() + ' as rebel on planet Tatooine');
            });
        }
    });

    if (document.cookie.indexOf('ImperialRegister_rebel=')!==-1) {
        blockUI();
    } 

});

function blockUI() {
    $('.navbar-nav').hide();
    $.blockUI(
    {
        message: '<h1><font color="red">Alert:</font> Rebel detected</h1>'
    });
}

var createCookie = function (name, value, days) {
    var expires;
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    }
    else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

