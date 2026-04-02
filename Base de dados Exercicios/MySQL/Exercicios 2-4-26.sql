# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Titles a partir do número de empregado 11500  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM titles WHERE emp_no >= 11500;
SELECT emp_no,title FROM titles WHERE emp_no >= 11500;

# ::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Utilizar o DISTINCT no last_name  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::

SELECT DISTINCT last_name FROM employees;

# ::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Utilizar o ORDER BY no last_name  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::

SELECT DISTINCT last_name FROM employees ORDER BY last_name ASC;
SELECT DISTINCT last_name FROM employees ORDER BY last_name DESC;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar todos os funcionários               :::::
# :::::  (first_name, last_name e birth_date)       :::::
# :::::  ordenado po data de nascimento ascendente  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT first_name, last_name, birth_date FROM employees ORDER BY birth_date ASC;

# :::::::::::::::::::::::::
# :::::  Exercicio 6  :::::
# :::::::::::::::::::::::::

SELECT * FROM titles ORDER BY emp_no DESC;

# ::::::::::::::::::::::::::::::
# :::::  Utilizar o LIMIT  :::::
# ::::::::::::::::::::::::::::::

SELECT * FROM titles ORDER BY emp_no DESC LIMIT 15;

# :::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o maior salário da empresa  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::

SELECT salary FROM salaries ORDER BY salary DESC LIMIT 1;

# :::::::::::::::::::::::::
# :::::  Exercicio 7  :::::
# :::::::::::::::::::::::::

SELECT * FROM departments ORDER BY dept_name ASC LIMIT 5;
