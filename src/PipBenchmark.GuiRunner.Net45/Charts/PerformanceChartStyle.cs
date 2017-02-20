using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;

namespace PipBenchmark.Runner.Gui.Charts
{
#if !CompactFramework
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
#endif
    public class PerformanceChartStyle
    {
        private ChartPen _verticalGridPen;
        private ChartPen _horizontalGridPen;
        private ChartPen _averageLinePen;
        private ChartPen _chartLinePen;

        private Color _backgroundColorTop = Color.DarkGreen;
        private Color _backgroundColorBottom = Color.DarkGreen;

        private bool _showVerticalGridLines = true;
        private bool _showHorizontalGridLines = true;
        private bool _showAverageLine = true;
        private bool _antiAliasing = true;

        public PerformanceChartStyle() 
        {
            _verticalGridPen = new ChartPen();
            _horizontalGridPen = new ChartPen();
            _averageLinePen = new ChartPen();
            _chartLinePen = new ChartPen();
        }

        public bool ShowVerticalGridLines 
        {
            get { return _showVerticalGridLines; }
            set { _showVerticalGridLines = value; }
        }

        public bool ShowHorizontalGridLines 
        {
            get { return _showHorizontalGridLines; }
            set { _showHorizontalGridLines = value; }
        }

        public bool ShowAverageLine 
        {
            get { return _showAverageLine; }
            set { _showAverageLine = value; }
        }

        public ChartPen VerticalGridPen 
        {
            get { return _verticalGridPen; }
            set { _verticalGridPen = value; }
        }

        public ChartPen HorizontalGridPen 
        {
            get { return _horizontalGridPen; }
            set { _horizontalGridPen = value; }
        }

        public ChartPen AverageLinePen 
        {
            get { return _averageLinePen; }
            set { _averageLinePen = value; }
        }

        public ChartPen ChartLinePen 
        {
            get { return _chartLinePen; }
            set { _chartLinePen = value; }
        }

        public bool AntiAliasing 
        {
            get { return _antiAliasing; }
            set { _antiAliasing = value; }
        }

        public Color BackgroundColorTop 
        {
            get { return _backgroundColorTop; }
            set { _backgroundColorTop = value; }
        }

        public Color BackgroundColorBottom 
        {
            get { return _backgroundColorBottom; }
            set { _backgroundColorBottom = value; }
        }
    }
}
