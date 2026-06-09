namespace GestorTemperaturas
{
    public class GestorDeTemperaturas
    {
        // Converte uma temperatura em graus Celsius para Fahrenheit.
        public static double CelsiusParaFahrenheit(double celsius)
        {
            return (celsius * 1.8) + 32;
        }

        // Converte uma temperatura em graus Fahrenheit para Celsius.
        public static double FahrenheitParaCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) / 1.8;
        }

        // Deteta se a temperatura em Celsius indica febre (>= 38°C).
        public static bool TemFebreCelsius(double celsius)
        {
            return celsius >= 38.0;
        }

        // Deteta se a temperatura em Fahrenheit indica febre (>= 100.4°F).
        public static bool TemFebreFahrenheit(double fahrenheit)
        {
            return fahrenheit >= 100.4;
        }

    }
}
