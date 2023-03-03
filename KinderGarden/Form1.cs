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
            dataGridView1.DataSource = data.kinderGarden;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            comboBox1.Items.Add("Москва");
            comboBox1.Items.Add("Санкт-Петербург");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            List<Kid> kids = data.kinderGarden[index].kids.ToList();
            DatabaseKinds kids1 = new DatabaseKinds(kids);
            kids1.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                dataGridView1.DataSource = data.kinderGarden.Where(u => u.Name.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            }
            else dataGridView1.DataSource = data.kinderGarden;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data.kinderGarden.OrderByDescending(u => u.CountKids).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.DataSource = data.kinderGarden;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = data.kinderGarden.Where(u => u.City.Contains("Москва")).ToList();
                    break;
                case 1:
                    dataGridView1.DataSource = data.kinderGarden.Where(u => u.City.Contains("Санкт-Петербург")).ToList();
                    break;
            }
        }
    }
}