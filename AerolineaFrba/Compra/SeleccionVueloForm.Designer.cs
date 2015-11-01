namespace AerolineaFrba.Compra
{
    partial class SeleccionVueloForm
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
            this.despegueTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.origenComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.destinoComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // despegueTimePicker
            // 
            this.despegueTimePicker.Location = new System.Drawing.Point(131, 12);
            this.despegueTimePicker.Name = "despegueTimePicker";
            this.despegueTimePicker.Size = new System.Drawing.Size(166, 20);
            this.despegueTimePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha de despegue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ciudad de origen";
            // 
            // origenComboBox
            // 
            this.origenComboBox.FormattingEnabled = true;
            this.origenComboBox.Location = new System.Drawing.Point(131, 45);
            this.origenComboBox.Name = "origenComboBox";
            this.origenComboBox.Size = new System.Drawing.Size(166, 21);
            this.origenComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ciudad de destino";
            // 
            // destinoComboBox
            // 
            this.destinoComboBox.FormattingEnabled = true;
            this.destinoComboBox.Location = new System.Drawing.Point(131, 77);
            this.destinoComboBox.Name = "destinoComboBox";
            this.destinoComboBox.Size = new System.Drawing.Size(166, 21);
            this.destinoComboBox.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(422, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(325, 75);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(109, 23);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Buscar Vuelos";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(325, 43);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(109, 23);
            this.cleanButton.TabIndex = 8;
            this.cleanButton.Text = "Limpiar Vuelos";
            this.cleanButton.UseVisualStyleBackColor = true;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(325, 285);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(109, 23);
            this.selectButton.TabIndex = 9;
            this.selectButton.Text = "Seleccionar Vuelo";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // SeleccionVueloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 330);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.destinoComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.origenComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.despegueTimePicker);
            this.Name = "SeleccionVueloForm";
            this.Text = "Compra de pasaje y/o encomienda";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker despegueTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox origenComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox destinoComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Button selectButton;
    }
}