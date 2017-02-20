using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace PipBenchmark.StandardBenchmarks.WPF.Graphic2D
{
    public class BitmapTest : PassiveBenchmark
    {
        private const string Name1Text = "Bitmaps";
        private const string Name2Text = "ResizedBitmaps";
        private const string Description1Text = "Measures bitmaps drawing in WPF";
        private const string Description2Text = "Measures bitmaps resizing and drawing in WPF";

        private const int ImagesCount = 10;
        private const int Width = 640;
        private const int Height = 480;

        private Window _window;
        private Canvas _canvas;
        private Image[] _images;
        private Random _random = new Random(Width);

        private int lastTick;
        private int frameCount;
        private int currentTick;
        private double elapsed;
        private double frameCountTime;
        private DispatcherTimer _frameTimer;

        public BitmapTest(bool defaultSize)
            : base(
                defaultSize ? Name1Text : Name2Text, 
                defaultSize ? Description1Text : Description2Text
            )
        {
            this.DefaultSize = defaultSize;
            //AddTest("Line", "Measures line drawings", ExecuteDrawLine);
            //AddTest("Shape Line", "Measures shape line drawings", ExecuteDrawShapeLine);
        }

        private bool DefaultSize { get; set; }

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

            _images = new Image[ImagesCount];
            int bitmapIndex = 0;
            string[] bitmaps = new string[4] { null, null, null, null };
            bitmaps[0] = "pack://application:,,,/PipBenchmark.StandardBenchmarks;component/Resources/Bitmap1.jpg";
            bitmaps[1] = "pack://application:,,,/PipBenchmark.StandardBenchmarks;component/Resources/Bitmap2.jpg";
            bitmaps[2] = "pack://application:,,,/PipBenchmark.StandardBenchmarks;component/Resources/Bitmap3.jpg";
            bitmaps[3] = "pack://application:,,,/PipBenchmark.StandardBenchmarks;component/Resources/Bitmap4.jpg";


            for (int index = 0; index < _images.Length; index++)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(bitmaps[bitmapIndex]));

                _images[index] = new Image();
                _images[index].Source = bitmap;

                if (DefaultSize)
                {
                    _images[index].Width = bitmap.Width;
                    _images[index].Height = bitmap.Height;
                }
                else
                {
                    _images[index].Width = _random.Next(200);
                    _images[index].Height = _random.Next(200);
                }
                _images[index].Stretch = Stretch.Fill;
                _images[index].StretchDirection = StretchDirection.Both;
                _images[index].Visibility = Visibility.Visible;
                _canvas.Children.Add(_images[index]);

                Canvas.SetLeft(_images[index], _random.Next(Width / 2));
                Canvas.SetTop(_images[index], _random.Next(Height / 2));

                bitmapIndex++;
                if (bitmapIndex > 3)
                {
                    bitmapIndex = 0;
                }
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

            for (int index = 0; index < _images.Length; index++)
            {
                if (!DefaultSize)
                {
                    _images[index].Width = _random.Next(200);
                    _images[index].Height = _random.Next(200);
                }

                Canvas.SetLeft(_images[index], _random.Next(Width / 2));
                Canvas.SetTop(_images[index], _random.Next(Height / 2));
            }
        }
    }
}
