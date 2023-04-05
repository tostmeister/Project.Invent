# Project.Invent
Практическое задание

Разработать информационную систему для IT-компании “IT Sever” для учёта оборудования. За каждым управляющим отделом, числиться какое-то оборудование. Система должна отображать ФИО, отдел, оборудование, инвентарный номер (должен быть уникальный шаблон 93ХХХХХХ номер). Пользователь может по поиску инвентарного номера, найти оборудование и за кем оно числиться или по ФИО вывести всё оборудование и инвентарный номер. Может добавить, изменить, удалить отображаемую информацию. 
Так же оборудование может быть списанным, списанное оборудование, отображается с надписью “Списано”.
Так же пользователь может искать по всем оборудованиям, только по списанным или только не по списанным.
Дополнительно:
Инвентарный номер может совпадать только со списанным оборудованием.
При добавлении оборудования, ему присваивается личный инвентарный номер
Использовать локальную базу данных (SQLite)
Данная система должна иметь не менее одного модуля (dll библиотеки) и использовать не менее 1 паттерна.
Должно быть не менее 400 записей . (необходим генератор добавления).

Старт программы начинается с кнопки "Show" - отоборажает список оборудования.
![image](https://user-images.githubusercontent.com/112758747/230026611-cd6b6894-bcf6-4659-88f4-01faabc603ce.png)

Далее мы можем добавить элемент с помощью кнопки "Добавить".
![image](https://user-images.githubusercontent.com/112758747/230026733-fb209f2f-7b69-40c0-81b7-a99e8036b1ab.png)

Также мы можем просмотреть профиль нажав на любой элемент в StackPanel.

В профиле мы списать, редактировать, удалить оборудование. Также мы можем вернуться на главное окно.
![image](https://user-images.githubusercontent.com/112758747/230026840-31fbc4cf-019e-454e-9371-3330f13e2e4e.png)

Окна оповещения:
![image](https://user-images.githubusercontent.com/112758747/230043877-0ee1f439-4bd4-42dd-b810-3e17faea1fb8.png)

![image](https://user-images.githubusercontent.com/112758747/230044163-77ea4dfa-dc8f-47d0-a4d8-f448c18a1d26.png)

![image](https://user-images.githubusercontent.com/112758747/230044242-8b184090-211b-4b9a-b699-6f05ca5c2b63.png)

![image](https://user-images.githubusercontent.com/112758747/230044527-aeaea47f-903a-4210-a82c-d2cc6823919e.png)

