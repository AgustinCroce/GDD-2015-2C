namespace AerolineaFrba.Abm_Rol
{
    partial class BaseRol
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
            this.label9 = new System.Windows.Forms.Label();
            this.TB_nombre = new System.Windows.Forms.TextBox();
            this.CB_estado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_guardar
            // 
            this.BT_guardar.Location = new System.Drawing.Point(197, 102);
            this.BT_guardar.Name = "BT_guardar";
            this.BT_guardar.Size = new System.Drawing.Size(75, 23);
            this.BT_guardar.TabIndex = 16;
            this.BT_guardar.Text = "Guardar";
            this.BT_guardar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TB_nombre);
            this.groupBox2.Controls.Add(this.CB_estado);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 84);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rol";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Nombre";
            // 
            // TB_nombre
            // 
            this.TB_nombre.Location = new System.Drawing.Point(94, 19);
            this.TB_nombre.MaxLength = 15;
            this.TB_nombre.Name = "TB_nombre";
            this.TB_nombre.Size = new System.Drawing.Size(159, 20);
            this.TB_nombre.TabIndex = 24;
            // 
            // CB_estado
            // 
            this.CB_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_estado.FormattingEnabled = true;
            this.CB_estado.Items.AddRange(new object[] {
            "Habilitado",
            "Deshabilitado"});
            this.CB_estado.Location = new System.Drawing.Point(94, 45);
            this.CB_estado.Name = "CB_estado";
            this.CB_estado.Size = new System.Drawing.Size(159, 21);
            this.CB_estado.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado";
            // 
            // BaseRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 133);
            this.Controls.Add(this.BT_guardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Name = "BaseRol";
            this.Text = "BaseRol";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button BT_guardar;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox CB_estado;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox TB_nombre;
    }
}