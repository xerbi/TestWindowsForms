using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsForms
{
    public partial class Edit : Form
    {
        MainForm startMenu;
        public Edit(MainForm start)
        {
            startMenu = start;
            InitializeComponent();
        }
        
        private void Edit_Close(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Завершить администрирование?",
                "Завершение администрирования",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
                startMenu.Visible = true;
            }
            else e.Cancel = true;
        }
    }
}
