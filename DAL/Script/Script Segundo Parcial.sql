CREATE DATABASE	Aplicada2PrimerParcial;	
go
CREATE TABLE Prestamoes
(
	IdPrestamo int primary key identity(1,1),
	IdCuenta int,
	Tiempo int,
	Fecha date,
	Interes money,
	Capital money


);
go

CREATE TABLE Cuotas
(
IdCuota int primary key identity(1,1),
IdPrestamo int,
Interes money,
Capital money,
Valor money,
Balance money,
CuotaNum int

);
go
select * from Cuotas
select * from	Prestamoes
select * from CuentaBancarias

