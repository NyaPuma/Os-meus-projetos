namespace FabricaMoveis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMoveisFactory fabricaM = new FabricaModerna();
            IMoveisFactory fabricaC = new FabricaClassica();

            ICadeira cadeiraM = fabricaM.CriarCadeira();
            IMesa mesaM = fabricaM.CriarMesa();

            cadeiraM.Sentar();
            mesaM.Usar();

            ICadeira cadeiraC = fabricaC.CriarCadeira();
            IMesa mesaC = fabricaC.CriarMesa();

            cadeiraC.Sentar();
            mesaC.Usar();
        }
    }
}
