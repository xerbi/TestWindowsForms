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
using Newtonsoft.Json;

namespace TestWindowsForms
{
    public partial class TestForm : Form
    {
        MainForm startMenu;

        public TestForm(MainForm start)
        {
            InitializeComponent();

            startMenu = start;

            this.Size = new Size(500, 600);
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            this.Text = "Test C#: тестирование";
            this.StartPosition = FormStartPosition.CenterScreen;
            MainTest();
        }

        private void MainTest()
        {
            // var questionJson = JsonConvert.DeserializeObject<>
            //     = OpenJsonFile();
            string s = OpenJsonFile();
        }

        private void Test_Close(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Вы уверенны, что хотите выйти из тестирования? Ваши данные при этом не сохраняться!",
                "Завершение тестирования",
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

        private string OpenJsonFile()
        {
            string jsonText = @"Json\Question.json";

            if (!File.Exists(jsonText))
            {
                try 
                {
                    using (StreamWriter sw = File.CreateText(jsonText))
                    {
                        sw.WriteLine("test");
                    }
                }
                catch(Exception e)
                {
                    //создать папку
                }
            }
            return File.ReadAllText(jsonText);
        }
        private void testJson()
        {
            //var test = JsonConvert
        }

        private void Exit_Click(object sender, EventArgs e)
        {

        }
    }
}