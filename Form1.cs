namespace StudyFramework1
{
    public partial class Form1 : Form
    {
        readonly XMLFunctions xMLFunctions = new();
        readonly System.Collections.ObjectModel.Collection<string> items = [];
        readonly Dictionary<string, string> qaPairs = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            items = xMLFunctions.InitializeDoc();
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
        }

        private void ComboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            xMLFunctions.UpdateSelectedSubtopic(comboBoxSubject.SelectedIndex, qaPairs);
            foreach (KeyValuePair<string, string> pair in qaPairs)
            {
                labelQuestion.Text = pair.Key;
                labelAnswer.Text = pair.Value;
                labelAnswer.Visible = false;
                return;
            }
        }

        private void ButtonAddSubject_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSubject.Text)) { return; }
            _ = comboBoxSubject.Items.Add(textBoxSubject.Text);
            xMLFunctions.AddSubject(textBoxSubject.Text);
            textBoxSubject.Text = string.Empty;

            if (comboBoxSubject.Items.Count > 0)
            {
                comboBoxSubject.SelectedIndex = comboBoxSubject.Items.Count - 1;
                return;
            }
        }

        private void ButtonAddTopic_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxTopic.Text)) { return; }
            _ = comboBoxTopic.Items.Add(textBoxTopic.Text);
            xMLFunctions.AddTopic(textBoxTopic.Text);
            textBoxTopic.Text = string.Empty;

            if (comboBoxTopic.Items.Count > 0)
            {
                comboBoxTopic.SelectedIndex = comboBoxTopic.Items.Count - 1;
                return;
            }

        }

        private void ButtonAddSubTopic_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSubTopic.Text)) { return; }
            _ = comboBoxSubTopic.Items.Add(textBoxSubTopic.Text);
            xMLFunctions.AddSubTopic(textBoxSubTopic.Text);
            textBoxSubTopic.Text = string.Empty;

            if (comboBoxSubTopic.Items.Count > 0)
            {
                comboBoxSubTopic.SelectedIndex = comboBoxSubTopic.Items.Count - 1;
                return;
            }

        }

        private void ButtonDeleteSubject_click(object sender, EventArgs e)
        {
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
            if (comboBoxTopic.Items.Count > 0)
            {
                xMLFunctions.RemoveTopic(comboBoxTopic.SelectedIndex);
                comboBoxTopic.Items.Remove(comboBoxTopic.SelectedItem);
                comboBoxTopic.Text = string.Empty;
                comboBoxSubTopic.Items.Clear();
                comboBoxSubTopic.Text = string.Empty;
            }

        }

        private void ButtonDeleteSubTopic_Click(object sender, EventArgs e)
        {
            if (comboBoxSubTopic.Items.Count > 0)
            {
                xMLFunctions.RemoveSubTopic(comboBoxSubTopic.SelectedIndex);
                comboBoxSubTopic.Items.Remove(comboBoxSubTopic.SelectedItem);
                comboBoxSubTopic.Text = string.Empty;
            }

        }

        private void ButtonUpdateXml_Click(object sender, EventArgs e)
        {
            xMLFunctions.UpdateXMLFile();
        }
    }
}
