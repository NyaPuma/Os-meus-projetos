namespace MVC3
{
    public class Cliente
    {
        private string _nome;
        private int _idade;
        private string _email;

        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public int Idade
        {
            get => _idade;
            set
            {
                // Regra de Negócio: Idade deve ser >= 16 anos
                if (value < 16)
                {
                    throw new ArgumentException("Erro no Model: A idade do cliente deve ser igual ou superior a 16 anos.");
                }
                _idade = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                // Regra de Negócio: Email deve conter '@'
                if (!value.Contains('@'))
                {
                    throw new ArgumentException("Erro no Model: O e-mail introduzido é inválido (deve conter '@').");
                }
                _email = value;
            }
        }

        // Construtor que força a validação das propriedades ao instanciar o objeto
        public Cliente(string nome, int idade, string email)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
        }
    }
}