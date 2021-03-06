CREATE DATABASE T_Rental_Jhon;
GO

USE T_Rental_Jhon;
GO

CREATE TABLE LOCADORA(
 idLocadora TINYINT PRIMARY KEY IDENTITY,
 nomeFantasia VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE CLIENTE(
 idCliente SMALLINT PRIMARY KEY IDENTITY,
 nomeCliente VARCHAR(100) NOT NULL,
 CPF VARCHAR(16) NOT NULL UNIQUE
);
GO

ALTER TABLE CLIENTE
ADD idLocadora TINYINT FOREIGN KEY REFERENCES LOCADORA(idLocadora);
GO

ALTER TABLE CLIENTE 
ADD sobrenomeCliente VARCHAR(50)
GO

CREATE TABLE MARCA(
 idMarca TINYINT PRIMARY KEY IDENTITY,
 marca VARCHAR(25) NOT NULL UNIQUE,
);
GO

CREATE TABLE MODELO(
 idModelo SMALLINT PRIMARY KEY IDENTITY,
 idMarca TINYINT FOREIGN KEY REFERENCES MARCA(idMarca),
 modelo VARCHAR(30) NOT NULL
);
GO

CREATE TABLE VEICULO(
 idVeiculo SMALLINT PRIMARY KEY IDENTITY,
 idModelo SMALLINT FOREIGN KEY REFERENCES MODELO(idModelo),
 idLocadora TINYINT FOREIGN KEY REFERENCES LOCADORA(idLocadora),
 placa VARCHAR(13) NOT NULL UNIQUE,
);
GO

CREATE TABLE ALUGUEL(
 idAluguel SMALLINT PRIMARY KEY IDENTITY,
 idVeiculo SMALLINT FOREIGN KEY REFERENCES VEICULO(idVeiculo),
 idCliente SMALLINT FOREIGN KEY REFERENCES CLIENTE(idCliente),
 dataRetirada DATETIME NOT NULL,
 dataDevolucao DATETIME NOT NULL
);
GO