namespace Trabalho_grupo_Abstract_Factory_Andre_JoaoM
{
    class Program
    {
        static void Main()
        {
            // Fabricar peças para Toyota
            IFabricaPecas fabrica = new FabricaToyota();
            IPeca motor = fabrica.CriarMotor();
            IPeca pneu = fabrica.CriarPneu();

            motor.Instalar(); // Saída: "Motor Toyota instalado."
            pneu.Instalar();   // Saída: "Pneu Toyota instalado."

            // Fabricar peças para Ford
            fabrica = new FabricaFord();
            motor = fabrica.CriarMotor();
            pneu = fabrica.CriarPneu();

            motor.Instalar(); // Saída: "Motor Ford instalado."
            pneu.Instalar();   // Saída: "Pneu Ford instalado."
        }
    }
}
