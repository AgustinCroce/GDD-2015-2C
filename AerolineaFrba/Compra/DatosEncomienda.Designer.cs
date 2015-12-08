namespace AerolineaFrba.Compra
{
    partial class DatosEncomienda
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
            this.label7 = new System.Windows.Forms.Label();
            this.kgsTextBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.precioTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Kgs";
            // 
            // kgsTextBox
            // 
            this.kgsTextBox.Location = new System.Drawing.Point(127, 193);
            this.kgsTextBox.MaxLength = 5;
            this.kgsTextBox.Name = "kgsTextBox";
            this.kgsTextBox.Size = new System.Drawing.Size(310, 20);
            this.kgsTextBox.TabIndex = 14;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(362, 247);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 15;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Precio";
            // 
            // precioTextBox
            // 
            this.precioTextBox.Enabled = false;
            this.precioTextBox.Location = new System.Drawing.Point(127, 221);
            this.precioTextBox.Name = "precioTextBox";
            this.precioTextBox.Size = new System.Drawing.Size(310, 20);
            this.precioTextBox.TabIndex = 17;
            // 
            // DatosEncomienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 278);
            this.Controls.Add(this.precioTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.kgsTextBox);
            this.Controls.Add(this.label7);
            this.Name = "DatosEncomienda";
            this.Text = "DatosEncomienda";
            this.Controls.SetChildIndex(this.fullNameTextBox, 0);
            this.Controls.SetChildIndex(this.dniTextBox, 0);
            this.Controls.SetChildIndex(this.addressTextBox, 0);
            this.Controls.SetChildIndex(this.phoneTextBox, 0);
            this.Controls.SetChildIndex(this.mailTextBox, 0);
            this.Controls.SetChildIndex(this.bornDateTimePicker, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.kgsTextBox, 0);
            this.Controls.SetChildIndex(this.acceptButton, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.precioTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox kgsTextBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox precioTextBox;
    }
}