
CREATE DATABASE CLINICA_GRUPO_14_DB
GO
USE CLINICA_GRUPO_14_DB
GO

CREATE TABLE Roles(
    ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    -- ROLES:
    -- 1   Admin
    -- 2   Recepcionista
    -- 3   Profesional
    -- 4   Paciente
)

CREATE TABLE Generos(
    ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
    -- GENEROS:
    -- 1   Masculino
    -- 2   Femenino
    -- 3   Otro
)

CREATE TABLE Personas(
    ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    FechaNac DATE NOT NULL,
    IDGenero SMALLINT NOT NULL FOREIGN KEY REFERENCES Generos(ID),
    NumDoc VARCHAR(50) NOT NULL,
    Correo VARCHAR(50) NOT NULL UNIQUE,
    Telefono VARCHAR(50),
    IDRol SMALLINT NOT NULL FOREIGN KEY REFERENCES Roles(ID),
    --rol sale de otra tabla
    Activo BIT NOT NULL
)

CREATE TABLE Especialidades(
    ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
)

CREATE TABLE Profesionales(
    ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdPersona SMALLINT NOT NULL FOREIGN KEY REFERENCES Personas(ID)
)

CREATE TABLE Profesionales_x_Especialidad(
    IDProfesional SMALLINT NOT NULL FOREIGN KEY REFERENCES Profesionales(ID),
    IDEspecialidad SMALLINT NOT NULL FOREIGN KEY REFERENCES Especialidades(ID),
    PRIMARY KEY(IDProfesional,IDEspecialidad)
)

-- CREATE TABLE EstadoTurnos(
--     ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
--     Nombre VARCHAR(50)
-- )


--Ingreso de datos
INSERT INTO Roles (Nombre) VALUES
('Admin'),
('Recepcionista'),
('Profesional'),
('Paciente')

INSERT INTO Generos (Nombre) VALUES
('Masculino'),
('Femenino'),
('Otro');

INSERT INTO Personas (Nombre, Apellido, FechaNac, IDGenero, NumDoc, Correo, Telefono, IDRol, Activo) VALUES
('Admin', 'Admin', '1980-01-01', 1, '12345678', 'admin@clinic.com', '1111111111', 1, 1);

INSERT INTO Personas (Nombre, Apellido, FechaNac, IDGenero, NumDoc, Correo, Telefono, IDRol, Activo) VALUES
('Maria', 'Perez', '1985-05-15', 2, '22334455', 'recep1@clinic.com', '2222222222', 2, 1),
('Pablo', 'Lopez', '1990-07-20', 1, '33445566', 'recep2@clinic.com', '3333333333', 2, 1),
('Clara', 'Garcia', '1987-03-25', 2, '44556677', 'recep3@clinic.com', '4444444444', 2, 1);

INSERT INTO Personas (Nombre, Apellido, FechaNac, IDGenero, NumDoc, Correo, Telefono, IDRol, Activo) VALUES
('Juan', 'Gomez', '2000-01-15', 1, '55667788', 'paciente1@clinic.com', '5555555555', 4, 1),
('Josefina', 'Martinez', '1995-02-20', 2, '66778899', 'paciente2@clinic.com', '6666666666', 4, 1),
('Pedro', 'Rodriguez', '1988-06-25', 1, '77889900', 'paciente3@clinic.com', '7777777777', 4, 1),
('Delfina', 'Fernandez', '1975-12-05', 2, '88990011', 'paciente4@clinic.com', '8888888888', 4, 1),
('John', 'Sanchez', '1983-11-30', 1, '99001122', 'paciente5@clinic.com', '9999999999', 4, 1),
('Lucia', 'Ramirez', '1969-08-17', 2, '00112233', 'paciente6@clinic.com', '1010101010', 4, 1),
('Emilio', 'Torres', '2005-09-10', 1, '11223344', 'paciente7@clinic.com', '1111111112', 4, 1),
('Emilia', 'Flores', '1998-04-22', 2, '22334455', 'paciente8@clinic.com', '2222222223', 4, 1);

