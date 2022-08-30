--creo la base de datos de ventas
if exists(Select * FROM SysDataBases WHERE name='BiosNews')
BEGIN
	use master
	DROP DATABASE BiosNews
END
go

CREATE DATABASE BiosNews
go

--pone en uso la bd
USE BiosNews
go

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

GRANT Execute to [IIS APPPOOL\DefaultAppPool]
go


create table Usuario(
	NombreUsuario varchar(10) not null PRIMARY KEY check(Len(NombreUsuario) = 10),
	Contraseña varchar(7) not null check(Contraseña like '[a-Z][a-Z][a-Z][a-Z][0-9][0-9][0-9]')
)

go

create table Periodista(
	Cedula int not null primary key,
	Nombre varchar(30) not null,
	Mail varchar(40) not null check(Mail like '%_@__%.__%'),
	BajaLogica bit not null default 0
)

go

create table Noticia(
	Codigo varchar(5) not null primary key check (len(Codigo)=5),
	FechaPublicacion datetime not null,
	Titulo varchar(50) not null,
	Contenido varchar(500) not null,
	Importancia int check(Importancia between 1 and 5),
	NombreUsuario varchar(10) not null foreign key references Usuario(NombreUsuario)
)
go

create table Autores(
	Cedula int not null foreign key references Periodista(Cedula),
	Codigo varchar(5) not null foreign key references Noticia(Codigo),
	primary key(Cedula, Codigo)
)
go

create table Secciones(
	CodigoSeccion varchar(5) primary key not null check(Len(CodigoSeccion)=5),
	Nombre varchar(20) not null check(len(nombre)between 3 and 20),
	BajaLogica bit not null default 0
)
go

create table Nacional(
	Codigo varchar(5) not null primary key foreign key references Noticia(Codigo),
	CodigoSeccion varchar(5) not null foreign key references Secciones(CodigoSeccion)
)
go

create table Internacional(
	Codigo varchar(5) not null primary key foreign key references Noticia(Codigo),
	Pais varchar(20) not null check(len(Pais)between 3 and 20)
)
go


create proc AltaUsu @nomUsu varchar(10), @pass varchar(7)
as
begin

	if exists(select * from Usuario where NombreUsuario = @nomUsu)
		return -1

	insert Usuario values(@nomUsu, @pass)
	   if (@@ERROR <> 0)
       Begin
           return -2
       end
end
go

create proc Logueo @nomUsu varchar(10), @pass varchar(7)
as
begin
	select * from Usuario where NombreUsuario = @nomUsu and Contraseña = @pass
end
go

create proc AltaSeccion @codigoSeccion varchar(5), @nombre varchar(20)
as
begin
	if(exists(select * from Secciones where CodigoSeccion = @codigoSeccion and BajaLogica = 0))
		return -1
	else if(exists(select * from Secciones where CodigoSeccion = @codigoSeccion and BajaLogica = 1))
	begin
		update Secciones set BajaLogica = 1 where CodigoSeccion = @codigoSeccion
		return 1
	end
	else
	begin
		insert Secciones (CodigoSeccion, Nombre) values(@codigoSeccion, @nombre)
	end
end
go

create proc ModificarSeccion @codigoSeccion varchar(5), @nombre varchar(20)
as
begin
	if(exists(select * from Secciones where CodigoSeccion = @codigoSeccion and BajaLogica = 0))
	begin
		update Secciones set Nombre = @nombre where CodigoSeccion = @codigoSeccion
		if(@@ERROR = 0)
			return 1
		else
			return -2
	end
	else
		return -1
end
go

create proc EliminarSeccion @codigoSeccion varchar(5)
as
begin
	if(not exists(select * from Secciones where CodigoSeccion = @codigoSeccion))
		return-1
	if(exists(select * from Nacional where CodigoSeccion = @codigoSeccion)) --tiene dependencia
	begin
		update Secciones set BajaLogica = 1 where CodigoSeccion = @codigoSeccion
		return 1
	end
	else
	begin
		delete Secciones where CodigoSeccion = @codigoSeccion
		return 1
	end
