﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Commons;
using System.Data.SqlClient;

namespace AerolineaFrba.Compra
{
    public partial class SeleccionCantidadesForm : Form
    {
        private DataGridViewRow vueloSeleccionado;
        private bool pasajeHabilitado = true;
        private bool encomiendaHabilitada = true;
        public bool habilitado = false;
        public double kgsHabilitados = 0;
        public int pasajesHabilitados = 0;

        public SeleccionCantidadesForm(DataGridViewRow vueloSeleccionado)
        {
            InitializeComponent();
            this.vueloSeleccionado = vueloSeleccionado;
            pasajeCheckBox.CheckedChanged += new EventHandler(pasajeCheckBox_CheckedChanged);
            encomiendaCheckBox.CheckedChanged += new EventHandler(encomiendaCheckBox_CheckedChanged);
            acceptButton.Enabled = false;
        }

        private void encomiendaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            encomiendaInput.Enabled = this.encomiendaCheckBox.Checked;
            acceptButton.Enabled = this.encomiendaCheckBox.Checked || this.pasajeCheckBox.Checked;
        }

        private void pasajeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pasajesInput.Enabled = this.pasajeCheckBox.Checked;
            acceptButton.Enabled = this.encomiendaCheckBox.Checked || this.pasajeCheckBox.Checked;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DbComunicator dbStoreProcedure = new DbComunicator();

            if (encomiendaCheckBox.Checked) {
                SqlCommand funcionEncomienda = dbStoreProcedure.GetStoreProcedure("TS.fnConsultarKgs");
                SqlParameter returnFuncionEncomienda = funcionEncomienda.Parameters.Add("RetVal", SqlDbType.Int);
                returnFuncionEncomienda.Direction = ParameterDirection.ReturnValue;
                funcionEncomienda.Parameters.Add(new SqlParameter("@Viaj_Cod", Convert.ToInt32(vueloSeleccionado.Cells[0].Value.ToString())));
                funcionEncomienda.Parameters.Add(new SqlParameter("@Kgs", Convert.ToInt32(encomiendaInput.Text)));
                funcionEncomienda.ExecuteNonQuery();


                if ((int)returnFuncionEncomienda.Value != 0)
                {
                    MessageBox.Show("No hay suficientes kgs disponibles para responder a su pedido");
                    this.encomiendaHabilitada = false;

                }
                else {
                    this.encomiendaHabilitada = true;
                }

            }


            if (pasajeCheckBox.Checked)
            {
                SqlCommand funcionButacas = dbStoreProcedure.GetStoreProcedure("TS.fnConsultarButacas");
                SqlParameter returnFuncionButacas = funcionButacas.Parameters.Add("RetVal", SqlDbType.Int);
                returnFuncionButacas.Direction = ParameterDirection.ReturnValue;
                funcionButacas.Parameters.Add(new SqlParameter("@Viaj_Cod", Convert.ToInt32(vueloSeleccionado.Cells[0].Value.ToString())));
                funcionButacas.Parameters.Add(new SqlParameter("@Cantidad", Convert.ToInt32(pasajesInput.Text)));
                funcionButacas.ExecuteNonQuery();

                if ((int)returnFuncionButacas.Value != 0)
                {
                    MessageBox.Show("No hay suficientes butacas disponibles para responder a su pedido");
                    this.pasajeHabilitado = false;
                }
                else {
                    this.pasajeHabilitado = true;
                }
            }
            
            dbStoreProcedure.CerrarConexion();

            this.habilitado = this.pasajeHabilitado && this.encomiendaHabilitada;

            if (this.habilitado) { 
                if (pasajeCheckBox.Checked){
                    this.pasajesHabilitados = Convert.ToInt32(pasajesInput.Text);
                }

                if (encomiendaCheckBox.Checked) {
                    this.kgsHabilitados = Convert.ToDouble(encomiendaInput.Text);
                }

                this.Close();
                
            }


        }
    }
}
