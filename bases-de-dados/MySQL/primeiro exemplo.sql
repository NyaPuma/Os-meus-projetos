# :::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  eliminar base de dados se a mesma existir  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::

DROP DATABASE IF EXISTS loja;

# :::::::::::::::::::::::::::::::::
# :::::  criar base de dados  :::::
# :::::::::::::::::::::::::::::::::

CREATE DATABASE loja;

# ::::::::::::::::::::::::::::::::::
# :::::  ativar base de dados  :::::
# ::::::::::::::::::::::::::::::::::

USE loja;

# :::::::::::::::::::::::::::::::::::
# :::::  criar tabela clientes  :::::
# :::::::::::::::::::::::::::::::::::

CREATE TABLE clientes (
	id_cliente INT PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	telefone VARCHAR(20),
	email VARCHAR(100),
	data_registo DATE
);

# :::::::::::::::::::::::::::::::::::
# :::::  criar tabela produtos  :::::
# :::::::::::::::::::::::::::::::::::

CREATE TABLE produtos (
	id_produto INT PRIMARY KEY,
	nome_produto VARCHAR(100),
	preco DECIMAL(10,2),
	stock INT DEFAULT 0
);

# :::::::::::::::::::::::::::::::::::::
# :::::  criar tabela encomendas  :::::
# :::::::::::::::::::::::::::::::::::::

CREATE TABLE encomendas (
	id_encomenda INT PRIMARY KEY,
	id_cliente INT,
	FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)
);

# ::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  criar tabela de detalhes da encomenda :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::

CREATE TABLE detalhe_encomendas (
	id_encomenda INT,
    id_produto INT,
    quantidade DECIMAL (10,2),
    
    PRIMARY KEY (id_encomenda, id_produto),
    
    FOREIGN KEY (id_encomenda) REFERENCES encomendas (id_encomenda),
    FOREIGN KEY (id_produto) REFERENCES produtos (id_produto)
);
    