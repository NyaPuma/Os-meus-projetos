using System;

namespace InstitutoFormacao.Dominio
{
    public class Curso
    {
        public string Nome { get; }
        public int CargaHoraria { get; }
        public PublicoAlvo PublicoAlvo { get; }
        public decimal Valor { get; }

        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do curso é obrigatório e não pode ser vazio.", nameof(nome));

            if (cargaHoraria <= 0)
                throw new ArgumentException("A carga horária deve ser maior que zero.", nameof(cargaHoraria));

            if (valor <= 0)
                throw new ArgumentException("O valor do curso deve ser superior a 0 euros.", nameof(valor));

            Nome         = nome;
            Valor        = valor;
            PublicoAlvo  = publicoAlvo;
            CargaHoraria = cargaHoraria;

        }
    }
}