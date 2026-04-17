# :::::::::::::::::::::::::::::::::::::::::
# :::::  Ver o maior e menor salário  :::::
# :::::::::::::::::::::::::::::::::::::::::

SELECT MAX(salary) from salaries;
SELECT MIN(salary) from salaries;

# ::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos funcionarios tem a empresa  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::

SELECT COUNT(*) FROM employees;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos funcionarios nasceram em 1953-09-02  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT COUNT(*) FROM employees WHERE birth_date='1953-09-02';

# :::::::::::::::::::::::::
# :::::  Exercicio 8  :::::
# :::::::::::::::::::::::::

SELECT COUNT(*) FROM departments;

# :::::::::::::::::::::::::::::::
# :::::  Média de salários  :::::
# :::::::::::::::::::::::::::::::

SELECT AVG(salary) FROM salaries;

# :::::::::::::::::::::::::::::::
# :::::  Soma dos salários  :::::
# :::::::::::::::::::::::::::::::

SELECT SUM(salary) FROM salaries;

# ::::::::::::::::::::::::::::::::::::::
# :::::  Soma dos salários atuais  :::::
# ::::::::::::::::::::::::::::::::::::::

SELECT SUM(salary) FROM salaries WHERE to_date='9999-01-01';

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar os funcionarios com last_name Facello  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM employees WHERE last_name='Facello';

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar os funcionarios com last_name que começa por F  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM employees WHERE last_name LIKE 'F%';

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar os funcionarios com last_name que acaba com i  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM employees WHERE last_name LIKE '%i';

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar os funcionarios com last_name que contém z  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM employees WHERE last_name LIKE '%z%';

# :::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar os funcionarios em que  :::::
# :::::  first_name começa por H        :::::
# :::::  last_name termina em i         :::::
# :::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM employees WHERE first_name LIKE 'H%' AND last_name LIKE '%i';

# :::::::::::::::::::::::::
# :::::  Exercicio 9  :::::
# :::::::::::::::::::::::::

SELECT * FROM titles WHERE title LIKE '%engineer%';

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Lista a profissão engineer de forma única  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT DISTINCT(title) FROM titles WHERE title LIKE '%engineer%';

# :::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Lista quantos engineer tenho na empresa  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT COUNT(*) FROM titles WHERE title LIKE '%engineer%';

# ::::::::::::::::::::::::::
# :::::  Exercicio 10  :::::
# ::::::::::::::::::::::::::

SELECT * FROM employees WHERE last_name IN('Facello','Peac');

# ::::::::::::::::::::::::::
# :::::  Exercicio 11  :::::
# ::::::::::::::::::::::::::

SELECT * FROM salaries WHERE salary BETWEEN 125000 AND 175000;

# :::::::::::::::::::::::::::::::
# :::::  Utilizar um alias  :::::
# :::::::::::::::::::::::::::::::

SELECT first_name AS 'Nome', last_name AS 'Apelido' FROM employees;
SELECT COUNT(*) AS 'Nº de Funcionários' FROM employees;

# :::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o title de cada employee  :::::
# :::::::::::::::::::::::::::::::::::::::::::::

SELECT employees.first_name, employees.last_name, titles.title
	FROM employees INNER JOIN titles
	ON employees.emp_no=titles.emp_no;
    
# ::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o salário de cada funcionário  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT employees.first_name, employees.last_name, salaries.salary
	FROM employees INNER JOIN salaries
	ON employees.emp_no=salaries.emp_no WHERE salaries.to_date='9999-01-01';
  
# :::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Contar os funcionários por genero  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::: 
  
SELECT gender, COUNT(gender) FROM employees GROUP BY gender;

# ::::::::::::::::::::::::::
# :::::  Exercicio 13  :::::
# ::::::::::::::::::::::::::

SELECT hire_date, COUNT(hire_date) FROM employees GROUP BY hire_date;

# ::::::::::::::::::::::::::
# :::::  Exercicio 14  :::::
# ::::::::::::::::::::::::::

SELECT hire_date, COUNT(hire_date) FROM employees 
	GROUP BY hire_date HAVING COUNT(hire_date)<50;
    
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos funcionários tenho por sobrenome  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT last_name, COUNT(last_name) FROM employees GROUP BY last_name;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos funcionários tenho neste momento na empresa  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT salaries.to_date, COUNT(salaries.to_date) FROM salaries 
	GROUP BY salaries.to_date HAVING salaries.to_date='9999-01-01';
