using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Commons;

namespace AerolineaFrba.Compra
{
    public partial class DatosPasajeForm : DatosBuscadorForm
    {
        private DataGridView pasajeGridView;

        public DatosPasajeForm(DataGridView pasajeGridView)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            DbComunicator db = new DbComunicator();
            this.pasajeGridView = pasajeGridView;
        }
    }
}
