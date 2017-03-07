using PipBenchmark.Gui.Shell;
using PipBenchmark.Runner;
using System;
using System.Windows.Forms;

namespace PipBenchmark.Gui.Parameters
{
    public class ParametersController : AbstractChildController
    {
        private IParametersView _view;
        private BenchmarkRunner _model;
        private OpenFileDialog _loadDialog;
        private SaveFileDialog _saveDialog;

        public ParametersController(MainController mainController, IParametersView view)
            : base(mainController)
        {
            _view = view;
            _view.LoadClicked += OnLoadClicked;
            _view.SaveClicked += OnSaveClicked;
            _view.SetToDefaultClicked += OnSetToDefaultClicked;

            _model = mainController.Model;
            _model.Configuration.Changed += OnConfigurationChanged;

            InitializeDialogs();
            UpdateView();
        }

        private void InitializeDialogs()
        {
            _loadDialog = new OpenFileDialog();
            _loadDialog.Filter = "Property Files|*.properties|All Files|*.*";
#if !CompactFramework
            _loadDialog.Title = "Load Properties";
            _loadDialog.Multiselect = false;
            _loadDialog.DefaultExt = "properties";
#endif

            _saveDialog = new SaveFileDialog();
            _saveDialog.FileName = "BenchmarkConfiguration.properties";
            _saveDialog.Filter = "Property Files|*.properties|All Files|*.*";
#if !CompactFramework
            _saveDialog.Title = "Save Properties";
#endif
        }

        public void UpdateView()
        {
            _view.Data = _model.Parameters.UserDefined;
        }

        public void Load()
        {
            if (_loadDialog.ShowDialog() == DialogResult.OK)
            {
                _model.Parameters.LoadFromFile(_loadDialog.FileName);
                UpdateView();
                MainController.ExecutionController.UpdateView();
                MainController.BenchmarksController.UpdateView();
            }
        }

        public void Save()
        {
            if (_saveDialog.ShowDialog() == DialogResult.OK)
            {
                _model.Parameters.SaveToFile(_saveDialog.FileName);
            }
        }

        private void OnConfigurationChanged(object sender, EventArgs args)
        {
            UpdateView();
        }

        private void OnLoadClicked(object sender, EventArgs args)
        {
            Load();
        }

        private void OnSaveClicked(object sender, EventArgs args)
        {
            Save();
        }

        private void OnSetToDefaultClicked(object sender, EventArgs args)
        {
            _model.Parameters.SetToDefault();
            _view.RefreshData();
        }
    }
}
