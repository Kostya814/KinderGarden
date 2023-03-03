using System.Data;

namespace KinderGarden
{
    public partial class OtherData : Form
    {
        Form1 f1;
        DataBase data = new DataBase();
        public OtherData(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            var par1 = data.kinderGarden.Select(u => u.kids).ToList();
            dataGridView1.Columns.Add("Column1", "Название");

            var par2 = par1.Select(u => u.Select(u => u.Parent)).ToList();


            dataGridView1.DataSource = data;
            int a = par1.Count;

        }
    }
}
