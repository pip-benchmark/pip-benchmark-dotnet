using PipBenchmark.StandardBenchmarks.WPF.Controls;
using PipBenchmark.StandardBenchmarks.WPF.Graphic2D;
using PipBenchmark.StandardBenchmarks.WPF.Graphic3D;
using PipBenchmark.StandardBenchmarks.WPF.Video;

namespace PipBenchmark.StandardBenchmarks.WPF
{
    public class WpfBenchmarkSuite : BenchmarkSuite
    {
        private const string NameText = "Graphics";
        private const string DescriptionText = "Set of WPF benchmarking tests";

        public WpfBenchmarkSuite()
            : base(NameText, DescriptionText)
        {
            AddBenchmark(new LinesTest());
            AddBenchmark(new RectangleTest());
            AddBenchmark(new TextTest());
            AddBenchmark(new BitmapTest(true));
            AddBenchmark(new BitmapTest(false));
            AddBenchmark(new ListViewBasedDataGridTest(false));
            AddBenchmark(new ListViewBasedDataGridTest(true));
            AddBenchmark(new StyledListBoxBasedDataGridTest(false));
            AddBenchmark(new StyledListBoxBasedDataGridTest(true));
            AddBenchmark(new ParticlesTest());
            AddBenchmark(new VideoTest());
        }
    }
}
