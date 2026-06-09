using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InstitutoFormacao.Dominio
{
    // Enumeração do público alvo. O público-alvo só pode ser um dos seguintes:
    //      • Estudante
    //      • Universitário
    //      • Empregado
    //      • Empreendedor
    // Estas opções são fixas, por isso serão representadas no código por um enumerador(enum),
    // de forma a facilitar a utilização e evitar erros.
    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor,
    }
}