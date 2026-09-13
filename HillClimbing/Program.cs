using System;

class Program
{
    static double SphereFunction(double[] x)
    {
        double sum = 0.0;
        for (int i = 0; i < x.Length; i++)
        {
            sum += x[i] * x[i];
        }
        return sum;
    }

    // Algoritmo: Bounded Uniform Convolution 
    static double[] BoundedUniformConvolution(double[] x, double p, double r, double lowerBound, double upperBound)
    {
        double[] w = (double[])x.Clone();

        for (int i = 0; i < w.Length; i++)
        {
            if (Random.Shared.NextDouble() <= p)
            {
                while (true)
                {
                    double noise = (Random.Shared.NextDouble() * 2.0 * r) - r;
                    double candidate = w[i] + noise;

                    if (candidate >= lowerBound && candidate <= upperBound)
                    {
                        w[i] = candidate;
                        break;
                    }
                }
            }
        }

        return w;
    }

    // Algoritmo: Hill-Climbing
    static (double[] bestSolution, double bestQuality, int totalEvaluations) HillClimbing(
        int dim,
        double lowerBound,
        double upperBound,
        double p,
        double r,
        int maxEvaluations)
    {
        double[] currentX = new double[dim];
        for (int i = 0; i < dim; i++)
        {
            currentX[i] = lowerBound + (Random.Shared.NextDouble() * (upperBound - lowerBound));
        }

        double currentQuality = SphereFunction(currentX);
        int evaluations = 1;
        while (evaluations < maxEvaluations)
        {
            double[] candidateU = BoundedUniformConvolution(currentX, p, r, lowerBound, upperBound);
            double candidateQuality = SphereFunction(candidateU);
            evaluations++;
            if (candidateQuality < currentQuality)
            {
                currentX = candidateU;
                currentQuality = candidateQuality;
            }
        }

        return (currentX, currentQuality, evaluations);
    }

    static void Main(string[] args)
    {
        // Parámetros a configurables
        int dim = 3;                  // Dimensión n del problema
        double p = 0.4;               // Probabilidad de mutación por variable
        double r = 0.1;               // Tamaño de paso / radio de ruido [-r, r]
        int maxEvaluations = 20000;   // Condición de paro por evaluaciones
        double lowerBound = -10.0;    // Límite inferior
        double upperBound = 10.0;     // Límite superior

        if (args.Length > 0 && int.TryParse(args[0], out int customDim))
        {
            dim = customDim;
        }

        Console.WriteLine($"Configuración: n={dim}, p={p}, r={r}, max_evals={maxEvaluations}");
        Console.WriteLine($"Espacio de búsqueda: [{lowerBound}, {upperBound}]");

        var (bestVector, bestQuality, totalEvals) = HillClimbing(dim, lowerBound, upperBound, p, r, maxEvaluations);

        Console.WriteLine("\n--- Resultado ---");
        Console.WriteLine($"Mejor vector x*: [{string.Join(", ", Array.ConvertAll(bestVector, v => v.ToString("F6")))}]");
        Console.WriteLine($"Aptitud f(x*): {bestQuality:E8}");
        Console.WriteLine($"Evaluaciones totales: {totalEvals}");
    }
}