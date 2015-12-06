namespace AerolineaFrba.Abm_Ciudad
{
    partial class BaseCiudad
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
            this.BT_guardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_nombre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_codigo = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_guardar
            // 
            this.BT_guardar.Location = new System.Drawing.Point(197, 97);
            this.BT_guardar.Name = "BT_guardar";
            this.BT_guardar.Size = new System.Drawing.Size(75, 23);
            this.BT_guardar.TabIndex = 16;
            this.BT_guardar.Text = "Guardar";
            this.BT_guardar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TB_nombre);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TB_codigo);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 79);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ciudad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Nombre";
            // 
            // TB_nombre
            // 
            this.TB_nombre.Location = new System.Drawing.Point(94, 45);
            this.TB_nombre.MaxLength = 25;
            this.TB_nombre.Name = "TB_nombre";
            this.TB_nombre.Size = new System.Drawing.Size(159, 20);
            this.TB_nombre.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Codigo";
            // 
            // TB_codigo
            // 
            this.TB_codigo.Enabled = false;
            this.TB_codigo.Location = new System.Drawing.Point(94, 19);
            this.TB_codigo.Name = "TB_codigo";
            this.TB_codigo.Size = new System.Drawing.Size(159, 20);
            this.TB_codigo.TabIndex = 24;
            // 
            // BaseCiudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 127);
            this.Controls.Add(this.BT_guardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Name = "BaseCiudad";
            this.Text = "BaseCiudad";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button BT_guardar;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox TB_nombre;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox TB_codigo;
    }
}