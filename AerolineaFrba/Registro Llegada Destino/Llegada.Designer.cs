namespace AerolineaFrba.Registro_Llegada_Destino
{
    partial class Llegada
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
            this.aeronaveComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.origenComboBox = new System.Windows.Forms.ComboBox();
            this.llegadaComboBox = new System.Windows.Forms.ComboBox();
            this.llegadaTimePicker = new System.Windows.Forms.DateTimePicker();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de Aeronave";
            // 
            // aeronaveComboBox
            // 
            this.aeronaveComboBox.FormattingEnabled = true;
            this.aeronaveComboBox.Location = new System.Drawing.Point(151, 10);
            this.aeronaveComboBox.Name = "aeronaveComboBox";
            this.aeronaveComboBox.Size = new System.Drawing.Size(200, 21);
            this.aeronaveComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ciudad de origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ciudad de llegada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tiempo de llegada";
            // 
            // origenComboBox
            // 
            this.origenComboBox.FormattingEnabled = true;
            this.origenComboBox.Location = new System.Drawing.Point(151, 37);
            this.origenComboBox.Name = "origenComboBox";
            this.origenComboBox.Size = new System.Drawing.Size(200, 21);
            this.origenComboBox.TabIndex = 5;
            // 
            // llegadaComboBox
            // 
            this.llegadaComboBox.FormattingEnabled = true;
            this.llegadaComboBox.Location = new System.Drawing.Point(151, 64);
            this.llegadaComboBox.Name = "llegadaComboBox";
            this.llegadaComboBox.Size = new System.Drawing.Size(200, 21);
            this.llegadaComboBox.TabIndex = 6;
            // 
            // llegadaTimePicker
            // 
            this.llegadaTimePicker.Location = new System.Drawing.Point(151, 91);
            this.llegadaTimePicker.Name = "llegadaTimePicker";
            this.llegadaTimePicker.Size = new System.Drawing.Size(200, 20);
            this.llegadaTimePicker.TabIndex = 7;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(287, 132);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 8;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // Llegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 167);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.llegadaTimePicker);
            this.Controls.Add(this.llegadaComboBox);
            this.Controls.Add(this.origenComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aeronaveComboBox);
            this.Controls.Add(this.label1);
            this.Name = "Llegada";
            this.Text = "Registro de llegada a destino";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox aeronaveComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox origenComboBox;
        private System.Windows.Forms.ComboBox llegadaComboBox;
        private System.Windows.Forms.DateTimePicker llegadaTimePicker;
        private System.Windows.Forms.Button acceptButton;
    }
}