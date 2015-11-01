namespace AerolineaFrba.Compra
{
    partial class DatosEncomiendaForm
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
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Kgs del Paquete";
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(127, 164);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(200, 20);
            this.weightTextBox.TabIndex = 13;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(258, 194);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 14;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // DatosEncomienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 229);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.label7);
            this.Name = "DatosEncomienda";
            this.Text = "Datos de la Encomienda";
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.weightTextBox, 0);
            this.Controls.SetChildIndex(this.acceptButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.Button acceptButton;
    }
}