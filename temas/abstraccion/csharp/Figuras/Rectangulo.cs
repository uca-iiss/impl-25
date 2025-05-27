namespace Figuras
{
    public class Rectangulo : FiguraBase
    {
        // Nombre de la figura
        public override string Nombre { get; protected set; } = "Rectangulo";
        // Ancho del rectángulo
        public double Ancho { get; private set; }
        // Alto del rectángulo
        public double Alto { get; private set; }

        // Constructor que valida y asigna las dimensiones
        public Rectangulo(double ancho, double alto)
        {
            ValidarDimension(ancho, "Ancho");
            ValidarDimension(alto, "Alto");
            
            Ancho = ancho;
            Alto = alto;
        }

        // Calcula el área del rectángulo
        public override double CalcularArea() => Ancho * Alto;
        
        // Calcula el perímetro del rectángulo
        public override double CalcularPerimetro() => 2 * (Ancho + Alto);
        
        // Devuelve una descripción del rectángulo
        public override string ObtenerDescripcion()
        {
            return $"Soy un {Nombre} de {Ancho} x {Alto}, " + 
                   $"area {CalcularArea():0.00} y perimetro {CalcularPerimetro():0.00}.";
        }
    }
}