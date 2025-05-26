from operaciones import Calculadora
from aspectos import aplicar_aspectos

def demo_aspectos():
    """Función para demostrar el funcionamiento de los aspectos"""
    calc = aplicar_aspectos()
    
    print("\n--- Probando suma ---")
    resultado = calc.suma(5, 3)
    print("Resultado: %s" % resultado)
    
    print("\n--- Probando división exitosa ---")
    resultado = calc.division(10, 2)
    print("Resultado: %s" % resultado)
    
    print("\n--- Probando división por cero ---")
    try:
        resultado = calc.division(10, 0)
    except ValueError as e:
        print("Error esperado: %s" % e)

if __name__ == "__main__":
    demo_aspectos()