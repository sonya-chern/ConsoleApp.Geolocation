# ConsoleApp.Geolocation
<h2>Описание</h2>
Консольное приложение позволяет скачивать JSON данные посредством HTTP-запроса. 
Сохраняет данные в файле с именем, указанным пользователем, в консоль выводит данные координат с частотой, указанной пользователем.
<h2>Язык</h2>
Приложение написано на языке С# c использованием стандартных классов.
<h2>Зависимости</h2>
Для корректной работы Приложения необходимо поключить сборку Newtonsoft.Json.
<h2>Использование</h2>
Для запуска программы необходимо в командной строке указать название приложения, добавить через пробел в двойных кавычках адрес для поиска полигона (например Москва), 
далее через пробел в двойных кавычках частоту точек, далее через пробел в двойных кавычках имя файла для сохранения результата  и нажать ENTER 
<pre>
>ConsoleApp.Geolocation.exe "Москва" "2" "jsonDowloading.txt"
</pre>
При успешном скачивании в папке создается файл "jsonDowloading.txt" с JSON данными, а в консоль выводит данные координат с указанной частотой.
