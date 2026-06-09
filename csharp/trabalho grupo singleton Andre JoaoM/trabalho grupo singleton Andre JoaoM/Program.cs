namespace trabalho_grupo_singleton_Andre_JoaoM
{
    using System;

    class Program
    {
        static void Main()
        {
            // Obter a instância única
            OficinaSingleton oficina1 = OficinaSingleton.Instancia;
            OficinaSingleton oficina2 = OficinaSingleton.Instancia;

            // Usar o método
            OficinaSingleton.RegistrarServico("Toyota Corolla");
            OficinaSingleton.RegistrarServico("Ford Focus");

            // Verificar se são a mesma instância
            Console.WriteLine($"oficina1 = oficina2? {oficina1 == oficina2}"); // True
        }
    }
}