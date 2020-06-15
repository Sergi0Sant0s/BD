create table Cliente
(
  id SERIAL NOT NULL,
  nome    varchar(60)  not null,
  telemovel    varchar(60) not null,
	email varchar(50) not null,
  morada varchar(100) not null,
  created_at DATE,
  constraint cliente_pk primary key( id )
);

create table Seccao
(
  id SERIAL NOT NULL,
  nome varchar(20),
  constraint seccao_pk primary key( id )
);

create table Estado_Reparacao
(
  id SERIAL NOT NULL,
  nome varchar(20),
  constraint estado_reparacao_pk primary key( id )
);

create table Funcionario
(
  id SERIAL NOT NULL check( id > 0 ),
  id_seccao int not null check( id_seccao >= 0 ),
  constraint func_pk primary key( id ),
  constraint func_fk foreign key ( id_seccao ) references Seccao (id)
);

create table Veiculo
(
  matricula varchar(6) not null,
  marca varchar(15) not null,
  modelo varchar(15) not null,
  ano int not null check(ano >1800),
  cliente_id int not null ,
  constraint veiculo_pk primary key( matricula ),
  constraint veiculo_fk foreign key (cliente_id) references Cliente (id)
);

create table Fornecedor
(
  id SERIAL NOT NULL,
  nome varchar(20) not null,
  telefone int not null check(telefone>0),
  email varchar(50) not null,
  morada varchar(50) not null,
  constraint forn_pk primary key (id)
);

create table Peca
(
  id SERIAL NOT NULL,
  nome varchar(20) not null,
marca varchar(50) not null,
  modelo varchar(50) not null,
  descricao varchar(100) not null,
  constraint peca_pk primary key (id)
);

create table Stock(
	id SERIAL NOT NULL,
	id_peca int not null check(id_peca>0),
	quantidade int not null check(quantidade > 0),
	id_fornecedor int not null check(id_fornecedor>0),
	custo_venda float not null check(custo_venda>=0),
	custo_compra float not null check(custo_compra>=0),
	constraint stock_pk primary key( id ),
	constraint stock_fk foreign key (id_peca) references Peca (id),
	constraint stock_fk2 foreign key (id_fornecedor) references Fornecedor(id)
);

create table Stock_History(
	id SERIAL NOT NULL,
	id_peca int not null check(id_peca>0),
	quantidade int not null check(quantidade > 0),
	id_fornecedor int not null check(id_fornecedor>0),
	custo_venda float not null check(custo_venda>=0),
	custo_compra float not null check(custo_compra>=0),
	constraint stock_history_pk primary key( id ),
	constraint stock_history_fk foreign key (id_peca) references Peca (id),
	constraint stock_history_fk2 foreign key (id_fornecedor) references Fornecedor(id)
);


create table Tipo_Servico(
	id SERIAL NOT NULL,
	nome varchar(100) not null,
	constraint tipo_pk primary key( id )
);

create table servico(
	id SERIAL NOT NULL,
	id_TipoServico int not null,
	id_funcionario int not null,
	matricula varchar(6) not null,
	descricao varchar(100) not null,
	descricao_reparacao varchar(100),
	id_estado int not null,
	data_inicio date ,
	data_fim date ,
	created_at date not null,
	constraint servico_pk primary key( id ),
	constraint servico_fk foreign key (id_TipoServico) references tipo_servico (id),
	constraint servico_fk2 foreign key (id_funcionario) references funcionario (id),
	constraint servico_fk3 foreign key (id_estado) references estado_reparacao (id),
	constraint servico_fk4 foreign key (matricula) references veiculo (matricula)
);

create table Peca_Servico(
	id SERIAL NOT NULL,
	id_servico int not null,
	id_stock int not null,
	quantidade int not null check(quantidade>0),
	constraint pecaservico_pk primary key( id )
);


-- inserir dados na tabela tipo_servico
insert into tipo_servico(nome) values('pintura');
insert into tipo_servico(nome) values('chaparia');
insert into tipo_servico(nome) values('mecanica');
insert into tipo_servico(nome) values('eletricista');
insert into tipo_servico(nome) values('revisao');

