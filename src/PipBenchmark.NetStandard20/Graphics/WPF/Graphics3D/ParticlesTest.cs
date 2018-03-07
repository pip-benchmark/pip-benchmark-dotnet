using System;
using System.Windows.Threading;

namespace PipBenchmark.StandardBenchmarks.WPF.Graphic3D
{
    /// <summary>
    /// Test is adapted Particles from Microsoft SDK example
    /// </summary>
    public class ParticlesTest : PassiveBenchmark
    {
        private const int LinesCount = 1000;
        private const int Width = 640;
        private const int Height = 480;

        private int lastTick;
        private int frameCount;
        private int currentTick;
        private double elapsed;
        private double totalElapsed;
        private double frameCountTime;
        private DispatcherTimer _frameTimer;
        private ParticlesWindow _particlesWindow;

        public ParticlesTest()
            : base("Particles", "Measures drawing 3D particles in WPF")
        {
            //AddTest("Line", "Measures line drawings", ExecuteDrawLine);
            //AddTest("Shape Line", "Measures shape line drawings", ExecuteDrawShapeLine);
        }

        public override void SetUp()
        {
            _particlesWindow = new ParticlesWindow();
            _particlesWindow.Width = Width;
            _particlesWindow.Height = Height;
            _particlesWindow.Closed += OnWindowClosed;
            _particlesWindow.Show();

            _frameTimer = new System.Windows.Threading.DispatcherTimer();
            _frameTimer.Tick += OnFrame;
            _frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
            _frameTimer.Start();
        }

        public override void TearDown()
        {
            _frameTimer.Stop();
            _particlesWindow.Close();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            Context.Stop();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            this.currentTick = System.Environment.TickCount;
            this.elapsed = (double)(this.currentTick - this.lastTick) / 1000.0;
            this.totalElapsed += this.elapsed;
            this.lastTick = this.currentTick;

            frameCount++;
            frameCountTime += elapsed;
            if (frameCountTime >= 1.0)
            {
                frameCountTime -= 1.0;
                Context.IncrementCounter(frameCount);
                frameCount = 0;
            }

            _particlesWindow.Update(elapsed, totalElapsed);
        }

    }
}
