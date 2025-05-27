using System;

namespace Figuras
{
    public abstract class FiguraBase : IFigura
    {
        public virtual string Nombre { get; protected set; } = "Figura Geométrica";
        
        public abstract double CalcularArea();
        
        public abstract double CalcularPerimetro();
        
        public virtual string ObtenerDescripcion()
        {
            return $"Soy un {Nombre} con área {CalcularArea():0.00} y perímetro {CalcularPerimetro():0.00}.";
        }
        
        protected void ValidarDimension(double valor, string nombreDimension)
        {
            if (valor <= 0)
                throw new ArgumentException($"{nombreDimension} debe ser mayor que cero.");
        }
    }
}