
namespace TimerVsWhileBackground
{
    public class SegundoPlanoConWhile : BackgroundService
    {
        int instanciasSiendoEjecutadas = 0;
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                instanciasSiendoEjecutadas++;
                Console.WriteLine($"WHILE: comenzando ejecución... (Tareas siendo ejecutadas {instanciasSiendoEjecutadas})");

                // Simulamos una tarea larga
                await Task.Delay(TimeSpan.FromSeconds(10));

                Console.WriteLine($"WHILE ({DateTime.Now.ToString("hh:mm:ss")}): Ejecutando tarea en segundo plano...");
                instanciasSiendoEjecutadas--;

                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);

            }
        }
    }
}
