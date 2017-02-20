using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace PipBenchmark.Runner.Gui.Charts
{
#if !CompactFramework
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
#endif
    public class ChartPen
    {
        private Pen _pen;

        public ChartPen()
        {
            _pen = new Pen(Color.Black);
        }

        public Color Color
        {
            get { return _pen.Color; }
            set { _pen.Color = value; }
        }

        public System.Drawing.Drawing2D.DashStyle DashStyle
        {
            get { return _pen.DashStyle; }
            set { _pen.DashStyle = value; }
        }

        public float Width
        {
            get { return _pen.Width; }
            set { _pen.Width = value; }
        }

#if !CompactFramework
        [Browsable(false)]
#endif
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pen Pen
        {
            get { return _pen; }
        }
    }
}
