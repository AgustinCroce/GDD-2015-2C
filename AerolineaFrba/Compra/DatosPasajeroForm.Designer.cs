﻿namespace AerolineaFrba.Compra
{
    partial class DatosPasajeroForm
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
            this.ButacaComboBox = new System.Windows.Forms.ComboBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Butaca";
            // 
            // ButacaComboBox
            // 
            this.ButacaComboBox.FormattingEnabled = true;
            this.ButacaComboBox.Location = new System.Drawing.Point(127, 164);
            this.ButacaComboBox.Name = "ButacaComboBox";
            this.ButacaComboBox.Size = new System.Drawing.Size(200, 21);
            this.ButacaComboBox.TabIndex = 13;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(258, 197);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 14;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // DatosPasajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 232);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.ButacaComboBox);
            this.Controls.Add(this.label7);
            this.Name = "DatosPasajero";
            this.Text = "Datos del Pasajero";
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.ButacaComboBox, 0);
            this.Controls.SetChildIndex(this.acceptButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ButacaComboBox;
        private System.Windows.Forms.Button acceptButton;
    }
}