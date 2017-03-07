using PipBenchmark.Gui.Shell;
using PipBenchmark.Runner;
using System;
using System.Windows.Forms;

namespace PipBenchmark.Gui.Config
{
    public class ConfigurationController : AbstractChildController
    {
        private IConfigurationView _view;
        private BenchmarkRunner _model;
        private OpenFileDialog _loadConfigurationDialog;
        private SaveFileDialog _saveConfigurationDialog;

        public ConfigurationController(MainController mainController, IConfigurationView view)
            : base(mainController)
        {
            _view = view;
            _view.LoadConfigurationClicked += OnLoadConfigurationClicked;
            _view.SaveConfigurationClicked += OnSaveConfigurationClicked;
            _view.SetToDefaultClicked += OnSetToDefaultClicked;

            _model = mainController.Model;
            _model.ConfigurationUpdated += OnConfigurationUpdated;

            InitializeDialogs();
            UpdateView();
        }

        private void InitializeDialogs()
        {
            _loadConfigurationDialog = new OpenFileDialog();
            _loadConfigurationDialog.Filter = "Property Files|*.properties|All Files|*.*";
#if !CompactFramework
            _loadConfigurationDialog.Title = "Load Configuration Properties";
            _loadConfigurationDialog.Multiselect = false;
            _loadConfigurationDialog.DefaultExt = "properties";
#endif

            _saveConfigurationDialog = new SaveFileDialog();
            _saveConfigurationDialog.FileName = "BenchmarkConfiguration.properties";
            _saveConfigurationDialog.Filter = "Property Files|*.properties|All Files|*.*";
#if !CompactFramework
            _saveConfigurationDialog.Title = "Save Configuration Properties";
#endif
        }

        public void UpdateView()
        {
            _view.Configuration = _model.Configuration;
        }

        public void LoadConfiguration()
        {
            if (_loadConfigurationDialog.ShowDialog() == DialogResult.OK)
            {
                _model.LoadConfigurationFromFile(_loadConfigurationDialog.FileName);
                UpdateView();
                MainController.ExecutionController.UpdateView();
                MainController.InitializationController.UpdateView();
            }
        }

        public void SaveConfiguration()
        {
            if (_saveConfigurationDialog.ShowDialog() == DialogResult.OK)
            {
                _model.SaveConfigurationToFile(_saveConfigurationDialog.FileName);
            }
        }

        private void OnConfigurationUpdated(object sender, EventArgs args)
        {
            UpdateView();
        }

        private void OnLoadConfigurationClicked(object sender, EventArgs args)
        {
            LoadConfiguration();
        }

        private void OnSaveConfigurationClicked(object sender, EventArgs args)
        {
            SaveConfiguration();
        }

        private void OnSetToDefaultClicked(object sender, EventArgs args)
        {
            _model.SetConfigurationToDefault();
            _view.RefreshData();
        }
    }
}
