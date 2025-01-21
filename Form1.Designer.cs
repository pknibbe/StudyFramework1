namespace StudyFramework1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            comboBoxSubject = new ComboBox();
            buttonAddSubject = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel7 = new Panel();
            buttonDeleteSubTopic = new Button();
            comboBoxSubTopic = new ComboBox();
            buttonAddSubTopic = new Button();
            label5 = new Label();
            panel4 = new Panel();
            buttonDeleteTopic = new Button();
            buttonAddTopic = new Button();
            comboBoxTopic = new ComboBox();
            label3 = new Label();
            panel1 = new Panel();
            buttonDeleteSubject = new Button();
            panel2 = new Panel();
            labelResult = new Label();
            buttonAddQuestion = new Button();
            buttonEditAnswer = new Button();
            buttonQuestionRemove = new Button();
            buttonEditQuestion = new Button();
            buttonClearMarks = new Button();
            comboBoxQuestion = new ComboBox();
            buttonMarkIncorrect = new Button();
            buttonShowWrong = new Button();
            buttonMarkCorrect = new Button();
            buttonShowAnswer = new Button();
            labelChooseQuestion = new Label();
            textBoxAnswer = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 14);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Choose Subject";
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(13, 32);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(184, 23);
            comboBoxSubject.TabIndex = 1;
            comboBoxSubject.SelectedIndexChanged += ComboBoxSubject_SelectedIndexChanged;
            // 
            // buttonAddSubject
            // 
            buttonAddSubject.Location = new Point(203, 7);
            buttonAddSubject.Name = "buttonAddSubject";
            buttonAddSubject.Size = new Size(102, 28);
            buttonAddSubject.TabIndex = 2;
            buttonAddSubject.Text = "Add Subject";
            buttonAddSubject.UseVisualStyleBackColor = true;
            buttonAddSubject.Click += ButtonAddSubject_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(964, 331);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3499947F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3200073F));
            tableLayoutPanel2.Controls.Add(panel7, 2, 0);
            tableLayoutPanel2.Controls.Add(panel4, 1, 0);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(958, 97);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(buttonDeleteSubTopic);
            panel7.Controls.Add(comboBoxSubTopic);
            panel7.Controls.Add(buttonAddSubTopic);
            panel7.Controls.Add(label5);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(641, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(314, 91);
            panel7.TabIndex = 2;
            // 
            // buttonDeleteSubTopic
            // 
            buttonDeleteSubTopic.Location = new Point(208, 41);
            buttonDeleteSubTopic.Name = "buttonDeleteSubTopic";
            buttonDeleteSubTopic.Size = new Size(102, 28);
            buttonDeleteSubTopic.TabIndex = 4;
            buttonDeleteSubTopic.Text = "Delete Subtopic";
            buttonDeleteSubTopic.UseVisualStyleBackColor = true;
            buttonDeleteSubTopic.Click += ButtonDeleteSubTopic_Click;
            // 
            // comboBoxSubTopic
            // 
            comboBoxSubTopic.FormattingEnabled = true;
            comboBoxSubTopic.Location = new Point(13, 32);
            comboBoxSubTopic.Name = "comboBoxSubTopic";
            comboBoxSubTopic.Size = new Size(184, 23);
            comboBoxSubTopic.TabIndex = 1;
            comboBoxSubTopic.SelectedIndexChanged += ComboBoxSubTopic_SelectedIndexChanged;
            // 
            // buttonAddSubTopic
            // 
            buttonAddSubTopic.Anchor = AnchorStyles.Right;
            buttonAddSubTopic.Location = new Point(208, 11);
            buttonAddSubTopic.Name = "buttonAddSubTopic";
            buttonAddSubTopic.Size = new Size(102, 28);
            buttonAddSubTopic.TabIndex = 2;
            buttonAddSubTopic.Text = "Add SubTopic";
            buttonAddSubTopic.UseVisualStyleBackColor = true;
            buttonAddSubTopic.Click += ButtonAddSubTopic_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 14);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 0;
            label5.Text = "Choose Subtopic";
            // 
            // panel4
            // 
            panel4.Controls.Add(buttonDeleteTopic);
            panel4.Controls.Add(buttonAddTopic);
            panel4.Controls.Add(comboBoxTopic);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(322, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(313, 91);
            panel4.TabIndex = 1;
            // 
            // buttonDeleteTopic
            // 
            buttonDeleteTopic.Location = new Point(203, 41);
            buttonDeleteTopic.Name = "buttonDeleteTopic";
            buttonDeleteTopic.Size = new Size(102, 28);
            buttonDeleteTopic.TabIndex = 4;
            buttonDeleteTopic.Text = "Delete Topic";
            buttonDeleteTopic.UseVisualStyleBackColor = true;
            buttonDeleteTopic.Click += ButtonDeleteTopic_Click;
            // 
            // buttonAddTopic
            // 
            buttonAddTopic.Anchor = AnchorStyles.Right;
            buttonAddTopic.Location = new Point(203, 7);
            buttonAddTopic.Name = "buttonAddTopic";
            buttonAddTopic.Size = new Size(102, 28);
            buttonAddTopic.TabIndex = 2;
            buttonAddTopic.Text = "Add Topic";
            buttonAddTopic.UseVisualStyleBackColor = true;
            buttonAddTopic.Click += ButtonAddTopic_Click;
            // 
            // comboBoxTopic
            // 
            comboBoxTopic.FormattingEnabled = true;
            comboBoxTopic.Location = new Point(13, 29);
            comboBoxTopic.Name = "comboBoxTopic";
            comboBoxTopic.Size = new Size(184, 23);
            comboBoxTopic.TabIndex = 1;
            comboBoxTopic.SelectedIndexChanged += ComboBoxTopic_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 11);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 0;
            label3.Text = "Choose Topic";
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonDeleteSubject);
            panel1.Controls.Add(buttonAddSubject);
            panel1.Controls.Add(comboBoxSubject);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(313, 91);
            panel1.TabIndex = 0;
            // 
            // buttonDeleteSubject
            // 
            buttonDeleteSubject.Location = new Point(203, 37);
            buttonDeleteSubject.Name = "buttonDeleteSubject";
            buttonDeleteSubject.Size = new Size(102, 28);
            buttonDeleteSubject.TabIndex = 4;
            buttonDeleteSubject.Text = "Delete Subject";
            buttonDeleteSubject.UseVisualStyleBackColor = true;
            buttonDeleteSubject.Click += ButtonDeleteSubject_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelResult);
            panel2.Controls.Add(buttonAddQuestion);
            panel2.Controls.Add(buttonEditAnswer);
            panel2.Controls.Add(buttonQuestionRemove);
            panel2.Controls.Add(buttonEditQuestion);
            panel2.Controls.Add(buttonClearMarks);
            panel2.Controls.Add(comboBoxQuestion);
            panel2.Controls.Add(buttonMarkIncorrect);
            panel2.Controls.Add(buttonShowWrong);
            panel2.Controls.Add(buttonMarkCorrect);
            panel2.Controls.Add(buttonShowAnswer);
            panel2.Controls.Add(labelChooseQuestion);
            panel2.Controls.Add(textBoxAnswer);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(958, 222);
            panel2.TabIndex = 5;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(16, 168);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(39, 15);
            labelResult.TabIndex = 14;
            labelResult.Text = "Result";
            // 
            // buttonAddQuestion
            // 
            buttonAddQuestion.Location = new Point(733, 3);
            buttonAddQuestion.Name = "buttonAddQuestion";
            buttonAddQuestion.Size = new Size(102, 28);
            buttonAddQuestion.TabIndex = 9;
            buttonAddQuestion.Text = "Add Question";
            buttonAddQuestion.UseVisualStyleBackColor = true;
            buttonAddQuestion.Click += ButtonAddQuestion_Click;
            // 
            // buttonEditAnswer
            // 
            buttonEditAnswer.Location = new Point(849, 37);
            buttonEditAnswer.Name = "buttonEditAnswer";
            buttonEditAnswer.Size = new Size(102, 28);
            buttonEditAnswer.TabIndex = 12;
            buttonEditAnswer.Text = "Edit Answer";
            buttonEditAnswer.UseVisualStyleBackColor = true;
            buttonEditAnswer.Click += ButtonEditAnswer_Click;
            // 
            // buttonQuestionRemove
            // 
            buttonQuestionRemove.Location = new Point(736, 37);
            buttonQuestionRemove.Name = "buttonQuestionRemove";
            buttonQuestionRemove.Size = new Size(102, 28);
            buttonQuestionRemove.TabIndex = 10;
            buttonQuestionRemove.Text = "Delete Question";
            buttonQuestionRemove.UseVisualStyleBackColor = true;
            buttonQuestionRemove.Click += ButtonQuestionRemove_Click;
            // 
            // buttonEditQuestion
            // 
            buttonEditQuestion.Location = new Point(849, 3);
            buttonEditQuestion.Name = "buttonEditQuestion";
            buttonEditQuestion.Size = new Size(102, 28);
            buttonEditQuestion.TabIndex = 11;
            buttonEditQuestion.Text = "Edit Question";
            buttonEditQuestion.UseVisualStyleBackColor = true;
            buttonEditQuestion.Click += ButtonEditQuestion_Click;
            // 
            // buttonClearMarks
            // 
            buttonClearMarks.Location = new Point(849, 141);
            buttonClearMarks.Name = "buttonClearMarks";
            buttonClearMarks.Size = new Size(102, 28);
            buttonClearMarks.TabIndex = 6;
            buttonClearMarks.Text = "Clear Marks";
            buttonClearMarks.UseVisualStyleBackColor = true;
            buttonClearMarks.Click += ButtonClearMarks_Click;
            // 
            // comboBoxQuestion
            // 
            comboBoxQuestion.FormattingEnabled = true;
            comboBoxQuestion.Location = new Point(16, 32);
            comboBoxQuestion.Name = "comboBoxQuestion";
            comboBoxQuestion.Size = new Size(691, 23);
            comboBoxQuestion.TabIndex = 1;
            comboBoxQuestion.SelectedIndexChanged += ComboBoxQuestion_SelectedIndexChanged;
            // 
            // buttonMarkIncorrect
            // 
            buttonMarkIncorrect.Location = new Point(849, 107);
            buttonMarkIncorrect.Name = "buttonMarkIncorrect";
            buttonMarkIncorrect.Size = new Size(102, 28);
            buttonMarkIncorrect.TabIndex = 4;
            buttonMarkIncorrect.Text = "Mark Incorrect";
            buttonMarkIncorrect.UseVisualStyleBackColor = true;
            buttonMarkIncorrect.Click += ButtonMarkIncorrect_Click;
            // 
            // buttonShowWrong
            // 
            buttonShowWrong.Location = new Point(339, 3);
            buttonShowWrong.Name = "buttonShowWrong";
            buttonShowWrong.Size = new Size(102, 28);
            buttonShowWrong.TabIndex = 5;
            buttonShowWrong.Text = "Show Wrong";
            buttonShowWrong.UseVisualStyleBackColor = true;
            buttonShowWrong.Click += ButtonShowWrong_Click;
            // 
            // buttonMarkCorrect
            // 
            buttonMarkCorrect.Location = new Point(849, 73);
            buttonMarkCorrect.Name = "buttonMarkCorrect";
            buttonMarkCorrect.Size = new Size(102, 28);
            buttonMarkCorrect.TabIndex = 3;
            buttonMarkCorrect.Text = "Mark Correct";
            buttonMarkCorrect.UseVisualStyleBackColor = true;
            buttonMarkCorrect.Click += ButtonMarkCorrect_Click;
            // 
            // buttonShowAnswer
            // 
            buttonShowAnswer.Location = new Point(469, 3);
            buttonShowAnswer.Name = "buttonShowAnswer";
            buttonShowAnswer.Size = new Size(102, 28);
            buttonShowAnswer.TabIndex = 1;
            buttonShowAnswer.Text = "Show Answer";
            buttonShowAnswer.UseVisualStyleBackColor = true;
            buttonShowAnswer.Click += ButtonShowAnswer_Click;
            // 
            // labelChooseQuestion
            // 
            labelChooseQuestion.AutoSize = true;
            labelChooseQuestion.Location = new Point(22, 14);
            labelChooseQuestion.Name = "labelChooseQuestion";
            labelChooseQuestion.Size = new Size(98, 15);
            labelChooseQuestion.TabIndex = 0;
            labelChooseQuestion.Text = "Choose Question";
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.Location = new Point(14, 71);
            textBoxAnswer.Multiline = true;
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.ScrollBars = ScrollBars.Vertical;
            textBoxAnswer.Size = new Size(829, 78);
            textBoxAnswer.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 331);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxSubject;
        private Button buttonAddSubject;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Button buttonDeleteSubject;
        private Button buttonAddTopic;
        private Button buttonDeleteTopic;
        private Button buttonAddSubTopic;
        private Button buttonDeleteSubTopic;
        private Button buttonMarkIncorrect;
        private Button buttonMarkCorrect;
        private Button buttonShowAnswer;
        private Button buttonClearMarks;
        private Button buttonShowWrong;
        private Button buttonQuestionRemove;
        private TextBox textBoxAnswer;
        private Button buttonEditAnswer;
        private Button buttonEditQuestion;
        private Panel panel4;
        private ComboBox comboBoxTopic;
        private Label label3;
        private Panel panel7;
        private ComboBox comboBoxSubTopic;
        private Label label5;
        private Button buttonAddQuestion;
        private Panel panel2;
        private ComboBox comboBoxQuestion;
        private Label labelChooseQuestion;
        private Label labelResult;
    }
}
