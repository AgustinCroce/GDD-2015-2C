namespace AerolineaFrba.Compra
{
    partial class TarjetaBaseForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.cardDateTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cardCodeTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cardNumberTextBoxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cardEmitterComboBox = new System.Windows.Forms.ComboBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Emisor";
            // 
            // cardDateTextBox
            // 
            this.cardDateTextBox.Location = new System.Drawing.Point(130, 76);
            this.cardDateTextBox.Name = "cardDateTextBox";
            this.cardDateTextBox.Size = new System.Drawing.Size(290, 20);
            this.cardDateTextBox.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Fecha de Vencimiento";
            // 
            // cardCodeTextBox
            // 
            this.cardCodeTextBox.Location = new System.Drawing.Point(130, 50);
            this.cardCodeTextBox.Name = "cardCodeTextBox";
            this.cardCodeTextBox.Size = new System.Drawing.Size(290, 20);
            this.cardCodeTextBox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Código de Seguridad";
            // 
            // cardNumberTextBoxt
            // 
            this.cardNumberTextBoxt.Location = new System.Drawing.Point(130, 23);
            this.cardNumberTextBoxt.Name = "cardNumberTextBoxt";
            this.cardNumberTextBoxt.Size = new System.Drawing.Size(290, 20);
            this.cardNumberTextBoxt.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Número";
            // 
            // cardEmitterComboBox
            // 
            this.cardEmitterComboBox.FormattingEnabled = true;
            this.cardEmitterComboBox.Location = new System.Drawing.Point(130, 103);
            this.cardEmitterComboBox.Name = "cardEmitterComboBox";
            this.cardEmitterComboBox.Size = new System.Drawing.Size(290, 21);
            this.cardEmitterComboBox.TabIndex = 20;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(345, 143);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 21;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(254, 143);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // TarjetaBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 202);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.cardEmitterComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cardDateTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cardCodeTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cardNumberTextBoxt);
            this.Controls.Add(this.label7);
            this.Name = "TarjetaBaseForm";
            this.Text = "TarjetaBaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox cardDateTextBox;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox cardCodeTextBox;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox cardNumberTextBoxt;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cardEmitterComboBox;
        public System.Windows.Forms.Button acceptButton;
        public System.Windows.Forms.Button cancelButton;
    }
}