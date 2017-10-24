
--1
CREATE TABLE Colegio(
    idColegio int NOT NULL,
    nombreColegio varchar2(100),
    direccion varchar2(100),
    correo varchar2(100),
    telefono varchar2(20),
    PRIMARY KEY (idColegio)
);

--2
CREATE TABLE Curso(
    idCurso int NOT NULL,
    gradoCurso varchar2(25),
    letraCurso char(1),
    cantidadAlumnos int,
    idColegioFK int,
    PRIMARY KEY (idCurso),
    FOREIGN KEY (idColegioFK) REFERENCES Colegio(idColegio)
);

--3
CREATE TABLE TipoUsuario(
    idTipoUsuario int NOT NULL,
    rol varchar2(25),
    PRIMARY KEY (idTipoUsuario)
);

--4
CREATE TABLE Usuario(
    correo varchar2(100) NOT NULL,
    clave varchar2(100),
    idTipoUsuarioFK int,
    PRIMARY KEY (correo),
    FOREIGN KEY (idTipoUsuarioFK) REFERENCES TipoUsuario(idTipoUsuario)
);

--5
CREATE TABLE Apoderado(
    idApoderado int NOT NULL,
    rut varchar2(11),
    nombre varchar2(100),
    apellidoP varchar2(100),
    apellidoM varchar2(100),
	direccion varchar2(100),
	telefono varchar2(20),
	sexo char(1),
	fechaNacimiento date,
    montoPagar int,
    idColegioFK int,
    idCursoFK int,
    correoFK varchar2(100),
    PRIMARY KEY (idApoderado),
    FOREIGN KEY (idCursoFK) REFERENCES Curso(idCurso),
    FOREIGN KEY (idColegioFK) REFERENCES Colegio(idColegio), --Para el detalle de reporte del gerente
    FOREIGN KEY (correoFK) REFERENCES Usuario(correo)
);

--6
CREATE TABLE Ejecutivo(
    idEjecutivo int NOT NULL,
    rut varchar2(11),
    nombre varchar2(100),
    apellidoP varchar2(100),
    apellidoM varchar2(100),
    correoFK varchar2(100),
	idCursoFK int,
    PRIMARY KEY (idEjecutivo),
    FOREIGN KEY (correoFK) REFERENCES Usuario(correo),
	FOREIGN KEY (idCursoFK) REFERENCES Curso(idCurso)
);

--7
CREATE TABLE Deposito(
    idDeposito int NOT NULL,
    monto int,
    fecha date,
    comentario varchar2(500),
    nombreImagen varchar2(100),
    correoFK varchar2(100),
    PRIMARY KEY (idDeposito),
    FOREIGN KEY (correoFK) REFERENCES Usuario(correo)
);

--8
CREATE TABLE PaqueteTuristico(
    idPaqueteTuristico int NOT NULL,
    origen varchar2(100),
    destino varchar2(100),
	dias int,
	noches int,
    precioPorAlumno int,
    proveedorTransporte varchar2(100),
    proveedorAlojamiento varchar2(100),
    PRIMARY KEY (idPaqueteTuristico)
);

--9
CREATE TABLE Contrato(
    idContrato int NOT NULL,
    fecha date,
    comentario varchar2(4000),
    isActivo number(1),
    idCursoFK int,
    idEjecutivoFK int,
    idPaqueteTuristicoFK int,
    PRIMARY KEY (idContrato),
    FOREIGN KEY (idCursoFK) REFERENCES Curso(idCurso),
    FOREIGN KEY (idEjecutivoFK) REFERENCES Ejecutivo(idEjecutivo),
    FOREIGN KEY (idPaqueteTuristicoFK) REFERENCES PaqueteTuristico(idPaqueteTuristico)
);

--10
CREATE TABLE Actividad(
    idActividad int NOT NULL,
    descripcion varchar2(100),
    montoRecaudado int,
	fecha date,
    idCursoFK int,
    PRIMARY KEY (idActividad),
    FOREIGN KEY (idCursoFK) REFERENCES Curso(idCurso)
);

