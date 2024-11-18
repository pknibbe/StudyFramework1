namespace StudyFramework1
{
    public partial class Form1 : Form
    {
        XMLFunctions xMLFunctions = new XMLFunctions();
        System.Collections.ObjectModel.Collection<string> items = new System.Collections.ObjectModel.Collection<string>();




        public Form1()
        {
            InitializeComponent();
            items = xMLFunctions.initializeDoc();
            if (items.Count > 0)
            {
                foreach (string item in items)
                {
                    comboBoxSubject.Items.Add(item);
                }
                comboBoxSubject.SelectedIndex = 0;
            }
        }

        private void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            xMLFunctions.updateSelectedSubject(comboBoxSubject.SelectedIndex);
        }

        private void buttonAddSubject_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)) { return; }
            _ = comboBoxSubject.Items.Add(textBox1.Text);

            if (comboBoxSubject.Items.Count < 2) { comboBoxSubject.SelectedIndex = 0; return; }
        }

        private void buttonDeleteSubject_click(object sender, EventArgs e)
        {
            if (comboBoxSubject.Items.Count > 0)
            {
                comboBoxSubject.Items.Remove(comboBoxSubject.SelectedItem);
                comboBoxSubject.SelectedIndex = 0;
            }
        }
    }
}