end
go

create proc AltaPeriodista @cedula int, @nombre varchar(30), @mail varchar(40)
as
begin
	if(exists(select * from Periodista where Cedula = @cedula and BajaLogica = 1))
	begin
		update Periodista set BajaLogica = 0, Mail = @mail where Cedula = @cedula
		return 1
	end
	else if(exists(select * from Periodista where Cedula = @cedula and BajaLogica = 0))
		return -1
	else
	begin
		insert Periodista (Cedula, Nombre, Mail) values (@cedula, @nombre, @mail)
		return 1
	end
end
go

create proc BajaPeriodista @cedula int
as
begin 
	if(not exists(select * from Periodista where cedula = @cedula))
		return -1

	else if(exists(select * from Autores where Cedula = @cedula)) 
	begin
		update Periodista set BajaLogica = 1 where cedula = @cedula
		return 1
	end
	else
		delete Periodista where Cedula = @cedula
end
go

create proc ModificarPeriodista @cedula int, @nombre varchar(30), @mail varchar(40)
as
begin
	if(exists(select * from Periodista where Cedula = @cedula and BajaLogica = 0))
		begin
		update Periodista set Nombre = @nombre, Mail = @mail where Cedula = @cedula
		return 1
	end
	else
		return -1
end
go

create proc AltaNoticiaNacional @codigo varchar(5), @fechaPublicacion datetime, @titulo varchar(50), @contenido varchar(500), @importancia int, @nombreUsuario varchar(10), @codigoSeccion varchar(5)
as
begin
	if(exists (select * from Noticia where Codigo = @codigo))
		return -1
	if(not exists(select * from Usuario where NombreUsuario = @nombreUsuario))
		return -2
	if(exists(select * from Secciones where CodigoSeccion = @codigoSeccion and BajaLogica = 0))
	begin
		insert Noticia values(@codigo, @fechaPublicacion, @titulo, @contenido,@importancia,@nombreUsuario)
		if @@ERROR <> 0
			return -3
		insert Nacional values(@codigo, @codigoSeccion)
		if @@ERROR <> 0
			return -3
		else
			return 0
	end
	else
		return -3
end
go

create proc ModificarNoticiaNacional @codigo varchar(5), @fechaPublicacion datetime, @titulo varchar(50), @contenido varchar(500), @importancia int, @nombreUsuario varchar(10), @codigoSeccion varchar(5)
as
begin
	if(not exists (select * from Nacional where Codigo = @codigo))
		return -1
	if(not exists(select * from Usuario where NombreUsuario = @nombreUsuario))
		return -2
	if(exists(select * from Secciones where CodigoSeccion = @codigoSeccion and BajaLogica = 0))
	begin
		update Noticia set FechaPublicacion = @fechaPublicacion, Titulo = @titulo, Contenido = @contenido, Importancia = @importancia, NombreUsuario = @nombreUsuario where Codigo = @codigo
		if @@ERROR = 0
		begin
			update Nacional set CodigoSeccion = @codigoSeccion where Codigo = @codigo
				if @@ERROR = 0
					return 0
				else
					return -3
		end
		else
			return -3
	end
	else
	return -3

end
go

create proc AltaNoticiaInternacional @codigo varchar(5), @fechaPublicacion datetime, @titulo varchar(50), @contenido varchar(500), @importancia int, @nombreUsuario varchar(10), @pais varchar(20)
as
begin
	if(exists (select * from Internacional where Codigo = @codigo))
		return -1
	if(not exists(select * from Usuario where NombreUsuario = @nombreUsuario))
		return -2

	insert Noticia values(@codigo, @fechaPublicacion, @titulo, @contenido,@importancia,@nombreUsuario)
	if @@ERROR <> 0
		return -3
	else
		insert Internacional values(@codigo, @Pais)

	if @@ERROR = 0
		return -3
	else
		return 0
end
go

