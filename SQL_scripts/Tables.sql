---------------------------------------- Tabelas ----------------------------------------------------

CREATE TABLE Funcionario (

	func_ID			INT			CHECK(func_ID > 0)	NOT NULL,
	primeiroNome	CHAR(15)						NOT NULL,
	ultimoNome		CHAR(15)						NOT NULL,
	genero			CHAR(1)							NOT NULL,	-- F ou M	
	morada			CHAR(40),
	dataNascimento	DATE,
	email			CHAR(30)						NOT NULL,
	noTelefone		CHAR(9)							NOT NULL,
	salary			SMALLMONEY	CHECK(salary > 0),		
	tipo			CHAR(1)							NOT NULL	-- M - Medico; R - Rececionista, E - Enfermeiro

	PRIMARY KEY (func_ID)
);

CREATE TABLE Departamento (
	nome_dept			CHAR(20)	NOT NULL,
	ID_dept				SMALLINT	CHECK(ID_dept > 0)		NOT NULL,
	ID_supervisor_dept	INT			,	

	PRIMARY KEY (ID_dept),
	-- FOREIGN KEY (ID_supervisor_dept) REFERENCES Medico (func_ID_Medico)  
);


CREATE TABLE Medico (
	func_ID_Medico		INT				NOT NULL,
	ID_dept				SMALLINT		NOT NULL,

	PRIMARY KEY (func_ID_Medico),
	FOREIGN KEY (func_ID_Medico) REFERENCES Funcionario(func_ID),
	FOREIGN KEY (ID_dept)	REFERENCES Departamento(ID_dept)
);

CREATE TABLE Especializacao_Medico (
	func_ID_Medico		INT			NOT NULL,
	especializacao		CHAR(20)	NOT NULL,

	PRIMARY KEY (especializacao,func_ID_Medico), 
	FOREIGN KEY (func_ID_Medico) REFERENCES Medico(func_ID_Medico)
);

CREATE TABLE Enfermeiro (
	func_ID_Enf		INT		NOT NULL,
	ID_dept			SMALLINT		NOT NULL,

	PRIMARY KEY (func_ID_Enf),
	FOREIGN KEY (func_ID_Enf) REFERENCES Funcionario(func_ID),
	FOREIGN KEY (ID_dept)	REFERENCES Departamento(ID_dept)
);

-- VER MELHOR
-- Não sei se faz sentido ter um rececionista !!
CREATE TABLE Rececionista (
	func_ID_Rec		INT		NOT NULL,
	Balcao			CHAR(1)		NOT NULL,

	PRIMARY KEY (func_ID_Rec),
	FOREIGN KEY (func_ID_Rec) REFERENCES Funcionario(func_ID)
);

CREATE TABLE Quarto_Hospital (
	ID_Quarto		INT	  NOT NULl,
	noCamas			SMALLINT	CHECK (noCamas > 0)   NOT NULl,

	PRIMARY KEY (ID_Quarto),
);

CREATE TABLE Paciente (
	noUtenteSaude	INT		CHECK (noUtenteSaude > 0)   NOT NULl,
	primeiroNome	CHAR(15)	NOT NULL,
	ultimoNome		CHAR(15)	NOT NULL,
	dataNascimento	DATE		NOT NULL,
	genero			CHAR(1)		NOT NULL,	-- F ou M	
	noTelefone		INT			NOT NULL,
	func_ID_Rec		INT		NOT NULL,
	ID_Quarto		INT,
	dataEntrada		DATE,				-- Pode ser null, se a cama não estiver a ser usada
	dataSaida		DATE,				-- Pode ser null, pq pode-se não saber o dia de saída/alta da pessoa
	

	PRIMARY KEY (noUtenteSaude),
	FOREIGN KEY (func_ID_Rec)	REFERENCES Rececionista(func_ID_Rec),
	FOREIGN KEY (ID_Quarto) REFERENCES Quarto_Hospital(ID_Quarto)
);


CREATE TABLE Cama_Hospital (
	ID_Cama		CHAR(20)   NOT NULl,
	camaOcupada	BIT		NOT NULL,		-- 0 : live , 1: ocupado
	ID_Quarto	INT		,				-- Pode ser null, se a cama não estiver a ser usada

	PRIMARY KEY (ID_Cama),
	FOREIGN KEY (ID_Quarto) REFERENCES Quarto_Hospital (ID_Quarto)
);


CREATE TABLE Enf_Auxilia (
	func_ID_Enf		INT		NOT NULL,
	noUtenteSaude	INT	   NOT NULl,

	PRIMARY KEY (func_ID_Enf, noUtenteSaude),
	FOREIGN KEY (func_ID_Enf)	REFERENCES Enfermeiro(func_ID_Enf),
	FOREIGN KEY (noUtenteSaude)	REFERENCES Paciente(noUtenteSaude)
);


