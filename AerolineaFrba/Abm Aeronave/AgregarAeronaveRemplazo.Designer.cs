namespace AerolineaFrba.Abm_Aeronave
{
    partial class AgregarAeronaveRemplazo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_guardar
            // 
            this.BT_guardar.Click += new System.EventHandler(this.BT_guardar_Click);
            // 
            // CB_servicio
            // 
            this.CB_servicio.Enabled = false;
            // 
            // TB_modelo
            // 
            this.TB_modelo.Enabled = false;
            // 
            // TB_matricula
            // 
            this.TB_matricula.Enabled = false;
            // 
            // TB_fabricante
            // 
            this.TB_fabricante.Enabled = false;
            // 
            // AgregarAeronaveRemplazo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 327);
            this.Name = "AgregarAeronaveRemplazo";
            this.Text = "AgregarAeronaveRemplazo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}