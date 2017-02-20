using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PipBenchmark.StandardBenchmarks.WPF.Video
{
    /// <summary>
    /// Interaction logic for VideoWindow.xaml
    /// </summary>
    public partial class VideoWindow : Window
    {
        MediaElement _masterVideoElement;

        public VideoWindow()
        {
            InitializeComponent();
        }


        public void PlayMedia()
        {
            StopMedia();

            _masterVideoElement = (MediaElement)this.Resources["MasterVideo"];
            _masterVideoElement.UnloadedBehavior = MediaState.Manual;

            this.Content = _masterVideoElement;
            //this.Background = new VisualBrush(_masterVideoElement);
            this.Width = _masterVideoElement.Width;
            this.Height = _masterVideoElement.Height;

            _masterVideoElement.Play();
        }

        public void StopMedia()
        {
            if (_masterVideoElement != null)
            {
                _masterVideoElement.Stop();
                _masterVideoElement = null;
            }
        }

        public bool IsMediaStopped
        {
            get { return _masterVideoElement == null || _masterVideoElement.LoadedBehavior == MediaState.Stop; }
        }

    }
}
