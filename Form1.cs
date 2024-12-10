namespace StudyFramework1
{
    public partial class Form1 : Form
    {
        readonly StudyData studyContent = new(StudyData.DataSource.FileSystem);
        bool skipPassed = false;
        string? newQuestion;

        public Form1()
        {
            InitializeComponent();

            foreach (string item in studyContent.GetStudySubjects())
            {
                if ((string.IsNullOrEmpty(item)) || (string.IsNullOrEmpty(item.Trim())) || (comboBoxSubject.Items.Contains(item))) continue;
                comboBoxSubject.Items.Add(item);
            }
            if (comboBoxSubject.Items.Count > 0)
                comboBoxSubject.SelectedIndex = 0;
            
            labelResult.Text = string.Empty;
        }

        private void ComboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            comboBoxTopic.Items.Clear();
            comboBoxTopic.Text = string.Empty;
            comboBoxSubTopic.Items.Clear();
            comboBoxSubTopic.Text = string.Empty;
            foreach (string topic in studyContent.GetSubjectTopics(comboBoxSubject.Text))
            {
                if ((string.IsNullOrEmpty(topic)) || (string.IsNullOrEmpty(topic.Trim())) || (comboBoxTopic.Items.Contains(topic))) continue;
                comboBoxTopic.Items.Add(topic);
            }
            if (comboBoxTopic.Items.Count > 0)
                comboBoxTopic.SelectedIndex = 0;
        }

        private void ComboBoxTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            comboBoxSubTopic.Items.Clear();
            comboBoxSubTopic.Text = string.Empty;
            foreach (string subtopic in studyContent.GetSubTopics(comboBoxSubject.Text, comboBoxTopic.Text))
            {
                if ((string.IsNullOrEmpty(subtopic)) || (string.IsNullOrEmpty(subtopic.Trim())) || (comboBoxSubTopic.Items.Contains(subtopic))) continue;
                comboBoxSubTopic.Items.Add(subtopic);
            }
            if (comboBoxSubTopic.Items.Count > 0)
                comboBoxSubTopic.SelectedIndex = 0;
        }

        private void ComboBoxSubTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            labelQuestion.Text = string.Empty;
            textBoxAnswer.Text = string.Empty;
            textBoxQuestion.Text = string.Empty;
            labelQuestion.Text = studyContent.GetCurrentQuestion(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text , skipPassed);
        }

        private void ButtonAddSubject_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (String.IsNullOrEmpty(textBoxSubject.Text)) return;
            _ = comboBoxSubject.Items.Add(textBoxSubject.Text);
            studyContent.AddSubject(textBoxSubject.Text);
            textBoxSubject.Text = string.Empty;

            if (comboBoxSubject.Items.Count > 0)
            {
                comboBoxSubject.SelectedIndex = comboBoxSubject.Items.Count - 1;
                return;
            }
            labelResult.Text = "Subject Added";
        }

        private void ButtonAddTopic_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (String.IsNullOrEmpty(textBoxTopic.Text)) return;
            _ = comboBoxTopic.Items.Add(textBoxTopic.Text);
            studyContent.AddTopic(textBoxSubject.Text, textBoxTopic.Text);
            textBoxTopic.Text = string.Empty;

            if (comboBoxTopic.Items.Count > 0)
            {
                comboBoxTopic.SelectedIndex = comboBoxTopic.Items.Count - 1;
                return;
            }
            labelResult.Text = "Topic Added";
        }

        private void ButtonAddSubTopic_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (String.IsNullOrEmpty(textBoxSubTopic.Text)) return;
            _ = comboBoxSubTopic.Items.Add(textBoxSubTopic.Text);
            studyContent.AddSubTopic(comboBoxSubject.Text, comboBoxTopic.Text, textBoxSubTopic.Text);
            textBoxSubTopic.Text = string.Empty;

            if (comboBoxSubTopic.Items.Count > 0)
            {
                comboBoxSubTopic.SelectedIndex = comboBoxSubTopic.Items.Count - 1;
                return;
            }
            labelResult.Text = "Subtopic Added";
            labelQuestion.Text = string.Empty;
        }


        private void ButtonAddQuestion_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (String.IsNullOrEmpty(textBoxQuestion.Text)) return;
            labelResult.Text = string.Empty;
            labelQuestion.Text = string.Empty;
            textBoxAnswer.Text = string.Empty;
            if (buttonAddQuestion.Text == "Add Question")
            {
                newQuestion = textBoxQuestion.Text;
                buttonAddQuestion.Text = "Add Answer";
                labelResult.Text = "Question Added";
                textBoxQuestion.Text = string.Empty;
                buttonEditAnswer.Visible = false;
                buttonEditQuestion.Visible = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(newQuestion)) 
                    studyContent.AddQAG(newQuestion, textBoxQuestion.Text, comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text);

                labelResult.Text = "Answer Added";
                buttonAddQuestion.Text = "Add Question";
                textBoxQuestion.Text = string.Empty;
                labelQuestion.Text = studyContent.GetCurrentQuestion(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, skipPassed);
                buttonEditAnswer.Visible = true;
                buttonEditQuestion.Visible = true;
            }
        }

        private void ButtonDeleteSubject_click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (comboBoxSubject.Items.Count > 0)
            {
                studyContent.RemoveSubject(comboBoxSubject.Text);
                comboBoxSubject.Items.Remove(comboBoxSubject.SelectedItem);
                comboBoxSubject.Text = string.Empty;
                comboBoxTopic.Items.Clear();
                comboBoxTopic.Text = string.Empty;
                comboBoxSubTopic.Items.Clear();
                comboBoxSubTopic.Text = string.Empty;
            }
        }

        private void ButtonDeleteTopic_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (comboBoxTopic.Items.Count > 0)
            {
                studyContent.RemoveTopic(comboBoxSubject.Text, comboBoxTopic.Text);
                comboBoxTopic.Items.Remove(comboBoxTopic.SelectedItem);
                comboBoxTopic.Text = string.Empty;
                comboBoxSubTopic.Items.Clear();
                comboBoxSubTopic.Text = string.Empty;
            }

        }

        private void ButtonDeleteSubTopic_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (comboBoxSubTopic.Items.Count > 0)
            {
                studyContent.RemoveSubTopic(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text);
                comboBoxSubTopic.Items.Remove(comboBoxSubTopic.SelectedItem);
                comboBoxSubTopic.Text = string.Empty;
            }

        }

        private void ButtonQuestionRemove_Click(object sender, EventArgs e)
        {
            studyContent.RemoveQAG(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, labelQuestion.Text);
        }

        /// <summary>
        /// This button displays the answer to the current question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowAnswer_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text = studyContent.GetCurrentAnswer(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, labelQuestion.Text);
            textBoxAnswer.Visible = true;
            buttonShowAnswer.Visible = false;
            buttonEditQuestion.Visible = true;
        }

        private void ButtonMarkCorrect_Click(object sender, EventArgs e)
        {
            studyContent.MarkAnswerCorrect(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, labelQuestion.Text);
            labelResult.Text = "Answer Marked Correct";
            studyContent.IncrementQuestionIndex();
            ShowCurrentQuestion();
            buttonEditQuestion.Visible = false;

        }

        private void ButtonMarkIncorrect_Click(object sender, EventArgs e)
        {
            studyContent.MarkAnswerIncorrect(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, labelQuestion.Text);

            labelResult.Text = "Answer Marked Incorrect";
            studyContent.IncrementQuestionIndex();
            ShowCurrentQuestion();
            buttonEditQuestion.Visible = false;
        }

        private void ShowFirstQuestion()
        {
            studyContent.ResetQuestionIndex();
            ShowCurrentQuestion();
        }

        private void ShowCurrentQuestion()
        {
            labelResult.Text = string.Empty;
            labelQuestion.Text = string.Empty;
            textBoxAnswer.Text = string.Empty;
            labelQuestion.Text = studyContent.GetCurrentQuestion(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, skipPassed);
            textBoxAnswer.Visible = false;
            buttonShowAnswer.Visible = true;
        }

        private void ButtonShowWrong_Click(object sender, EventArgs e)
        {
            if (buttonShowWrong.Text == "Show Wrong")
            {
                skipPassed = true;
                buttonShowWrong.Text = "Show All";
            }
            else
            {
                skipPassed = false;
                buttonShowWrong.Text = "Show Wrong";
            }
        }

        private void ButtonClearMarks_Click(object sender, EventArgs e)
        {
            studyContent.ClearAllMarks(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text);
            ShowFirstQuestion();
        }

        private void ButtonEditQuestion_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (buttonEditQuestion.Text.Contains("dit"))
            {
                textBoxQuestion.Text = labelQuestion.Text;
                buttonEditQuestion.Text = "Save Question";
            }
            else {
                studyContent.UpdateQuestionText(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, labelQuestion.Text, textBoxQuestion.Text);
                buttonEditQuestion.Text = "Edit Question";
                labelResult.Text = "Question text updated";
                labelQuestion.Text = textBoxQuestion.Text;
                textBoxQuestion.Text = string.Empty;
            }
        }

        private void ButtonEditAnswer_Click(object sender, EventArgs e)
        {
            if (buttonEditAnswer.Text.Contains("dit"))
            {
                textBoxQuestion.Text = String.Empty;
                buttonEditAnswer.Text = "Save Answer";
            }
            else
            {
                studyContent.UpdateAnswerText(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, labelQuestion.Text, textBoxAnswer.Text);
            }

        }
    }
}
