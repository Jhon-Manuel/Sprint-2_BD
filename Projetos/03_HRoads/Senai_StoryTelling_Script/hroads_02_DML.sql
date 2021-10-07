

INSERT INTO CLASSE(nome)
VALUES ('Barbáro'),('Cruzado'),('Caçador'),('Monge'),('Necromancer'),('Feiticeiro'),('Arcanista');

INSERT INTO PERSONAGEM(nome,capmaxVida,capmaxMana,idClasse,dataCriacao,dataAtualizacao)
VALUES ('DeuBug',100,80,1,'20210809 15:05',NULL),('BitBug',70,100,5,'20210809 15:08',NULL),('Fer8',75,60,7,'20210809 15:11',NULL);

INSERT INTO TIPOHABILIDADE(nome)
VALUES ('Ataque'),('Defesa'),('Cura'),('Magia');

INSERT INTO HABILIDADE(nome,idtipoHabilidade,idClasse)
VALUES ('Lança Mortal',1,1),('Escudo Mortal',2,1),('Recuperar Vida',3,4),('Escudo Supremo',2,4),(NUll,NULL,7);
