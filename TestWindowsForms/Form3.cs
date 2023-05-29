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
        private int[] chooseQuestionL1 = new int[Edit.numberOfQuestionL1];
        private int[] chooseQuestionL2 = new int[Edit.numberOfQuestionL2];
        private int[] answerQuestion = new int[4];
        private Label[] labelsAnswer = new Label[4];
        private RadioButton[] AnswerRadioBtn = new RadioButton[4];
        private int point = 0;

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
            this.question.MaximumSize = new Size(330, 300);
            Size s = new Size();
            s.Width = 65;
            s.Height = 28;
            this.question.Size = s;
            FirstStart();
        }

        // Генерируется первый вопрос
        private void FirstStart()
        {
            AnswerRadioBtn[0] = this.answer1;
            AnswerRadioBtn[1] = this.answer2;
            AnswerRadioBtn[2] = this.answer3;
            AnswerRadioBtn[3] = this.answer4;

            getRandomNumberMass(chooseQuestionL1);
            getRandomNumberMass(chooseQuestionL2);
            questionJson = JsonConvert.DeserializeObject<Serializ>(OpenJsonFile());

            string quest = questionJson.question_level1[chooseQuestionL1[0]].question;
            setParametersLabel(questionJson.question_level1[chooseQuestionL1[0]].question.Length);
            this.question.Text = quest;

            labelsAnswer[0] = this.textAnswer1;
            labelsAnswer[1] = this.textAnswer2;
            labelsAnswer[2] = this.textAnswer3;
            labelsAnswer[3] = this.textAnswer4;

            getRandomNumberMass(answerQuestion);
            setLabelAnswer(labelsAnswer, answerQuestion, questionJson.question_level1[chooseQuestionL1[0]].answer);
        }

        // Устанавливает вывод текста в зависимости от длинны получаемой строки
        private void setParametersLabel(int size)
        {
            if (size > 250)
            {
                this.question.Font = new Font(Font.FontFamily.Name, 8);
                return;
            }
            if (size > 150)
            {
                this.question.Font = new Font(Font.FontFamily.Name, 10);
                return;
            }
            
            this.question.Font = new Font(Font.FontFamily.Name, 15);
        }

        // устанавливает рандомно ответы
        private void setLabelAnswer(Label[] label, int[] numberAnswer, string[] answer)
        {
            for (int i = 0; i < label.Length; ++i)
            {
                label[i].Text = answer[numberAnswer[i]];
            }
        }

        // рандомизирует массив с ответами и с вопросами
        private void getRandomNumberMass(int[] massive)
        {
            Random rand = new Random();
            massive[0] = rand.Next(0, massive.Length);
            for (int i = 1; i < massive.Length; ++i)
            {
                int r = rand.Next(1, massive.Length);
                for (int j = 0; j < i; ++j)
                {
                    if (r == massive[j])
                    {
                        r = rand.Next(0, massive.Length);
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
                    question.Text = "Ошибка! Необходимо настроить программу.";
                }
            }
            return File.ReadAllText(jsonText);
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            int goodAnswer = 0;
            for (int i = 0; i < 4; ++i)
            {
                if (answerQuestion[i] == 0)
                {
                    goodAnswer = i;
                    break;
                }
            }

            //point
            for (int i = 0; i < 4; ++i)
            {
                if (AnswerRadioBtn[i].Checked)
                {
                    if (i != goodAnswer) break;
                    point += 1;
                    break;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {

        }
    }
}