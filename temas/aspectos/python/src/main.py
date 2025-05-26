from operaciones import Calculadora
from springpython.aop import ProxyFactory
from aspectos import LogAspect, ErrorHandlingAspect, TimingAspect

def demo_aspectos():
    """Función para demostrar el funcionamiento de los aspectos en las operaciones"""
    
    # Crear una instancia de la calculadora
    calc = Calculadora()
    
    # Crear el proxy con aspectos
    factory = ProxyFactory()
    factory.target = calc
    factory.interceptors = [LogAspect(), ErrorHandlingAspect(), TimingAspect()]
    calc_proxy = factory.getProxy()
    
    # Probar la operación de suma
    print("\n--- Probando suma ---")
    resultado = calc_proxy.suma(5, 3)
    print(f"Resultado: {resultado}")
    
    # Probar la operación de división exitosa
    print("\n--- Probando división exitosa ---")
    resultado = calc_proxy.division(10, 2)
    print(f"Resultado: {resultado}")
    
    # Probar la operación de división por cero
    print("\n--- Probando división por cero ---")
    try:
        resultado = calc_proxy.division(10, 0)
    except ValueError as e:
        print(f"Error esperado: {e}")

if __name__ == "__main__":
    demo_aspectos()