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



    public partial class MainForm : Form
    {
        ResultForm resultList;
        TestForm startTest;
        Edit editForm;

        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size(500, 600);
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            this.Text = "Test C#";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            startTest = new TestForm(this);
            startTest.Show();

            HiddenForm();
        }

        private void Result_Click(object sender, EventArgs e)
        {
            resultList = new ResultForm(this);
            resultList.Show();
            HiddenForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editForm = new Edit(this);
            editForm.Show();
            HiddenForm();
        }

        public void ShowForm() => this.Visible = true;
        public void HiddenForm() => this.Visible = false;
        private void Exit_Click(object sender, EventArgs e) => this.Close();

        private void Main_Close(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Вы уверенны, что хотите выйти из программы?",
                "Завершение программы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (dialog == DialogResult.Yes) e.Cancel = false;
            else e.Cancel = true;
        }
    }
}