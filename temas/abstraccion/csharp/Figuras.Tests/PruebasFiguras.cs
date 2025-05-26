using System;
using Xunit;
using System.Globalization;

namespace Figuras.Tests
{
    public class PruebasFiguras
    {
        public PruebasFiguras()
        {
            // Configurar cultura invariante para evitar problemas con decimales
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [Fact]
        public void TestRectangulo_DescripcionCorrecta()
        {
            // Arrange: crear un rectángulo y la descripción esperada
            var rect = new Rectangulo(4, 5);
            var expected = "Soy un Rectangulo de 4 x 5, area 20.00 y perimetro 18.00.";

            // Act: obtener la descripción real
            var actual = rect.ObtenerDescripcion();

            // Assert: comparar descripciones
            MostrarComparacion(expected, actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTriangulo_TiposYCalculos()
        {
            // Arrange - Crear diferentes tipos de triángulos
            var equilatero = new Triangulo(5, 4.33, 5, 5); // altura ≈ 4.33 para triángulo equilátero
            var isosceles = new Triangulo(6, 5.66, 6, 8);   // altura calculada para ejemplo
            var escaleno = new Triangulo(3, 4, 5, 2.4);     // 3-4-5 con altura 2.4

            // Act & Assert - Verificar tipos de triángulo
            MostrarComparacion("Equilatero", equilatero.Tipo.ToString());
            Assert.Equal(Triangulo.TipoTriangulo.Equilatero, equilatero.Tipo);

            MostrarComparacion("Isosceles", isosceles.Tipo.ToString());
            Assert.Equal(Triangulo.TipoTriangulo.Isosceles, isosceles.Tipo);

            MostrarComparacion("Escaleno", escaleno.Tipo.ToString());
            Assert.Equal(Triangulo.TipoTriangulo.Escaleno, escaleno.Tipo);

            // Verificar cálculos de área
            MostrarComparacion("10.83", equilatero.CalcularArea().ToString("0.00"));
            Assert.Equal(10.83, equilatero.CalcularArea(), 2);

            MostrarComparacion("16.98", isosceles.CalcularArea().ToString("0.00"));
            Assert.Equal(16.98, isosceles.CalcularArea(), 2);

            MostrarComparacion("6.00", escaleno.CalcularArea().ToString("0.00"));
            Assert.Equal(6.00, escaleno.CalcularArea(), 2);
        }

        [Fact]
        public void TestCirculo_CalculosPrecisos()
        {
            // Arrange: crear un círculo y calcular valores esperados
            var circulo = new Circulo(5);
            var expectedArea = Math.PI * 25;
            var expectedPerimetro = Math.PI * 10;

            // Act: obtener área y perímetro reales
            var actualArea = circulo.CalcularArea();
            var actualPerimetro = circulo.CalcularPerimetro();

            // Assert: comparar resultados con precisión de 4 decimales
            MostrarComparacion(expectedArea.ToString("0.0000"), actualArea.ToString("0.0000"));
            Assert.Equal(expectedArea, actualArea, 4); // Precisión de 4 decimales
            
            MostrarComparacion(expectedPerimetro.ToString("0.0000"), actualPerimetro.ToString("0.0000"));
            Assert.Equal(expectedPerimetro, actualPerimetro, 4);
        }

        [Fact]
        public void TestPolimorfismo_ListaFiguras()
        {
            // Arrange: crear un arreglo de figuras de diferentes tipos
            var figuras = new IFigura[]
            {
                new Rectangulo(3, 4),
                new Triangulo(3, 4, 5, 2.4),
                new Circulo(5)
            };

            // Descripciones esperadas para cada figura
            var expectedDescriptions = new[]
            {
                "Soy un Rectangulo de 3 x 4, area 12.00 y perimetro 14.00.",
                "Soy un Triangulo Escaleno (base 3, altura 4), area 6.00 y perimetro 10.40.",
                "Soy un Circulo con radio 5, area 78.54 y circunferencia 31.42."
            };

            // Act & Assert: comparar descripciones de cada figura
            for (int i = 0; i < figuras.Length; i++)
            {
                var descripcion = figuras[i].ObtenerDescripcion();
                MostrarComparacion(expectedDescriptions[i], descripcion);
                Assert.Equal(expectedDescriptions[i], descripcion);
            }
        }

        [Fact]
        public void TestValidacionDimensiones_DebeFallar()
        {
            // Arrange - Casos que deben fallar (dimensiones inválidas)
            var casosInvalidos = new Action[]
            {
                () => new Rectangulo(0, 5),
                () => new Rectangulo(-2, 3),
                () => new Triangulo(1, 0, 1, 1),
                () => new Circulo(-1)
            };

            // Act & Assert: cada caso debe lanzar una excepción
            foreach (var caso in casosInvalidos)
            {
                MostrarCasoPrueba(caso.Method.Name);
                var ex = Assert.Throws<ArgumentException>(caso);
                MostrarMensajeError(ex.Message);
                Assert.Contains("debe ser mayor que cero", ex.Message);
            }
        }

        // Métodos auxiliares para mostrar información visual
        private void MostrarComparacion(string esperado, string obtenido)
        {
            // Muestra la comparación entre el valor esperado y el obtenido
            Console.WriteLine("\n--- Comparacion ---");
            Console.WriteLine($"Esperado: {esperado}");
            Console.WriteLine($"Obtenido: {obtenido}");
            Console.WriteLine("------------------");
        }

        private void MostrarCasoPrueba(string nombreCaso)
        {
            // Muestra el nombre del caso de prueba actual
            Console.WriteLine($"\nProbando caso: {nombreCaso}");
        }

        private void MostrarMensajeError(string mensaje)
        {
            // Muestra el mensaje de error esperado
            Console.WriteLine($"Error esperado: {mensaje}");
        }
    }
}