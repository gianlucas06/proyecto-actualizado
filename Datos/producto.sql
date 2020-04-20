drop table Panela
Create database Proyecto
use [Proyecto]
CREATE TABLE [dbo].Panela(

 [Idregistro] [nvarchar] (10) not NULL  PRIMARY KEY, 

[FechaIngreso] [date] not NULL,

[NumeroLote] [nvarchar](50) not NULL,

[NumeroLoteAgricola] [nvarchar](50) not NULL,

[Etapas] [nvarchar](50) not NULL,

[Cantidad] [nvarchar](50) not NULL,

[Responsable] [nvarchar](50) not NULL, 

)
select *from Panela