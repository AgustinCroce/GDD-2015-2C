namespace AerolineaFrba.Compra
{
    partial class PagoKioskoForm
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
            this.creditCardGroupBox = new System.Windows.Forms.GroupBox();
            this.cardEmitterTextBox = new System.Windows.Forms.TextBox();
            this.editCreditCardButton = new System.Windows.Forms.Button();
            this.addCreditCardButton = new System.Windows.Forms.Button();
            this.cardNumberDuesComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cardDateTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cardCodeTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cardNumberTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.creditCardGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // creditCardGroupBox
            // 
            this.creditCardGroupBox.Controls.Add(this.cardEmitterTextBox);
            this.creditCardGroupBox.Controls.Add(this.editCreditCardButton);
            this.creditCardGroupBox.Controls.Add(this.addCreditCardButton);
            this.creditCardGroupBox.Controls.Add(this.cardNumberDuesComboBox);
            this.creditCardGroupBox.Controls.Add(this.label11);
            this.creditCardGroupBox.Controls.Add(this.label10);
            this.creditCardGroupBox.Controls.Add(this.cardDateTextBox);
            this.creditCardGroupBox.Controls.Add(this.label9);
            this.creditCardGroupBox.Controls.Add(this.cardCodeTextBox);
            this.creditCardGroupBox.Controls.Add(this.label8);
            this.creditCardGroupBox.Controls.Add(this.cardNumberTextBox);
            this.creditCardGroupBox.Controls.Add(this.label7);
            this.creditCardGroupBox.Location = new System.Drawing.Point(16, 213);
            this.creditCardGroupBox.Name = "creditCardGroupBox";
            this.creditCardGroupBox.Size = new System.Drawing.Size(421, 192);
            this.creditCardGroupBox.TabIndex = 12;
            this.creditCardGroupBox.TabStop = false;
            this.creditCardGroupBox.Text = "Datos de la Tarjeta de Crédito";
            // 
            // cardEmitterTextBox
            // 
            this.cardEmitterTextBox.Location = new System.Drawing.Point(125, 105);
            this.cardEmitterTextBox.Name = "cardEmitterTextBox";
            this.cardEmitterTextBox.Size = new System.Drawing.Size(290, 20);
            this.cardEmitterTextBox.TabIndex = 12;
            // 
            // editCreditCardButton
            // 
            this.editCreditCardButton.Location = new System.Drawing.Point(223, 159);
            this.editCreditCardButton.Name = "editCreditCardButton";
            this.editCreditCardButton.Size = new System.Drawing.Size(75, 23);
            this.editCreditCardButton.TabIndex = 11;
            this.editCreditCardButton.Text = "Editar";
            this.editCreditCardButton.UseVisualStyleBackColor = true;
            this.editCreditCardButton.Click += new System.EventHandler(this.editCreditCardButton_Click);
            // 
            // addCreditCardButton
            // 
            this.addCreditCardButton.Location = new System.Drawing.Point(142, 159);
            this.addCreditCardButton.Name = "addCreditCardButton";
            this.addCreditCardButton.Size = new System.Drawing.Size(75, 23);
            this.addCreditCardButton.TabIndex = 10;
            this.addCreditCardButton.Text = "Agregar";
            this.addCreditCardButton.UseVisualStyleBackColor = true;
            this.addCreditCardButton.Click += new System.EventHandler(this.addCreditCardButton_Click);
            // 
            // cardNumberDuesComboBox
            // 
            this.cardNumberDuesComboBox.FormattingEnabled = true;
            this.cardNumberDuesComboBox.Location = new System.Drawing.Point(125, 131);
            this.cardNumberDuesComboBox.Name = "cardNumberDuesComboBox";
            this.cardNumberDuesComboBox.Size = new System.Drawing.Size(290, 21);
            this.cardNumberDuesComboBox.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Nro. de Cuotas";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Emisor";
            // 
            // cardDateTextBox
            // 
            this.cardDateTextBox.Location = new System.Drawing.Point(125, 78);
            this.cardDateTextBox.Name = "cardDateTextBox";
            this.cardDateTextBox.Size = new System.Drawing.Size(290, 20);
            this.cardDateTextBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Fecha de Vencimiento";
            // 
            // cardCodeTextBox
            // 
            this.cardCodeTextBox.Location = new System.Drawing.Point(125, 48);
            this.cardCodeTextBox.Name = "cardCodeTextBox";
            this.cardCodeTextBox.Size = new System.Drawing.Size(290, 20);
            this.cardCodeTextBox.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Código de Seguridad";
            // 
            // cardNumberTextBox
            // 
            this.cardNumberTextBox.Location = new System.Drawing.Point(125, 20);
            this.cardNumberTextBox.Name = "cardNumberTextBox";
            this.cardNumberTextBox.Size = new System.Drawing.Size(290, 20);
            this.cardNumberTextBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Número";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(362, 423);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 13;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // PagoKioskoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 458);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.creditCardGroupBox);
            this.Name = "PagoKioskoForm";
            this.Text = "Datos del Pago";
            this.Controls.SetChildIndex(this.fullNameTextBox, 0);
            this.Controls.SetChildIndex(this.dniTextBox, 0);
            this.Controls.SetChildIndex(this.addressTextBox, 0);
            this.Controls.SetChildIndex(this.phoneTextBox, 0);
            this.Controls.SetChildIndex(this.mailTextBox, 0);
            this.Controls.SetChildIndex(this.bornDateTimePicker, 0);
            this.Controls.SetChildIndex(this.creditCardGroupBox, 0);
            this.Controls.SetChildIndex(this.acceptButton, 0);
            this.creditCardGroupBox.ResumeLayout(false);
            this.creditCardGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox creditCardGroupBox;
        public System.Windows.Forms.ComboBox cardNumberDuesComboBox;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox cardDateTextBox;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox cardCodeTextBox;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox cardNumberTextBox;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button addCreditCardButton;
        private System.Windows.Forms.Button editCreditCardButton;
        private System.Windows.Forms.TextBox cardEmitterTextBox;
    }
}