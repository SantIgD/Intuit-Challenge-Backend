USE [Challenge]
-- Create a new table called 'Customers' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Clientes', 'U') IS NOT NULL
DROP TABLE dbo.Clientes
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Clientes	
(
   ID						INT				NOT NULL   PRIMARY KEY, -- primary key column
   Nombres					[NVARCHAR](50)  NOT NULL,
   Apellidos				[NVARCHAR](50)  NOT NULL,
   Fecha_de_Nacimiento		[DATE]					,
   CUIT						[NVARCHAR](50)	NOT NULL,
   domicilio				[NVARCHAR](50)			,
   telefono_celular			[NVARCHAR](50)	NOT NULL,
   email					[NVARCHAR](50)	NOT NULL,

);
GO