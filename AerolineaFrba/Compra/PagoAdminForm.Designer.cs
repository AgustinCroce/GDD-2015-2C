﻿namespace AerolineaFrba.Compra
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
            this.aceptarButton = new System.Windows.Forms.Button();
            this.creditCardGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cardCheckBox
            // 
            this.cardCheckBox.AutoSize = true;
            this.cardCheckBox.Location = new System.Drawing.Point(16, 190);
            this.cardCheckBox.Name = "cardCheckBox";
            this.cardCheckBox.Size = new System.Drawing.Size(104, 17);
            this.cardCheckBox.TabIndex = 14;
            this.cardCheckBox.Text = "Paga con tarjeta";
            this.cardCheckBox.UseVisualStyleBackColor = true;
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(362, 423);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 15;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // PagoAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 458);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.cardCheckBox);
            this.Name = "PagoAdminForm";
            this.Text = "PagoAdminForm";
            this.Controls.SetChildIndex(this.fullNameTextBox, 0);
            this.Controls.SetChildIndex(this.dniTextBox, 0);
            this.Controls.SetChildIndex(this.addressTextBox, 0);
            this.Controls.SetChildIndex(this.phoneTextBox, 0);
            this.Controls.SetChildIndex(this.mailTextBox, 0);
            this.Controls.SetChildIndex(this.bornDateTimePicker, 0);
            this.Controls.SetChildIndex(this.creditCardGroupBox, 0);
            this.Controls.SetChildIndex(this.acceptButton, 0);
            this.Controls.SetChildIndex(this.cardCheckBox, 0);
            this.Controls.SetChildIndex(this.aceptarButton, 0);
            this.creditCardGroupBox.ResumeLayout(false);
            this.creditCardGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cardCheckBox;
        private System.Windows.Forms.Button aceptarButton;
    }
}