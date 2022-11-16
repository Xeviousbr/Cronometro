using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cronometro
{
    public partial class FTempo : Form
    {
        // public int Oper { get; internal set; }        
        public TimeSpan TS { get; internal set; }
        
        public FTempo()
        {
            InitializeComponent();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            string Tempo = maskedTextBox1.Text;
            DateTime dateTime = DateTime.Parse(Tempo);
            TS = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
            this.DialogResult = DialogResult.OK;
        }
    }
}
