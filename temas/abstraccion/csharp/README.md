# Figuras Geométricas en C#

Este proyecto implementa un sistema de figuras geométricas en C# que demuestra los principios de `Abstracción`.

## Estructura del Código

### Interfaz `IFigura`
Define el contrato básico que deben cumplir todas las figuras geométricas:
- Propiedad `Nombre` (solo lectura)
- Método `CalcularArea()` para calcular el área
- Método `CalcularPerimetro()` para calcular el perímetro
- Método `ObtenerDescripcion()` para obtener una descripción detallada

### Clase Abstracta `FiguraBase`
Provee funcionalidad común a todas las figuras:
- Validación automática de dimensiones.
- Implementación base de `ObtenerDescripcion()`
- Propiedad `Nombre` virtual para sobreescritura
- Métodos abstractos para cálculos

### Implementaciones
#### 1. `Circulo`
- **Propiedades**:
  - `Radio` (setter privado para encapsulamiento)
  - `Nombre` sobreescrito como "Círculo" 
- **Métodos**:
  - `CalcularArea()`: Calcula el área usando π*r²
  - `CalcularPerimetro()`: Calcula circunferencia como 2πr 
  - `ObtenerDescripcion()`: Devuelve cadena con radio, área y circunferencia

#### 2. `Rectangulo`
- **Propiedades**:
  - `Ancho` y `Alto` (setters privados)
  - `Nombre` sobreescrito como "Rectángulo" 
- **Métodos**:
  - `CalcularArea()`: Calcula área como ancho*alto
  - `CalcularPerimetro()`: Calcula perímetro como 2*(ancho+alto) 
  - `ObtenerDescripcion()`: Incluye ahora perímetro en la descripción

#### 3. `Triangulo`
- **Propiedades**:
  - `Base` y `Altura` (setters privados)
  - `TipoTriangulo`: Enum (Equilátero, Isósceles, Escaleno) 
  - Lados adicionales para cálculo de perímetro 
- **Métodos**:
  - `CalcularArea()`: Calcula área como (base*altura)/2
  - `CalcularPerimetro()`: Suma de los tres lados 
  - `ObtenerDescripcion()`: Ahora incluye tipo de triángulo y perímetro

## Pruebas Unitarias

Las pruebas ahora verifican:
1. Cálculo preciso de áreas y perímetros (hasta 4 decimales)
2. Descripciones completas con formato invariante
3. Validación de dimensiones inválidas
4. Comportamiento polimórfico en colecciones
5. Tipos de triángulos 

### Despliegue para pruebas

> [!NOTE]
> La totalidad de estas pruebas se han realizado en PowerShell.

#### 1. Iniciar los contenedores ####

Desde la carpeta temas/abstraccion/csharp

```bash
    docker-compose -f abstraccion.csharp-RITCHIE.yml up -d
```
#### 2. Accede a Jenkins

Abre [http://localhost:8080](http://localhost:8080) en tu navegador.

#### 3. Desbloquea Jenkins
Ejecuta el siguiente comando para obtener la contraseña inicial:

```bash
docker exec csharp-jenkins-dotnet-1 cat /var/jenkins_home/secrets/initialAdminPassword
```

- Instalar plugins recomendados

- Continuar como administrador

#### 4. Creación del Pipeline

1. En el panel de Jenkins, haz clic en “New Item”.
2. Introduce un nombre para el proyecto (por ejemplo, `Abstraccion-csharp`).
3. Selecciona “Pipeline” como tipo de proyecto y haz clic en OK.
4. En el menú lateral, selecciona **Pipeline** y luego:

    - En “Definition” selecciona **Pipeline script from SCM**
    - En “SCM” elige **Git**
    - En “Repository URL” introduce la URL de tu repositorio
    - En Jenkinsfile, poner `temas/abstraccion/csharp/abstraccion.csharp-RITCHIE.Jenkinsfile`
    - Haz clic en **Save**.

---

 #### 4. Eliminar todo (limpieza)
```bash
docker stop csharp-jenkins-dotnet-1
docker rm csharp-jenkins-dotnet-1
docker volume rm csharp_jenkins_home
docker rmi csharp-jenkins-dotnet
```
