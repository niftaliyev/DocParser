# DocParser API

## Описание

DocParser API — это RESTful сервис для парсинга документов, поддерживающий форматы PDF и DOCX. Пользователи могут загружать файлы, получать текстовое содержимое и метаданные, такие как количество страниц для PDF.

---

## Структура проекта

- **DocParser.Api**: Контроллеры API для взаимодействия с пользователем.
- **DocParser.Application**: Логика обработки запросов и взаимодействие с сервисами.
- **DocParser.Domain**: Модели данных и интерфейсы для парсеров.
- **DocParser.Infrastructure**: Реализации парсеров для обработки PDF и DOCX файлов.
- **DocParser.Tests**: Юнит-тесты для сервисов и логики проекта.

---

## Установка и запуск

### Требования

- .NET 9

### Шаги для запуска

1. Клонируйте репозиторий:
    ```bash
    git clone https://github.com/niftaliyev/DocParser.git
    ```

2. Перейдите в директорию проекта:
    ```bash
    cd DocParser
    ```

3. Восстановите зависимости:
    ```bash
    dotnet restore
    ```

4. Запустите приложение:
    ```bash
    dotnet run
    ```

5. Откройте Swagger UI для тестирования API:
    ```
    https://localhost:5000/swagger
    ```

---

## Архитектура

Проект использует слоистую архитектуру (Layered Architecture) и основывается на принципах DDD (Domain-Driven Design).

- **Api**: контроллеры для обработки HTTP-запросов.
- **Application**: бизнес-логика и сервисы.
- **Domain**: модели данных и интерфейсы для парсеров.
- **Infrastructure**: реализации парсеров для PDF и DOCX.

---

## Основные компоненты

- **ParseController**: контроллер, который принимает файл и передает его в соответствующий парсер.
- **DocParserService**: сервис, который определяет, какой парсер использовать в зависимости от расширения файла.
- **IDocumentParser**: интерфейс для парсеров.
- **PdfParser** и **WordParser**: реализации парсеров для PDF и DOCX файлов.

---

## Пример использования

### POST /api/parse
