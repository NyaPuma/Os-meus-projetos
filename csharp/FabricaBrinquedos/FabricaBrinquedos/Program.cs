namespace FabricaBrinquedos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // criar os brinquedos atraves da fabrica
            Brinquedo urso = Fabrica.CriarBrinquedo("Urso Peluche");
            urso?.Mover();

            Brinquedo carro = Fabrica.CriarBrinquedo("Carro Telecomandado");
            carro?.Mover();

            Brinquedo boneca = Fabrica.CriarBrinquedo("Boneca");
            boneca?.Mover();
        }
    }
}
