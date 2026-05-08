using System;
using System.Collections.Generic;
using System.Text;

namespace RelacaoDependencia
{
    internal class RelatorioService
    {
        public string Conteudo { get; set; }

        //Metodo que utiliza Funcionario apenas temporariamente

        public void GerarRelatorio(Funcionario funcionario)
        {
            //Guardar a informação do objeto
            Conteudo = $"Nome: {funcionario.Nome}| Salario: {funcionario.Salario}";
            //exibir
            Console.WriteLine("Relatorio do Funcionario");
            Console.WriteLine(Conteudo);
        }
    }
}
