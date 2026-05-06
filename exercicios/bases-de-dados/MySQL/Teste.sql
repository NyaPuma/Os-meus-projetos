# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# :::::  Uma clinica veterinária pretende informatizar a gestão de donos, animais, consultas,            ::::: #
# :::::  veterenários e tratamentos                                                                      ::::: #
# :::::  	-> Os clientes (donos) têm ID, nome, telefone, e-mail, e morada.                             ::::: #
# ::::: 	-> Cada cliente pode ter vários animais, com ID, nome, espécie, raça e data de nascimento    ::::: #
# ::::: 	-> As consultas devem registar data, hora, animal, veterinário, e diagnóstico                ::::: #
# ::::: 	-> Um veterinário tem ID, nome e especialidade                                               ::::: #
# ::::: 	-> Uma consulta pode ter vários tratamentos (medicação, exames, etc.)                        ::::: #
# ::::: 	-> Deve ser possível consultar o histórico clínico de cada animal                            ::::: #
# ::::: 	                                                                                             ::::: #
# :::::  + Um cliente pode possuir vários animais                                                        ::::: #
# :::::  + Um animal pode ter várias consultas                                                           ::::: #
# :::::  + Um veterinário pode realizar várias consultas                                                 ::::: #
# :::::  + Uma consulta pode incluir vários tratamentos e um tratamento pode surgir em várias consultas  ::::: #
# :::::                                                                                                  ::::: #
# :::::  Crie as tabelas no MYSQL WorkBench                                                              ::::: #
# :::::  Insire pelo menos 3 registos em cada tabela                                                     ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

CREATE DATABASE IF NOT EXISTS clinica_veterinaria;
USE clinica_veterinaria;

# :::::::::::::::::::: #
# ::::: Clientes ::::: #
# :::::::::::::::::::: #
CREATE TABLE clientes (
    id_cliente INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    telefone VARCHAR(50),
    email VARCHAR(50),
    morada VARCHAR(100)
);

# ::::::::::::::::::: #
# ::::: Animais ::::: #
# ::::::::::::::::::: #
CREATE TABLE animais (
    id_animal INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT NOT NULL,
    nome VARCHAR(50) NOT NULL,
    especie VARCHAR(50) NOT NULL,
    raca VARCHAR(50) NOT NULL,
    data_nascimento DATE NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)
);

# :::::::::::::::::::::::: #
# ::::: Veterinarios ::::: #
# :::::::::::::::::::::::: #
CREATE TABLE veterinarios (
    id_veterinario INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    especialidade VARCHAR(50) NOT NULL
);

# ::::::::::::::::::::: #
# ::::: Consultas ::::: #
# ::::::::::::::::::::: #
CREATE TABLE consultas (
    id_consulta INT PRIMARY KEY AUTO_INCREMENT,
    id_animal INT NOT NULL,
    id_veterinario INT NOT NULL,
    data_consulta DATE NOT NULL,
    hora_consulta INT(2) NOT NULL,
    diagnostico VARCHAR(200) NOT NULL,
    FOREIGN KEY (id_animal) REFERENCES animais(id_animal),
    FOREIGN KEY (id_veterinario) REFERENCES veterinarios(id_veterinario)
);

# ::::::::::::::::::::::: #
# ::::: Tratamentos ::::: #
# ::::::::::::::::::::::: #
CREATE TABLE tratamentos (
    id_tratamento INT PRIMARY KEY AUTO_INCREMENT,
    medicacao VARCHAR(500),
    exames VARCHAR(500)
);

# ::::::::::::::::::::::::::::::::::::::::: #
# ::::: Histórico (tabela de ligação) ::::: #
# ::::::::::::::::::::::::::::::::::::::::: #
CREATE TABLE consulta_tratamento (
    id_consulta INT NOT NULL,
    id_tratamento INT NOT NULL,
    PRIMARY KEY (id_consulta, id_tratamento),
    FOREIGN KEY (id_consulta) REFERENCES consultas(id_consulta),
    FOREIGN KEY (id_tratamento) REFERENCES tratamentos(id_tratamento)
);

# ::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Inserir 3 registos em cada tabela ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::: #
INSERT INTO clinica_veterinaria.clientes (nome, telefone, email, morada) VALUES ('José', '911222333', 'jose@email', 'algures');
INSERT INTO clinica_veterinaria.clientes (nome, telefone, email, morada) VALUES ('Maria', '922333444', 'maria@email', 'lado nenhum');
INSERT INTO clinica_veterinaria.clientes (nome, telefone, email, morada) VALUES ('Daniela', '933444555', 'daniela@email', 'ali a beira');

INSERT INTO clinica_veterinaria.animais (id_cliente, nome, especie, raca, data_nascimento) VALUES ('2', 'Tobias', 'Caniche', 'Amarelo', '2000-10-03');
INSERT INTO clinica_veterinaria.animais (id_cliente, nome, especie, raca, data_nascimento) VALUES ('2', 'Pipi', 'Labrador', 'Montanhes', '2015-03-29');
INSERT INTO clinica_veterinaria.animais (id_cliente, nome, especie, raca, data_nascimento) VALUES ('1', 'Mimi', 'Pastora', 'Alema', '2020-07-13');

INSERT INTO clinica_veterinaria.veterinarios (nome, especialidade) VALUES ('Eduardo', 'Alimentar');
INSERT INTO clinica_veterinaria.veterinarios (nome, especialidade) VALUES ('Sofia', 'Cortar pelo');
INSERT INTO clinica_veterinaria.veterinarios (nome, especialidade) VALUES ('Pedro', 'Brincar');

INSERT INTO clinica_veterinaria.consultas (id_animal, id_veterinario, data_consulta, hora_consulta, diagnostico) VALUES ('1', '3', '2026-01-01', '12', 'muito fixe');
INSERT INTO clinica_veterinaria.consultas (id_animal, id_veterinario, data_consulta, hora_consulta, diagnostico) VALUES ('1', '2', '2026-02-02', '16', 'ok');
INSERT INTO clinica_veterinaria.consultas (id_animal, id_veterinario, data_consulta, hora_consulta, diagnostico) VALUES ('3', '2', '2026-03-03', '18', 'muito mau');

INSERT INTO clinica_veterinaria.tratamentos (medicacao, exames) VALUES ('comer mais', 'nao tem');
INSERT INTO clinica_veterinaria.tratamentos (medicacao, exames) VALUES ('comprimidos', 'perna');
INSERT INTO clinica_veterinaria.tratamentos (medicacao, exames) VALUES ('gel', 'cabeça');

INSERT INTO clinica_veterinaria.consulta_tratamento (id_consulta, id_tratamento) VALUES ('1',' 2');
INSERT INTO clinica_veterinaria.consulta_tratamento (id_consulta, id_tratamento) VALUES ('1', '3');
INSERT INTO clinica_veterinaria.consulta_tratamento (id_consulta, id_tratamento) VALUES ('2', '2');