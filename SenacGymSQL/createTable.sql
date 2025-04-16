
CREATE TABLE tblUsuario (
id int identity primary key,
login varchar(100),
nome varchar(100),
password varchar(32),
ativo bit
)

CREATE TABLE tblAluno (
    id                    INT IDENTITY(1,1) PRIMARY KEY,             -- ID único para cada aluno
    nome                  VARCHAR(100) NOT NULL,					 -- Nome do aluno
    telefone			  VARCHAR(15),                               -- Telefone
    dataNascimento        DATE,                                      -- Data de nascimento do aluno
    email				  VARCHAR(100) UNIQUE,                       -- Email do aluno
	ativoAte			  DATE										 -- Até quando o aluno estará ativo
);


CREATE TABLE tblImc (
    id                     INT IDENTITY(1,1) PRIMARY KEY,            -- ID único para cada IMC
    idAluno                INT NOT NULL,                             -- Chave estrangeira para o aluno
    peso                   DECIMAL(5,2) NOT NULL,                    -- Peso em kg, com precisão de 2 casas decimais
    altura                 DECIMAL(5,2) NOT NULL,                    -- Altura em metros, com precisão de 2 casas decimais
    data                   DATE DEFAULT GETDATE(),                   -- Data do IMC
    FOREIGN KEY (idAluno) REFERENCES tblAluno(id)                    -- Relacionamento com Aluno
);



CREATE TABLE tblPlano (
    id                      INT IDENTITY(1,1) PRIMARY KEY,             -- Chave primária 'id'
    nome                    VARCHAR(50) NOT NULL,                      -- Nome do plano (ex: Diário, Mensal, etc.)
    descricao				VARCHAR(255),                              -- Descrição do plano
    valor					DECIMAL(10, 2) NOT NULL,                   -- Valor do plano
    duracao				    INT NOT NULL                               -- Duração do plano em dias
);

CREATE TABLE tblPagamento (
    id               INT IDENTITY(1,1) PRIMARY KEY,             -- ID único para cada pagamento
    idAluno          INT NOT NULL,                               -- Chave estrangeira para o aluno
    idPlano          INT NOT NULL,                               -- Chave estrangeira para o plano
    valorPagamento   DECIMAL(10, 2) NOT NULL,                   -- Valor do pagamento
    dataPagamento    DATETIME DEFAULT GETDATE(),                -- Data do pagamento
    FOREIGN KEY (idAluno) REFERENCES tblAluno(id),             -- Relacionamento com Aluno
    FOREIGN KEY (idPlano) REFERENCES tblPlano(id),              -- Relacionamento com Plano

);



CREATE TABLE tblMusculo (
    id                   INT IDENTITY(1,1) PRIMARY KEY,             -- Chave primária 'id'
    nome                 VARCHAR(100) NOT NULL
);

CREATE TABLE tblExercicio (
    id                   INT IDENTITY(1,1) PRIMARY KEY,
    nome                 VARCHAR(100) NOT NULL
);


CREATE TABLE tblAtividade (
    id                   INT IDENTITY(1,1) PRIMARY KEY,             -- Chave primária 'id'
    idMusculo            INT NOT NULL,
	idExercicio          INT NOT NULL,
	idAluno				 INT NOT NULL,
	comentario           VARCHAR(100),
	serie				 int,
	repeticao            int,
	treino			 	 varchar(100),
	FOREIGN KEY (idExercicio) REFERENCES tblExercicio(id),
	FOREIGN KEY (idMusculo)		  REFERENCES tblMusculo(id),
	FOREIGN KEY (idAluno) REFERENCES tblAluno(id),
);

