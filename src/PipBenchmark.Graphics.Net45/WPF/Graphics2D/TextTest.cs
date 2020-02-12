using PipBenchmark.Utilities.Random;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace PipBenchmark.StandardBenchmarks.WPF.Graphic2D
{
    public class TextTest : PassiveBenchmark
    {
        private const int LinesCount = 1000;
        private const int Width = 640;
        private const int Height = 480;

        private Window _window;
        private Canvas _canvas;
        private Label[] _labels;
        private System.Random _random = new System.Random(Width);

        private int lastTick;
        private int frameCount;
        private int currentTick;
        private double elapsed;
        private double frameCountTime;
        private DispatcherTimer _frameTimer;

        public TextTest()
            : base("Text", "Measures text drawing in WPF")
        {
        }

        public override void SetUp()
        {
            _canvas = new Canvas();
            _canvas.Background = new SolidColorBrush(Colors.White);
            _labels = new Label[LinesCount];

            _window = new Window();
            _window.Width = Width;
            _window.Height = Height;
            _window.Content = _canvas;
            _window.Background = new SolidColorBrush(Colors.Black);
            _window.Closed += OnWindowClosed;
            _window.Show();

            for (int index = 0; index < _labels.Length; index++)
            {
                Color color = Color.FromArgb((byte)RandomInteger.NextInteger(255),
                    (byte)RandomInteger.NextInteger(255), (byte)RandomInteger.NextInteger(255), (byte)RandomInteger.NextInteger(255));

                _labels[index] = new Label();
                _canvas.Children.Add(_labels[index]);
                _labels[index].Content = RandomDouble.NextDouble(1.0).ToString();
                Canvas.SetLeft(_labels[index], RandomInteger.NextInteger(Width));
                Canvas.SetTop(_labels[index], RandomInteger.NextInteger(Height));
            }

            lastTick = System.Environment.TickCount;
            _frameTimer = new System.Windows.Threading.DispatcherTimer();
            _frameTimer.Tick += OnFrame;
            _frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
            _frameTimer.Start();
        }

        public override void TearDown()
        {
            _frameTimer.Stop();
            _window.Close();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            Context.Stop();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            currentTick = System.Environment.TickCount;
            elapsed = (double)(this.currentTick - this.lastTick) / 1000.0;
            lastTick = this.currentTick;

            frameCount++;
            frameCountTime += elapsed;
            if (frameCountTime >= 1.0)
            {
                frameCountTime -= 1.0;
                Context.IncrementCounter(frameCount);
                frameCount = 0;
            }

            for (int index = 0; index < _labels.Length; index++)
            {
                _labels[index].Content = RandomDouble.NextDouble(1.0).ToString();
                Canvas.SetLeft(_labels[index], RandomInteger.NextInteger(Width));
                Canvas.SetTop(_labels[index], RandomInteger.NextInteger(Height));
            }
        }
    }
}
