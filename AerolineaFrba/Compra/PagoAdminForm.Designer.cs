namespace AerolineaFrba.Compra
{
    partial class PagoAdminForm
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
            this.cardCheckBox = new System.Windows.Forms.CheckBox();
            this.creditCardGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cardCheckBox
            // 
            this.cardCheckBox.AutoSize = true;
            this.cardCheckBox.Location = new System.Drawing.Point(22, 219);
            this.cardCheckBox.Name = "cardCheckBox";
            this.cardCheckBox.Size = new System.Drawing.Size(104, 17);
            this.cardCheckBox.TabIndex = 14;
            this.cardCheckBox.Text = "Paga con tarjeta";
            this.cardCheckBox.UseVisualStyleBackColor = true;
            // 
            // PagoAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 473);
            this.Controls.Add(this.cardCheckBox);
            this.Name = "PagoAdminForm";
            this.Text = "PagoAdminForm";
            this.Controls.SetChildIndex(this.precioLabel, 0);
            this.Controls.SetChildIndex(this.fullNameTextBox, 0);
            this.Controls.SetChildIndex(this.dniTextBox, 0);
            this.Controls.SetChildIndex(this.addressTextBox, 0);
            this.Controls.SetChildIndex(this.phoneTextBox, 0);
            this.Controls.SetChildIndex(this.mailTextBox, 0);
            this.Controls.SetChildIndex(this.bornDateTimePicker, 0);
            this.Controls.SetChildIndex(this.creditCardGroupBox, 0);
            this.Controls.SetChildIndex(this.acceptButton, 0);
            this.Controls.SetChildIndex(this.cardCheckBox, 0);
            this.creditCardGroupBox.ResumeLayout(false);
            this.creditCardGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cardCheckBox;
    }
}