namespace AerolineaFrba.Devolucion
{
    partial class DevolucionForm
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnrTextBox = new System.Windows.Forms.TextBox();
            this.motivoTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.encomiendaGroupBox = new System.Windows.Forms.GroupBox();
            this.encomiendaGridView = new System.Windows.Forms.DataGridView();
            this.pasajesGroupBox = new System.Windows.Forms.GroupBox();
            this.pasajeGridView = new System.Windows.Forms.DataGridView();
            this.acceptButton = new System.Windows.Forms.Button();
            this.refreshEncomiendaButton = new System.Windows.Forms.Button();
            this.refreshPasajeButton = new System.Windows.Forms.Button();
            this.encomiendaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encomiendaGridView)).BeginInit();
            this.pasajesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pasajeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(74, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(333, 20);
            this.dateTimePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PNR";
            // 
            // pnrTextBox
            // 
            this.pnrTextBox.Location = new System.Drawing.Point(74, 43);
            this.pnrTextBox.MaxLength = 18;
            this.pnrTextBox.Name = "pnrTextBox";
            this.pnrTextBox.Size = new System.Drawing.Size(333, 20);
            this.pnrTextBox.TabIndex = 3;
            // 
            // motivoTextBox
            // 
            this.motivoTextBox.Location = new System.Drawing.Point(74, 69);
            this.motivoTextBox.MaxLength = 255;
            this.motivoTextBox.Name = "motivoTextBox";
            this.motivoTextBox.Size = new System.Drawing.Size(333, 96);
            this.motivoTextBox.TabIndex = 4;
            this.motivoTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Motivo";
            // 
            // encomiendaGroupBox
            // 
            this.encomiendaGroupBox.Controls.Add(this.refreshEncomiendaButton);
            this.encomiendaGroupBox.Controls.Add(this.encomiendaGridView);
            this.encomiendaGroupBox.Location = new System.Drawing.Point(22, 184);
            this.encomiendaGroupBox.Name = "encomiendaGroupBox";
            this.encomiendaGroupBox.Size = new System.Drawing.Size(385, 128);
            this.encomiendaGroupBox.TabIndex = 6;
            this.encomiendaGroupBox.TabStop = false;
            this.encomiendaGroupBox.Text = "Encomienda";
            // 
            // encomiendaGridView
            // 
            this.encomiendaGridView.AllowUserToAddRows = false;
            this.encomiendaGridView.AllowUserToDeleteRows = false;
            this.encomiendaGridView.AllowUserToResizeColumns = false;
            this.encomiendaGridView.AllowUserToResizeRows = false;
            this.encomiendaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.encomiendaGridView.Location = new System.Drawing.Point(8, 19);
            this.encomiendaGridView.Name = "encomiendaGridView";
            this.encomiendaGridView.ReadOnly = true;
            this.encomiendaGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.encomiendaGridView.ShowCellToolTips = false;
            this.encomiendaGridView.ShowEditingIcon = false;
            this.encomiendaGridView.ShowRowErrors = false;
            this.encomiendaGridView.Size = new System.Drawing.Size(371, 75);
            this.encomiendaGridView.TabIndex = 20;
            // 
            // pasajesGroupBox
            // 
            this.pasajesGroupBox.Controls.Add(this.refreshPasajeButton);
            this.pasajesGroupBox.Controls.Add(this.pasajeGridView);
            this.pasajesGroupBox.Location = new System.Drawing.Point(24, 318);
            this.pasajesGroupBox.Name = "pasajesGroupBox";
            this.pasajesGroupBox.Size = new System.Drawing.Size(383, 182);
            this.pasajesGroupBox.TabIndex = 7;
            this.pasajesGroupBox.TabStop = false;
            this.pasajesGroupBox.Text = "Pasajes";
            // 
            // pasajeGridView
            // 
            this.pasajeGridView.AllowUserToAddRows = false;
            this.pasajeGridView.AllowUserToDeleteRows = false;
            this.pasajeGridView.AllowUserToResizeColumns = false;
            this.pasajeGridView.AllowUserToResizeRows = false;
            this.pasajeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pasajeGridView.Location = new System.Drawing.Point(6, 19);
            this.pasajeGridView.Name = "pasajeGridView";
            this.pasajeGridView.ReadOnly = true;
            this.pasajeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pasajeGridView.ShowCellToolTips = false;
            this.pasajeGridView.ShowEditingIcon = false;
            this.pasajeGridView.ShowRowErrors = false;
            this.pasajeGridView.Size = new System.Drawing.Size(371, 128);
            this.pasajeGridView.TabIndex = 19;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(285, 506);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(122, 23);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "Cancelar Items";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // refreshEncomiendaButton
            // 
            this.refreshEncomiendaButton.Location = new System.Drawing.Point(263, 99);
            this.refreshEncomiendaButton.Name = "refreshEncomiendaButton";
            this.refreshEncomiendaButton.Size = new System.Drawing.Size(116, 23);
            this.refreshEncomiendaButton.TabIndex = 20;
            this.refreshEncomiendaButton.Text = "Cancelar Selección";
            this.refreshEncomiendaButton.UseVisualStyleBackColor = true;
            this.refreshEncomiendaButton.Click += new System.EventHandler(this.refreshEncomiendaButton_Click);
            // 
            // refreshPasajeButton
            // 
            this.refreshPasajeButton.Location = new System.Drawing.Point(261, 153);
            this.refreshPasajeButton.Name = "refreshPasajeButton";
            this.refreshPasajeButton.Size = new System.Drawing.Size(116, 23);
            this.refreshPasajeButton.TabIndex = 20;
            this.refreshPasajeButton.Text = "Cancelar Selección";
            this.refreshPasajeButton.UseVisualStyleBackColor = true;
            this.refreshPasajeButton.Click += new System.EventHandler(this.refreshPasajeButton_Click);
            // 
            // DevolucionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 541);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.pasajesGroupBox);
            this.Controls.Add(this.encomiendaGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.motivoTextBox);
            this.Controls.Add(this.pnrTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "DevolucionForm";
            this.Text = "Devolucion";
            this.encomiendaGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.encomiendaGridView)).EndInit();
            this.pasajesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pasajeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pnrTextBox;
        private System.Windows.Forms.RichTextBox motivoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox encomiendaGroupBox;
        private System.Windows.Forms.GroupBox pasajesGroupBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.DataGridView pasajeGridView;
        private System.Windows.Forms.DataGridView encomiendaGridView;
        private System.Windows.Forms.Button refreshEncomiendaButton;
        private System.Windows.Forms.Button refreshPasajeButton;
    }
}