create proc ModificarNoticiaInternacional @codigo varchar(5), @fechaPublicacion datetime, @titulo varchar(50), @contenido varchar(500), @importancia int, @nombreUsuario varchar(10), @pais varchar(20)
as
begin
	if(not exists (select * from Internacional where Codigo = @codigo))
		return -1
	if(not exists(select * from Usuario where NombreUsuario = @nombreUsuario))
		return -2

		update Noticia set FechaPublicacion = @fechaPublicacion, Titulo = @titulo, Contenido = @contenido, Importancia = @importancia, NombreUsuario = @nombreUsuario where Codigo = @codigo
	if @@ERROR = 0
	begin
		update Internacional set Pais = @pais where Codigo = @codigo
		if @@ERROR = 0
			return 0
		else
			return -3
	end
	else
		return -3
end
go


create proc AltaAutoresNoticia @cedula int, @codigo varchar(5)
as
begin
	if(not exists(select * from Periodista where Cedula = @cedula))
		return -1
	else if(not exists(select * from Noticia where Codigo = @codigo))
		return -2
	else if(exists (select * from Periodista where BajaLogica = 1 and Cedula = @cedula))
		return -3
	else
		insert Autores(Cedula, Codigo)values(@cedula, @codigo)

	if @@ERROR = 0
		return 1
	else
		return -4
end
go

create proc EliminarAutorNoticia @codigo varchar(5)
as
begin
	if(not exists(select * from Autores where Codigo = @codigo))
		return -1

	delete Autores where Codigo = @codigo
	return 1
end
go

create proc ListarAutores @codigo varchar(5) as
begin
	select * from Autores 
	inner join Periodista P on Autores.Cedula = p.Cedula
	where Codigo = @codigo
end
go

create proc ListarNotNacional as
begin
	select * from Nacional
	inner join Noticia N on Nacional.Codigo = N.Codigo
end
go

create proc ListarNotInter as
begin
	select * from Internacional
	inner join Noticia N on Internacional.Codigo = N.Codigo
end
go

create proc ListarNotNacionalUlt5Dias as
begin
	select * from Nacional
	inner join Noticia N on Nacional.Codigo = N.Codigo
	where datepart(DAY, FechaPublicacion) >= dateadd(day, -5, datepart(day, getdate())) and datepart(year, FechaPublicacion) = datepart(year, getdate()) and datepart(month, FechaPublicacion) = datepart(month, getdate())
end
go

create proc ListarNotInterUlt5Dias as
begin
	select * from Internacional
	inner join Noticia N on Internacional.Codigo = N.Codigo
	where datepart(DAY, FechaPublicacion) >= dateadd(day, -5, datepart(day, getdate())) and datepart(year, FechaPublicacion) = datepart(year, getdate()) and datepart(month, FechaPublicacion) = datepart(month, getdate())
end
go


create proc ListarPeriodistasActivo as
begin
	Select * from Periodista where BajaLogica = 0
end
go

create proc ListarSeccionesActivo as
begin
	select * from Secciones where BajaLogica = 0
end
go

create proc BuscarSeccion @codigoSec varchar(5)
as
begin
	select * from Secciones where CodigoSeccion = @codigoSec
end
go

create proc BuscarSeccionActivo @codigoSec varchar(5)
as
begin
	select * from Secciones where CodigoSeccion = @codigoSec and BajaLogica = 0
end
go

create proc BuscarUsuario @nomUsu varchar(10)
as
begin
	select * from Usuario where NombreUsuario = @nomUsu
end
go

create proc BuscarPeriodista @cedula int
as
begin
	select * from Periodista where Cedula = @cedula
end
go

create proc BuscarPeriodistaActivo @cedula int
as
begin
	select * from Periodista where Cedula = @cedula and BajaLogica = 0
end
go

create proc BuscarNacional @codigo varchar(5)
as
begin
	select * from Nacional
	inner join Noticia N on Nacional.Codigo = N.Codigo
	where Nacional.Codigo = @codigo
end
go

