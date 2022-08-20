use Zoologico
go

create table InformacionZoo(
	id INT IDENTITY (1,1) PRIMARY KEY,
	pais varchar (20),
	nombre varchar (20),
	telefono varchar (15),
	sitioWeb varchar (20)
)