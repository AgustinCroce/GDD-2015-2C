namespace AerolineaFrba.Abm_Aeronave
{
    partial class BaseAeronave
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_butacas_pasillo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_butacas_ventanilla = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_modelo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_numero = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_matricula = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_fabricante = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_kg_disponibles = new System.Windows.Forms.TextBox();
            this.CB_servicio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_guardar
            // 
            this.BT_guardar.Location = new System.Drawing.Point(197, 295);
            this.BT_guardar.Name = "BT_guardar";
            this.BT_guardar.Size = new System.Drawing.Size(75, 23);
            this.BT_guardar.TabIndex = 16;
            this.BT_guardar.Text = "Guardar";
            this.BT_guardar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_butacas_pasillo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TB_butacas_ventanilla);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 89);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Butacas";
            // 
            // TB_butacas_pasillo
            // 
            this.TB_butacas_pasillo.Location = new System.Drawing.Point(107, 53);
            this.TB_butacas_pasillo.MaxLength = 8;
            this.TB_butacas_pasillo.Name = "TB_butacas_pasillo";
            this.TB_butacas_pasillo.Size = new System.Drawing.Size(147, 20);
            this.TB_butacas_pasillo.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Butacas Ventanilla";
            // 
            // TB_butacas_ventanilla
            // 
            this.TB_butacas_ventanilla.Location = new System.Drawing.Point(107, 25);
            this.TB_butacas_ventanilla.MaxLength = 8;
            this.TB_butacas_ventanilla.Name = "TB_butacas_ventanilla";
            this.TB_butacas_ventanilla.Size = new System.Drawing.Size(147, 20);
            this.TB_butacas_ventanilla.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Butacas Pasillo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TB_modelo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TB_numero);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TB_matricula);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TB_fabricante);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TB_kg_disponibles);
            this.groupBox2.Controls.Add(this.CB_servicio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 182);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aeronave";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Modelo";
            // 
            // TB_modelo
            // 
            this.TB_modelo.Location = new System.Drawing.Point(94, 45);
            this.TB_modelo.MaxLength = 15;
            this.TB_modelo.Name = "TB_modelo";
            this.TB_modelo.Size = new System.Drawing.Size(159, 20);
            this.TB_modelo.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Número";
            // 
            // TB_numero
            // 
            this.TB_numero.Enabled = false;
            this.TB_numero.Location = new System.Drawing.Point(94, 19);
            this.TB_numero.MaxLength = 15;
            this.TB_numero.Name = "TB_numero";
            this.TB_numero.Size = new System.Drawing.Size(159, 20);
            this.TB_numero.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Matricula";
            // 
            // TB_matricula
            // 
            this.TB_matricula.Location = new System.Drawing.Point(94, 98);
            this.TB_matricula.MaxLength = 10;
            this.TB_matricula.Name = "TB_matricula";
            this.TB_matricula.Size = new System.Drawing.Size(159, 20);
            this.TB_matricula.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Fabricante";
            // 
            // TB_fabricante
            // 
            this.TB_fabricante.Location = new System.Drawing.Point(94, 122);
            this.TB_fabricante.MaxLength = 10;
            this.TB_fabricante.Name = "TB_fabricante";
            this.TB_fabricante.Size = new System.Drawing.Size(159, 20);
            this.TB_fabricante.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Kg Disponibles";
            // 
            // TB_kg_disponibles
            // 
            this.TB_kg_disponibles.Location = new System.Drawing.Point(94, 148);
            this.TB_kg_disponibles.MaxLength = 10;
            this.TB_kg_disponibles.Name = "TB_kg_disponibles";
            this.TB_kg_disponibles.Size = new System.Drawing.Size(159, 20);
            this.TB_kg_disponibles.TabIndex = 18;
            // 
            // CB_servicio
            // 
            this.CB_servicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_servicio.FormattingEnabled = true;
            this.CB_servicio.Location = new System.Drawing.Point(94, 71);
            this.CB_servicio.Name = "CB_servicio";
            this.CB_servicio.Size = new System.Drawing.Size(159, 21);
            this.CB_servicio.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de Servicio";
            // 
            // BaseAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 327);
            this.Controls.Add(this.BT_guardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "BaseAeronave";
            this.Text = "BaseAeronave";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button BT_guardar;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox TB_butacas_pasillo;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TB_butacas_ventanilla;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox CB_servicio;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox TB_kg_disponibles;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox TB_modelo;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox TB_matricula;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox TB_fabricante;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox TB_numero;
    }
}