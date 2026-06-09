# :::::::::::::::::::::::::::::::::::::::
# :::::  inserir dados de clientes  :::::
# :::::::::::::::::::::::::::::::::::::::

INSERT INTO clientes VALUES (1,'Rui','912345678','a@a.com','2026-04-02');
INSERT INTO clientes VALUES (2,'Maria','912345688','b@a.com','2026-04-01');
INSERT INTO clientes VALUES (3,'José','912345689','c@a.com','2026-04-03');
INSERT INTO clientes VALUES (4,'Ana','912345689','c@a.com','2026-04-04');
INSERT INTO clientes VALUES (5,'Ricardo','912645689','c@a.com','2026-04-03');

# ::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Alterar o telefone de um cliente  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::

UPDATE clientes 
SET 
    telefone = '999999999'
WHERE
    id_cliente = 1;
    
# :::::::::::::::::::::::::::::::
# :::::  Apagar um cliente  :::::
# :::::::::::::::::::::::::::::::

DELETE FROM clientes 
WHERE
    id_cliente = 4;

# ::::::::::::::::::::::::::::::::::::::::::
# :::::  Ver dados da tabela clientes  :::::
# ::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM loja.clientes;

# :::::::::::::::::::::::::::::::::::::::
# :::::  inserir dados de produtos  :::::
# :::::::::::::::::::::::::::::::::::::::

INSERT INTO produtos VALUES (1,'Açucar',10,5);
INSERT INTO produtos VALUES (2,'Arroz',10,5);
INSERT INTO produtos VALUES (3,'Leite',10,5);

# ::::::::::::::::::::::::::::::::::::::::::
# :::::  Ver dados da tabela produtos  :::::
# ::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM loja.produtos;

# :::::::::::::::::::::::::::::::::::::::::
# :::::  inserir dados de encomendas  :::::
# :::::::::::::::::::::::::::::::::::::::::

INSERT INTO encomendas VALUES (1,1);
INSERT INTO encomendas VALUES (2,3);
INSERT INTO encomendas VALUES (3,1);

# ::::::::::::::::::::::::::::::::::::::::::::
# :::::  Ver dados da tabela encomendas  :::::
# ::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM loja.encomendas;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Inserir dados da tabela detalhes de encomendas  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

INSERT INTO detalhe_encomendas VALUES (1,1,10);
INSERT INTO detalhe_encomendas VALUES (1,2,5);
INSERT INTO detalhe_encomendas VALUES (2,3,2);
INSERT INTO detalhe_encomendas VALUES (2,1,3);

# ::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Ver dados da tabela detalhe_encomendas  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM loja.detalhe_encomendas;
