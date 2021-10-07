USE T_InLock_Games_Jhon;
GO

--Listar todos os USUARIOS
SELECT U.idUsuario,U.email,U.idTipoUsuario,TU.titulo FROM usuario U
INNER JOIN tipoUsuario TU
ON U.idTipoUsuario = TU.IdTipoUsuario;
GO

--Lista todos os estudios
SELECT idEstudio, nomeEstudio FROM ESTUDIO;

--Listar todos os jogos
SELECT idJogo nomeJogo, descricao, dataLancamento, valor, idEstudio FROM JOGO;
GO

--Lista todos os jogos e seus respectivos estúdios
SELECT J.idEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, E.nomeEstudio FROM JOGO J
INNER JOIN ESTUDIO E
ON J.idEstudio = E.idEstudio;
GO

--Lista todos os estúdios e seus repectivos jogos
SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento,J.valor
FROM ESTUDIO E
LEFT JOIN JOGO J
ON E.idEstudio = J.idEstudio

--Busca um usuário por email e senha (login)
SELECT U.idUsuario, U.email, TU.idTipoUsuario, TU.titulo FROM USUARIO U
INNER JOIN TIPOUSUARIO TU
ON U.idTipoUsuario = U.idTipoUsuario
WHERE email = 'admin@admin.com' AND senha = 'admin';
GO

--Buscar um jogo por idJogo
SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor FROM ESTUDIO E 
INNER JOIN JOGO J
ON E.idEstudio = J.idEstudio
WHERE J.idJogo = 1;
GO

--Buscar um estúdio por idEstúdio
SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM JOGO J
INNER JOIN ESTUDIO E 
ON J.idEstudio = E.idEstudio
WHERE E.idEstudio = 1;
GO

SELECT * FROM JOGO