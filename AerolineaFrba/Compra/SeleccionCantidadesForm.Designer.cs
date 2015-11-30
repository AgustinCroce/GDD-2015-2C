namespace AerolineaFrba.Compra
{
    partial class SeleccionCantidadesForm
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
            this.pasajeCheckBox = new System.Windows.Forms.CheckBox();
            this.encomiendaCheckBox = new System.Windows.Forms.CheckBox();
            this.pasajesInput = new System.Windows.Forms.TextBox();
            this.encomiendaInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pasajeCheckBox
            // 
            this.pasajeCheckBox.AutoSize = true;
            this.pasajeCheckBox.Location = new System.Drawing.Point(85, 63);
            this.pasajeCheckBox.Name = "pasajeCheckBox";
            this.pasajeCheckBox.Size = new System.Drawing.Size(58, 17);
            this.pasajeCheckBox.TabIndex = 0;
            this.pasajeCheckBox.Text = "Pasaje";
            this.pasajeCheckBox.UseVisualStyleBackColor = true;
            // 
            // encomiendaCheckBox
            // 
            this.encomiendaCheckBox.AutoSize = true;
            this.encomiendaCheckBox.Location = new System.Drawing.Point(85, 90);
            this.encomiendaCheckBox.Name = "encomiendaCheckBox";
            this.encomiendaCheckBox.Size = new System.Drawing.Size(85, 17);
            this.encomiendaCheckBox.TabIndex = 1;
            this.encomiendaCheckBox.Text = "Encomienda";
            this.encomiendaCheckBox.UseVisualStyleBackColor = true;
            // 
            // pasajesInput
            // 
            this.pasajesInput.Enabled = false;
            this.pasajesInput.Location = new System.Drawing.Point(210, 61);
            this.pasajesInput.Name = "pasajesInput";
            this.pasajesInput.Size = new System.Drawing.Size(100, 20);
            this.pasajesInput.TabIndex = 2;
            // 
            // encomiendaInput
            // 
            this.encomiendaInput.Enabled = false;
            this.encomiendaInput.Location = new System.Drawing.Point(210, 87);
            this.encomiendaInput.Name = "encomiendaInput";
            this.encomiendaInput.Size = new System.Drawing.Size(100, 20);
            this.encomiendaInput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione si desea comprar pasajes y/o encomendar un paquete en el vuelo. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "En el caso que corresponda especifique la cantidad";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(317, 131);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 6;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(226, 131);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SeleccionCantidadesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 163);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encomiendaInput);
            this.Controls.Add(this.pasajesInput);
            this.Controls.Add(this.encomiendaCheckBox);
            this.Controls.Add(this.pasajeCheckBox);
            this.Name = "SeleccionCantidadesForm";
            this.Text = "Compra de pasaje y/o encomienda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox pasajeCheckBox;
        private System.Windows.Forms.CheckBox encomiendaCheckBox;
        private System.Windows.Forms.TextBox pasajesInput;
        private System.Windows.Forms.TextBox encomiendaInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
    }
}