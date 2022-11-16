USE [master]
GO
CREATE DATABASE[ClinicaWebDB]
GO
USE[ClinicaWebDB]
GO
--Tabla registro medico
CREATE TABLE [dbo].[Medico](
[Id] [int] PRIMARY KEY IDENTITY (1,1),
[Nombre] [varchar] (50) NOT NULL,
[Telefono] [varchar] (10) NOT NULL,
[Especialidad] [varchar] (100) NOT NULL
)

--Tabla de registro examenes
CREATE TABLE [dbo].[Examenes](
[Id] [int] PRIMARY KEY IDENTITY (1,1),
[Examen] [varchar](1500) NOT NULL
)

--Tabla de registro anexos medicos
CREATE TABLE [dbo].[Anexos](
[Id] [int] PRIMARY KEY IDENTITY (1,1),
[Anexo] [varchar] (1500) NOT NULL
)

--Tabla de Horarios medicos
CREATE TABLE [dbo].[Horarios](
[Id] [int] PRIMARY KEY IDENTITY (1,1),
[IdMedico] [int] NOT NULL,
[Entrada] [datetime] NOT NULL,
[Salida] [datetime] NOT NULL,
CONSTRAINT FK1_Medico_Horarios FOREIGN KEY (IdMedico) REFERENCES Medico (Id)
)

--Tabla registro pacientes
CREATE TABLE [dbo].[Paciente](
[Id] [int] PRIMARY KEY IDENTITY (1,1) NOT NULL,
[IdMedico] [int] NOT NULL,
[IdExamen] [int] NOT NULL,
[IdAnexo] [int] NOT NULL,
[Nombre] [varchar] (50) NOT NULL,
[Edad] [varchar] (5) NOT NULL,
[Telefono] [varchar] (10) NOT NULL,
[FechaNacimiento] [varchar] (10) NOT NULL,
[Genero] [varchar] (10) NOT NULL,
CONSTRAINT FK1_Medico_Paciente FOREIGN KEY (IdMedico) REFERENCES Medico (Id),
CONSTRAINT FK2_Examenes_Paciente FOREIGN KEY (IdExamen) REFERENCES Examenes (Id),
CONSTRAINT FK3_Anexos_Paciente FOREIGN KEY (IdAnexo) REFERENCES Anexos (Id)
)

--Tabla rol
CREATE TABLE [dbo].[Rol](
[Id] [int] PRIMARY KEY IDENTITY (1,1) NOT NULL,
[Nombre] [varchar] (30) NOT NULL,
CONSTRAINT FK1_Usuario_Rol FOREIGN KEY (Id) REFERENCES Rol (Id)
);
go

--Tabla usuario 
CREATE TABLE[dbo].[Usuario](
[Id] [int] PRIMARY KEY IDENTITY (1,1) NOT NULL,
[IdRol][int] NOT NULL,
[Nombre] [varchar] (30) NOT NULL,
[Apellido] [varchar] (30) NOT NULL,
[Login] [varchar] (25) NOT NULL,
[Password] [varchar] (32) NOT NULL,
[Estatus] [tinyint] NOT NULL,
[FechaRegistro] [datetime] NOT NULL,
CONSTRAINT FK1_Rol_Usuario FOREIGN KEY (Id) REFERENCES Usuario (Id)
);
go



USE [ClinicaWebDB]
GO

INSERT INTO [dbo].[Medico]
		([Nombre],[Telefono],[Especialidad])
VALUES
		('Josue Acevedo','77545525','Cardiologo')
GO
INSERT INTO [dbo].[Anexos]
				([Anexo])
VALUES	
		('Recibir Consulta Mensual')
GO

INSERT INTO [dbo].[Examenes]
		([Examen])

VALUES
('Examen de Sangre')
GO

INSERT INTO [dbo].[Paciente]

           ([IdMedico],[IdExamen],[IdAnexo],[Fechanacimiento] )
VALUES 
 ('','','','Pedro Alvarez','Examen de Orin','Recibir Consulta Mensual','Juan Pedro','25','79856142','12/02/2020')
 go

 INSERT INTO [dbo].[Horarios]
 ([IdMedico],[Entrada],[Salida])

 VALUES
 ('Juan Antonio','10.00 am','5:30 Pm')
 go

 INSERT INTO [dbo].[Rol]

([Nombre])
VALUES
('Javier Monge')
go

INSERT INTO [dbo].[Usuario]
([IdRol],[Nombre],[Apellido],[Login],[Password],[Estatus],[FechaRegistro])

VALUES
('','Kevin alexander','Perez Hernandez','Kevin Perez','T028964','1','28/10/2022')
go

