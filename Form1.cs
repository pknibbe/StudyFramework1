namespace StudyFramework1
{
    public partial class Form1 : Form
    {
        readonly StudyData studyContent = new(StudyData.DataSource.FileSystem);
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
            textBoxAnswer.Visible = false;
        }

        // ComboBox selection event handlers
        private void ComboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubject.FindStringExact(comboBoxSubject.Text) == -1) comboBoxSubject.Items.Add((string)comboBoxSubject.Text);
            comboBoxQuestion.Items.Clear();
            comboBoxQuestion.Text = string.Empty;
            labelResult.Text = string.Empty;
            comboBoxTopic.Items.Clear();
            comboBoxTopic.Text = string.Empty;
            comboBoxSubTopic.Items.Clear();
            comboBoxSubTopic.Text = string.Empty;
            textBoxAnswer.Visible = false;
            buttonAddQuestion.Text = "Add Question";
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

            comboBoxQuestion.Items.Clear();
            comboBoxQuestion.Text = string.Empty;
            comboBoxSubTopic.Items.Clear();
            comboBoxSubTopic.Text = string.Empty;
            textBoxAnswer.Visible = false;
            buttonAddQuestion.Text = "Add Question";
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
            textBoxAnswer.Text = string.Empty;
            textBoxAnswer.Visible = false;
            buttonAddQuestion.Text = "Add Question";
            ResetQuestionComboBox();
        }

        private void ComboBoxQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            textBoxAnswer.Visible = false;
            buttonShowAnswer.Visible = true;
            buttonEditQuestion.Visible = true;
        }

        // Button Click event handlers
        private void ButtonAddSubject_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (String.IsNullOrEmpty(comboBoxSubject.Text)) return;
            if (comboBoxSubject.FindStringExact(comboBoxSubject.Text) != -1) return;
            _ = comboBoxSubject.Items.Add(comboBoxSubject.Text);
            studyContent.AddSubject(comboBoxSubject.Text);
            comboBoxSubject.Text = string.Empty;

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
            if (String.IsNullOrEmpty(comboBoxTopic.Text)) return;
            if (comboBoxTopic.FindStringExact(comboBoxTopic.Text) != -1) return;
            _ = comboBoxTopic.Items.Add(comboBoxTopic.Text);
            studyContent.AddTopic(comboBoxSubject.Text, comboBoxTopic.Text);
            comboBoxTopic.Text = string.Empty;

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
            if (String.IsNullOrEmpty(comboBoxSubTopic.Text)) return;
            if (comboBoxSubTopic.FindStringExact(comboBoxSubTopic.Text) != -1) return;
            _ = comboBoxSubTopic.Items.Add(comboBoxSubTopic.Text);
            studyContent.AddSubTopic(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text);

            if (comboBoxSubTopic.Items.Count > 0)
            {
                comboBoxSubTopic.SelectedIndex = comboBoxSubTopic.Items.Count - 1;
                return;
            }
            labelResult.Text = "Subtopic Added";
        }

        private void ButtonAddQuestion_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (buttonAddQuestion.Text == "Add Question")
            {
                if (String.IsNullOrEmpty(comboBoxQuestion.Text)) return;
                if (studyContent.QuestionExists(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, comboBoxQuestion.Text)) return;
                newQuestion = comboBoxQuestion.Text;
                buttonAddQuestion.Text = "Add Answer";
                labelResult.Text = "Question Added";
                textBoxAnswer.Text = string.Empty;
                buttonEditAnswer.Visible = false;
                buttonEditQuestion.Visible = false;
                comboBoxQuestion.Visible = false;
                textBoxAnswer.Visible = true;
                labelChooseQuestion.Text = "Enter the answer to the question";
            }
            else
            {
                if (String.IsNullOrEmpty(textBoxAnswer.Text))
                {
                    labelResult.Text = "Question answer cannot be left blank.";
                    return;
                }

                if (!string.IsNullOrEmpty(newQuestion))
                    studyContent.AddQAG(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, newQuestion, textBoxAnswer.Text);

                labelResult.Text = "Answer Added";
                buttonAddQuestion.Text = "Add Question";
                textBoxAnswer.Visible = false;
                textBoxAnswer.Text = string.Empty;
                buttonEditAnswer.Visible = true;
                buttonEditQuestion.Visible = true;
                comboBoxQuestion.Visible = true;
                labelChooseQuestion.Text = "Choose Question";
                ResetQuestionComboBox();

                ShowCurrentQuestion();
            }
        }

        private void ButtonDeleteSubject_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (comboBoxSubject.FindStringExact(comboBoxSubject.Text) > 0)
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
            if (comboBoxTopic.FindStringExact(comboBoxTopic.Text) > 0)
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
            studyContent.RemoveQAG(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, comboBoxQuestion.Text);
            ResetQuestionComboBox();
        }

        /// <summary>
        /// This button displays the answer to the current question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowAnswer_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text = studyContent.GetCurrentAnswer(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, comboBoxQuestion.Text);
            textBoxAnswer.Visible = true;
            buttonShowAnswer.Visible = false;
            buttonEditQuestion.Visible = true;
        }

        private void ButtonMarkCorrect_Click(object sender, EventArgs e)
        {
            studyContent.MarkAnswerCorrect(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, comboBoxQuestion.Text);
            labelResult.Text = "Answer Marked Correct";
            if (SkipPassed())
            {
                comboBoxQuestion.Items.Remove(comboBoxQuestion.SelectedItem);
            }
            else if (comboBoxQuestion.SelectedIndex < comboBoxSubject.Items.Count - 1) comboBoxQuestion.SelectedIndex++;
            ShowCurrentQuestion();
            buttonEditQuestion.Visible = true;
        }

        private void ButtonMarkIncorrect_Click(object sender, EventArgs e)
        {
            studyContent.MarkAnswerIncorrect(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, comboBoxQuestion.Text);

            labelResult.Text = "Answer Marked Incorrect";
            if (comboBoxQuestion.SelectedIndex < comboBoxSubject.Items.Count - 1) comboBoxQuestion.SelectedIndex++;
            ShowCurrentQuestion();
            buttonEditQuestion.Visible = true;
        }

        private void ButtonShowWrong_Click(object sender, EventArgs e)
        {
            if (SkipPassed())
            {
                buttonShowWrong.Text = "Show Wrong";
            }
            else
            {
                buttonShowWrong.Text = "Show All";
            }
            ResetQuestionComboBox();
        }

        private void ButtonClearMarks_Click(object sender, EventArgs e)
        {
            studyContent.ClearAllMarks(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text);
            ResetQuestionComboBox();
        }

        private void ButtonEditQuestion_Click(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            if (buttonEditQuestion.Text.Contains("dit"))
            {
                buttonEditQuestion.Text = "Save Question";
            }
            else
            {
                studyContent.UpdateQuestionText(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, comboBoxQuestion.Text, textBoxAnswer.Text);
                buttonEditQuestion.Text = "Edit Question";
                labelResult.Text = "Question text updated";
                textBoxAnswer.Visible = false;
            }
        }

        private void ButtonEditAnswer_Click(object sender, EventArgs e)
        {
            if (buttonEditAnswer.Text.Contains("dit"))
            {
                buttonEditAnswer.Text = "Save Answer";
            }
            else
            {
                studyContent.UpdateAnswerText(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, comboBoxQuestion.Text, textBoxAnswer.Text);
                buttonEditAnswer.Text = "Edit Answer";
                labelResult.Text = "Answer Saved";
            }

        }

        // utility functions
        private void IncrementQuestion()
        {
            if (comboBoxQuestion.SelectedIndex < comboBoxQuestion.Items.Count - 2) comboBoxQuestion.SelectedIndex++;
            buttonShowAnswer.Visible = true;
        }

        private void ResetQuestionComboBox()
        {
            comboBoxQuestion.Items.Clear();
            comboBoxQuestion.Text = string.Empty;
            foreach (string question in studyContent.GetSubTopicQuestions(comboBoxSubject.Text, comboBoxTopic.Text, comboBoxSubTopic.Text, SkipPassed()))
            {
                if ((string.IsNullOrEmpty(question)) || (string.IsNullOrEmpty(question.Trim())) || (comboBoxQuestion.Items.Contains(question))) continue;
                comboBoxQuestion.Items.Add(question);
            }
            if (comboBoxQuestion.Items.Count > 0)
                comboBoxQuestion.SelectedIndex = 0;

            buttonShowAnswer.Visible = true;

        }

        private bool SkipPassed() { return buttonShowWrong.Text == "Show All"; }

        private void ShowCurrentQuestion()
        {
            labelResult.Text = string.Empty;
            textBoxAnswer.Text = string.Empty;
            textBoxAnswer.Visible = false;
            buttonShowAnswer.Visible = true;
        }
    }
}
