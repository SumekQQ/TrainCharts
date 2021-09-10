using System;
using System.Windows.Forms;
using TrainChart.Model;

namespace TrainChart
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            checkBoxLine1.Checked = true; 
            checkBoxEn57.Checked = true;
        }

        private void buttonTrainForce_Click(object sender, EventArgs e)
        {
            var selectedTrain = GetSelectedTrainName();

            if (string.IsNullOrEmpty(selectedTrain))
            {
                return;
            }

            var form = new Form3(selectedTrain);
            form.ShowDialog();
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            var form = new Form4(checkBoxLine1.Checked);
            form.ShowDialog();
        }

        private void buttonSpeeds_Click(object sender, EventArgs e)
        {
            var trainType = checkBoxEn57.Checked ? TrainType.EN57 : TrainType.SA133;

            var form = new Form1(checkBoxLine1.Checked, trainType);
            form.ShowDialog();
        }

        private void checkBoxEn57_Click(object sender, EventArgs e)
        {
            checkBoxEn57.Checked = true;
            checkBoxSa133.Checked = false;
        }

        private void checkBoxSa133_Click(object sender, EventArgs e)
        {
            checkBoxEn57.Checked = false;
            checkBoxSa133.Checked = true;
        }

        private string GetSelectedTrainName()
        {
            if (checkBoxEn57.Checked)
            {
                return checkBoxEn57.Text;
            }

            if (checkBoxSa133.Checked)
            {
                return checkBoxSa133.Text;
            }

            return string.Empty;
        }

        private void checkBoxLine1_Click(object sender, EventArgs e)
        {
            checkBoxLine1.Checked = true;
            checkBoxLine2.Checked = false;
        }

        private void checkBoxLine2_Click(object sender, EventArgs e)
        {
            checkBoxLine1.Checked = false;
            checkBoxLine2.Checked = true;
        }
    }
}
