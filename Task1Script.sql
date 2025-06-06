IF DB_ID('TestDB') IS NULL
BEGIN
    CREATE DATABASE TestDB;
END
GO

USE TestDB;
GO

-- Проверка существования процедуры и её удаление, если она существует
IF OBJECT_ID('FillPersonsTable', 'P') IS NOT NULL
    DROP PROCEDURE FillPersonsTable;
GO

-- Проверка существования таблицы и её удаление, если она существует
IF OBJECT_ID('Persons', 'U') IS NOT NULL
    DROP TABLE Persons;
GO

-- Создание таблицы
CREATE TABLE Persons (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    BirthDate DATE
);
GO

-- Создание процедуры для генерации 100 000 случайных записей
CREATE PROCEDURE FillPersonsTable
AS
BEGIN
    -- Очистка таблицы перед заполнением
    TRUNCATE TABLE Persons;
    
    DECLARE @i INT = 1;
    DECLARE @Names TABLE (Name NVARCHAR(50), NameType NVARCHAR(10));

    -- Заполняем временную таблицу именами и фамилиями
    INSERT INTO @Names (Name, NameType) VALUES 
        ('John', 'First'), ('Jane', 'First'), ('Mike', 'First'), ('Sarah', 'First'),
        ('Alex', 'First'), ('Emma', 'First'), ('David', 'First'), ('Lisa', 'First'),
        ('Smith', 'Last'), ('Johnson', 'Last'), ('Williams', 'Last'), ('Brown', 'Last'),
        ('Jones', 'Last'), ('Garcia', 'Last'), ('Miller', 'Last'), ('Davis', 'Last');

    -- Генерация 100 000 записей
    WHILE @i <= 100000
    BEGIN
        DECLARE @FirstName NVARCHAR(50);
        DECLARE @LastName NVARCHAR(50);

        -- Выбор случайного имени
        SELECT TOP 1 @FirstName = Name 
        FROM @Names 
        WHERE NameType = 'First' 
        ORDER BY NEWID();

        -- Выбор случайной фамилии
        SELECT TOP 1 @LastName = Name 
        FROM @Names 
        WHERE NameType = 'Last' 
        ORDER BY NEWID();

        -- Вставка записи с email в формате firstname.lastname@example.com
        INSERT INTO Persons (FirstName, LastName, Email, BirthDate)
        VALUES (
            @FirstName,
            @LastName,
            LOWER(CONCAT(@FirstName, '.', @LastName, '@example.com')),
            DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 36500), GETDATE())
        );

        SET @i = @i + 1;
    END
END;
GO

-- Выполнение процедуры
EXEC FillPersonsTable;
GO