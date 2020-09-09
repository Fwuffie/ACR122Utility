using MiFare.PcSc;
using PCSC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACRUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contextFactory = ContextFactory.Instance;
            using (var context = contextFactory.Establish(SCardScope.System))
            {
                output.Text +=  "Currently connected readers: ";
                var readerNames = context.GetReaders();
                foreach (var readerName in readerNames)
                {
                    output.Text += "\n" + readerName;
                }
            }

        }
    }
}
