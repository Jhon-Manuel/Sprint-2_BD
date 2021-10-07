CREATE DATABASE SP_MEDICAL_GROUP

USE SP_MEDICAL_GROUP

CREATE TABLE CLINICA(
 idClinica TINYINT PRIMARY KEY IDENTITY,
 nomeFantasia VARCHAR(100) NOT NULL UNIQUE,
 razaoSocial VARCHAR(100) NOT NULL UNIQUE,
 endereco VARCHAR(150) NOT NULL UNIQUE,
 CNPJ VARCHAR(25) NOT NULL UNIQUE
);

CREATE TABLE TIPOUSUARIO(
 idTipoUsuario SMALLINT PRIMARY KEY IDENTITY,
 tipoUsuario VARCHAR(80) NOT NULL UNIQUE,
);

CREATE TABLE ESPECIALIDADE(
 idEspecialidade TINYINT PRIMARY KEY IDENTITY,
 tipoEspecialidade VARCHAR(80) NOT NULL UNIQUE,
);

CREATE TABLE SITUACAO(
 idSituacao TINYINT PRIMARY KEY IDENTITY,
 tipoSituacao VARCHAR(15) NOT NULL UNIQUE,
);

CREATE TABLE USUARIO(
 idUsuario SMALLINT PRIMARY KEY IDENTITY,
 idTipoUsuario SMALLINT FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario),
 idClinica TINYINT FOREIGN KEY REFERENCES CLINICA(idClinica),
 email VARCHAR(100) NOT NULL UNIQUE,
 senha VARCHAR(8) NOT NULL UNIQUE
);

CREATE TABLE PACIENTE(
 idPaciente SMALLINT PRIMARY KEY IDENTITY,
 idUsuario SMALLINT FOREIGN KEY REFERENCES USUARIO(idUsuario),
 nome VARCHAR(100) NOT NULL UNIQUE,
 dataNascimento VARCHAR(10) NOT NULL UNIQUE,
 telefone VARCHAR(15) NOT NULL UNIQUE,
 RG VARCHAR(20) NOT NULL UNIQUE,
 endereco VARCHAR(120) NOT NULL UNIQUE
);

CREATE TABLE MEDICO(
 idMedico TINYINT PRIMARY KEY IDENTITY,
 idUsuario SMALLINT FOREIGN KEY REFERENCES USUARIO(idUsuario),
 idEspecialidade TINYINT FOREIGN KEY REFERENCES ESPECIALIDADE(idEspecialidades),
 nome VARCHAR(100) NOT NULL UNIQUE, 
 CM VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE CONSULTA(
 idConsulta SMALLINT PRIMARY KEY IDENTITY,
 idPaciente SMALLINT FOREIGN KEY REFERENCES PACIENTE(idPaciente),
 idMedico TINYINT FOREIGN KEY REFERENCES MEDICO(idMedico),
 idSituacao TINYINT FOREIGN KEY REFERENCES SITUACAO(idSituacao),
 dataConsulta DATE NOT NULL,
);
 