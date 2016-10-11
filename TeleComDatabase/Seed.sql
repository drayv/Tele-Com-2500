/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Services (Name) VALUES ('Установка модема GST-23.')			-- 1
INSERT INTO Services (Name) VALUES ('Настройка ПО модема GSM-23.')		-- 2
INSERT INTO Services (Name) VALUES ('Прокладка кабеля до 10 метров.')	-- 3
INSERT INTO Services (Name) VALUES ('Прокладка кабеля до 20 метров.')	-- 4
INSERT INTO Services (Name) VALUES ('Прокладка кабеля до 30 метров.')	-- 5
INSERT INTO Services (Name) VALUES ('Установка модема GSM-10.')			-- 6
INSERT INTO Services (Name) VALUES ('Настройка ПО модема GSM-10.')		-- 7
INSERT INTO Services (Name) VALUES ('Установка модема GSM-30.')			-- 8
INSERT INTO Services (Name) VALUES ('Настройка ПО модема GSM-30.')		-- 9
INSERT INTO Services (Name) VALUES ('Установка модема GSM-50.')			-- 10
INSERT INTO Services (Name) VALUES ('Настройка ПО модема GSM-50.')		-- 11
INSERT INTO Services (Name) VALUES ('Доступ в интернет 30 Мбит\с.')		-- 12
INSERT INTO Services (Name) VALUES ('Доступ в интернет 50 Мбит\с.')		-- 13
INSERT INTO Services (Name) VALUES ('Доступ в интернет 80 Мбит\с.')		-- 14
INSERT INTO Services (Name) VALUES ('Доступ в интернет 100 Мбит\с.')	-- 15

INSERT INTO Rates (Service, Amount, StartDate) VALUES ('1', '100', '2015-01-01') -- 1
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('2', '50', '2015-01-02') -- 2
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('2', '60', '2016-01-01') -- 2
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('2', '70', '2017-01-01') -- 2
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('3', '30', '2015-01-03') -- 3
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('4', '60', '2015-01-04') -- 4
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('5', '90', '2015-01-05') -- 5
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('6', '110', '2016-01-05') -- 5
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('7', '120', '2015-01-06') -- 6
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('8', '60', '2015-01-07') -- 7
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('9', '130', '2015-01-08') -- 8
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('0', '75', '2015-01-09') -- 9
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('10', '150', '2015-01-10') -- 10
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('11', '80', '2015-01-11') -- 11
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('12', '100', '2015-01-12') -- 12
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('13', '150', '2015-01-13') -- 13
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('14', '200', '2015-01-14') -- 14
INSERT INTO Rates (Service, Amount, StartDate) VALUES ('15', '250', '2015-01-15') -- 15

INSERT INTO Standards (Service, Name, Value) VALUES ('1', 'Время выполнения работы', '30 минут') -- 1
INSERT INTO Standards (Service, Name, Value) VALUES ('2', 'Время выполнения работы', '1 час') -- 2
INSERT INTO Standards (Service, Name, Value) VALUES ('3', 'Время выполнения работы', '20 минут') -- 3
INSERT INTO Standards (Service, Name, Value) VALUES ('4', 'Время выполнения работы', '40 минут') -- 4
INSERT INTO Standards (Service, Name, Value) VALUES ('5', 'Время выполнения работы', '1 час') -- 5
INSERT INTO Standards (Service, Name, Value) VALUES ('6', 'Время выполнения работы', '30 минут') -- 6
INSERT INTO Standards (Service, Name, Value) VALUES ('7', 'Время выполнения работы', '1 час') -- 7
INSERT INTO Standards (Service, Name, Value) VALUES ('8', 'Время выполнения работы', '30 минут') -- 8
INSERT INTO Standards (Service, Name, Value) VALUES ('9', 'Время выполнения работы', '2 часа') -- 9
INSERT INTO Standards (Service, Name, Value) VALUES ('10', 'Время выполнения работы', '30 минут') -- 10
INSERT INTO Standards (Service, Name, Value) VALUES ('11', 'Время выполнения работы', '3 часа') -- 11
INSERT INTO Standards (Service, Name, Value) VALUES ('12', 'Максимальное время недоступности услуги в сутки', '1 час') -- 12
INSERT INTO Standards (Service, Name, Value) VALUES ('12', 'Техподдержка', 'отсутствует') -- 12
INSERT INTO Standards (Service, Name, Value) VALUES ('13', 'Максимальное время недоступности услуги в сутки', '40 минут') -- 13
INSERT INTO Standards (Service, Name, Value) VALUES ('13', 'Техподдержка', 'отсутствует') -- 13
INSERT INTO Standards (Service, Name, Value) VALUES ('14', 'Максимальное время недоступности услуги в сутки', '30 минут') -- 14
INSERT INTO Standards (Service, Name, Value) VALUES ('14', 'Техподдержка', 'круглосуточно') -- 14
INSERT INTO Standards (Service, Name, Value) VALUES ('15', 'Максимальное время недоступности услуги в сутки', '20 минут') -- 15
INSERT INTO Standards (Service, Name, Value) VALUES ('15', 'Техподдержка', 'круглосуточно') -- 15