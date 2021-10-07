USE T_Rental_Jhon;
GO

INSERT INTO LOCADORA (nomeFantasia)
VALUES ('AutoCar');
GO

INSERT INTO CLIENTE (nomeCliente,CPF)
VALUES ('Paulo','152.751.580-09'),('Gustavo','566.478.720-19'),('Rafa','904.775.450-68')
GO

UPDATE CLIENTE 
SET idLocadora = 1


UPDATE CLIENTE
SET sobrenomeCliente = 'Mancine'
WHERE idCLiente = 3

DELETE FROM MODELO
WHERE idModelo in (4,5,6)


INSERT INTO MARCA (marca)
VALUES ('GM'),('Ford'),('Fiat');
GO

INSERT INTO MODELO (modelo,idMarca)
VALUES ('Onix',1),('Fiesta',2),('Argo',1);
GO

INSERT INTO VEICULO (idModelo,idLocadora,placa)
VALUES (2,1,'AAA'),(1,1,'BBB'),(3,1,'CCC'),(2,1,'DDD');
GO

INSERT INTO ALUGUEL (idVeiculo,idCliente,dataRetirada,dataDevolucao)
VALUES (1,1,'20210802 2:30:21PM','20210807 03:30:34PM'),(1,2,'20210803 11:21:22AM','20210820 03:43:22PM'),(2,2,'20210805 10:21:23AM','20210822 04:03:12PM');
GO




