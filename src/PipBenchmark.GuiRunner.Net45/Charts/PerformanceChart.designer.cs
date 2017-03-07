namespace PipBenchmark.Gui.Charts
{
    partial class PerformanceChart
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this._refreshTimer = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this._refreshTimer.Tick += new System.EventHandler(this.OnTimerRefreshTick);
            // 
            // PerfChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "PerfChart";
            this.Size = new System.Drawing.Size(235, 87);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer _refreshTimer;
    }
}
