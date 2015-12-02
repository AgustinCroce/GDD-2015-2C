namespace AerolineaFrba.Abm_Ruta
{
    partial class BaseRuta
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
            this.button1 = new System.Windows.Forms.Button();
            this.BT_guardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_origen = new System.Windows.Forms.ComboBox();
            this.CB_destino = new System.Windows.Forms.ComboBox();
            this.CB_servicio = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_precio_kg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_precio_pasaje = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_codigo_unico = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_codigo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT_guardar
            // 
            this.BT_guardar.Location = new System.Drawing.Point(197, 282);
            this.BT_guardar.Name = "BT_guardar";
            this.BT_guardar.Size = new System.Drawing.Size(75, 23);
            this.BT_guardar.TabIndex = 2;
            this.BT_guardar.Text = "Guardar";
            this.BT_guardar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de Servicio";
            // 
            // CB_origen
            // 
            this.CB_origen.FormattingEnabled = true;
            this.CB_origen.Location = new System.Drawing.Point(47, 71);
            this.CB_origen.Name = "CB_origen";
            this.CB_origen.Size = new System.Drawing.Size(207, 21);
            this.CB_origen.TabIndex = 10;
            // 
            // CB_destino
            // 
            this.CB_destino.FormattingEnabled = true;
            this.CB_destino.Location = new System.Drawing.Point(47, 105);
            this.CB_destino.Name = "CB_destino";
            this.CB_destino.Size = new System.Drawing.Size(207, 21);
            this.CB_destino.TabIndex = 11;
            // 
            // CB_servicio
            // 
            this.CB_servicio.FormattingEnabled = true;
            this.CB_servicio.Location = new System.Drawing.Point(95, 138);
            this.CB_servicio.Name = "CB_servicio";
            this.CB_servicio.Size = new System.Drawing.Size(159, 21);
            this.CB_servicio.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_precio_kg);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TB_precio_pasaje);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 89);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Precios";
            // 
            // TB_precio_kg
            // 
            this.TB_precio_kg.Location = new System.Drawing.Point(129, 53);
            this.TB_precio_kg.Name = "TB_precio_kg";
            this.TB_precio_kg.Size = new System.Drawing.Size(125, 20);
            this.TB_precio_kg.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Precio Base por Pasaje";
            // 
            // TB_precio_pasaje
            // 
            this.TB_precio_pasaje.Location = new System.Drawing.Point(129, 25);
            this.TB_precio_pasaje.Name = "TB_precio_pasaje";
            this.TB_precio_pasaje.Size = new System.Drawing.Size(125, 20);
            this.TB_precio_pasaje.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Precio Base por KG";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TB_codigo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CB_servicio);
            this.groupBox2.Controls.Add(this.TB_codigo_unico);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CB_destino);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CB_origen);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 169);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ruta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Código Unico";
            // 
            // TB_codigo_unico
            // 
            this.TB_codigo_unico.Enabled = false;
            this.TB_codigo_unico.Location = new System.Drawing.Point(81, 19);
            this.TB_codigo_unico.Name = "TB_codigo_unico";
            this.TB_codigo_unico.Size = new System.Drawing.Size(173, 20);
            this.TB_codigo_unico.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Código";
            // 
            // TB_codigo
            // 
            this.TB_codigo.Location = new System.Drawing.Point(47, 45);
            this.TB_codigo.Name = "TB_codigo";
            this.TB_codigo.Size = new System.Drawing.Size(207, 20);
            this.TB_codigo.TabIndex = 21;
            // 
            // BaseRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.BT_guardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "BaseRuta";
            this.Text = "BaseRuta";
            this.Load += new System.EventHandler(this.BaseRuta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button BT_guardar;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox CB_origen;
        public System.Windows.Forms.ComboBox CB_destino;
        public System.Windows.Forms.ComboBox CB_servicio;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox TB_precio_kg;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TB_precio_pasaje;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox TB_codigo_unico;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox TB_codigo;
    }
}