USE SP_MEDICAL_GROUP

INSERT INTO CLINICA(nomeFantasia,razaoSocial,endereco,CNPJ)
VALUES ('CLinica Possarle','SP Medical Group','Av. Barão Limeira-532-São Paulo-SP
','86.400.902/0001-30');

INSERT INTO TIPOUSUARIO(tipoUsuario)
VALUES ('Administrador'),('Médico'),('Paciente');

INSERT INTO ESPECIALIDADE(tipoEspecialidade)
VALUES ('Acupuntura
'),(' Anestesiologia
'),(' Angiologia
'),(' Cardiologia
'),(' Cirurgia Cardiovascular
'),(' Cirurgia da Mão
'),(' Cirurgia do Aparelho Digestivo
'),(' Cirurgia Geral
'),(' Cirurgia Pediátrica
'),(' Cirurgia Plástica
'),(' Cirurgia Torácica
'),(' Cirurgia Vascular
'),(' Dermatologia
'),(' Radioterapia
'),(' Urologia
'),(' Pediatria
'),('Psiquiatria');

INSERT INTO SITUACAO(tipoSituacao)
VALUES ('Realizada'),('Cancelada'),('Agendada')

INSERT INTO USUARIO(email,senha)
VALUES ('ligia@gmail.com','123456
'),(
'alexandre@gmail.com','234567
'),(
'fernando@gmail.com','345678
'),(
'henrique@gmail.com','456789
'),(
'joao@hotmail.com','567900
'),(
'bruno@gmail.com','679011
'),(
'mariana@outlook.com','790122
'),(
'ricardo.lemos@spmedicalgroup.com.br','901233
'),(
'roberto.possarle@spmedicalgroup.com.br','101234
'),(
'helena.souza@spmedicalgroup.com.br','11234
');

INSERT INTO PACIENTE(nome,dataNascimento,telefone,RG,CPF,endereco)
VALUES ('Ligia,10/13/1983','11 3456-7654','43522543-5','94839859000','Rua Estado de Israel- 240- São Paulo- Estado de São Paulo/04022-000'),('
Alexandre','7/23/2001','11 98765-6543','32654345-7','73556944057','Av. Paulista- 1578 - Bela Vista- São Paulo - SP/01310-200'),('
Fernando','10/10/1978','11 97208-4453','54636525-3','16839338002','Av. Ibirapuera - Indianópolis- 2927-  São Paulo - SP/04029-200'),('
Henrique','10/13/1985','11 3456-6543','54366362-5','14332654765,'R. Vitória- 120 - Vila Sao Jorge- Barueri - SP/06402-030'
),0('
Joã1YU8''o','8/27/1975','11 7656-6377','53254444-1','91305348010','R. Ver. Geraldo de Camargo- 66 - Santa Luzia- Ribeirão Pires - SP/09405-380'),('
Bruno','3/21/1972','11 95436-8769','54566266-7','79799299004','Alameda dos Arapanés- 945 - Indianópolis, São Paulo - SP/04524-001'),('
Mariana','03/05/2018',NULL,'54566266-8','13771913039','R Sao Antonio- 232 - Vila Universal- Barueri - SP/06407-140');

INSERT INTO MEDICO(nome,CM)
VALUES ('Ricardo Lemos,54356-SP'),('
Roberto Possarle,53452-SP'),('
Helena Strada,65463-SP');

INSERT INTO CONSULTA(dataConsulta)
VALUES ('01/02/2020 15:00')('
01/06/2020 10:00')('
02/07/2020 11:00')('
02/06/2018 10:00')('
02/07/2019 11:00')('
03/08/2020 15:00')('
03/09/2020 11:00');