# :::::::::::::::::::::::::::::::::
# :::::  criar base de dados  :::::
# :::::::::::::::::::::::::::::::::

CREATE DATABASE loja_informatica;

# ::::::::::::::::::::::::::::::::::
# :::::  ativar base de dados  :::::
# ::::::::::::::::::::::::::::::::::

USE loja_informatica;

# ::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela códigos postais  :::::
# ::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE codigopostal (
	id_codpostal INT PRIMARY KEY,
    codigopostal INT
);

# ::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de pagamentos  :::::
# ::::::::::::::::::::::::::::::::::::::::

CREATE TABLE pagamentos (
	id_metodopagamento INT PRIMARY KEY,
    metodos VARCHAR(100)
);

# ::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de estados de ordem  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE estadodeordem (
	id_estado INT PRIMARY KEY,
    estado VARCHAR(20)
);

# :::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de modelos de telemoveis  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE modelos (
	id_modelos INT PRIMARY KEY,
    modelo VARCHAR(20)
);

# ::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de marcas de telemoveis  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE marcas (
	id_marcas INT PRIMARY KEY,
    marca VARCHAR(20)
);

# :::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de cores de telemoveis  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE cores (
	id_cores INT PRIMARY KEY,
    cor VARCHAR(20)
);

# :::::::::::::::::::::::::::::::::::::
# :::::  criar tabela telemoveis  :::::
# :::::::::::::::::::::::::::::::::::::

CREATE TABLE telemoveis (
	id_telemovel INT PRIMARY KEY,
    id_modelos INT,
    id_marcas INT,
    id_cores INT,
    
	FOREIGN KEY (id_modelos) REFERENCES modelos(id_modelos),
	FOREIGN KEY (id_marcas) REFERENCES marcas(id_marcas),
	FOREIGN KEY (id_cores) REFERENCES cores(id_cores)
);

# ::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de cargos de funcionários  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE cargos_funcionarios (
	id_cargo INT PRIMARY KEY,
    nome_do_cargo VARCHAR(50)
);

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de especialização de funcionários  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE especializacao_funcionarios (
	id_especializacao INT PRIMARY KEY,
    nome_da_especializacao VARCHAR(50)
);

# ::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de funcionários  :::::
# ::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE funcionarios (
	id_funcionario INT PRIMARY KEY,
    id_cargo INT,
    id_especializacao INT,
    nome VARCHAR(50),
    
	FOREIGN KEY (id_cargo) REFERENCES cargos_funcionarios (id_cargo),
    FOREIGN KEY (id_especializacao) REFERENCES especializacao_funcionarios (id_especializacao) 
);

# ::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de tipos de peças  :::::
# ::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE tipo_pecas (
	id_tipopecas INT PRIMARY KEY,
    designacao VARCHAR(50)
);

# ::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de fabricantes de peças  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE fabricantes (
	id_fabricantes INT PRIMARY KEY,
    nome VARCHAR(50)
);


# :::::::::::::::::::::::::::::::::::
# :::::  criar tabela de peças  :::::
# :::::::::::::::::::::::::::::::::::

CREATE TABLE pecas (
	id_pecas INT PRIMARY KEY,
    id_tipopecas INT,
    id_fabricantes INT,
    preco DECIMAL(10,2),
    stock INT,
    
	FOREIGN KEY (id_tipopecas) REFERENCES tipo_pecas (id_tipopecas),
    FOREIGN KEY (id_fabricantes) REFERENCES fabricantes (id_fabricantes) 
);

# :::::::::::::::::::::::::::::::::::
# :::::  criar tabela clientes  :::::
# :::::::::::::::::::::::::::::::::::

CREATE TABLE clientes (
	id_cliente INT PRIMARY KEY,
    id_codpostal INT,
	nome VARCHAR(100) NOT NULL,
	telefone VARCHAR(20) UNIQUE,
	email VARCHAR(100) UNIQUE,
    endereco VARCHAR(100),
	NIF INT(20),
    
	FOREIGN KEY (id_codpostal) REFERENCES codigopostal(id_codpostal)
);

# :::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela ordem de serviço  :::::
# :::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE ordemdeservico (
	id_ordem INT PRIMARY KEY,
	datadecriacao DATE,
    descricao VARCHAR(1000),
    id_estado INT,
    id_cliente INT,
    id_funcionario INT,
    id_telemovel INT,
    id_metodopagamento INT,
    
	FOREIGN KEY (id_estado) REFERENCES estadodeordem(id_estado),
	FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
	FOREIGN KEY (id_funcionario) REFERENCES funcionarios(id_funcionario),
	FOREIGN KEY (id_telemovel) REFERENCES telemoveis(id_telemovel),
	FOREIGN KEY (id_metodopagamento) REFERENCES pagamentos(id_metodopagamento)
);

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de utilização de peças por ordem  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE pecas_utilizadas (
	quantidade INT(20),
    id_ordem INT,
    id_pecas INT,
    
    PRIMARY KEY (id_ordem, id_pecas),
    FOREIGN KEY (id_ordem) REFERENCES ordemdeservico (id_ordem),
    FOREIGN KEY (id_pecas) REFERENCES pecas (id_pecas)
);

# :::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de histórico de reparações  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE historico_reparacoes (
	historico VARCHAR(1000),
    id_ordem INT,
    id_telemovel INT,
    
    PRIMARY KEY (id_ordem,id_telemovel),
    FOREIGN KEY (id_ordem) REFERENCES ordemdeservico (id_ordem),
    FOREIGN KEY (id_telemovel) REFERENCES telemoveis (id_telemovel)
);