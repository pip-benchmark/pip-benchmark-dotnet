using PipBenchmark.Utilities.Random;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PipBenchmark.Hardware
{
    public class StandardVideoBenchmark : Benchmark
    {
        private const int MaxLength = 100;
        private const int MaxWindowWidth = 480;
        private const int MaxWindowHeight = 480;

        private object _syncRoot = new object();
        private Form _outputForm;
        private System.Drawing.Graphics _outputGraphics;

        public StandardVideoBenchmark()
            : base("Video", "Measures speed of drawing draphical primitives")
        {
        }

        public override void SetUp()
        {
            _outputForm = new Form();
            _outputForm.Width = Math.Min(MaxWindowWidth, Screen.PrimaryScreen.Bounds.Width);
            _outputForm.Height = Math.Min(MaxWindowHeight, Screen.PrimaryScreen.Bounds.Height);
#if !CompactFramework
            _outputForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
#endif
            _outputForm.TopMost = true;
            _outputForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            _outputForm.Text = "Video Benchmarking";
            _outputForm.MinimizeBox = false;
            _outputForm.MaximizeBox = false;
#if !CompactFramework
            _outputForm.FormClosed += OnFormClosed;
#else
            _outputForm.Closed += OnFormClosed;
#endif
            _outputForm.Show();
            _outputGraphics = _outputForm.CreateGraphics();
        }

#if !CompactFramework
        private void OnFormClosed(object sender, FormClosedEventArgs args)
#else
        private void OnFormClosed(object sender, EventArgs args)
#endif
        {
            if (Context != null)
            {
                Context.Stop();
            }
        }

        public override void Execute()
        {
            if (_outputGraphics == null)
            {
                return;
            }

#if !CompactFramework
            int windowWidth = _outputForm.Width;
            int windowHeight = _outputForm.Height;
#else
            int windowWidth = Screen.PrimaryScreen.Bounds.Width;
            int windowHeight = Screen.PrimaryScreen.Bounds.Height;
#endif

            int xStart = -MaxLength / 2 + RandomInteger.NextInteger(MaxWindowWidth + MaxLength);
            int yStart = -MaxLength / 2 + RandomInteger.NextInteger(MaxWindowHeight + MaxLength);
            int xEnd = -MaxLength / 2 + RandomInteger.NextInteger(MaxWindowWidth + MaxLength);
            int yEnd = -MaxLength / 2 + RandomInteger.NextInteger(MaxWindowHeight + MaxLength);

            if (RandomInteger.NextInteger(2) == 0)
            {
                lock (_syncRoot)
                {
                    using (Pen pen = new Pen(GetRandomColor(), 1 + RandomInteger.NextInteger(5)))
                    {
                        _outputGraphics.DrawLine(pen, xStart, yStart, xEnd, yEnd);
                    }
                }
            }
            else
            {
                lock (_syncRoot)
                {
                    using (Brush brush = new SolidBrush(GetRandomColor()))
                    {
                        _outputGraphics.FillRectangle(brush, Math.Min(xStart, xEnd),
                            Math.Min(yStart, yEnd), Math.Abs(xEnd - xStart), Math.Abs(yEnd - yStart));
                    }
                }
            }
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(RandomInteger.NextInteger(256),
                RandomInteger.NextInteger(256), RandomInteger.NextInteger(256));
        }

        public override void TearDown()
        {
            lock (_syncRoot)
            {
                _outputGraphics.Dispose();
                _outputGraphics = null;

                _outputForm.Hide();
                _outputForm = null;
            }
        }
    }
}
