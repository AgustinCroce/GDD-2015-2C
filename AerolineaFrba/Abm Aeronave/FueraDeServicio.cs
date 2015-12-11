using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FueraDeServicio : Form
    {
        public DateTime desde, hasta;
        public Boolean ok;

        public FueraDeServicio()
        {
            InitializeComponent();
            DTP_desde.MinDate = Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema);
            DTP_hasta.MinDate = Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema);
            this.ok = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ok = false;
            this.Close();
        }

        private void BT_Aceptar_Click(object sender, EventArgs e)
        {
            if (DTP_hasta.Value.Date.CompareTo(DTP_desde.Value.Date) != 1) MessageBox.Show("La fecha final tiene que ser posterior a la inicial");
            else {
                this.desde = DTP_desde.Value;
                this.hasta = DTP_hasta.Value;
                this.ok = true;
                this.Close();
            }
        }
    }
}
