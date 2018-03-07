using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PipBenchmark.StandardBenchmarks.WPF.Controls
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class GridLayout : Window
    {
        int counter = 0;
        int gridSize = 5;
        int numItems = 8;

        public ArrayList Targets = new ArrayList();
        public ArrayList Hosts = new ArrayList();
        public ArrayList Panels = new ArrayList();
        public ArrayList Buttons = new ArrayList();
        
        public GridLayout()
        {
            InitializeComponent();
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            Application app = System.Windows.Application.Current;

            Panels.Add(LTLGrid);
            Panels.Add(LTLGrid2);
            Panels.Add(LTLStackPanel);
            Panels.Add(LTLWrapPanel);

            //Debug.WriteLine("Grid children: " + ButtonGrid.Children.Count);

            for (int i = 0; i < numItems; i++)
            {
                LayoutToLayoutTarget target = new LayoutToLayoutTarget();
                Targets.Add(target);
                target.Margin = new Thickness(5);
                target.MinWidth = 80; target.MinHeight = 50;
                target.BorderThickness = new Thickness(0);

                Grid.SetRow(target, i / 5);
                Grid.SetColumn(target, i % 5);
                LTLGrid.Children.Add(target);

                LayoutToLayoutHost host = new LayoutToLayoutHost();
                Hosts.Add(host);
                host.BorderThickness = new Thickness(0);

                Button demoButton = new Button();
                demoButton.Content = "# " + i;
                demoButton.Click += OnAdvanceClick;
                host.Child = demoButton;

                Canvas.SetLeft(host, 0); Canvas.SetTop(host, 0);
                LTLCanvas.Children.Add(host);

                host.BindToTarget(target);
            }
        }

        private void OnAdvanceClick(object sender, RoutedEventArgs e)
        {
            DoAdvanceLayout();
        }

        /// <summary>
        /// Increase the starting location in the grid by one
        /// </summary>
        public void DoAdvanceLayout()
        {
            counter++;

            for (int i = 0; i < Hosts.Count; i++)
                MoveObject(Hosts[i] as LayoutToLayoutHost, counter + i);
        }

        /// <summary>
        /// Decrease the starting location in the grid by one
        /// </summary>
        public void DoRetreatLayout()
        {
            counter--;

            for (int i = 0; i < Hosts.Count; i++)
                MoveObject(Hosts[i] as LayoutToLayoutHost, counter + i);
        }

        /// <summary>
        /// Set the Stackpanel's orientation to vertical
        /// </summary>
        public void DoStackVerticalLayout()
        {
            //for (int i = 0; i < Hosts.Count; i++)
            //    (Hosts[i] as LayoutToLayoutHost).BeginAnimating(false);

            LTLStackPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
        }

        /// <summary>
        /// Set the stackpanel's orientation to vertical
        /// </summary>
        public void DoStackHorizontalLayout()
        {
            //for (int i = 0; i < Hosts.Count; i++)
            //    (Hosts[i] as LayoutToLayoutHost).BeginAnimating(false);

            LTLStackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
        }

        /// <summary>
        /// Set the wrappanel's orientation to vertical
        /// </summary>
        public void DoWrapVerticalLayout()
        {
            //for (int i = 0; i < Hosts.Count; i++)
            //    (Hosts[i] as LayoutToLayoutHost).BeginAnimating(false);

            LTLWrapPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
        }

        /// <summary>
        /// Set the wrappanel's orientation to vertical
        /// </summary>
        public void DoWrapHorizontalLayout()
        {
            //for (int i = 0; i < Hosts.Count; i++)
            //    (Hosts[i] as LayoutToLayoutHost).BeginAnimating(false);

            LTLWrapPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
        }

        /// <summary>
        /// Move all buttons into the 5x5 grid
        /// </summary>
        public void DoMoveToGrid5()
        {
            ClearPanels();
            gridSize = 5;
            counter = 0;

            for (int i = 0; i < numItems; i++)
            {
                LayoutToLayoutTarget target = Targets[i] as LayoutToLayoutTarget;
                //(Hosts[i] as LayoutToLayoutHost).BeginAnimating(false);
                Grid.SetRow(target, i / 5);
                Grid.SetColumn(target, i % 5);
                LTLGrid.Children.Add(target);
            }
        }

        /// <summary>
        /// Move all buttons into the 3x3 grid
        /// </summary>
        public void DoMoveToGrid3()
        {
            ClearPanels();
            gridSize = 3;
            counter = 0;

            for (int i = 0; i < numItems; i++)
            {
                LayoutToLayoutTarget target = Targets[i] as LayoutToLayoutTarget;
                //(Hosts[i] as LayoutToLayoutHost).BeginAnimating(false);
                Grid.SetRow(target, i / 3);
                Grid.SetColumn(target, i % 3);
                LTLGrid2.Children.Add(target);
            }

        }

        /// <summary>
        /// Move all buttons into the stack panel
        /// </summary>
        public void DoStackPanelLayout()
        {
            ClearPanels();
            for (int i = 0; i < numItems; i++)
            {
                LayoutToLayoutTarget target = Targets[i] as LayoutToLayoutTarget;
                //(Hosts[i] as LayoutToLayoutHost).BeginAnimating(false);
                LTLStackPanel.Children.Add(target);
            }

        }

        /// <summary>
        /// Move all buttons into the wrap panel
        /// </summary>
        public void DoMoveToWrap()
        {
            ClearPanels();
            for (int i = 0; i < numItems; i++)
            {
                LayoutToLayoutTarget target = Targets[i] as LayoutToLayoutTarget;
                //(Hosts[i] as LayoutToLayoutHost).BeginAnimating(false);
                LTLWrapPanel.Children.Add(target);
            }

        }


        /// <summary>
        /// move an object from one grid cell to another
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="position"></param>
        void MoveObject(LayoutToLayoutHost obj, int position)
        {
            int max = gridSize * gridSize - 1;
            if (position > max)
                position = max;
            if (position < 0)
                position = 0;

            //obj.BeginAnimating(false);
            Grid.SetRow(obj.Target, position / gridSize);
            Grid.SetColumn(obj.Target, position % gridSize);
        }

        /// <summary>
        /// Remove all elements from all panels
        /// </summary>
        void ClearPanels()
        {
            for (int i = 0; i < Panels.Count; i++)
            {
                (Panels[i] as Panel).Children.Clear();
            }
        }
    }
}
