//Основной файл скриптов движка

//Мерцание элемента
function animate_blink(params) {
    //Получаем элемент
    var elem = $('#' + params["elem"]);
    //Получаем длительность анимации
    var duration = params["duration"];
    //Получаем таймаут между миганиями
    var delay = params["delay"];

    //Ставим дефолтную видимость
    var defVisible = 0;


    //Воспроизводим анимацию
    elem.animate({ opacity: value }, duration);
}

//Мигание элемента
function animate_flash(params) {
    //Получаем элемент
    var elem = $('#' + params["elem"]);
    //Получаем количество итераций анимации
    var duration = params["duration"];
    //Получаем таймаут между миганиями
    var delay = params["delay"];
    //Ставим дефолтную видимость
    var defVisible = 0;

    //Устанавливаем таймер
    var timer = setInterval(function () {
        //Ставим видимость
        elem.css("opacity", defVisible);

        //Меняем видимость
        if (defVisible == 0)
            defVisible = 1;
        else
            defVisible = 0;

        //Уменьшаем счётчик
        duration--;
        //Если итерации исчерпаны
        if (duration <= 0) {
            //Отменяем работу таймера
            clearInterval(timer);
            //Если у нас видимость убрана
            if (defVisible == 1)
                //Возвращаем видимость
                elem.css("opacity", 1);
        }
    }, delay);
}

//Перемещение элемента
function animate_move(params) {

}

//Смена прозрачности элемента
function animate_opacity(params) {

    //Получаем элемент
    var elem = $('#' + params["elem"]);
    //Получаем длительность анимации
    var duration = params["duration"];
    //Получаем итоговое значение анимации
    var value = params["value"];

    //Воспроизводим анимацию
    elem.animate({ opacity: value }, duration);
}

//Смена цвета элемента
function animate_color(params) {

}

//Смена сцены
function scene_redirect(params) {
    //Получаем адрес редиректа
    var address = params["address"];
    //Редиректимся
    window.location.replace(address);
}

//Установка параметра
function set_param(params) {

}


/* Внутренние функции */

//Догрузка страницы
$(document).ready(function () {
    //Инициализируем триггеры
    initTriggers();
});

//Инициализируем триггеры
function initTriggers() {
    //Получаем все div-ы с триггерами
    var elems = $('div[trigger_on="true"]');

    //Проходимся по всем элементам
    for (var i = 0; i < elems.length; i++) {
        //Получаем элемент и добавляем ему триггеры
        addTriggers(elems.eq(i))
    }
}

//Добавляем триггеры элементу
function addTriggers(elem) {
    //Получаем список имён триггеров, навешанных на данном элементе
    var triggerList = elem.attr('triggerList').split('; ');
    //Проходимся по списку триггеров
    for (var i = 0; i < triggerList.length; i++) {

        /*
         Вот тут будет код подвешивания триггера
         */

    }
}