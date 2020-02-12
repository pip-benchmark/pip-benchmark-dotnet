using PipBenchmark.Utilities.Random;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace PipBenchmark.StandardBenchmarks.WPF.Controls
{
    public class StyledListBoxBasedDataGridTest : PassiveBenchmark
    {
        private const string Name1Text = "StyledListBoxBasedDataGridRandomData";
        private const string Name2Text = "StyledListBoxBasedDataGridGrowList";
        private const string Description1Text = "Measures ListBoxBasedDataGrid with random data";
        private const string Description2Text = "Measures ListBoxBasedDataGrid with growing list";

        private const int ItemsCount = 1000;
        private const int Width = 640;
        private const int Height = 480;

        private System.Random _random = new System.Random(Width);

        private int lastTick;
        private int frameCount;
        private int currentTick;
        private double elapsed;
        private double frameCountTime;
        private DispatcherTimer _frameTimer;
        private StyledDataGridWindow _window;

        ObservableCollection<DataItem> _dataItems = new ObservableCollection<DataItem>();

        public StyledListBoxBasedDataGridTest(bool growOnly)
            : base(
                growOnly ? Name2Text : Name1Text,
                growOnly ? Description2Text : Description1Text
            )
        {
            this.GrowListOnly = growOnly;
        }

        private bool GrowListOnly { get ; set;}

        public override void SetUp()
        {
            if (!GrowListOnly)
            {
                AppendNewDataItems(ItemsCount);
            }

            _window = new StyledDataGridWindow();
            _window.Width = Width;
            _window.Height = Height;
            _window.DataContext = _dataItems;
            _window.Closed += OnWindowClosed;
            _window.Show();

            _frameTimer = new System.Windows.Threading.DispatcherTimer();
            _frameTimer.Tick += OnFrame;
            _frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
            _frameTimer.Start();
        }

        public override void TearDown()
        {
            _frameTimer.Stop();
            _window.Close();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            Context.Stop();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            this.currentTick = System.Environment.TickCount;
            this.elapsed = (double)(this.currentTick - this.lastTick) / 1000.0;
            this.lastTick = this.currentTick;

            frameCount++;
            frameCountTime += elapsed;
            if (frameCountTime >= 1.0)
            {
                frameCountTime -= 1.0;
                Context.IncrementCounter(frameCount);
                frameCount = 0;
            }

            if (GrowListOnly)
            {
                AppendNewDataItems(10);
                _window.ScrollTo(_dataItems.Count - 1);

                if (_dataItems.Count > ItemsCount)
                {
                    _dataItems.Clear();
                }
            }
            else
            {
                for (int index = 0; index < ItemsCount; index++)
                {
                    _dataItems[index].Age = RandomInteger.NextInteger(100);
                    _dataItems[index].Name = "Name #" + index + " - " + RandomInteger.NextInteger(1000);
                    _dataItems[index].RandomNumber = RandomDouble.NextDouble(1.0) * 1000;
                }
                _window.ScrollTo(RandomInteger.NextInteger(ItemsCount - 1));
            }
        }

        private void AppendNewDataItems(int count)
        {
            for (int index = 0; index < count; index++)
            {
                _dataItems.Add(new DataItem()
                {
                    Age = RandomInteger.NextInteger(100),
                    Name = "Name #" + _dataItems.Count,
                    RandomNumber = RandomDouble.NextDouble(1.0) * 1000
                });
            }
        }
    }
}
