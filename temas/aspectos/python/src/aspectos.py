from springpython.aop import ProxyFactory, MethodInterceptor
import logging
import time

logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

class LogAspect(MethodInterceptor):
    def invoke(self, invocation):
        logger.info("Antes de ejecutar: %s, args=%s", 
                   invocation.method.__name__, invocation.args)
        result = invocation.proceed()
        logger.info("Despues de ejecutar: %s", invocation.method.__name__)
        return result

class ErrorHandlingAspect(MethodInterceptor):
    def invoke(self, invocation):
        try:
            return invocation.proceed()
        except Exception as e:
            logger.error("Error en %s: %s", invocation.method.__name__, e)
            raise

class TimingAspect(MethodInterceptor):
    def invoke(self, invocation):
        inicio = time.time()
        result = invocation.proceed()
        fin = time.time()
        logger.info("%s ejecutado en %.4f segundos", 
                   invocation.method.__name__, fin - inicio)
        return result

def aplicar_aspectos():
    from operaciones import Calculadora
    
    factory = ProxyFactory()
    factory.target = Calculadora()
    factory.interceptors = [
        LogAspect(),
        ErrorHandlingAspect(),
        TimingAspect()
    ]
    
    return factory.getProxy()