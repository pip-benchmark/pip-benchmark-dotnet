﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PipBenchmark.Gui.Charts
{
    /// <summary>
    /// Scale mode for value aspect ratio
    /// </summary>
    public enum ScaleMode
    {
        /// <summary>
        /// Absolute Scale Mode: Values from 0 to 100 are accepted and displayed
        /// </summary>
        Absolute,
        /// <summary>
        /// Relative Scale Mode: All values are allowed and displayed in a proper relation
        /// </summary>
        Relative
    }
}