INSERT INTO Personas (Nombre, Apellido, FechaNac, IDGenero, NumDoc, Correo, Telefono, IDRol, Activo) VALUES
('Leonel', 'Mendez', '1978-01-15', 1, '33445566', 'profesional1@clinic.com', '3333333334', 3, 1),
('Alicia', 'Ruiz', '1982-03-20', 2, '44556677', 'profesional2@clinic.com', '4444444445', 3, 1),
('Maximiliano', 'Diaz', '1975-04-10', 1, '55667788', 'profesional3@clinic.com', '5555555556', 3, 1),
('Micaela', 'Castro', '1980-06-30', 2, '66778899', 'profesional4@clinic.com', '6666666667', 3, 1),
('Sebastian', 'Ortiz', '1976-11-05', 1, '77889900', 'profesional5@clinic.com', '7777777778', 3, 1),
('Tota', 'Morales', '1985-09-25', 2, '88990011', 'profesional6@clinic.com', '8888888889', 3, 1),
('Mauricio', 'Gimenez', '1983-08-14', 1, '99001122', 'profesional7@clinic.com', '9999999990', 3, 1),
('Lucila', 'Vargas', '1979-02-18', 2, '00112233', 'profesional8@clinic.com', '1010101011', 3, 1);

INSERT INTO Profesionales (IdPersona)
SELECT ID FROM Personas WHERE IDRol = 3;

INSERT INTO Especialidades (Nombre) VALUES
('Cardiología'),
('Dermatología'),
('Neurología'),
('Pediatría'),
('Psiquiatría'),
('Odontología'),
('Oftalmología'),
('Ginecología');

-- Asignar especialidades a los profesionales
INSERT INTO Profesionales_x_Especialidad (IDProfesional, IDEspecialidad) VALUES
-- Profesional1: Cardiología, Pediatría
(1, 1), (1, 4),
-- Profesional2: Dermatología, Neurología
(2, 2), (2, 3),
-- Profesional3: Psiquiatría
(3, 5),
-- Profesional4: Odontología
(4, 6),
-- Profesional5: Oftalmología, Ginecología
(5, 7), (5, 8),
-- Profesional6: Cardiología
(6, 1),
-- Profesional7: Pediatría
(7, 4),
-- Profesional8: Neurología, Oftalmología
(8, 3), (8, 7);

Create Table Horarios(
    Id smallint not null PRIMARY KEY IDENTITY(9,1),
    HoraInicio TIME NOT NULL
)

INSERT INTO Horarios (HoraInicio)
VALUES
('09:00:00'),
('10:00:00'),
('11:00:00'),
('12:00:00'),
('13:00:00'),
('14:00:00'),
('15:00:00'),
('16:00:00'),
('17:00:00'),
('18:00:00'),
('19:00:00'),
('20:00:00');

Create Table EstadoTurnos(
    Id SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
)

INSERT INTO EstadoTurnos(Nombre)
VALUES
('ABIERTO'),
('CERRADO'),
('CANCELADO'),
('REPROGRAMADO'),
('AUSENTE');


-----HASTA ACA LA GENERACION

--Consulta para ver especialidades de profesionales
-- select
-- P.nombre as Nombre_Profesional,
-- P.Apellido as Apellido_Profesional,
-- E.Nombre as Especialidad
-- from Personas p
-- inner JOIN Profesionales Pr ON P.ID=Pr.IdPersona
-- Inner Join Profesionales_x_Especialidad PXE ON PXE.IdProfesional=PR.ID
-- Inner join Especialidades E ON PXE.IDEspecialidad=E.ID


--Consulta para ver especialidades
-- select E.Id as Id_Especialidad, E.Nombre as Especialidad  from especialidades E

--Consulta para profesionales con nombre, apellido e IDProfesional
-- select P.ID as IdProfesional,PER.Nombre as Nombre, PER.Apellido as Apellido from Profesionales P
-- INNER JOIN Personas PER ON P.IdPersona=PER.ID


--Consulta para personas (Tod@s)
SELECT
P.ID, P.Nombre, P.Apellido, P.FechaNac,
P.IDGenero, G.Nombre as Gen, P.NumDoc,
P.Correo, P.Telefono, P.IDRol, R.Nombre as Rol,
P.Activo, P.Password 
FROM Personas P 
INNER JOIN Generos G ON P.IDGenero = G.ID
INNER JOIN Roles R ON P.IDRol = R.ID


--Consulta para roles
select R.ID as Id, R.Nombre as Nombre from Roles R

--Consulta de especialidades
select E.ID,E.Nombre  from Especialidades E

--Consulta de ProfesionalesXEspecialidad
select * from Profesionales_x_Especialidad

--consulta de Profesionales
select * from Profesionales


select * from Horarios


SELECT * from EstadoTurnos