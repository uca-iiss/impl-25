namespace Figuras
{
    /// Define los requisitos minimos que debe cumplir una figura geométrica.
    public interface IFigura
    {
        // Propiedad de solo lectura (get)
        string Nombre { get; }  

        // Método obligatorio para calcular el área
        double CalcularArea();  

        // Método obligatorio para calcular el perímetro
        double CalcularPerimetro();  

        // Método obligatorio para obtener una descripción
        string ObtenerDescripcion();  
    }
}