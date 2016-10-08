ALTER TABLE [dbo].[Rates]
	ADD CONSTRAINT [FK_Rates_Service]
	FOREIGN KEY (Service)
	REFERENCES [dbo].[Services] (Id)