-- inserir dados na tabela cliente
insert into cliente(nome, telemovel, email, morada, created_at) values('antonio', 918945614, 'cliente@gmail.com', 'Ponte 25 de Abril', '2020-06-15');
insert into cliente(nome, telemovel, email, morada, created_at) values('manuel', 918945614, 'cliente@gmail.com', 'Ponte 25 de Abril', '2020-06-15');
insert into cliente(nome, telemovel, email, morada, created_at) values('rodrigo', 918945614, 'cliente@gmail.com', 'Ponte 25 de Abril', '2020-06-15');
insert into cliente(nome, telemovel, email, morada, created_at) values('antonia', 918945614, 'cliente@gmail.com', 'Ponte 25 de Abril', '2020-06-15');
insert into cliente(nome, telemovel, email, morada, created_at) values('maria', 918945614, 'cliente@gmail.com', 'Avenida da Liberdade', '2010-12-07');
insert into cliente(nome, telemovel, email, morada, created_at) values('manuela', 918945614, 'cliente@gmail.com', 'Avenida da Liberdade', '2020-06-15');
insert into cliente(nome, telemovel, email, morada, created_at) values('rita', 918945614, 'cliente@gmail.com', 'Avenida da Liberdade', '2000-01-01');
insert into cliente(nome, telemovel, email, morada, created_at) values('marreco', 918945614, 'cliente@gmail.com', 'Avenida da Liberdade', '2000-06-01');
insert into cliente(nome, telemovel, email, morada, created_at) values('jervazio', 918945614, 'cliente@gmail.com', 'Avenida da Liberdade', '2010-12-07');
insert into cliente(nome, telemovel, email, morada, created_at) values('bzaina', 918945614, 'cliente@gmail.com', 'Rua das flores', '2020-06-15');
insert into cliente(nome, telemovel, email, morada, created_at) values('tiburcio', 918945614, 'cliente@gmail.com', 'Rossio da Se', '2008-01-01');
insert into cliente(nome, telemovel, email, morada, created_at) values('rui', 918945614, 'cliente@gmail.com', 'Rua dos Capelistas', '2010-12-07');
insert into cliente(nome, telemovel, email, morada, created_at) values('carlos', 918945614, 'cliente@gmail.com', 'Rua da Taxa', '2020-06-15');
insert into cliente(nome, telemovel, email, morada, created_at) values('sergio', 918945614, 'cliente@gmail.com', 'Rua Santa Margarida', '2020-06-15');
insert into cliente(nome, telemovel, email, morada, created_at) values('ze', 918945614, 'cliente@gmail.com', 'Rua do Anjo', '2010-12-07');
insert into cliente(nome, telemovel, email, morada, created_at) values('rute', 918945614, 'cliente@gmail.com', 'Rua do Anjo', '2010-12-07');
insert into cliente(nome, telemovel, email, morada, created_at) values('jusefina', 918945614, 'cliente@gmail.com', 'Rua de Sao Marcos', '2008-01-10');
insert into cliente(nome, telemovel, email, morada, created_at) values('antonio', 918945614, 'cliente@gmail.com', 'Rua de Sao Marcos', '2000-01-01');

--inserir dados na tabela de seccao
insert into seccao(nome) values('pintura');
insert into seccao(nome) values('chaparia');
insert into seccao(nome) values('mecanica');
insert into seccao(nome) values('eletricista');

--inserir dados na tabela de funcionarios
insert into funcionario(id, id_seccao) values(1,1);
insert into funcionario(id,id_seccao) values(2, 1);
insert into funcionario(id,id_seccao) values(3,2);
insert into funcionario(id,id_seccao) values(4,2);
insert into funcionario(id,id_seccao) values(5, 3);
insert into funcionario(id,id_seccao) values(6,3);
insert into funcionario(id,id_seccao) values(7,4);
insert into funcionario(id,id_seccao) values(8,4);

--inserir dados na tabela de veiculos
insert into veiculo(matricula, marca, modelo, ano, cliente_id) values ('AA00AA', 'Audi', 'A7', 2019, 10);
insert into veiculo(matricula, marca, modelo, ano, cliente_id) values ('BB00AA', 'VW', 'Golf', 2019, 1);
insert into veiculo(matricula, marca, modelo, ano, cliente_id) values ('CA00FD', 'Porche', '911', 2019, 15);
insert into veiculo(matricula, marca, modelo, ano, cliente_id) values ('AT10PO', 'Ferrari', 'F12', 2019, 11);
insert into veiculo(matricula, marca, modelo, ano, cliente_id) values ('HG93YC', 'Audi', 'Q5', 2019, 3);
insert into veiculo(matricula, marca, modelo, ano, cliente_id) values ('AA11AA', 'VW', 'Golf', 2019, 16);
insert into veiculo(matricula, marca, modelo, ano, cliente_id) values ('AA22AA', 'Skoda', 'Fabia', 2019, 10);
insert into veiculo(matricula, marca, modelo, ano, cliente_id) values ('MB3ZAS', 'Audi', 'A3', 2019, 8);

