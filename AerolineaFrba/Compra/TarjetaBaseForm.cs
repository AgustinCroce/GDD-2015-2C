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
    public partial class TarjetaBaseForm : Form
    {
        public TarjetaBaseForm()
        {
            InitializeComponent();
            string queryCiudades = "SELECT TipoTar_Nombre, TipoTar_Cod FROM TS.Tipo_Tarjeta";
            DbComunicator db = new DbComunicator();
            cardEmitterComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "TipoTar_Nombre", "TipoTar_Cod"), null);
            cardEmitterComboBox.DisplayMember = "Key";
            cardEmitterComboBox.ValueMember = "Value";
        }

    }
}
