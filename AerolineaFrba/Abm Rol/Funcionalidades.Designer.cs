namespace AerolineaFrba.Abm_Rol
{
    partial class Funcionalidades
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
            this.label1 = new System.Windows.Forms.Label();
            this.CB_funcionalidades = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BT_guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionalidad";
            // 
            // CB_funcionalidades
            // 
            this.CB_funcionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_funcionalidades.FormattingEnabled = true;
            this.CB_funcionalidades.Location = new System.Drawing.Point(92, 10);
            this.CB_funcionalidades.Name = "CB_funcionalidades";
            this.CB_funcionalidades.Size = new System.Drawing.Size(296, 21);
            this.CB_funcionalidades.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT_guardar
            // 
            this.BT_guardar.Location = new System.Drawing.Point(312, 48);
            this.BT_guardar.Name = "BT_guardar";
            this.BT_guardar.Size = new System.Drawing.Size(76, 23);
            this.BT_guardar.TabIndex = 3;
            this.BT_guardar.Text = "Guardar Cambio";
            this.BT_guardar.UseVisualStyleBackColor = true;
            this.BT_guardar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Funcionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 83);
            this.Controls.Add(this.BT_guardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CB_funcionalidades);
            this.Controls.Add(this.label1);
            this.Name = "Funcionalidades";
            this.Text = "Funcionalidad";
            this.Load += new System.EventHandler(this.Funcionalidades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_funcionalidades;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BT_guardar;
    }
}