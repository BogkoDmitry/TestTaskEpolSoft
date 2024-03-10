Тестовое задание

Пояснения:
1. В тестовом задании в примере сущности JSON поменял структуру с вынесением Id на уровень Patient, так как по текущей схеме отлично подходил вариант с Owned сущностью,
без необходимости создания (https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities).
2. Все переменные среды, такие как порты, строка подключения к базе данных были захаркожены напрямую в код, с целью облегчения работы (исключительно, подходит только для демонстрационных целей!)
3. Для добавления 100 patients из консольного приложения был сгенерирован json-файл с целью проверки консистентности данных, так как можно было проверить действия на одних и тех же данных (изначально использовал Random).
4. Так же в консольном приложении был продублирован код с описанием сущности `Patient` и enum `Gender` с целью облегчения работы (эти файлы должны браться из TestTaskApi).
5. Не добавлялся слой Service, так как это было бы избыточно для тестового показа, контекст базы данных вызывается напрямую из контроллера (так тоже делать не нужно, но в этом конкретном случае так проще и не влияет на работу).

Инструкция:
Для запуска приложения должен быть включен docker, нужно запустить две команды `docker-compose build` -> `docker-compose up`. В настройках docker-compose для консольного приложения установлен параметр перезапуска в 
случае ошибки (так как консольное приложение при запуске может попытаться сделать запрос к еще не запущенному api, в таком случае упадет ошибка, для этого и предназначена `retry policy`).
