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
        private int counterL1 = 0;
        private int counterL2 = 0;
        private bool exite = true;
        private string answerTExt;

        public TestForm(MainForm start)
        {
            InitializeComponent();
            startMenu = start;
            this.Name.Visible = false;
            this.Size = new Size(500, 600);
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            this.Text = "Test C#: тестирование";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label Question
            this.question.MaximumSize = new Size(330, 300);
            this.textAnswer1.MaximumSize = new Size(170, 100);
            this.textAnswer2.MaximumSize = new Size(170, 100);
            this.textAnswer3.MaximumSize = new Size(170, 100);
            this.textAnswer4.MaximumSize = new Size(170, 100);
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
            string path = @"Json\Question.json";
            questionJson = JsonConvert.DeserializeObject<Serializ>(OpenJsonFile(path));

            string quest = questionJson.question_level1[chooseQuestionL1[counterL1]].question;
            setParametersLabel(questionJson.question_level1[chooseQuestionL1[counterL1]].question.Length);
            this.question.Text = quest;

            labelsAnswer[0] = this.textAnswer1;
            labelsAnswer[1] = this.textAnswer2;
            labelsAnswer[2] = this.textAnswer3;
            labelsAnswer[3] = this.textAnswer4;

            getRandomNumberMass(answerQuestion);
            setLabelAnswer(labelsAnswer, answerQuestion, questionJson.question_level1[chooseQuestionL1[counterL1]].answer);
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

        private void setParametersLabelAnswer(int size)
        {
            if (size > 22)
            {
                this.textAnswer1.Font = new Font(Font.FontFamily.Name, 8);
                this.textAnswer2.Font = new Font(Font.FontFamily.Name, 8);
                this.textAnswer3.Font = new Font(Font.FontFamily.Name, 8);
                this.textAnswer4.Font = new Font(Font.FontFamily.Name, 8);
                return;
            }
            if (size > 10)
            {
                this.textAnswer1.Font = new Font(Font.FontFamily.Name, 10);
                this.textAnswer2.Font = new Font(Font.FontFamily.Name, 10);
                this.textAnswer3.Font = new Font(Font.FontFamily.Name, 10);
                this.textAnswer4.Font = new Font(Font.FontFamily.Name, 10);
                return;
            }

            this.textAnswer1.Font = new Font(Font.FontFamily.Name, 15);
            this.textAnswer2.Font = new Font(Font.FontFamily.Name, 15);
            this.textAnswer3.Font = new Font(Font.FontFamily.Name, 15);
            this.textAnswer4.Font = new Font(Font.FontFamily.Name, 15);
        }

        // устанавливает рандомно ответы
        private void setLabelAnswer(Label[] label, int[] numberAnswer, string[] answer)
        {
            setParametersLabelAnswer(answer[0].Length);
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
            if (!exite) return;
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

        private string OpenJsonFile(string jsonText)
        {
            if (!File.Exists(jsonText))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(jsonText))
                    {
                        sw.WriteLine("test");
                    }
                }
                catch (Exception e)
                {
                    question.Text = "Ошибка! Необходимо настроить программу.";
                }
            }
            //File.ReadAllText(jsonText);
            
            return Edit.DecryptData(jsonText);
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            if (counterL1 < Edit.numberOfQuestionL1 - 1)
            {
                checkAnswer(answerQuestion, AnswerRadioBtn, 1);
                counterL1 += 1;

                string quest1 = questionJson.question_level1[chooseQuestionL1[counterL1]].question;
                setParametersLabel(questionJson.question_level1[chooseQuestionL1[counterL1]].question.Length);
                this.question.Text = quest1;

                getRandomNumberMass(answerQuestion);
                setLabelAnswer(labelsAnswer, answerQuestion, questionJson.question_level1[chooseQuestionL1[counterL1]].answer);
                return;
            }

            if (!(counterL2 < Edit.numberOfQuestionL2))
            {
                int allPoint = Edit.numberOfQuestionL1 + Edit.numberOfQuestionL2 * 2;
                if (Edit.SUCCESSFUL < point) answerTExt = "5";
                else if (Edit.GOOD < point) answerTExt = "4";
                else if (Edit.NORMAL < point) answerTExt = "3";
                else answerTExt = "2";
                this.btnAnswer.Text = "Выход";
                setParametersLabel(1);
                this.question.Text = $"Ваш результат: {point}/{allPoint}\nВаша оценка - {answerTExt}";
                this.groupBox1.Visible = false;
                this.btnAnswer.Click -= new System.EventHandler(this.Answer_Click);
                this.btnAnswer.Click += new System.EventHandler(this.End);
                this.Name.Visible = true;
                return;
            }

            checkAnswer(answerQuestion, AnswerRadioBtn, 2);
            string quest2 = questionJson.question_level2[chooseQuestionL2[counterL2]].question;
            setParametersLabel(questionJson.question_level2[chooseQuestionL2[counterL2]].question.Length);
            this.question.Text = quest2;

            getRandomNumberMass(answerQuestion);
            setLabelAnswer(labelsAnswer, answerQuestion, questionJson.question_level2[chooseQuestionL2[counterL2]].answer);
            counterL2 += 1;
        }

        private void End(object sender, EventArgs e)
        {
            startMenu.Visible = true;
            exite = false;
            Edit.DecryptFile(@"json\Result.txt", Edit.key);
            using (var tw = File.AppendText(@"json\Result.txt"))
            {
                
                tw.WriteLine($"{this.Name.Text} - {answerTExt}");
            }
            Edit.EncryptFile(@"json\Result.txt", Edit.key);
            this.Close();
        }

        private void checkAnswer(int[] answer, RadioButton[] btn, int p)
        {
            int goodAnswer = 0;
            for (int i = 0; i < 4; ++i)
            {
                if (answer[i] == 0)
                {
                    goodAnswer = i;
                    break;
                }
            }

            for (int i = 0; i < 4; ++i)
            {
                if (btn[i].Checked)
                {
                    if (i != goodAnswer) break;
                    point += p;
                    break;
                }
            }
        }
    }
}