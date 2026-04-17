# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# :::::  Uma escola de formação pretende gerir cursos, formandos, formadores e inscrições.            ::::: #
# :::::  	 Os formandos têm ID, nome, e-mail e telefone.                                           ::::: #
# ::::: 	 Os formadores têm ID, nome e área de especialização.                                    ::::: #
# ::::: 	 Os cursos têm ID, nome, duração e preço.                                                ::::: #
# ::::: 	 Um curso pode ter vários formandos e um formando pode frequentar vários cursos.         ::::: #
# ::::: 	 Cada curso é lecionado por um formador.                                                 ::::: #
# ::::: 	 Deve ser registada a data de inscrição e o estado (ativo, concluído, desistente).       ::::: #
# ::::: 	 Um formador pode lecionar vários cursos                                                 ::::: #
# ::::: 	 Um curso pode ter vários formandos e um formando pode estar inscrito em vários cursos.  ::::: #
# :::::  Crie as tabelas no MYSQL WorkBench                                                           ::::: #
# :::::  Insira pelo menos 3 registos em cada tabela.                                                 ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

CREATE DATABASE escola_formacao;
USE escola_formacao;

# :::::::::::::::::::::: #
# ::::: Formadores ::::: #
# :::::::::::::::::::::: #
CREATE TABLE formadores (
    id_formador INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    area_especializacao VARCHAR(50) NOT NULL
);

# :::::::::::::::::: #
# ::::: Cursos ::::: #
# :::::::::::::::::: #
CREATE TABLE cursos (
    id_curso INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    duracao INT NOT NULL,
    preco DOUBLE NOT NULL,
    id_formador INT NOT NULL,
    FOREIGN KEY (id_formador) REFERENCES formadores(id_formador)
);

# ::::::::::::::::::::: #
# ::::: Formandos ::::: #
# ::::::::::::::::::::: #
CREATE TABLE formandos (
    id_formando INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    email VARCHAR(50) UNIQUE NOT NULL,
    telefone VARCHAR(20) NOT NULL
);

# :::::::::::::::::::::::::::::::::::::::::: #
# ::::: Inscrições (tabela de ligação) ::::: #
# :::::::::::::::::::::::::::::::::::::::::: #
CREATE TABLE inscricoes (
    id_inscricao INT PRIMARY KEY AUTO_INCREMENT,
    id_formando INT NOT NULL,
    id_curso INT NOT NULL,
    data_inscricao DATE NOT NULL,
    estado VARCHAR(50) NOT NULL,
    FOREIGN KEY (id_formando) REFERENCES formandos(id_formando),
    FOREIGN KEY (id_curso) REFERENCES cursos(id_curso)
);

# ::::::::::::::::::::::::::::::::::::::::: #
# ::::: Inserir 3 valores nas tabelas ::::: #
# ::::::::::::::::::::::::::::::::::::::::: #
    
    # ::::: Formadores ::::: #
	INSERT INTO formadores (nome, area_especializacao) VALUES ('Vitor', 'Beber');
	INSERT INTO formadores (nome, area_especializacao) VALUES ('Pedro', 'Comer');
	INSERT INTO formadores (nome, area_especializacao) VALUES ('Daniela', 'Dormir');
    
    # ::::: Formandos ::::: #
	INSERT INTO formandos (nome, email, telefone) VALUES ('Tiago', 'tiago@email', '911111111');
	INSERT INTO formandos (nome, email, telefone) VALUES ('Gaspar', 'gaspar@email', '911111112');
	INSERT INTO formandos (nome, email, telefone) VALUES ('Manuela', 'manuela@email', '911111113');
    
    # ::::: Cursos ::::: #
	INSERT INTO cursos (nome, duracao, preco, id_formador) VALUES ('Natação', '120', '0.50', '1');
	INSERT INTO cursos (nome, duracao, preco, id_formador) VALUES ('Cozinheiro', '60', '1.75', '2');
	INSERT INTO cursos (nome, duracao, preco, id_formador) VALUES ('Policia', '30', '2.50', '3');
    
    # ::::: Inscrições (tabela de ligação) ::::: #
	INSERT INTO inscricoes (id_formando, id_curso, data_inscricao, estado) VALUES ('1', '1', '2026-03-03', 'ativo');
	INSERT INTO inscricoes (id_formando, id_curso, data_inscricao, estado) VALUES ('2', '2', '2026-03-03', 'concluído');
	INSERT INTO inscricoes (id_formando, id_curso, data_inscricao, estado) VALUES ('3', '3', '2026-03-03', 'desistente');
    
# ::::::::::::::::::::::::::::::::::::::::: #
# ::::: Select troca de id pelos nome ::::: #
# ::::::::::::::::::::::::::::::::::::::::: #

SELECT cursos.nome AS 'Nome do curso', 
	   cursos.duracao AS 'Duração do curso', 
       cursos.preco AS 'Preço do curso', 
       formadores.nome AS 'Nome do formador', 
       formadores.area_especializacao AS 'Area de especialização do formador' 
       FROM cursos
			INNER JOIN formadores ON formadores.id_formador = cursos.id_formador;
    
SELECT formandos.nome AS 'Nome do aluno',
	   cursos.nome AS 'Nome do curso', 
       inscricoes.data_inscricao AS 'Data da inscrição', 
       inscricoes.estado AS 'Estado da inscrição' 
       FROM inscricoes
			INNER JOIN formandos ON formandos.id_formando = inscricoes.id_formando
			INNER JOIN cursos ON cursos.id_curso = inscricoes.id_curso;
