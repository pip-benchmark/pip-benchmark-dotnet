using System;
using System.Windows.Threading;

namespace PipBenchmark.StandardBenchmarks.WPF.Video
{
    /// <summary>
    /// Test is adapted Particles from Microsoft SDK example
    /// </summary>
    public class VideoTest : PassiveBenchmark
    {
        private const int LinesCount = 1000;
        private const int Width = 640;
        private const int Height = 480;

        private DispatcherTimer _frameTimer;
        private VideoWindow _videoWindow;

        public VideoTest()
            : base("Video", "Measures overall graphics performance in WPF")
        {
            //AddTest("Line", "Measures line drawings", ExecuteDrawLine);
            //AddTest("Shape Line", "Measures shape line drawings", ExecuteDrawShapeLine);
        }

        public override void SetUp()
        {
            _videoWindow = new VideoWindow();
            _videoWindow.Width = Width;
            _videoWindow.Height = Height;
            _videoWindow.Closed += OnWindowClosed;
            _videoWindow.Show();

            _videoWindow.PlayMedia();

            _frameTimer = new System.Windows.Threading.DispatcherTimer();
            _frameTimer.Tick += OnFrame;
            _frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
            _frameTimer.Start();
        }

        public override void TearDown()
        {
            _frameTimer.Stop();
            _videoWindow.StopMedia();
            _videoWindow.Close();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            Context.Stop();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            if (_videoWindow.IsMediaStopped)
            {
                _videoWindow.PlayMedia();
            }
        }

    }
}