--inserir dados na tabela de fornecedores
insert into fornecedor (nome, telefone, email, morada) values('Fimag', 918945614, 'fimag@fimag.pt', 'Rua de Sao Marcos');
insert into fornecedor (nome, telefone, email, morada) values('Primo Peças', 918945614, 'primo@pecas.pt', 'Rua do Anjo');
insert into fornecedor (nome, telefone, email, morada) values('PD Auto', 918945614, 'pd@auto.pt', 'Parque Industrial de Adaufe');
insert into fornecedor (nome, telefone, email, morada) values('Stock Car', 918945614, 'stock@car.pt', 'Rua das Flores');

--inserir dados na tabela de peca
insert into peca (nome, modelo, marca, descricao) values ('Motor de Arranque', 'A7','Audi','Motor de arranque da marca Valeo para um Audi A7');
insert into peca (nome, modelo, marca, descricao) values ('Motor de Arranque', 'A7','Audi','Motor de arranque da marca Bosh para um Audi A7');
insert into peca (nome, modelo, marca, descricao) values ('Disco de travao', 'Golf','VW','Disco de travao da marca Valeo para um Golf');
insert into peca (nome, modelo, marca, descricao) values ('Escovas limpa-vidros', 'C3','Citroen','Escovas limpa vidros da marca Bosh para um Citroen C3');

--inserir dados na tabela de stock
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(1,2,1, 120.45, 90.67);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(1,14,4, 150.00, 101.99);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(2,32,3, 71.43, 32);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(2,4,1, 23.73, 11);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(2,1,2, 71.43, 32);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(3,2,1, 150.00, 101.99);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(3,2,2, 23.73, 11);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(4,4,3, 120.45, 90.67);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(4,7,1, 120.45, 90.67);
insert into stock(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(4,1,2, 23.73, 11);

insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(1,2,1, 120.45, 90.67);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(1,14,4, 150.00, 101.99);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(2,32,3, 71.43, 32);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(2,4,1, 23.73, 11);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(2,1,2, 71.43, 32);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(3,2,1, 150.00, 101.99);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(3,2,2, 23.73, 11);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(4,4,3, 120.45, 90.67);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(4,7,1, 120.45, 90.67);
insert into stock_history(id_peca, quantidade, id_fornecedor, custo_venda, custo_compra) values(4,1,2, 23.73, 11);

insert into Estado_Reparacao(nome) values('Para Reparar');
insert into Estado_Reparacao(nome) values('Em reparacao');
insert into Estado_Reparacao(nome) values('Finalizado');

--inserir dados na tabela de serviços
insert into servico(id_tiposervico, id_funcionario, matricula, descricao, id_estado, data_inicio, data_fim, created_at)
values(3, 1, 'AA22AA', 'O carro nao pega.', 2, '2020-06-15', '2020-06-16','2020-06-15');

insert into servico(id_tiposervico, id_funcionario, matricula, descricao, id_estado, created_at)
values(1,2, 'CA00FD', 'Porta do condutor e porta esquerda traseira riscada', 1,'2020-01-10');

insert into servico(id_tiposervico, id_funcionario, matricula, descricao, descricao_reparacao,id_estado, data_inicio, data_fim, created_at)
values(2, 4, 'AT10PO', 'Traseira destruida','Serviço de chaparia e pintura', 3, '2020-01-10', '2020-06-04','2020-01-10');

insert into servico(id_tiposervico, id_funcionario, matricula, descricao, descricao_reparacao, id_estado, data_inicio, data_fim, created_at)
values(5, 5, 'HG93YC', 'Revisao','Troca de oleo e filtros', 3, '2020-06-15', '2020-06-15','2020-06-15');

--inserir dados na tabela peca_servico
insert into peca_servico(id_servico, id_stock, quantidade)
values (1, 1, 1);

insert into peca_servico(id_servico, id_stock, quantidade)
values (5, 6, 2);