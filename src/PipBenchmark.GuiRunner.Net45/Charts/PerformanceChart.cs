using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PipBenchmark.Runner.Gui.Charts
{
    public partial class PerformanceChart : UserControl
    {
        // Keep only a maximum MAX_VALUE_COUNT amount of values; This will allow
        private const int MAX_VALUE_COUNT = 512;
        // Draw a background grid with a fixed line spacing
        private const int GRID_SPACING = 16;

        // Amount of currently visible values (calculated from control width and value spacing)
        private int _visibleValues = 0;
        // Horizontal value space in Pixels
        private int _valueSpacing = 5;
        // The currently highest displayed value, required for Relative Scale Mode
        private decimal _currentMaxValue = 0;
        // Offset value for the scrolling grid
        private int _gridScrollOffset = 0;
        // The current average value
        private decimal _averageValue = 0;
#if !CompactFramework
        // Border Style
        private Border3DStyle _border3dStyle = Border3DStyle.Sunken;
#endif
        // Scale mode for value aspect ratio
        private ScaleMode _scaleMode = ScaleMode.Absolute;
        // Timer Mode
        private TimerMode _timerMode;
        // List of stored values
        private List<decimal> _drawValues = new List<decimal>(MAX_VALUE_COUNT);
        // Value queue for Timer Modes
        private Queue<decimal> _waitingValues = new Queue<decimal>();
        // Style and Design
        private PerformanceChartStyle _perfChartStyle;

        public PerformanceChart() 
        {
            InitializeComponent();

            // Initialize Variables
            _perfChartStyle = new PerformanceChartStyle();

#if !CompactFramework
            // Set Optimized Double Buffer to reduce flickering
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Redraw when resized
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.Font = SystemInformation.MenuFont;
#endif
        }

#if !CompactFramework
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance"), Description("Appearance and Style")]
#endif
        public PerformanceChartStyle PerfChartStyle 
        {
            get { return _perfChartStyle; }
            set { _perfChartStyle = value; }
        }

#if !CompactFramework
        [DefaultValue(typeof(Border3DStyle), "Sunken"), Description("BorderStyle"), Category("Appearance")]
        new public Border3DStyle BorderStyle 
        {
            get 
            {
                return _border3dStyle;
            }
            set 
            {
                _border3dStyle = value;
                Invalidate();
            }
        }
#endif

        public ScaleMode ScaleMode 
        {
            get { return _scaleMode; }
            set { _scaleMode = value; }
        }

        public TimerMode TimerMode 
        {
            get { return _timerMode; }
            set {
                if (value == TimerMode.Disabled) 
                {
                    // Stop and append only when changed
                    if (_timerMode != TimerMode.Disabled) 
                    {
                        _timerMode = value;

                        _refreshTimer.Enabled = false;
                        // If there are any values in the queue, append them
                        ChartAppendFromQueue();
                    }
                }
                else 
                {
                    _timerMode = value;
                    _refreshTimer.Enabled = true;
                }
            }
        }

        public int TimerInterval 
        {
            get { return _refreshTimer.Interval; }
            set 
            {
                if (value < 15)
                {
                    throw new ArgumentOutOfRangeException("TimerInterval", "The Timer interval must be greater then 15");
                }
                else
                {
                    _refreshTimer.Interval = value;
                }
            }
        }

        /// <summary>
        /// Clears the whole chart
        /// </summary>
        public void Clear() 
        {
            _drawValues.Clear();
            Invalidate();
        }

        /// <summary>
        /// Adds a value to the Chart Line
        /// </summary>
        /// <param name="value">progress value</param>
        public void AddValue(decimal value) 
        {
            if (_scaleMode == ScaleMode.Absolute && value > 100M)
            {
                throw new Exception(String.Format("Values greater then 100 not allowed in ScaleMode: Absolute ({0})", value));
            }

            switch (_timerMode) 
            {
                case TimerMode.Disabled:
                    ChartAppend(value);
                    Invalidate();
                    break;
                case TimerMode.Simple:
                case TimerMode.SynchronizedAverage:
                case TimerMode.SynchronizedSum:
                    // For all Timer Modes, the Values are stored in the Queue
                    AddValueToQueue(value);
                    break;
                default:
                    throw new Exception(String.Format("Unsupported TimerMode: {0}", _timerMode));
            }
        }

        /// <summary>
        /// Add value to the queue for a timed refresh
        /// </summary>
        /// <param name="value"></param>
        private void AddValueToQueue(decimal value) 
        {
            _waitingValues.Enqueue(value);
        }


        /// <summary>
        /// Appends value <paramref name="value"/> to the chart (without redrawing)
        /// </summary>
        /// <param name="value">performance value</param>
        private void ChartAppend(decimal value) 
        {
            // Insert at first position; Negative values are flatten to 0 (zero)
            _drawValues.Insert(0, Math.Max(value, 0));

            // Remove last item if maximum value count is reached
            if (_drawValues.Count > MAX_VALUE_COUNT)
            {
                _drawValues.RemoveAt(MAX_VALUE_COUNT);
            }

            // Calculate horizontal grid offset for "scrolling" effect
            _gridScrollOffset += _valueSpacing;
            if (_gridScrollOffset > GRID_SPACING)
            {
                _gridScrollOffset = _gridScrollOffset % GRID_SPACING;
            }
        }


        /// <summary>
        /// Appends Values from queue
        /// </summary>
        private void ChartAppendFromQueue() 
        {
            // Proceed only if there are values at all
            if (_waitingValues.Count > 0) 
            {
                if (_timerMode == TimerMode.Simple) 
                {
                    while (_waitingValues.Count > 0)
                    {
                        ChartAppend(_waitingValues.Dequeue());
                    }
                }
                else if (_timerMode == TimerMode.SynchronizedAverage ||
                         _timerMode == TimerMode.SynchronizedSum) 
                {
                    // appendValue variable is used for calculating the average or sum value
                    decimal appendValue = Decimal.Zero;
                    int valueCount = _waitingValues.Count;

                    while (_waitingValues.Count > 0)
                    {
                        appendValue += _waitingValues.Dequeue();
                    }

                    // Calculate Average value in SynchronizedAverage Mode
                    if (_timerMode == TimerMode.SynchronizedAverage)
                    {
                        appendValue = appendValue / (decimal)valueCount;
                    }

                    // Finally append the value
                    ChartAppend(appendValue);
                }
            }
            else 
            {
                // Always add 0 (Zero) if there are no values in the queue
                ChartAppend(Decimal.Zero);
            }

            // Refresh the Chart
            Invalidate();
        }

        /// <summary>
        /// Calculates the vertical Position of a value in relation the chart size,
        /// Scale Mode and, if ScaleMode is Relative, to the current maximum value
        /// </summary>
        /// <param name="value">performance value</param>
        /// <returns>vertical Point position in Pixels</returns>
        private int CalcVerticalPosition(decimal value) 
        {
            decimal result = Decimal.Zero;

            if (_scaleMode == ScaleMode.Absolute)
            {
                result = value * this.Height / 100;
            }
            else if (_scaleMode == ScaleMode.Relative)
            {
                result = (_currentMaxValue > 0) ? (value * this.Height / _currentMaxValue) : 0;
            }

            result = this.Height - result;

            return Convert.ToInt32(Math.Round(result));
        }


        /// <summary>
        /// Returns the currently highest (displayed) value, for Relative ScaleMode
        /// </summary>
        /// <returns></returns>
        private decimal GetHighestValueForRelativeMode() 
        {
            decimal maxValue = 0;

            for (int i = 0; i < _visibleValues; i++) 
            {
                // Set if higher then previous max value
                if (_drawValues[i] > maxValue)
                {
                    maxValue = _drawValues[i];
                }
            }

            return maxValue;
        }

        /// <summary>
        /// Draws the chart (w/o background or grid, but with border) to the Graphics canvas
        /// </summary>
        /// <param name="g">Graphics</param>
        private void DrawChart(Graphics g) 
        {
            _visibleValues = Math.Min(this.Width / _valueSpacing, _drawValues.Count);

            if (_scaleMode == ScaleMode.Relative)
            {
                _currentMaxValue = GetHighestValueForRelativeMode();
            }

            // Dirty little "trick": initialize the first previous Point outside the bounds
            Point previousPoint = new Point(Width + _valueSpacing, Height);
            Point currentPoint = new Point();

            // Only draw average line when possible (visibleValues) and needed (style setting)
            if (_visibleValues > 0 && _perfChartStyle.ShowAverageLine) 
            {
                _averageValue = 0;
                DrawAverageLine(g);
            }

            // Connect all visible values with lines
            for (int i = 0; i < _visibleValues; i++) 
            {
                currentPoint.X = previousPoint.X - _valueSpacing;
                currentPoint.Y = CalcVerticalPosition(_drawValues[i]);

                // Actually draw the line
                g.DrawLine(_perfChartStyle.ChartLinePen.Pen, previousPoint.X, previousPoint.Y,
                    currentPoint.X, currentPoint.Y);

                previousPoint = currentPoint;
            }

            // Draw current relative maximum value stirng
            if (_scaleMode == ScaleMode.Relative) 
            {
                SolidBrush sb = new SolidBrush(_perfChartStyle.ChartLinePen.Color);
                g.DrawString(_currentMaxValue.ToString(), this.Font, sb, 4.0f, 2.0f);
            }

#if !CompactFramework
            // Draw Border on top
            ControlPaint.DrawBorder3D(g, 0, 0, Width, Height, _border3dStyle);
#endif
        }

        private void DrawAverageLine(Graphics g) 
        {
            for (int i = 0; i < _visibleValues; i++)
            {
                _averageValue += _drawValues[i];
            }

            _averageValue = _averageValue / _visibleValues;

            int verticalPosition = CalcVerticalPosition(_averageValue);
            g.DrawLine(_perfChartStyle.AverageLinePen.Pen, 0, verticalPosition, Width, verticalPosition);
        }

        /// <summary>
        /// Draws the background gradient and the grid into Graphics <paramref name="g"/>
        /// </summary>
        /// <param name="g">Graphic</param>
        private void DrawBackgroundAndGrid(Graphics g) 
        {
            // Draw the background Gradient rectangle
            Rectangle baseRectangle = new Rectangle(0, 0, this.Width, this.Height);
#if !CompactFramework
            using (Brush gradientBrush = new LinearGradientBrush(baseRectangle,
                _perfChartStyle.BackgroundColorTop, _perfChartStyle.BackgroundColorBottom,
                LinearGradientMode.Vertical)) 
#else
            using (Brush gradientBrush = new SolidBrush(_perfChartStyle.BackgroundColorBottom))
#endif
            {
                g.FillRectangle(gradientBrush, baseRectangle);
            }

            // Draw all visible, vertical gridlines (if wanted)
            if (_perfChartStyle.ShowVerticalGridLines) 
            {
                for (int i = Width - _gridScrollOffset; i >= 0; i -= GRID_SPACING) 
                {
                    g.DrawLine(_perfChartStyle.VerticalGridPen.Pen, i, 0, i, Height);
                }
            }

            // Draw all visible, horizontal gridlines (if wanted)
            if (_perfChartStyle.ShowHorizontalGridLines) 
            {
                for (int i = 0; i < Height; i += GRID_SPACING) 
                {
                    g.DrawLine(_perfChartStyle.HorizontalGridPen.Pen, 0, i, Width, i);
                }
            }
        }

        /// Override OnPaint method
        protected override void OnPaint(PaintEventArgs e) 
        {
            base.OnPaint(e);

#if !CompactFramework
            // Enable AntiAliasing, if needed
            if (_perfChartStyle.AntiAliasing)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
#endif

            DrawBackgroundAndGrid(e.Graphics);
            DrawChart(e.Graphics);
        }

        protected override void OnResize(EventArgs e) 
        {
            base.OnResize(e);
            Invalidate();
        }

        private void OnColorSetChanged(object sender, EventArgs e) 
        {
            //Refresh Chart on Resize
            Invalidate();
        }

        private void OnTimerRefreshTick(object sender, EventArgs e) 
        {
#if !CompactFramework
            // Don't execute event if running in design time
            if (this.DesignMode)
            {
                return;
            }
#endif
            ChartAppendFromQueue();
        }
    }
}
