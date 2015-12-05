namespace AerolineaFrba.Abm_Aeronave
{
    partial class FueraDeServicio
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
            this.DTP_desde = new System.Windows.Forms.DateTimePicker();
            this.DTP_hasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BT_Aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DTP_desde
            // 
            this.DTP_desde.Location = new System.Drawing.Point(53, 14);
            this.DTP_desde.Name = "DTP_desde";
            this.DTP_desde.Size = new System.Drawing.Size(219, 20);
            this.DTP_desde.TabIndex = 0;
            // 
            // DTP_hasta
            // 
            this.DTP_hasta.Location = new System.Drawing.Point(53, 40);
            this.DTP_hasta.Name = "DTP_hasta";
            this.DTP_hasta.Size = new System.Drawing.Size(219, 20);
            this.DTP_hasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT_Aceptar
            // 
            this.BT_Aceptar.Location = new System.Drawing.Point(197, 78);
            this.BT_Aceptar.Name = "BT_Aceptar";
            this.BT_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.BT_Aceptar.TabIndex = 5;
            this.BT_Aceptar.Text = "Aceptar";
            this.BT_Aceptar.UseVisualStyleBackColor = true;
            this.BT_Aceptar.Click += new System.EventHandler(this.BT_Aceptar_Click);
            // 
            // FueraDeServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.Controls.Add(this.BT_Aceptar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP_hasta);
            this.Controls.Add(this.DTP_desde);
            this.Name = "FueraDeServicio";
            this.Text = "FueraDeServicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTP_desde;
        private System.Windows.Forms.DateTimePicker DTP_hasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BT_Aceptar;
    }
}