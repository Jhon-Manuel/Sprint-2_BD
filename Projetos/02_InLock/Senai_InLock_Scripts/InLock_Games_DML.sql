USE T_InLock_Games_Jhon;
GO

INSERT INTO ESTUDIO(nomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix');
GO

INSERT INTO JOGO(idEstudio,nomeJogo,descricao,dataLancamento,valor)
VALUES (1,'Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�','20120415',' 99.00 '),
	   (2,'Red Dead Redemption II','Jogo eletr�nico de a��o-aventura werstern','20180626',' 120.00');
GO

INSERT INTO TIPOUSUARIO(titulo)
VALUES ('Administrador'),('Cliente');
GO

INSERT INTO USUARIO(idTipoUsuario, email, senha)
VALUES (1,'admin@admin.com','admin'),(2,'cliente@cliente.com','cliente');
GO
