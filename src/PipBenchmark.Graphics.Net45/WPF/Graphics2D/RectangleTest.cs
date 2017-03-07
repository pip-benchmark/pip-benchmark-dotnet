using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PipBenchmark.StandardBenchmarks.WPF.Graphic2D
{
    public class RectangleTest : PassiveBenchmark
    {
        private const int LinesCount = 1000;
        private const int Width = 640;
        private const int Height = 480;

        private Window _window;
        private Canvas _canvas;
        private Rectangle[] _rectangles;
        private System.Random _random = new System.Random(Width);

        private int lastTick;
        private int frameCount;
        private int currentTick;
        private double elapsed;
        private double frameCountTime;
        private DispatcherTimer _frameTimer;

        public RectangleTest()
            : base("Rectangles", "Measures rectagles drawing in WPF")
        {
            //AddTest("Line", "Measures line drawings", ExecuteDrawLine);
            //AddTest("Shape Line", "Measures shape line drawings", ExecuteDrawShapeLine);
        }

        public override void SetUp()
        {
            _canvas = new Canvas();
            _canvas.Background = new SolidColorBrush(Colors.White);

            _window = new Window();
            _window.Width = Width;
            _window.Height = Height;
            _window.Content = _canvas;
            _window.Background = new SolidColorBrush(Colors.Black);
            _window.Closed += OnWindowClosed;
            _window.Show();

            _rectangles = new Rectangle[LinesCount];

            for (int index = 0; index < _rectangles.Length; index++)
            {
                Color color = Color.FromArgb((byte)_random.Next(255),
                    (byte)_random.Next(255), (byte)_random.Next(255), (byte)_random.Next(255));

                _rectangles[index] = new Rectangle();
                _rectangles[index].Width = _random.Next(Width / 2);
                _rectangles[index].Height = _random.Next(Height / 2);
                _rectangles[index].Stroke = new SolidColorBrush(color);
                _rectangles[index].Fill = new SolidColorBrush(color);
                _rectangles[index].StrokeThickness = 2;
                _canvas.Children.Add(_rectangles[index]);
                Canvas.SetLeft(_rectangles[index], _random.Next(Width / 2));
                Canvas.SetTop(_rectangles[index], _random.Next(Height / 2));
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
            this.currentTick = System.Environment.TickCount;
            this.elapsed = (double)(this.currentTick - this.lastTick) / 1000.0;
            this.lastTick = this.currentTick;

            frameCount++;
            frameCountTime += elapsed;
            if (frameCountTime >= 1.0)
            {
                frameCountTime -= 1.0;
                Context.IncrementCounter(frameCount);
                frameCount = 0;
            }

            for (int index = 0; index < _rectangles.Length; index++)
            {
                _rectangles[index].Width = _random.Next(Width / 2);
                _rectangles[index].Height = _random.Next(Width / 2);

                Canvas.SetLeft(_rectangles[index], _random.Next(Width / 2));
                Canvas.SetTop(_rectangles[index], _random.Next(Height / 2));
            }
        }
    }
}