create proc BuscarInternacional @codigo varchar(5)
as
begin
	select * from Internacional
	inner join Noticia N on Internacional.Codigo = N.Codigo
	where Internacional.Codigo = @codigo
end
go


exec AltaUsu 'Usuario001', 'AZAZ090'
go
exec AltaUsu 'Usuario002', 'ABCD123'
go
exec AltaUsu 'Usuario003', 'BOND007'
go
exec AltaUsu 'Usuario004', 'ASDF456'
go

exec AltaPeriodista 19191212,'Periodista 1', 'CorreoPeriodista@Num1.com'
go
exec AltaPeriodista 10000012,'Periodista 2', 'CorreoPeriodista@Num2.com'
go
exec AltaPeriodista 33333333,'Periodista 3', 'CorreoPeriodista@Num3.com'
go
exec AltaPeriodista 44444444,'Periodista 4', 'CorreoPeriodista@Num4.com'
go
exec AltaPeriodista 55555555,'Periodista 5', 'CorreoPeriodista@Num5.com'
go

exec AltaSeccion 12345,'Policial_Secc1'
go
exec AltaSeccion 10001,'Clima_Secc2'
go
exec AltaSeccion 10002,'Deportes_Secc3'
go
exec AltaSeccion 10003,'Cultura_Secc4'
go
exec AltaSeccion 10004,'Economia_Secc5'
go

select * from noticia

exec AltaNoticiaNacional 12345, '2021-07-12T15:30:00', 'Copa Ameríca: Volvió Uruguay', 'Uruguay venció 2-0 a Bolivia en el partido de la cuarta fecha del grupo A de la Copa América 2021', 2, 'Usuario001', 10002
go
exec AltaNoticiaNacional 12347, '2021-05-13T10:10:00', 'Rendimiento en soja cayó 13%', 'Confirmando lo que el sector privado estimó, el rendimiento en el cultivo de soja no llegó a 1.900 kilos por hectárea.', 3, 'Usuario002', 10004
go
exec AltaNoticiaNacional 12349, '2021-08-23T10:10:00', 'Inumet dejó sin efecto las advertencias', 'Ante la persistencia de vientos fuertes, el Instituto Uruguayo de Meteorología (Inumet) emitió este jueves una alerta amarilla.', 4, 'Usuario003', 10001
go
exec AltaNoticiaNacional 12311, '2021-08-22T10:10:00', 'Gestionan shows en el Centenari', 'El Estado Centenario, inhabilitado para que Uruguay haga de local durante sus próximos partidos por las Eliminatorias rumbo al Mundial de Catar 2022.', 2, 'Usuario004', 10003
go
exec AltaNoticiaNacional 12313, '2021-08-20T10:10:00', 'Inumet advierte por tormentas', 'El Instituto Uruguayo de Meteorología (Inumet) emitió un comunicado este martes en el que advirtió que "a partir de la tarde del miércoles 23', 4, 'Usuario002', 10001
go
exec AltaNoticiaNacional 14315, '2021-06-24T10:10:00', 'Regreso a clases: este lunes vuelven', 'El regreso gradual a las clases presenciales en Primaria se completará este lunes, con la vuelta de casi 75 mil estudiantes de cuarto', 1, 'Usuario003', 10003
go
exec AltaNoticiaNacional 14317, '2020-06-10T10:10:00', 'Tercera dosis de refuerzo Pfizer para los que tienen Coronavac comienza a darse este lunes', 'Según datos del Ministerio de Salud Pública se anotaron más de 1 millón de personas y más de medio millón ya tiene fecha y hora.', 1, 'Usuario003', 10003
go
exec AltaNoticiaNacional 14319, '2020-08-13T10:10:00', 'Uruguay calificó como sexto país “más libre del mundo”, según la ONG Freedom House', 'El portal de noticias argentino Infobae dedicó una nueva nota a nuestro país por la gestión de la pandemia y por la buena convivencia.', 1, 'Usuario003', 10003
go


