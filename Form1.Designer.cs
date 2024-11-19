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
            tableLayoutPanel4 = new TableLayoutPanel();
            panel7 = new Panel();
            comboBoxSubTopic = new ComboBox();
            label5 = new Label();
            panel8 = new Panel();
            textBoxSubTopic = new TextBox();
            buttonAddSubTopic = new Button();
            label6 = new Label();
            panel9 = new Panel();
            buttonDeleteSubTopic = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel4 = new Panel();
            comboBoxTopic = new ComboBox();
            label3 = new Label();
            panel5 = new Panel();
            textBoxTopic = new TextBox();
            buttonAddTopic = new Button();
            label4 = new Label();
            panel6 = new Panel();
            buttonDeleteTopic = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            textBoxSubject = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            buttonDeleteSubject = new Button();
            panel10 = new Panel();
            buttonClearMarks = new Button();
            buttonShowWrong = new Button();
            buttonMarkIncorrect = new Button();
            buttonMarkCorrect = new Button();
            labelAnswer = new Label();
            buttonShowAnswer = new Button();
            labelQuestion = new Label();
            buttonUpdateXml = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel10.SuspendLayout();
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
            buttonAddSubject.Anchor = AnchorStyles.Right;
            buttonAddSubject.Location = new Point(300, 12);
            buttonAddSubject.Name = "buttonAddSubject";
            buttonAddSubject.Size = new Size(74, 45);
            buttonAddSubject.TabIndex = 2;
            buttonAddSubject.Text = "Add Subject";
            buttonAddSubject.UseVisualStyleBackColor = true;
            buttonAddSubject.Click += ButtonAddSubject_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel10, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 102F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 101F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.Size = new Size(751, 450);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.4316177F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.5683823F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111F));
            tableLayoutPanel4.Controls.Add(panel7, 0, 1);
            tableLayoutPanel4.Controls.Add(panel8, 1, 1);
            tableLayoutPanel4.Controls.Add(label6, 1, 0);
            tableLayoutPanel4.Controls.Add(panel9, 2, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel4.Location = new Point(3, 208);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel4.Size = new Size(745, 95);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.Controls.Add(comboBoxSubTopic);
            panel7.Controls.Add(label5);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 26);
            panel7.Name = "panel7";
            panel7.Size = new Size(243, 66);
            panel7.TabIndex = 0;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 14);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 0;
            label5.Text = "Choose Subtopic";
            // 
            // panel8
            // 
            panel8.Controls.Add(textBoxSubTopic);
            panel8.Controls.Add(buttonAddSubTopic);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(252, 26);
            panel8.Name = "panel8";
            panel8.Size = new Size(378, 66);
            panel8.TabIndex = 1;
            // 
            // textBoxSubTopic
            // 
            textBoxSubTopic.Location = new Point(12, 32);
            textBoxSubTopic.Name = "textBoxSubTopic";
            textBoxSubTopic.Size = new Size(255, 23);
            textBoxSubTopic.TabIndex = 3;
            // 
            // buttonAddSubTopic
            // 
            buttonAddSubTopic.Anchor = AnchorStyles.Right;
            buttonAddSubTopic.Location = new Point(300, 10);
            buttonAddSubTopic.Name = "buttonAddSubTopic";
            buttonAddSubTopic.Size = new Size(74, 45);
            buttonAddSubTopic.TabIndex = 2;
            buttonAddSubTopic.Text = "Add SubTopic";
            buttonAddSubTopic.UseVisualStyleBackColor = true;
            buttonAddSubTopic.Click += ButtonAddSubTopic_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(406, 0);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 2;
            label6.Text = "Minor Topic";
            // 
            // panel9
            // 
            panel9.Controls.Add(buttonDeleteSubTopic);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(636, 26);
            panel9.Name = "panel9";
            panel9.Size = new Size(106, 66);
            panel9.TabIndex = 3;
            // 
            // buttonDeleteSubTopic
            // 
            buttonDeleteSubTopic.Location = new Point(10, 6);
            buttonDeleteSubTopic.Name = "buttonDeleteSubTopic";
            buttonDeleteSubTopic.Size = new Size(84, 56);
            buttonDeleteSubTopic.TabIndex = 4;
            buttonDeleteSubTopic.Text = "Delete Current Subtopic";
            buttonDeleteSubTopic.UseVisualStyleBackColor = true;
            buttonDeleteSubTopic.Click += ButtonDeleteSubTopic_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.43162F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.5683823F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111F));
            tableLayoutPanel3.Controls.Add(panel4, 0, 1);
            tableLayoutPanel3.Controls.Add(panel5, 1, 1);
            tableLayoutPanel3.Controls.Add(label4, 1, 0);
            tableLayoutPanel3.Controls.Add(panel6, 2, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel3.Location = new Point(3, 105);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel3.Size = new Size(745, 97);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(comboBoxTopic);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 27);
            panel4.Name = "panel4";
            panel4.Size = new Size(243, 67);
            panel4.TabIndex = 0;
            // 
            // comboBoxTopic
            // 
            comboBoxTopic.FormattingEnabled = true;
            comboBoxTopic.Location = new Point(13, 32);
            comboBoxTopic.Name = "comboBoxTopic";
            comboBoxTopic.Size = new Size(184, 23);
            comboBoxTopic.TabIndex = 1;
            comboBoxTopic.SelectedIndexChanged += ComboBoxTopic_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 14);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 0;
            label3.Text = "Choose Topic";
            // 
            // panel5
            // 
            panel5.Controls.Add(textBoxTopic);
            panel5.Controls.Add(buttonAddTopic);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(252, 27);
            panel5.Name = "panel5";
            panel5.Size = new Size(378, 67);
            panel5.TabIndex = 1;
            // 
            // textBoxTopic
            // 
            textBoxTopic.Location = new Point(12, 32);
            textBoxTopic.Name = "textBoxTopic";
            textBoxTopic.Size = new Size(255, 23);
            textBoxTopic.TabIndex = 3;
            // 
            // buttonAddTopic
            // 
            buttonAddTopic.Anchor = AnchorStyles.Right;
            buttonAddTopic.Location = new Point(300, 7);
            buttonAddTopic.Name = "buttonAddTopic";
            buttonAddTopic.Size = new Size(74, 45);
            buttonAddTopic.TabIndex = 2;
            buttonAddTopic.Text = "Add Topic";
            buttonAddTopic.UseVisualStyleBackColor = true;
            buttonAddTopic.Click += ButtonAddTopic_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(406, 0);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 2;
            label4.Text = "Major Topic";
            // 
            // panel6
            // 
            panel6.Controls.Add(buttonDeleteTopic);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(636, 27);
            panel6.Name = "panel6";
            panel6.Size = new Size(106, 67);
            panel6.TabIndex = 3;
            // 
            // buttonDeleteTopic
            // 
            buttonDeleteTopic.Location = new Point(10, 6);
            buttonDeleteTopic.Name = "buttonDeleteTopic";
            buttonDeleteTopic.Size = new Size(84, 56);
            buttonDeleteTopic.TabIndex = 4;
            buttonDeleteTopic.Text = "Delete Current Topic";
            buttonDeleteTopic.UseVisualStyleBackColor = true;
            buttonDeleteTopic.Click += ButtonDeleteTopic_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.43162F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.5683823F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 1);
            tableLayoutPanel2.Controls.Add(panel2, 1, 1);
            tableLayoutPanel2.Controls.Add(label2, 1, 0);
            tableLayoutPanel2.Controls.Add(panel3, 2, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel2.Size = new Size(745, 96);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBoxSubject);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(243, 66);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBoxSubject);
            panel2.Controls.Add(buttonAddSubject);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(252, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(378, 66);
            panel2.TabIndex = 1;
            // 
            // textBoxSubject
            // 
            textBoxSubject.Location = new Point(12, 32);
            textBoxSubject.Name = "textBoxSubject";
            textBoxSubject.Size = new Size(255, 23);
            textBoxSubject.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(418, 0);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 2;
            label2.Text = "Subject";
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonDeleteSubject);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(636, 27);
            panel3.Name = "panel3";
            panel3.Size = new Size(106, 66);
            panel3.TabIndex = 3;
            // 
            // buttonDeleteSubject
            // 
            buttonDeleteSubject.Location = new Point(10, 6);
            buttonDeleteSubject.Name = "buttonDeleteSubject";
            buttonDeleteSubject.Size = new Size(84, 56);
            buttonDeleteSubject.TabIndex = 4;
            buttonDeleteSubject.Text = "Delete Current Subject";
            buttonDeleteSubject.UseVisualStyleBackColor = true;
            buttonDeleteSubject.Click += ButtonDeleteSubject_click;
            // 
            // panel10
            // 
            panel10.Controls.Add(buttonUpdateXml);
            panel10.Controls.Add(buttonClearMarks);
            panel10.Controls.Add(buttonShowWrong);
            panel10.Controls.Add(buttonMarkIncorrect);
            panel10.Controls.Add(buttonMarkCorrect);
            panel10.Controls.Add(labelAnswer);
            panel10.Controls.Add(buttonShowAnswer);
            panel10.Controls.Add(labelQuestion);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 309);
            panel10.Name = "panel10";
            panel10.Size = new Size(745, 138);
            panel10.TabIndex = 3;
            // 
            // buttonClearMarks
            // 
            buttonClearMarks.Location = new Point(356, 81);
            buttonClearMarks.Name = "buttonClearMarks";
            buttonClearMarks.Size = new Size(75, 39);
            buttonClearMarks.TabIndex = 6;
            buttonClearMarks.Text = "Clear Marks";
            buttonClearMarks.UseVisualStyleBackColor = true;
            // 
            // buttonShowWrong
            // 
            buttonShowWrong.Location = new Point(270, 81);
            buttonShowWrong.Name = "buttonShowWrong";
            buttonShowWrong.Size = new Size(75, 39);
            buttonShowWrong.TabIndex = 5;
            buttonShowWrong.Text = "Show Wrong";
            buttonShowWrong.UseVisualStyleBackColor = true;
            // 
            // buttonMarkIncorrect
            // 
            buttonMarkIncorrect.Location = new Point(189, 81);
            buttonMarkIncorrect.Name = "buttonMarkIncorrect";
            buttonMarkIncorrect.Size = new Size(75, 39);
            buttonMarkIncorrect.TabIndex = 4;
            buttonMarkIncorrect.Text = "Mark Incorrect";
            buttonMarkIncorrect.UseVisualStyleBackColor = true;
            // 
            // buttonMarkCorrect
            // 
            buttonMarkCorrect.Location = new Point(108, 81);
            buttonMarkCorrect.Name = "buttonMarkCorrect";
            buttonMarkCorrect.Size = new Size(75, 39);
            buttonMarkCorrect.TabIndex = 3;
            buttonMarkCorrect.Text = "Mark Correct";
            buttonMarkCorrect.UseVisualStyleBackColor = true;
            // 
            // labelAnswer
            // 
            labelAnswer.AutoSize = true;
            labelAnswer.Location = new Point(22, 35);
            labelAnswer.Name = "labelAnswer";
            labelAnswer.Size = new Size(52, 15);
            labelAnswer.TabIndex = 2;
            labelAnswer.Text = "Answer: ";
            // 
            // buttonShowAnswer
            // 
            buttonShowAnswer.Location = new Point(16, 81);
            buttonShowAnswer.Name = "buttonShowAnswer";
            buttonShowAnswer.Size = new Size(75, 39);
            buttonShowAnswer.TabIndex = 1;
            buttonShowAnswer.Text = "Show Answer";
            buttonShowAnswer.UseVisualStyleBackColor = true;
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Location = new Point(16, 9);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(58, 15);
            labelQuestion.TabIndex = 0;
            labelQuestion.Text = "Question:";
            // 
            // buttonUpdateXml
            // 
            buttonUpdateXml.Location = new Point(444, 81);
            buttonUpdateXml.Name = "buttonUpdateXml";
            buttonUpdateXml.Size = new Size(75, 39);
            buttonUpdateXml.TabIndex = 7;
            buttonUpdateXml.Text = "Update Xml";
            buttonUpdateXml.UseVisualStyleBackColor = true;
            buttonUpdateXml.Click += ButtonUpdateXml_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxSubject;
        private Button buttonAddSubject;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private TextBox textBoxSubject;
        private Panel panel3;
        private Button buttonDeleteSubject;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel4;
        private ComboBox comboBoxTopic;
        private Label label3;
        private Panel panel5;
        private TextBox textBoxTopic;
        private Button buttonAddTopic;
        private Label label4;
        private Panel panel6;
        private Button buttonDeleteTopic;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel7;
        private ComboBox comboBoxSubTopic;
        private Label label5;
        private Panel panel8;
        private TextBox textBoxSubTopic;
        private Button buttonAddSubTopic;
        private Label label6;
        private Panel panel9;
        private Button buttonDeleteSubTopic;
        private Panel panel10;
        private Button buttonMarkIncorrect;
        private Button buttonMarkCorrect;
        private Label labelAnswer;
        private Button buttonShowAnswer;
        private Label labelQuestion;
        private Button buttonClearMarks;
        private Button buttonShowWrong;
        private Button buttonUpdateXml;
    }
}
