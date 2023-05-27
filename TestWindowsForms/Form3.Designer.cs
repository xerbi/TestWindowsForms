
namespace TestWindowsForms
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textAnswer4 = new System.Windows.Forms.Label();
            this.textAnswer3 = new System.Windows.Forms.Label();
            this.textAnswer2 = new System.Windows.Forms.Label();
            this.textAnswer1 = new System.Windows.Forms.Label();
            this.answer4 = new System.Windows.Forms.RadioButton();
            this.answer3 = new System.Windows.Forms.RadioButton();
            this.answer2 = new System.Windows.Forms.RadioButton();
            this.answer1 = new System.Windows.Forms.RadioButton();
            this.question = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(397, 526);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "button1";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textAnswer4);
            this.groupBox1.Controls.Add(this.textAnswer3);
            this.groupBox1.Controls.Add(this.textAnswer2);
            this.groupBox1.Controls.Add(this.textAnswer1);
            this.groupBox1.Controls.Add(this.answer4);
            this.groupBox1.Controls.Add(this.answer3);
            this.groupBox1.Controls.Add(this.answer2);
            this.groupBox1.Controls.Add(this.answer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 189);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ответы";
            // 
            // textAnswer4
            // 
            this.textAnswer4.AutoSize = true;
            this.textAnswer4.Location = new System.Drawing.Point(247, 130);
            this.textAnswer4.Name = "textAnswer4";
            this.textAnswer4.Size = new System.Drawing.Size(38, 15);
            this.textAnswer4.TabIndex = 7;
            this.textAnswer4.Text = "label1";
            // 
            // textAnswer3
            // 
            this.textAnswer3.AutoSize = true;
            this.textAnswer3.Location = new System.Drawing.Point(247, 45);
            this.textAnswer3.Name = "textAnswer3";
            this.textAnswer3.Size = new System.Drawing.Size(38, 15);
            this.textAnswer3.TabIndex = 6;
            this.textAnswer3.Text = "label1";
            // 
            // textAnswer2
            // 
            this.textAnswer2.AutoSize = true;
            this.textAnswer2.Location = new System.Drawing.Point(16, 130);
            this.textAnswer2.Name = "textAnswer2";
            this.textAnswer2.Size = new System.Drawing.Size(38, 15);
            this.textAnswer2.TabIndex = 5;
            this.textAnswer2.Text = "label1";
            // 
            // textAnswer1
            // 
            this.textAnswer1.AutoSize = true;
            this.textAnswer1.Location = new System.Drawing.Point(16, 45);
            this.textAnswer1.Name = "textAnswer1";
            this.textAnswer1.Size = new System.Drawing.Size(38, 15);
            this.textAnswer1.TabIndex = 4;
            this.textAnswer1.Text = "label1";
            // 
            // answer4
            // 
            this.answer4.AutoSize = true;
            this.answer4.Location = new System.Drawing.Point(321, 108);
            this.answer4.Name = "answer4";
            this.answer4.Size = new System.Drawing.Size(33, 19);
            this.answer4.TabIndex = 3;
            this.answer4.TabStop = true;
            this.answer4.Text = "D";
            this.answer4.UseVisualStyleBackColor = true;
            // 
            // answer3
            // 
            this.answer3.AutoSize = true;
            this.answer3.Location = new System.Drawing.Point(321, 22);
            this.answer3.Name = "answer3";
            this.answer3.Size = new System.Drawing.Size(33, 19);
            this.answer3.TabIndex = 2;
            this.answer3.TabStop = true;
            this.answer3.Text = "C";
            this.answer3.UseVisualStyleBackColor = true;
            // 
            // answer2
            // 
            this.answer2.AutoSize = true;
            this.answer2.Location = new System.Drawing.Point(121, 108);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(32, 19);
            this.answer2.TabIndex = 1;
            this.answer2.TabStop = true;
            this.answer2.Text = "B";
            this.answer2.UseVisualStyleBackColor = true;
            // 
            // answer1
            // 
            this.answer1.AutoSize = true;
            this.answer1.Location = new System.Drawing.Point(121, 22);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(33, 19);
            this.answer1.TabIndex = 0;
            this.answer1.TabStop = true;
            this.answer1.Text = "A";
            this.answer1.UseVisualStyleBackColor = true;
            // 
            // question
            // 
            this.question.AutoSize = true;
            this.question.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.question.Location = new System.Drawing.Point(12, 28);
            this.question.MaximumSize = new System.Drawing.Size(0, 2000);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(65, 28);
            this.question.TabIndex = 2;
            this.question.Text = "label1";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.question);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Exit);
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "TestForm";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Test_Close);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label textAnswer4;
        public System.Windows.Forms.Label textAnswer3;
        public System.Windows.Forms.Label textAnswer2;
        public System.Windows.Forms.Label textAnswer1;
        private System.Windows.Forms.RadioButton answer4;
        private System.Windows.Forms.RadioButton answer3;
        private System.Windows.Forms.RadioButton answer2;
        private System.Windows.Forms.RadioButton answer1;
        private System.Windows.Forms.Label question;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}