exec AltaNoticiaInternacional 12346, '2021-08-21T10:10:00','¿Por qué no hay espejos en los baños de disney?', 'Esta curiosa ausencia de espejos no es accidental, sino que es una técnica para evitar que los visitantes tengan que hacer largas colas para esperar su turno para ingresar al baño. Porque es sabido que las puertas de los baños son unos de los lugares en donde más individuos se concentran.', 1, 'Usuario001', 'Estados Unidos'
go
exec AltaNoticiaInternacional 12348, '2021-07-15T10:10:00','Turcos descubren en el bitcoin', 'Las criptomonedas han conquistado a los turcos: no solo los inversores ven en ellas un valor refugio, también muchos empleados y trabajadores con sueldos precarios recurren a ellas para salvaguardar sus ahorros o seducidos por el sueño de un sobresueldo.', 2, 'Usuario004', 'Turquia'
go
exec AltaNoticiaInternacional 12310, '2021-06-09T10:10:00','Restauran el último puente', 'El puente colgante Q’eswachaka, que data del imperio inca en Perú y cuyo ritual de conservación es Patrimonio Cultural Inmaterial de la Humanidad, quedó restaurado tras colapsar en marzo por el deterioro de sus sogas que no pudieron ser renovadas debido a la pandemia, informó el gobierno regional de Cusco.', 3, 'Usuario002', 'Peru'
go
exec AltaNoticiaInternacional 12312, '2021-03-12T10:10:00','¿Tu paquete llegará en las próximas horas?', '¿Cuántas veces en la pandemia has leído el siguiente mensaje: ‘Tu pedido se entregará mañana durante el transcurso del día’? Seguramente muchas y ante esto, la tecnología chilena SimpliRoute se enfoca en fijar un horario exacto de llegada y permitir a usuario final su rastreo en tiempo real.', 1, 'Usuario004', 'Mexico'
go
exec AltaNoticiaInternacional 12314, '2021-06-24T10:10:00','Windows 11: así es el nuevo', 'Hoy por fin hemos conocido todos los detalles sobre un sistema operativo que coge el testigo de Windows 10 y que lo hace con cambios muy importantes a nivel visual, pero también en otros apartados. Señores y señoras, bienvenidos al sistema operativo de nueva generación de Microsoft.', 4, 'Usuario002', 'Estados Unidos'
go
exec AltaNoticiaInternacional 12316, '2020-01-08T10:10:00','Donald Trump pide la renuncia del presidente Joe Biden', 'El ex presidente de Estados Unidos Donald Trump estimó el domingo que su sucesor Joe Biden debería renunciar tras la victoria de los talibanes en Afganistán.', 4, 'Usuario002', 'Estados Unidos'
go
exec AltaNoticiaInternacional 12318, '2020-07-09T10:10:00','Castillo recoge mas rechazo que aprobación en dos semanas al frente de Perú', 'La desaprobación del nuevo presidente peruano, el izquierdista Pedro Castillo, supera a su aprobación en apenas 15 días en el poder, según una encuesta publicada este domingo.', 4, 'Usuario002', 'Peru'
go

exec AltaAutoresNoticia 19191212, 12345
go
exec AltaAutoresNoticia 10000012, 12345
go
exec AltaAutoresNoticia 33333333, 12345
go
exec AltaAutoresNoticia 33333333, 12347
go
exec AltaAutoresNoticia 44444444, 12349
go
--
exec AltaAutoresNoticia 44444444, 12311
go
exec AltaAutoresNoticia 55555555, 12313
go
exec AltaAutoresNoticia 55555555, 12315
go
exec AltaAutoresNoticia 55555555, 12346
go
exec AltaAutoresNoticia 19191212, 12348
go
--
exec AltaAutoresNoticia 19191212, 12310
go
exec AltaAutoresNoticia 10000012, 12310
go
exec AltaAutoresNoticia 33333333, 12312
go
exec AltaAutoresNoticia 19191212, 12312
go
exec AltaAutoresNoticia 19191212, 12314
go
--
exec AltaAutoresNoticia 33333333, 12314
go
exec AltaAutoresNoticia 55555555, 12314
go
