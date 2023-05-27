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
        private Serializ questionJson;
        private int[] chooseQuestionL1 = new int[5];
        private int[] chooseQuestionL2 = new int[5];

        public TestForm(MainForm start)
        {
            InitializeComponent();

            startMenu = start;

            this.Size = new Size(500, 600);
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            this.Text = "Test C#: тестирование";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label Question
            this.question.MaximumSize = new Size(450, 300);
            Size s = new Size();
            s.Width = 65;
            s.Height = 28;
            this.question.Size = s;
            FirstStart();
        }

        private void FirstStart()
        {
            getRandomNumberMass(chooseQuestionL1);
            getRandomNumberMass(chooseQuestionL2);
            questionJson = JsonConvert.DeserializeObject<Serializ>(OpenJsonFile());
            int i = 8;

            /*if (questionJson.question_level1[chooseQuestionL1[0]].question.Length > 50)
            {
                Size s = new Size();
                s.Width = 38;
                s.Height = 13;
                this.question.Size = s;
            }*/
            int test = questionJson.question_level2[i].question.Length;
            if (test > 100)
            {
                this.question.Font = new Font(Font.FontFamily.Name, 8);
            }
            //string quest = questionJson.question_level1[chooseQuestionL1[0]].question;
            string quest = questionJson.question_level2[i].question;
            this.question.Text = quest;
        }

        private void getRandomNumberMass(int[] massive)
        {
            Random rand = new Random();
            massive[0] = rand.Next(1, massive.Length + 1);
            for (int i = 1; i < massive.Length; ++i)
            {
                int r = rand.Next(1, massive.Length + 1);
                for (int j = 0; j < i; ++j)
                {
                    if (r == massive[j])
                    {
                        r = rand.Next(1, massive.Length + 1);
                        j = -1;
                    }
                }
                massive[i] = r;
            }
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