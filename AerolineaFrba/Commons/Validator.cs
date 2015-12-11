using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace AerolineaFrba.Commons
{
    public class Validator{

        public Boolean blocked;

        public Validator(){
            this.blocked = false;
        }

        public Boolean validateInt(string texto){
            int output;
            return int.TryParse(texto, out output);
        }

        public Boolean validateDouble(string texto){
            double output;
            if (texto.IndexOf('.') != -1) return false;
            return double.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out output);
        }

        public void KeyPressBinding(Func<string, Boolean> validatorFunc, Boolean space, KeyPressEventArgs e){
            if (!validatorFunc(e.KeyChar.ToString())) e.Handled = true;
            if (e.KeyChar == (char)8) e.Handled = false; //Permite Backspace
            if (e.KeyChar == (char)32) e.Handled = !space;
        }

        public void KeyPressBinding2(Func<string, Boolean> validatorFunc, Boolean space, KeyPressEventArgs e, string texto)
        {
            if (texto.IndexOf('.') != -1 && e.KeyChar == (char)46) e.Handled = true;
            if (e.KeyChar == (char)8) e.Handled = false; //Permite Backspace
            if (e.KeyChar == (char)32) e.Handled = !space;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46 && e.KeyChar != (char)32) e.Handled = true;
        }
    }
}
