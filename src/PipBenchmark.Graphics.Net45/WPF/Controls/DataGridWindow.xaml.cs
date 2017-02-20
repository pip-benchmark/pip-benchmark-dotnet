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

namespace PipBenchmark.StandardBenchmarks.WPF.Controls
{
    /// <summary>
    /// Interaction logic for dataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : Window
    {
        public DataGridWindow()
        {
            InitializeComponent();
        }

        public void ScrollTo(int index)
        {
            listView.SelectedIndex = index;
            listView.ScrollIntoView(listView.Items[index]);
        }
    }
}
