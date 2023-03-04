using System;

namespace KinderGarden
{
    public partial class Form1 : Form
    {
        DataBase data = new DataBase();
        int indexDelRow;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns.Add("Column1", "Название");
            dataGridView1.Columns.Add("Column2", "Город");
            dataGridView1.Columns.Add("Column3", "Количество детей");

            fillData();
            comboBox1.Items.Add("Москва");
            comboBox1.Items.Add("Санкт-Петербург");

        }
        private void fillData()
        {

            foreach (var i in data.kinderGarden)
            {
                dataGridView1.Rows.Add(i.Name, i.City, i.CountKids);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index == -1 || data.kinderGarden.Count <= index) return;
            List<Kid> kids = data.kinderGarden[index].kids.ToList();

            DatabaseKinds kids1 = new DatabaseKinds(kids, this);
            kids1.Show();
            this.Hide();


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
            int indexRows = dataGridView1.CurrentCell.RowIndex;
            int indexColumn = dataGridView1.CurrentCell.ColumnIndex;
            if (indexRows == -1 || data.kinderGarden.Count <= indexRows) return;


            switch (indexColumn)
            {
                case 0:
                    data.kinderGarden[indexRows].Name = dataGridView1.Rows[indexRows].Cells[indexColumn].Value.ToString();
                    break;
            }



        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            indexDelRow = e.Row.Index;
            if (indexDelRow == -1) return;
            data.kinderGarden.RemoveAt(indexDelRow);
        }



        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("", "");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            OtherData data = new OtherData(this, true);
            data.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OtherData data = new OtherData(this, false);
            data.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            List<Kid> kids= new List<Kid>();
            string name = textBox2.Text;
            string city = textBox3.Text;
            data.kinderGarden.Add(new KinderGarden(kids, new City(city), name));
            button2_Click(sender, e);
        }
    }
}