ALTER TABLE [dbo].[Standards]
	ADD CONSTRAINT [FK_Standarts_Service]
	FOREIGN KEY (Service)
	REFERENCES [dbo].[Services] (Id)