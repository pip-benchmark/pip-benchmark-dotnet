﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using PipBenchmark.Graphics.Properties;

namespace PipBenchmark.Graphics
{
    public class GraphicsBenchmarkSuite : BenchmarkSuite
    {
        private const int MaxLength = 100;
        private const int MaxWindowWidth = 480;
        private const int MaxWindowHeight = 480;
        private Image[] Images = new Image[] { 
            Resources.Bitmap1, Resources.Bitmap2, Resources.Bitmap3, Resources.Bitmap4,
            Resources.Bitmap5 
        };

        private object _syncRoot = new object();
        private Random _randomGenerator = new Random();
        private Form _outputForm;
        private System.Drawing.Graphics _outputGraphics;
        private int _windowWidth;
        private int _windowHeight;

        public GraphicsBenchmarkSuite()
            : base("Graphics", "Benchmark for graphical operations")
        {
            InitializeTests();
        }

        private void InitializeTests()
        {
            AddBenchmark("Line", "Measures line drawings", ExecuteDrawLine);
            AddBenchmark("Rectangle", "Measures rectangle drawings", ExecuteDrawRectangle);
            AddBenchmark("Text", "Measures text drawings", ExecuteDrawText);
            AddBenchmark("Bitmap", "Measures bitmap drawings", ExecuteDrawBitmap);
            AddBenchmark("BitmapScaled", "Measures scaled bitmap drawings", ExecuteDrawBitmapScaled);
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
            _outputForm.Text = "Graphics Benchmarking";
            _outputForm.MinimizeBox = false;
            _outputForm.MaximizeBox = false;
#if !CompactFramework
            _outputForm.FormClosed += OnFormClosed;
#else
            _outputForm.Closed += OnFormClosed;
#endif
            _outputForm.Resize += OnFormResize;
            _outputForm.Show();
            _outputGraphics = _outputForm.CreateGraphics();
            UpdateFormSize();
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

        private void OnFormResize(object sender, EventArgs args)
        {
            UpdateFormSize();
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

        private void UpdateFormSize()
        {
#if !CompactFramework
            _windowWidth = _outputForm.Width;
            _windowHeight = _outputForm.Height;
#else
            _windowWidth = Screen.PrimaryScreen.Bounds.Width;
            _windowHeight = Screen.PrimaryScreen.Bounds.Height;
#endif
        }
        
        private Color GetRandomColor()
        {
            return Color.FromArgb(_randomGenerator.Next(256),
                _randomGenerator.Next(256), _randomGenerator.Next(256));
        }

        public void ExecuteDrawLine()
        {
            lock (_syncRoot)
            {
                int xStart = -MaxLength / 2 + _randomGenerator.Next(MaxWindowWidth + MaxLength);
                int yStart = -MaxLength / 2 + _randomGenerator.Next(MaxWindowHeight + MaxLength);
                int xEnd = -MaxLength / 2 + _randomGenerator.Next(MaxWindowWidth + MaxLength);
                int yEnd = -MaxLength / 2 + _randomGenerator.Next(MaxWindowHeight + MaxLength);

                using (Pen pen = new Pen(GetRandomColor(), 1 + _randomGenerator.Next(5)))
                {
                    _outputGraphics.DrawLine(pen, xStart, yStart, xEnd, yEnd);
                }
            }
        }

        public void ExecuteDrawRectangle()
        {
            lock (_syncRoot)
            {
                int xStart = -MaxLength / 2 + _randomGenerator.Next(MaxWindowWidth + MaxLength);
                int yStart = -MaxLength / 2 + _randomGenerator.Next(MaxWindowHeight + MaxLength);
                int xEnd = -MaxLength / 2 + _randomGenerator.Next(MaxWindowWidth + MaxLength);
                int yEnd = -MaxLength / 2 + _randomGenerator.Next(MaxWindowHeight + MaxLength);

                using (Brush brush = new SolidBrush(GetRandomColor()))
                {
                    _outputGraphics.FillRectangle(brush, Math.Min(xStart, xEnd),
                        Math.Min(yStart, yEnd), Math.Abs(xEnd - xStart), Math.Abs(yEnd - yStart));
                }
            }
        }

        public void ExecuteDrawText()
        {
            lock (_syncRoot)
            {
                int x = -MaxLength / 2 + _randomGenerator.Next(MaxWindowWidth + MaxLength);
                int y = -MaxLength / 2 + _randomGenerator.Next(MaxWindowHeight + MaxLength);

                using (Brush brush = new SolidBrush(GetRandomColor()))
                {
                    FontFamily fontFamily;
#if !CompactFramework
                    do
                    {
                        fontFamily = FontFamily.Families[
                        _randomGenerator.Next(0, FontFamily.Families.Length)];
                    } while (!fontFamily.IsStyleAvailable(FontStyle.Regular));
#else
                    switch (_randomGenerator.Next(3))
                    {
                        case 0:
                            fontFamily = FontFamily.GenericSansSerif;
                            break;
                        case 1:
                            fontFamily = FontFamily.GenericSerif;
                            break;
                        default:
                            fontFamily = FontFamily.GenericMonospace;
                            break;
                    }
#endif

                    using (Font font = new Font(fontFamily,
                        _randomGenerator.Next(6, 32), FontStyle.Regular))
                    {
                        _outputGraphics.DrawString("Draw Text", font, brush, x, y);
                    }
                }
            }
        }

        public void ExecuteDrawBitmap()
        {
            lock (_syncRoot)
            {
                int x = -MaxLength / 2 + _randomGenerator.Next(MaxWindowWidth + MaxLength);
                int y = -MaxLength / 2 + _randomGenerator.Next(MaxWindowHeight + MaxLength);

#if !CompactFramework
                _outputGraphics.DrawImageUnscaled(Images[_randomGenerator.Next(0, Images.Length)], x, y);
#else
                _outputGraphics.DrawImage(Images[_randomGenerator.Next(0, Images.Length)], x, y);
#endif
            }
        }

        public void ExecuteDrawBitmapFast()
        {
            lock (_syncRoot)
            {
                int x = -MaxLength / 2 + _randomGenerator.Next(MaxWindowWidth + MaxLength);
                int y = -MaxLength / 2 + _randomGenerator.Next(MaxWindowHeight + MaxLength);

                _outputGraphics.DrawImage(Images[_randomGenerator.Next(0, Images.Length)], x, y);
            }
        }

        public void ExecuteDrawBitmapScaled()
        {
            lock (_syncRoot)
            {
                Image image = Images[_randomGenerator.Next(0, Images.Length)];
                int x = -MaxLength / 2 + _randomGenerator.Next(MaxWindowWidth + MaxLength);
                int y = -MaxLength / 2 + _randomGenerator.Next(MaxWindowHeight + MaxLength);
                int width = _randomGenerator.Next(10, image.Width);
                int height = _randomGenerator.Next(10, image.Height);

#if !CompactFramework
                _outputGraphics.DrawImage(image, x, y, width, height);
#else
                _outputGraphics.DrawImage(image, x, y);
#endif
            }
        }

    }
}
