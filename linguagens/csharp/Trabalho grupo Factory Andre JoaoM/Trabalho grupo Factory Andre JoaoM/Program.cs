namespace Trabalho_grupo_Factory_Andre_JoaoM
{
    class Program
    {
        static void Main()
        {
            // Criar uma fábrica de motores
            FabricaPecas fabrica = new FabricaMotor();
            IPeca peca = fabrica.CriarPeca();
            peca.Instalar(); // Saída: "Motor instalado."

            // Criar uma fábrica de pneus
            fabrica = new FabricaPneu();
            peca = fabrica.CriarPeca();
            peca.Instalar(); // Saída: "Pneu instalado."

            // Criar uma fábrica de baterias
            fabrica = new FabricaBateria();
            peca = fabrica.CriarPeca();
            peca.Instalar(); // Saída: "Bateria instalada."
        }
    }
}
