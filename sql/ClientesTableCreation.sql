USE [Challenge]
-- Create a new table called 'Customers' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Clientes', 'U') IS NOT NULL
DROP TABLE dbo.Clientes
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Clientes	
(
   ID						INT				IDENTITY(1,1)   PRIMARY KEY , -- primary key column
   Nombres					[NVARCHAR](50)  NOT NULL,
   Apellidos				[NVARCHAR](50)  NOT NULL,
   Fecha_de_Nacimiento		[DATE]					,
   CUIT						[NVARCHAR](50)	NOT NULL,
   domicilio				[NVARCHAR](50)			,
   telefono_celular			[NVARCHAR](50)	NOT NULL,
   email					[NVARCHAR](50)	NOT NULL,

);
GO

-- Data Examples
insert into Clientes (Nombres, Apellidos, Fecha_de_Nacimiento, CUIT, domicilio, telefono_celular, Email)

Values 
	('Juan', 'Perez', '1997-08-31', '1-13452341-0', 'roma 4635', '4335132', 'jperez@gmail.com'),
	('Pedro', 'Roman', '2003-03-05', '1-34151343-0', 'platense 3412', '3151342351', 'proman@gmail.com'),
	('Marta', 'Armen', '1997-03-15', '2-31414231-1', 'Sanchez 2311', '4335132', 'marmen@gmail.com');

GO
