using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsForms
{
    public partial class ResultForm : Form
    {
        MainForm startMenu;

        public ResultForm(MainForm start)
        {
            startMenu = start;
            InitializeComponent();
            this.Size = new Size(500, 600);
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            this.Text = "Test C#: результат";
            this.StartPosition = FormStartPosition.CenterScreen;

            Edit.DecryptFile(@"json\Result.txt", Edit.key);
            StreamReader sr = new StreamReader(@"json\Result.txt");
            //Read the first line of text
            string line = sr.ReadToEnd();
            this.ListStudents.Text = line;
            sr.Close();
            Edit.EncryptFile(@"json\Result.txt", Edit.key);
        }

        private void Result_Close(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Выйти из результов тестироавания?",
                "Завершение просмтора",
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