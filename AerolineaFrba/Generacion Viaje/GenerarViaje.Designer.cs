namespace AerolineaFrba.Generacion_Viaje
{
    partial class GenerarViaje
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
            this.DTP_fecha_salida = new System.Windows.Forms.DateTimePicker();
            this.DTP_fecha_estimada_llegada = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BT_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_servicio = new System.Windows.Forms.ComboBox();
            this.CB_aeronave = new System.Windows.Forms.ComboBox();
            this.CB_ruta = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DTP_fecha_salida
            // 
            this.DTP_fecha_salida.Location = new System.Drawing.Point(150, 23);
            this.DTP_fecha_salida.Name = "DTP_fecha_salida";
            this.DTP_fecha_salida.Size = new System.Drawing.Size(546, 20);
            this.DTP_fecha_salida.TabIndex = 0;
            this.DTP_fecha_salida.Value = new System.DateTime(2015, 12, 3, 10, 54, 3, 0);
            // 
            // DTP_fecha_estimada_llegada
            // 
            this.DTP_fecha_estimada_llegada.Location = new System.Drawing.Point(150, 49);
            this.DTP_fecha_estimada_llegada.Name = "DTP_fecha_estimada_llegada";
            this.DTP_fecha_estimada_llegada.Size = new System.Drawing.Size(546, 20);
            this.DTP_fecha_estimada_llegada.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha de salida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha estimada de llegada";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT_guardar
            // 
            this.BT_guardar.Enabled = false;
            this.BT_guardar.Location = new System.Drawing.Point(633, 242);
            this.BT_guardar.Name = "BT_guardar";
            this.BT_guardar.Size = new System.Drawing.Size(75, 23);
            this.BT_guardar.TabIndex = 8;
            this.BT_guardar.Text = "Guardar";
            this.BT_guardar.UseVisualStyleBackColor = true;
            this.BT_guardar.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DTP_fecha_salida);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTP_fecha_estimada_llegada);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 85);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fechas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CB_servicio);
            this.groupBox2.Controls.Add(this.CB_aeronave);
            this.groupBox2.Controls.Add(this.CB_ruta);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 120);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion General";
            // 
            // CB_servicio
            // 
            this.CB_servicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_servicio.Enabled = false;
            this.CB_servicio.FormattingEnabled = true;
            this.CB_servicio.Location = new System.Drawing.Point(74, 82);
            this.CB_servicio.Name = "CB_servicio";
            this.CB_servicio.Size = new System.Drawing.Size(622, 21);
            this.CB_servicio.TabIndex = 16;
            // 
            // CB_aeronave
            // 
            this.CB_aeronave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_aeronave.Enabled = false;
            this.CB_aeronave.FormattingEnabled = true;
            this.CB_aeronave.Location = new System.Drawing.Point(74, 55);
            this.CB_aeronave.Name = "CB_aeronave";
            this.CB_aeronave.Size = new System.Drawing.Size(622, 21);
            this.CB_aeronave.TabIndex = 15;
            // 
            // CB_ruta
            // 
            this.CB_ruta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ruta.FormattingEnabled = true;
            this.CB_ruta.Location = new System.Drawing.Point(74, 24);
            this.CB_ruta.Name = "CB_ruta";
            this.CB_ruta.Size = new System.Drawing.Size(622, 21);
            this.CB_ruta.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Servicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Aeronave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ruta";
            // 
            // GenerarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 277);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BT_guardar);
            this.Controls.Add(this.button1);
            this.Name = "GenerarViaje";
            this.Text = "Generar Viaje";
            this.Load += new System.EventHandler(this.GenerarViaje_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTP_fecha_salida;
        private System.Windows.Forms.DateTimePicker DTP_fecha_estimada_llegada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BT_guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CB_aeronave;
        private System.Windows.Forms.ComboBox CB_ruta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_servicio;
    }
}