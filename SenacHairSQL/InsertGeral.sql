
INSERT INTO tblSituacao (situacao) VALUES 
  ('Agendada'),
  ('Efetivada'),
  ('Cancelada');


INSERT INTO tblProcedimento (procedimento, valor) VALUES  
  ('Corte de cabelo', 40), 
  ('Penteado', 80),
  ('Tintura de cabelo', 100),
  ('Descoloração', 120),
  ('Alisamento e escova progressiva', 150),
  ('Hidratação capilar', 50),
  ('Reconstrução capilar', 70),
  ('Escova', 50),
  ('Ondas e cachos', 60),
  ('Selagem capilar', 90),
  ('Cauterização', 100),
  ('Mechas', 120),
  ('Reflexos', 110),
  ('Ombré hair', 140),
  ('Californiana', 130),
  ('Corte com tesoura', 50),
  ('Corte com navalha', 60),
  ('Relaxamento', 90),
  ('Permanente', 110),
  ('Toning (matização)', 60),
  ('Corte de cabelo masculino', 40),
  ('Design de barba', 30),
  ('Raspar a barba', 20),
  ('Aparar a barba', 25),
  ('Sobrancelhas', 20),
  ('Hidratação facial', 50),
  ('Shave (barbeiro tradicional)', 35),
  ('Massagem facial', 40),
  ('Massagem do couro cabeludo', 30),
  ('Corte com tesoura e navalha', 60),
  ('Limpeza de pele masculina', 70),
  ('Tratamento para acne', 80),
  ('Tratamento para cabelo e couro cabeludo', 90),
  ('Coloração de barba', 40),
  ('Desembaraço de barba', 25),
  ('Remodelagem de barba', 35);

INSERT INTO tblFormaPagamento (FormaPagamento) VALUES  
  ('Dinheiro'), 
  ('PIX'),
  ('Débito'),
  ('Crédito');

INSERT INTO tblCliente (nome, cpf, celular) VALUES 
  ('Maria Silva', '12345678901', '11999999999'),
  ('João Souza', '23456789012', '21988888888'),
  ('Ana Costa', '34567890123', '31977777777'),
  ('Pedro Rocha', '45678901234', '41966666666'),
  ('Carla Lima', '56789012345', '51955555555');


INSERT INTO tblCabeleireiro (nome, email, telefone) VALUES 
  ('Fernanda Oliveira', 'fernanda@salao.com', '1122222222'),
  ('Ricardo Santos', 'ricardo@salao.com', '2133333333'),
  ('Juliana Pereira', 'juliana@salao.com', '3144444444');


SET DATEFORMAT ymd;

INSERT INTO tblAgendamento (data, idSituacao, idCliente, idCabeleireiro) VALUES
	('2025-02-10 12:00:00.000', 1, 1, 1),
	('2025-02-10 11:00:00.000', 2, 2, 2),
	('2025-02-11 10:00:00.000', 3, 3, 3),
	('2025-02-12 09:00:00.000', 1, 4, 1),
	('2025-02-12 11:00:00.000', 2, 5, 2),
	('2025-02-12 12:00:00.000', 3, 4, 3),
	('2025-02-12 13:00:00.000', 2, 5, 1),
	('2025-02-13 11:00:00.000', 1, 1, 3),
	('2025-02-13 12:00:00.000', 2, 2, 1),
	('2025-02-14 13:00:00.000', 1, 3, 2),
	('2025-02-11 09:00:00.000', 1, 1, 1),
	('2025-02-11 10:00:00.000', 2, 2, 2),
	('2025-02-11 11:00:00.000', 3, 3, 3),
	('2025-02-12 09:00:00.000', 1, 4, 1),
	('2025-02-12 10:00:00.000', 2, 5, 2),
	('2025-02-12 11:00:00.000', 3, 4, 3),
	('2025-02-12 12:00:00.000', 2, 5, 1),
	('2025-02-13 09:00:00.000', 1, 1, 3),
	('2025-02-13 10:00:00.000', 2, 2, 1),
	('2025-02-13 11:00:00.000', 3, 3, 2),
	('2025-02-13 12:00:00.000', 1, 1, 2),
	('2025-02-14 09:00:00.000', 2, 2, 3),
	('2025-02-14 10:00:00.000', 3, 3, 1),
	('2025-02-14 11:00:00.000', 1, 4, 2),
	('2025-02-14 12:00:00.000', 2, 5, 3),
	('2025-02-14 13:00:00.000', 3, 1, 1),
	('2025-02-14 14:00:00.000', 1, 2, 2),
	('2025-02-14 15:00:00.000', 2, 3, 3),
	('2025-02-14 16:00:00.000', 3, 4, 1),
	('2025-02-14 17:00:00.000', 1, 5, 2);


INSERT INTO tblAgendamentoProcedimento (idAgendamento, idProcedimento) VALUES
  (1, 1), (1, 5),
  (2, 3),
  (3, 2), (3, 4),
  (4, 6),
  (5, 7), (5, 8), (5, 9),
  (6, 10),
  (7, 12),
  (8, 15),
  (9, 20),
  (10, 25), (10, 30);


INSERT INTO tblPagamento (valor, idAgendamento, idFormaPagamento) VALUES
  (190.00, 1, 1),
  (100.00, 2, 2),
  (200.00, 3, 3),
  (50.00, 4, 4),
  (180.00, 5, 1),
  (90.00, 6, 2),
  (120.00, 7, 3),
  (130.00, 8, 4),
  (60.00, 9, 1),
  (80.00, 10, 2);


INSERT INTO tblUsuario (login, nome, password, ativo) VALUES
  ('fernanda', 'Fernanda Oliveira', '4c29f94d61f96dde64a65202a6de6700', 1),
  ('ricardo', 'Ricardo Santos', '4c29f94d61f96dde64a65202a6de6700', 1),
  ('juliana', 'Juliana Pereira', '4c29f94d61f96dde64a65202a6de6700', 1),
  ('william', 'William Torres', '4c29f94d61f96dde64a65202a6de6700', 1),
  ('a', 'Testador', '0cc175b9c0f1b6a831c399e269772661', 1);
