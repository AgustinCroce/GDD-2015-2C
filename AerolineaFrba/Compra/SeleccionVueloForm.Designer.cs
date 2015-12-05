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
            this.searchButton = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.vuelosGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.vuelosGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // despegueTimePicker
            // 
            this.despegueTimePicker.Location = new System.Drawing.Point(131, 12);
            this.despegueTimePicker.Name = "despegueTimePicker";
            this.despegueTimePicker.Size = new System.Drawing.Size(200, 20);
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
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(325, 75);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(109, 23);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Buscar Vuelos";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(325, 43);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(109, 23);
            this.cleanButton.TabIndex = 8;
            this.cleanButton.Text = "Limpiar Vuelos";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(325, 285);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(109, 23);
            this.selectButton.TabIndex = 9;
            this.selectButton.Text = "Seleccionar Vuelo";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // vuelosGridView
            // 
            this.vuelosGridView.AllowUserToAddRows = false;
            this.vuelosGridView.AllowUserToDeleteRows = false;
            this.vuelosGridView.AllowUserToResizeColumns = false;
            this.vuelosGridView.AllowUserToResizeRows = false;
            this.vuelosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vuelosGridView.Location = new System.Drawing.Point(12, 104);
            this.vuelosGridView.MultiSelect = false;
            this.vuelosGridView.Name = "vuelosGridView";
            this.vuelosGridView.ReadOnly = true;
            this.vuelosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vuelosGridView.ShowCellToolTips = false;
            this.vuelosGridView.ShowEditingIcon = false;
            this.vuelosGridView.ShowRowErrors = false;
            this.vuelosGridView.Size = new System.Drawing.Size(422, 175);
            this.vuelosGridView.TabIndex = 18;
            // 
            // SeleccionVueloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 330);
            this.Controls.Add(this.vuelosGridView);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.destinoComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.origenComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.despegueTimePicker);
            this.Name = "SeleccionVueloForm";
            this.Text = "Compra de pasaje y/o encomienda";
            this.Load += new System.EventHandler(this.SeleccionVueloForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vuelosGridView)).EndInit();
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
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.DataGridView vuelosGridView;
    }
}