﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PipBenchmark.Gui.About
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void OnOkButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
