# Optimización de la Función Sphere con Hill-Climbing

Implementación en C# de los algoritmos descritos en el material de metaheurísticas para resolver el problema de minimización de la función de la esfera (Sphere Function) en $n$ dimensiones.

## Algoritmos Implementados
- **Algoritmo: Hill-Climbing (Ascenso a la Colina):** Adaptado a minimización ($f(U) < f(X)$).
- **Algoritmo: Bounded Uniform Convolution (Operador Tweak):** Genera vecinos perturbando variables con probabilidad $p$ dentro del rango $[-r, r]$ asegurando que se mantengan en los límites $[-10, 10]$.

---

## Requisitos
- .NET SDK 6.0, 7.0 u 8.0+.
- IDE: JetBrains Rider, Visual Studio o terminal con CLI de .NET.

---

## Instrucciones de Ejecución

### Desde JetBrains Rider / Visual Studio:
1. Abrir la solución `HillClimbing.sln`.
2. Presionar el botón de **Run**  o presionar `Ctrl + F5`.

### Desde la Terminal / Consola:
Ubícate en la carpeta donde está el archivo `.csproj` o `Program.cs` y ejecuta:

- **Ejecución básica ($n=3$ por defecto):**
  ```bash
  dotnet run
