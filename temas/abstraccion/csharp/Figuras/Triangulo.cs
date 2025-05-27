namespace Figuras
{
    public class Triangulo : FiguraBase
    {
        // Enumeración para los tipos de triángulo
        public enum TipoTriangulo { Equilatero, Isosceles, Escaleno }
        
        // Nombre de la figura
        public override string Nombre { get; protected set; } = "Triangulo";
        // Base del triángulo
        public double Base { get; private set; }
        // Altura del triángulo
        public double Altura { get; private set; }
        // Segundo lado del triángulo
        public double Lado2 { get; private set; }
        // Tercer lado del triángulo
        public double Lado3 { get; private set; }
        // Tipo de triángulo (equilátero, isósceles, escaleno)
        public TipoTriangulo Tipo { get; private set; }

        // Constructor que valida y asigna las dimensiones
        public Triangulo(double baseTri, double altura, double lado2, double lado3)
        {
            ValidarDimension(baseTri, "Base");
            ValidarDimension(altura, "Altura");
            ValidarDimension(lado2, "Lado 2");
            ValidarDimension(lado3, "Lado 3");
            
            Base = baseTri;
            Altura = altura;
            Lado2 = lado2;
            Lado3 = lado3;
            Tipo = DeterminarTipo();
        }

        // Determina el tipo de triángulo según sus lados
        private TipoTriangulo DeterminarTipo()
        {
            if (Base == Lado2 && Lado2 == Lado3) return TipoTriangulo.Equilatero;
            if (Base == Lado2 || Base == Lado3 || Lado2 == Lado3) return TipoTriangulo.Isosceles;
            return TipoTriangulo.Escaleno;
        }

        // Calcula el área del triángulo
        public override double CalcularArea() => (Base * Altura) / 2;
        
        // Calcula el perímetro del triángulo
        public override double CalcularPerimetro() => Base + Lado2 + Lado3;
        
        // Devuelve una descripción del triángulo
        public override string ObtenerDescripcion()
        {
            return $"Soy un {Nombre} {Tipo} (base {Base}, altura {Altura}), " +
                   $"area {CalcularArea():0.00} y perimetro {CalcularPerimetro():0.00}.";
        }
    }
}