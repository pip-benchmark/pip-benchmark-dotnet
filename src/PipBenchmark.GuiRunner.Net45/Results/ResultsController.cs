using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using PipBenchmark.Runner;

#if !CompactFramework
using System.Drawing.Printing;
#endif

using PipBenchmark.Gui.Shell;

namespace PipBenchmark.Gui.Results
{
    public class ResultsController : AbstractChildController
    {
        private static readonly Font PrintFont = new Font("Tahoma", 10, FontStyle.Regular);
        private IResultsView _view;
        private BenchmarkRunner _model;
        private SaveFileDialog _saveReportDialog;
#if !CompactFramework
        private string[] _printLines;
        private int _linesPrinted;
        private PrintDialog _printReportDialog;
        private PrintDocument _printDocument;
#endif

        public ResultsController(MainController mainController, IResultsView view)
            : base(mainController)
        {
            _view = view;
            _view.SaveReportClicked += OnSaveReportClicked;
            _view.PrintReportClicked += OnPrintReportClicked;

            _model = mainController.Model;

            InitializeDialogs();
        }

        private void InitializeDialogs()
        {
            _saveReportDialog = new SaveFileDialog();
            _saveReportDialog.FileName = "BenchmarkReport.txt";
            _saveReportDialog.Filter = "Text Files|*.txt|All Files|*.*";
#if !CompactFramework
            _saveReportDialog.Title = "Save Benchmark Report";

            _printReportDialog = new PrintDialog();
            _printReportDialog.AllowSelection = false;
            _printReportDialog.AllowSomePages = false;

            _printDocument = new PrintDocument();
            _printDocument.DocumentName = "Benchmark Report";
            _printDocument.BeginPrint += OnBeginPrint;
            _printDocument.PrintPage += OnPrintPage;
#endif
        }

        public void GenerateReport()
        {
            string report = _model.GenerateReport();
            _view.ReportContent = report;
        }

        public void SaveReport()
        {
            if (_saveReportDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = File.OpenWrite(_saveReportDialog.FileName))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(_view.ReportContent);
                    }
                }
            }
        }

        public void PrintReport()
        {
#if !CompactFramework
            if (_printReportDialog.ShowDialog() == DialogResult.OK)
            {
                _printDocument.PrinterSettings = _printReportDialog.PrinterSettings;
                _printDocument.Print();
            }
#endif
        }

        private void OnSaveReportClicked(object sender, EventArgs args)
        {
            SaveReport();
        }

        private void OnPrintReportClicked(object sender, EventArgs args)
        {
            PrintReport();
        }

#if !CompactFramework
        private void OnBeginPrint(object sender, PrintEventArgs e)
        {
            char[] param = {'\n'};

            if (_printReportDialog.PrinterSettings.PrintRange == PrintRange.Selection)
            {
                _printLines = _view.ReportContent.Split(param);
            }
            else
            {
                _printLines = _view.ReportContent.Split(param);
            }
                    
            char[] trimParam = {'\r'};
            for (int index = 0; index < _printLines.Length; index++)
            {
                _printLines[index] = _printLines[index].TrimEnd(trimParam);
            }
            _linesPrinted = 0;
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            while (_linesPrinted < _printLines.Length)
            {
                e.Graphics.DrawString(_printLines[_linesPrinted++], PrintFont, Brushes.Black, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }
        }
#endif
    }
}
