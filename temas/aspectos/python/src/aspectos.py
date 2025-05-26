import logging
import time
from springpython.aop import MethodInterceptor

# Configuración básica de logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

class LogAspect(MethodInterceptor):
    """Aspecto para loggear antes y después de ejecutar un método"""
    def invoke(self, invocation):
        logger.info(f"Antes de ejecutar: {invocation.method.__name__}, args={invocation.args}")
        result = invocation.proceed()
        logger.info(f"Después de ejecutar: {invocation.method.__name__}")
        return result

class ErrorHandlingAspect(MethodInterceptor):
    """Aspecto para manejar errores en los métodos"""
    def invoke(self, invocation):
        try:
            return invocation.proceed()
        except Exception as e:
            logger.error(f"Error en {invocation.method.__name__}: {e}")
            raise

class TimingAspect(MethodInterceptor):
    """Aspecto para medir el tiempo de ejecución"""
    def invoke(self, invocation):
        inicio = time.time()
        result = invocation.proceed()
        fin = time.time()
        logger.info(f"{invocation.method.__name__} ejecutado en {fin - inicio:.4f} segundos")
        return result