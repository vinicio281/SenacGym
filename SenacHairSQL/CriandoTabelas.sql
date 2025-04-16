-- Tabela de Clientes
create table tblCliente (
    id      int         primary key     identity,
    nome    varchar(100),
    cpf     varchar(11),
    celular varchar(15)
);

-- Tabela de Cabeleireiros
create table tblCabeleireiro (
    id      int         primary key     identity,
    nome    varchar(100),
    email   varchar(100),
    telefone varchar(15)
);

-- Tabela de Situações
create table tblSituacao (
    id      int         primary key     identity,
    situacao varchar(50)
);

-- Tabela de Agendamentos
create table tblAgendamento (
    id              int         primary key     identity,
    data            datetime,
    idSituacao      int,
    idCliente       int,
    idCabeleireiro  int,
    foreign key (idCliente) references tblCliente,
    foreign key (idSituacao) references tblSituacao,
    foreign key (idCabeleireiro) references tblCabeleireiro
);

-- Tabela de Procedimentos
create table tblProcedimento (
    id              int         primary key     identity,
    procedimento    varchar(100),
    valor           decimal(5,2)
);

-- Tabela de Relacionamento entre Agendamentos e Procedimentos
create table tblAgendamentoProcedimento (
    id              int         primary key     identity,
    idAgendamento   int,
    idProcedimento  int,
    foreign key (idAgendamento) references tblAgendamento,
    foreign key (idProcedimento) references tblProcedimento
);

-- Tabela de Formas de Pagamento
create table tblFormaPagamento (
    id              int         primary key     identity,
    formaPagamento  varchar(50)
);

-- Tabela de Pagamentos
create table tblPagamento (
    id                  int         primary key     identity,
    valor               money,
    idAgendamento       int,
    idFormaPagamento    int,
    foreign key (idFormaPagamento) references tblFormaPagamento,
    foreign key (idAgendamento) references tblAgendamento
);

-- Tabela de Usuários
create table tblUsuario (
    id      int         identity    primary key,
    login   varchar(50),
    nome    varchar(100),
    password varchar(100),
    ativo   bit
);