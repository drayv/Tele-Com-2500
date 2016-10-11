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

INSERT INTO Services (Name) VALUES ('Установка модема GST-23.')
INSERT INTO Services (Name) VALUES ('Настройка ПО модема GSM-23.')
INSERT INTO Services (Name) VALUES ('Прокладка кабеля до 10 метров.')
INSERT INTO Services (Name) VALUES ('Прокладка кабеля до 20 метров.')
INSERT INTO Services (Name) VALUES ('Прокладка кабеля до 30 метров.')
INSERT INTO Services (Name) VALUES ('Установка модема GSM-10.')
INSERT INTO Services (Name) VALUES ('Настройка ПО модема GSM-10.')
INSERT INTO Services (Name) VALUES ('Установка модема GSM-30.')
INSERT INTO Services (Name) VALUES ('Настройка ПО модема GSM-30.')
INSERT INTO Services (Name) VALUES ('Установка модема GSM-50.')
INSERT INTO Services (Name) VALUES ('Настройка ПО модема GSM-50.')