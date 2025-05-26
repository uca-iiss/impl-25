namespace Figuras
{
    public class Circulo : FiguraBase
    {
        // Nombre de la figura
        public override string Nombre { get; protected set; } = "Circulo";
        // Radio del círculo
        public double Radio { get; private set; }

        // Constructor que valida y asigna el radio
        public Circulo(double radio)
        {
            ValidarDimension(radio, "Radio");
            Radio = radio;
        }

        // Calcula el área del círculo
        public override double CalcularArea() => Math.PI * Radio * Radio;
        
        // Calcula la circunferencia (perímetro) del círculo
        public override double CalcularPerimetro() => 2 * Math.PI * Radio;
        
        // Devuelve una descripción del círculo
        public override string ObtenerDescripcion()
        {
            return $"Soy un {Nombre} con radio {Radio}, " +
                   $"area {CalcularArea():0.00} y circunferencia {CalcularPerimetro():0.00}.";
        }
    }
}