CREATE TABLE Enf_Supervisiona (
	func_ID_EnfS	INT			NOT NULL,
	ID_Cama_EnfS	CHAR(20)	NOT NULL,

	PRIMARY KEY (func_ID_EnfS, ID_Cama_EnfS),
	FOREIGN KEY (func_ID_EnfS)	REFERENCES Enfermeiro(func_ID_Enf),
	FOREIGN KEY (ID_Cama_EnfS)	REFERENCES Cama_Hospital (ID_Cama)
);

CREATE TABLE Consulta (
	func_ID_Medico		INT			NOT NULL,
	noUtenteSaude		INT			,
	noConsulta			INT		CHECK (noConsulta > 0)   NOT NULl,
	dataConsulta		DATE		,
	hora				CHAR(10)	,	-- ex: 2 PM, 10h30 AM ...

	PRIMARY KEY (noConsulta, func_ID_Medico),
	FOREIGN KEY (func_ID_Medico) REFERENCES  Medico(func_ID_Medico),
	FOREIGN KEY (noUtenteSaude)	REFERENCES Paciente(noUtenteSaude)
);

CREATE TABLE Farmaco (
	codigo					INT		NOT NULL,
	nome					CHAR(20)		NOT NULL,
	custo					INT,

	PRIMARY KEY (codigo)
);

CREATE TABLE Prescreve (
	func_ID_Medico		INT			NOT NULL,
	noConsulta			INT			NOT NULl,
	codigo_Farmaco		INT			NOT NULL,
	qtdCaixa			INT		CHECK(qtdCaixa > 0 )  NOT NULL,	 -- 1 caixa, 2 ...

	PRIMARY KEY (func_ID_Medico, noConsulta, codigo_Farmaco), 
	FOREIGN KEY (noConsulta, func_ID_Medico) REFERENCES  Consulta(noConsulta, func_ID_Medico),
	FOREIGN KEY (codigo_Farmaco) REFERENCES Farmaco (codigo)

);

CREATE TABLE Bloco_Operatorio (
	noBloco		INT		CHECK (noBloco > 0)  NOT NULL,
	utilizacao	BIT		NOT NULL,	-- 0: livre , 1 : ocupado

	PRIMARY KEY (noBloco)
);

CREATE TABLE Equipa_Medica (
	equipaM_ID				INT		CHECK (equipaM_ID > 0)  NOT NULL,
	Super_func_ID_Medico	INT		NOT NULL,

	PRIMARY KEY (equipaM_ID),
	FOREIGN KEY (Super_func_ID_Medico)	REFERENCES Medico (func_ID_Medico),
);

CREATE TABLE Cirurgia (
	tipoCirurgia		CHAR(40)		NOT NULL,
	dataCirurgia		DATE			,
	Hora_Inicio			CHAR(10)		,
	Duracao				CHAR(5)			,
	EquipaM_ID			INT				NOT NULL,
	noBlocoOperatorio	INT				NOT NULL,
	noUtenteSaude		INT				,

	PRIMARY KEY (tipoCirurgia),
	FOREIGN KEY (noBlocoOperatorio)	REFERENCES Bloco_Operatorio (noBloco),
	FOREIGN KEY (noUtenteSaude)	REFERENCES Paciente (noUtenteSaude),
	FOREIGN KEY (EquipaM_ID)	REFERENCES Equipa_Medica (EquipaM_ID)
);

CREATE TABLE EM_contemEnf (
	func_ID_Enf		INT		NOT NULL,
	EquipaM_ID		INT				NOT NULL,

	PRIMARY KEY (func_ID_Enf, EquipaM_ID),
	FOREIGN KEY (func_ID_Enf)	REFERENCES Enfermeiro (func_ID_Enf),
	FOREIGN KEY (EquipaM_ID)	REFERENCES Equipa_Medica (EquipaM_ID)
);

CREATE TABLE EM_contemMed (
	func_ID_Medico		INT		NOT NULL,
	EquipaM_ID			INT				NOT NULL,

	PRIMARY KEY (func_ID_Medico, EquipaM_ID),
	FOREIGN KEY (func_ID_Medico)	REFERENCES Medico (func_ID_Medico),
	FOREIGN KEY (EquipaM_ID)	REFERENCES Equipa_Medica (EquipaM_ID)
);


ALTER TABLE Departamento ADD FOREIGN KEY (ID_supervisor_dept) REFERENCES Medico (func_ID_Medico) ;





