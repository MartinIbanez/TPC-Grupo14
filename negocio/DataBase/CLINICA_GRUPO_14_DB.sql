CREATE DATABASE CLINICA_GRUPO_14_DB
GO
USE CLINICA_GRUPO_14_DB
GO



-- CREATE TABLE Roles(
--     ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
--     Nombre VARCHAR(50) NOT NULL,
--     -- ROLES:
--     -- 1   Admin
--     -- 2   Recepcionista
--     -- 3   Profesional
--     -- 4   Paciente
-- )

-- CREATE TABLE Generos(
--     ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
--     Nombre VARCHAR(50) NOT NULL
--     -- GENEROS:
--     -- 1   Masculino
--     -- 2   Femenino
--     -- 3   Otro
-- )

CREATE TABLE Personas(
    ID SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    FechaNac DATE NOT NULL,
    Genero SMALLINT,
    NumDoc VARCHAR(50) NOT NULL,
    Correo VARCHAR(50) NOT NULL UNIQUE,
    Telefono VARCHAR(50),
    Rol SMALLINT NOT NULL,
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


-- --Ingreso de datos
-- INSERT INTO Roles (Nombre) VALUES
-- ('Admin'),           1
-- ('Recepcionista'),   2
-- ('Profesional'),     3
-- ('Paciente')         4

-- INSERT INTO Generos (Nombre) VALUES
-- ('Masculino'),   1
-- ('Femenino'),    2
-- ('Otro');        3

INSERT INTO Personas (Nombre, Apellido, FechaNac, Genero, NumDoc, Correo, Telefono, Rol, Activo) VALUES
('Admin', 'Admin', '1980-01-01', 1, '12345678', 'admin@clinic.com', '1111111111', 1, 1);

INSERT INTO Personas (Nombre, Apellido, FechaNac, Genero, NumDoc, Correo, Telefono, Rol, Activo) VALUES
('Maria', 'Perez', '1985-05-15', 2, '22334455', 'recep1@clinic.com', '2222222222', 2, 1),
('Pablo', 'Lopez', '1990-07-20', 1, '33445566', 'recep2@clinic.com', '3333333333', 2, 1),
('Clara', 'Garcia', '1987-03-25', 2, '44556677', 'recep3@clinic.com', '4444444444', 2, 1);

INSERT INTO Personas (Nombre, Apellido, FechaNac, Genero, NumDoc, Correo, Telefono, Rol, Activo) VALUES
('Juan', 'Gomez', '2000-01-15', 1, '55667788', 'paciente1@clinic.com', '5555555555', 4, 1),
('Josefina', 'Martinez', '1995-02-20', 2, '66778899', 'paciente2@clinic.com', '6666666666', 4, 1),
('Pedro', 'Rodriguez', '1988-06-25', 1, '77889900', 'paciente3@clinic.com', '7777777777', 4, 1),
('Delfina', 'Fernandez', '1975-12-05', 2, '88990011', 'paciente4@clinic.com', '8888888888', 4, 1),
('John', 'Sanchez', '1983-11-30', 1, '99001122', 'paciente5@clinic.com', '9999999999', 4, 1),
('Lucia', 'Ramirez', '1969-08-17', 2, '00112233', 'paciente6@clinic.com', '1010101010', 4, 1),
('Emilio', 'Torres', '2005-09-10', 1, '11223344', 'paciente7@clinic.com', '1111111112', 4, 1),
('Emilia', 'Flores', '1998-04-22', 2, '22334455', 'paciente8@clinic.com', '2222222223', 4, 1);

INSERT INTO Personas (Nombre, Apellido, FechaNac, Genero, NumDoc, Correo, Telefono, Rol, Activo) VALUES
('Leonel', 'Mendez', '1978-01-15', 1, '33445566', 'profesional1@clinic.com', '3333333334', 3, 1),
('Alicia', 'Ruiz', '1982-03-20', 2, '44556677', 'profesional2@clinic.com', '4444444445', 3, 1),
('Maximiliano', 'Diaz', '1975-04-10', 1, '55667788', 'profesional3@clinic.com', '5555555556', 3, 1),
('Micaela', 'Castro', '1980-06-30', 2, '66778899', 'profesional4@clinic.com', '6666666667', 3, 1),
('Sebastian', 'Ortiz', '1976-11-05', 1, '77889900', 'profesional5@clinic.com', '7777777778', 3, 1),
('Tota', 'Morales', '1985-09-25', 2, '88990011', 'profesional6@clinic.com', '8888888889', 3, 1),
('Mauricio', 'Gimenez', '1983-08-14', 1, '99001122', 'profesional7@clinic.com', '9999999990', 3, 1),
('Lucila', 'Vargas', '1979-02-18', 2, '00112233', 'profesional8@clinic.com', '1010101011', 3, 1);

INSERT INTO Profesionales (IdPersona)
SELECT ID FROM Personas WHERE Rol = 3;

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


CREATE TABLE Horarios(
    Id SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdProfesional SMALLINT NOT NULL FOREIGN KEY REFERENCES Profesionales(ID),
    DayOfWeek SMALLINT NOT NULL,
    HoraInicio SMALLINT NOT NULL,
    HoraFin SMALLINT NOT NULL
)

INSERT INTO Horarios (IdProfesional, DayOfWeek, HoraInicio, HoraFin)
VALUES
--

(1, 1, 9, 12),  -- Profesional 1, Lunes, 09:00-12:00        LEONEL
(1, 3, 9, 12),  -- Profesional 1, Miércoles, 09:00-12:00    
(2, 2, 14, 18), -- Profesional 2, Martes, 14:00-18:00       ALICIA
(3, 4, 10, 15), -- Profesional 3, Jueves, 10:00-15:00       MAXIMILIANO
(3, 5, 15, 18), -- Profesional 3, Viernes, 15:00-18:00
(4, 1, 9, 14),  -- Profesional 4, Lunes, 09:00-14:00        MICAELA
(4, 5, 14, 18), -- Profesional 4, Viernes, 14:00-18:00
(5, 2, 16, 20), -- Profesional 5, Martes, 16:00-20:00       SEBASTIAN
(5, 4, 9, 13),  -- Profesional 5, Jueves, 09:00-13:00
(6, 6, 8, 14), -- Profesional 6, Sabado, 08:00-14:00        TOTA
(7, 3, 13, 17), -- Profesional 7, Miercoles, 13:00-17:00    MAURICIO
(8, 1, 9, 12),  -- Profesional 8, Lunes, 09:00-12:00        LUCILA
(8, 3, 9, 12), -- Profesional 8, Miercoles, 09:00-12:00     LUCILA
(8, 5, 9, 12); -- Profesional 8, Viernes, 09:00-12:00       LUCILA

-- Drop Table Turnos

CREATE TABLE Turnos(
    Id smallint not null PRIMARY KEY IDENTITY(1,1),
    IdProfesional SMALLINT NOT NULL FOREIGN KEY REFERENCES Profesionales(ID),
    IdPaciente SMALLINT NOT NULL FOREIGN KEY REFERENCES Personas(ID),
    FechaTurno DATE not null,
    HoraTurno smallint not null,
    IdEspecialidad SMALLINT not null FOREIGN KEY REFERENCES Especialidades(ID),
    Estado smallint not null,
    -- ('ABIERTO')      0
    -- ('CERRADO')      1
    -- ('CANCELADO')    2
    -- ('AUSENTE')      3
    Observaciones varchar(100)
)

-- Turnos de prueba

INSERT INTO Turnos(IdProfesional,IdPaciente,FechaTurno,HoraTurno,IdEspecialidad,Estado,Observaciones)
VALUES
(2,6,'2024-07-09',16,3,1,'Examen ok, vuelve a control en 1 año'),
-- Dra Alicia
-- Paciente Josefina
-- TURNO 09/0/24, 16:00
-- Neurologia,
-- ESTADO TURNO: CERRADO (1)

(8,8,'2024-07-12',9,7,0,'');
-- Dra Lucila
-- Paciente Delfina
-- Turno 12/07/24, 09:00
-- Oftalmologia,
-- ESTADO TURNO: ABIERTO (0)

INSERT INTO Turnos(IdProfesional,IdPaciente,FechaTurno,HoraTurno,IdEspecialidad,Estado,Observaciones)
VALUES
(2,6,'2024-07-09',16,3,1,'Examen ok, vuelve a control en 1 año')


-- DROP TABLE Turnos
select * from Turnos

-- Consulta para listar turnos!
select T.Id as Id,T.IdProfesional as IdProfesional,Per.Nombre as NombreProfesional,Per.Apellido as ApellidoProfesional,T.IdPaciente as IdPaciente,P.Nombre as NombrePaciente,P.Apellido as ApellidoPaciente,E.Nombre as EspecialidadTurno,T.Estado as Estado,T.FechaTurno as FechaTurno,T.HoraTurno as HoraTurno, T.Observaciones as Observaciones from Turnos T INNER JOIN Profesionales PRO ON PRO.ID=T.IdProfesional INNER JOIN Personas P ON P.ID=T.IdPaciente INNER JOIN Personas Per ON Per.ID=PRO.IdPersona INNER JOIN Especialidades E ON E.ID=T.IdEspecialidad


select * from Horarios
select * from Personas


CREATE TABLE Usuarios(
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Usuario VARCHAR(50) NOT NULL,
    Pass VARCHAR(50) NOT NULL,
    TipoUser INT NOT NULL,
    Email VARCHAR(50) NOT NULL, 	
)

INSERT INTO Usuarios(Usuario,Pass,TipoUser,Email) VALUES
('Admin','admin','1','administrador@clinic.com'),
('Recepcionista','recep','2','rececpcionista@clinic.com'),
('Medico','medico','3','profesional@clinic.com'),
('Paciente','paciente','4','paciente@clinic.com');



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
P.Genero, P.NumDoc,
P.Correo, P.Telefono,P.Activo
FROM Personas P 





--Consulta de especialidades
select E.ID,E.Nombre  from Especialidades E 

--Consulta de ProfesionalesXEspecialidad
select PXE.IDProfesional as IdProfesional,PXE.IDEspecialidad as IdEspecialidad from Profesionales_x_Especialidad PXE

--consulta de Profesionales con Nombre y Apellido
select PR.ID as ID,P.Nombre as Nombre,P.Apellido as Apellido from Profesionales PR INNER JOIN Personas P ON P.ID=PR.IdPersona

select * from Horarios

SELECT * from EstadoTurnos

select PXE.IDProfesional as IdProfesional,PXE.IDEspecialidad as IdEspecialidad from Profesionales_x_Especialidad PXE
-- where PXE.IDProfesional = 1
select * from Horarios

--Consulta de todos los horarios disponibles
select H.Id as Id,H.IdProfesional as IdProfesional,H.DayOfWeek as DayOfWeek,H.HoraInicio as HoraInicio,H.HoraFin as HoraFin FROM Horarios H

select * from Especialidades


select * from Personas

select * from Profesionales


SELECT PR.ID AS ID, P.Nombre, P.Apellido, P.FechaNac, P.NumDoc, P.Correo, P.Telefono, P.Activo, E.Nombre AS Especialidad
FROM Profesionales PR
INNER JOIN Personas P ON P.ID = PR.IdPersona
LEFT JOIN Profesionales_x_Especialidad PXE ON PR.ID = PXE.IDProfesional
LEFT JOIN Especialidades E ON PXE.IDEspecialidad = E.Id


SELECT PR.ID AS ID, P.Nombre, P.Apellido, P.FechaNac, P.NumDoc, P.Correo, P.Telefono, P.Activo
FROM Profesionales PR
INNER JOIN Personas P ON P.ID = PR.IdPersona
-- INNER JOIN Profesionales_x_Especialidad PXE ON PR.ID = PXE.IDProfesional
-- INNER JOIN Especialidades E ON PXE.IDEspecialidad = E.Id

    select * from Horarios


select * from Profesionales
select * from Profesionales_x_Especialidad

select * from Horarios

select H.Id as Id,H.IdProfesional as IdProfesional,H.DayOfWeek as Dia,H.HoraInicio as HoraInicio,H.HoraFin as HoraFin FROM Horarios H

select PXE.IDProfesional as IdProfesional,PXE.IDEspecialidad as IdEspecialidad from Profesionales_x_Especialidad PXE


select * from Horarios


SELECT P.ID, P.Nombre, P.Apellido, P.FechaNac, P.Genero, P.NumDoc, P.Correo, P.Telefono, P.Rol, P.Activo FROM Personas P