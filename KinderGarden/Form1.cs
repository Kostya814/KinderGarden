using System.Collections.Generic;
using System.Windows.Forms;

namespace KinderGarden
{
    public partial class Form1 : Form
    {
        DataBase data = new DataBase();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data.Initialize();


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            fillData();
            comboBox1.Items.Add("Москва");
            comboBox1.Items.Add("Санкт-Петербург");

        }
        private void fillData()
        {
            dataGridView1.Columns.Add("Column1", "Название");
            dataGridView1.Columns.Add("Column2", "Город");
            dataGridView1.Columns.Add("Column3", "Количество детей");
            foreach (var i in data.kinderGarden)
            {
                dataGridView1.Rows.Add(i.Name, i.City, i.CountKids);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index == -1) 
            {
                List<Kid> kids = data.kinderGarden[index].kids.ToList();

                DatabaseKinds kids1 = new DatabaseKinds(kids);
                kids1.Show();
                this.Hide();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                var newData = data.kinderGarden.Where(u => u.Name.ToLower().Contains(textBox1.Text.ToLower())).ToList();
                dataGridView1.Rows.Clear();
                foreach (var i in newData)
                {
                    
                    dataGridView1.Rows.Add(i.Name, i.City, i.CountKids);
                }


            }
            else
            {
                dataGridView1.Rows.Clear();
                foreach (var i in data.kinderGarden)
                {
                    dataGridView1.Rows.Add(i.Name, i.City, i.CountKids);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newData = data.kinderGarden.OrderByDescending(u => u.CountKids).ToList();
            dataGridView1.Rows.Clear();
            foreach (var i in newData)
            {
                dataGridView1.Rows.Add(i.Name, i.City, i.CountKids);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
            foreach (var i in data.kinderGarden)
            {
                dataGridView1.Rows.Add(i.Name, i.City, i.CountKids);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    var newData = data.kinderGarden.Where(u => u.City.Contains("Москва")).ToList();
                    dataGridView1.Rows.Clear();
                    foreach (var i in newData)
                    {

                        dataGridView1.Rows.Add(i.Name, i.City, i.CountKids);
                    }
                    break;
                case 1:
                    var newData1 = data.kinderGarden.Where(u => u.City.Contains("Санкт-Петербург")).ToList();
                    dataGridView1.Rows.Clear();
                    foreach (var i in newData1)
                    {

                        dataGridView1.Rows.Add(i.Name, i.City, i.CountKids);
                    }
                    break;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Апчу", "");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}