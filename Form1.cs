namespace StudyFramework1
{
    public partial class Form1 : Form
    {
        readonly XMLFunctions xMLFunctions = new();
        bool skipPassed = false;

        public Form1()
        {
            InitializeComponent();
            List<string> items = xMLFunctions.InitializeDoc();
            if (items.Count > 0)
            {
                foreach (string item in items)
                {
                    if ((string.IsNullOrEmpty(item)) || (string.IsNullOrEmpty(item.Trim())) || (comboBoxSubject.Items.Contains(item))) continue;
                    comboBoxSubject.Items.Add(item);
                }
                if (comboBoxSubject.Items.Count > 0)
                    comboBoxSubject.SelectedIndex = 0;
            }
            labelResult.Text = string.Empty;
        }

        private void ComboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            comboBoxTopic.Items.Clear();
            comboBoxTopic.Text = string.Empty;
            comboBoxSubTopic.Items.Clear();
            comboBoxSubTopic.Text = string.Empty;
            foreach (string topic in xMLFunctions.UpdateSelectedSubject(comboBoxSubject.SelectedIndex))
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
            foreach (string subtopic in xMLFunctions.UpdateSelectedTopic(comboBoxTopic.SelectedIndex))
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
            xMLFunctions.UpdateSelectedSubtopic(comboBoxSubject.SelectedIndex);
            labelQuestion.Text = xMLFunctions.GetQuestion(skipPassed);
        }

        private void ButtonAddSubject_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (String.IsNullOrEmpty(textBoxSubject.Text)) return;
            _ = comboBoxSubject.Items.Add(textBoxSubject.Text);
            xMLFunctions.AddSubject(textBoxSubject.Text);
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
            xMLFunctions.AddTopic(textBoxTopic.Text);
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
            xMLFunctions.AddSubTopic(textBoxSubTopic.Text);
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
            if (buttonAddQuestion.Text == "Add Question")
            {
                xMLFunctions.newQuestion = textBoxQuestion.Text;
                buttonAddQuestion.Text = "Add Answer";
                labelResult.Text = "Question Added";
                textBoxQuestion.Text = string.Empty;
                buttonEditAnswer.Visible = false;
                buttonEditQuestion.Visible = false;
            }
            else
            {
                xMLFunctions.AddQAG(xMLFunctions.newQuestion, textBoxQuestion.Text);
                labelResult.Text = "Answer Added";
                buttonAddQuestion.Text = "Add Question";
                textBoxQuestion.Text = string.Empty;
                labelQuestion.Text = xMLFunctions.GetQuestion(skipPassed);
                buttonEditAnswer.Visible = true;
                buttonEditQuestion.Visible = true;
            }
        }

        private void ButtonDeleteSubject_click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (comboBoxSubject.Items.Count > 0)
            {
                xMLFunctions.RemoveSubject(comboBoxSubject.SelectedIndex);
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
                xMLFunctions.RemoveTopic();
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
                xMLFunctions.RemoveSubTopic();
                comboBoxSubTopic.Items.Remove(comboBoxSubTopic.SelectedItem);
                comboBoxSubTopic.Text = string.Empty;
            }

        }

        private void ButtonQuestionRemove_Click(object sender, EventArgs e)
        {
            xMLFunctions.RemoveQuestion();
        }

        /// <summary>
        /// This button displays the answer to the current question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowAnswer_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text = xMLFunctions.GetAnswer();
            textBoxAnswer.Visible = true;
            buttonShowAnswer.Visible = false;
        }

        private void ButtonMarkCorrect_Click(object sender, EventArgs e)
        {
            xMLFunctions.MarkAnswerCorrect();
            labelResult.Text = "Answer Marked Correct";
            ShowCurrentQuestion();
        }

        private void ButtonMarkIncorrect_Click(object sender, EventArgs e)
        {
            xMLFunctions.MarkAnswerIncorrect();

            labelResult.Text = "Answer Marked Incorrect";
            ShowCurrentQuestion();
        }

        private void ShowFirstQuestion()
        {
            xMLFunctions.ResetQuestionIndex();
            ShowCurrentQuestion();
        }

        private void ShowCurrentQuestion()
        {
            labelResult.Text = string.Empty;
            labelQuestion.Text = string.Empty;
            textBoxAnswer.Text = string.Empty;
            labelQuestion.Text = xMLFunctions.GetQuestion(skipPassed);
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
            xMLFunctions.ClearAllMarks();
            ShowFirstQuestion();
        }

        private void ButtonEditQuestion_Click(object sender, EventArgs e)
        {
            if (buttonEditQuestion.Text.Contains("dit"))
            {
                textBoxQuestion.Text = String.Empty;
                buttonEditQuestion.Text = "Save Question";
            }
            else {
                xMLFunctions.UpdateQuestionText(textBoxQuestion.Text);
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
                xMLFunctions.UpdateAnswerText(textBoxQuestion.Text);
            }

        }
    }
}
