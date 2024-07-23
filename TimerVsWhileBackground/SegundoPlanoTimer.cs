
namespace TimerVsWhileBackground
{
    public class SegundoPlanoTimer : BackgroundService
    {
        private Timer timer;
        private int instanciasSiendoEjecutadas = 0;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            timer = new Timer(EjecutarTarea, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            return Task.CompletedTask;
        }

        private async void EjecutarTarea(object? state)
        {
            Interlocked.Add(ref instanciasSiendoEjecutadas, 1);

            Console.WriteLine($"TIMER: comenzando ejecución... (Tareas siendo ejecutadas {instanciasSiendoEjecutadas})");

            // Simulamos una tarea larga
            await Task.Delay(TimeSpan.FromSeconds(10));

            Interlocked.Add(ref instanciasSiendoEjecutadas, -1);

            Console.WriteLine($"TIMER ({DateTime.Now.ToString("hh:mm:ss")}): Ejecutando tarea en segundo plano...");
        }

        public override void Dispose()
        {
            timer?.Dispose();
            base.Dispose();
        }

    }
}
