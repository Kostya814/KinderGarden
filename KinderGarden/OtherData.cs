namespace KinderGarden
{
    public partial class OtherData : Form
    {
        Form1 f1;
        DataBase data = new DataBase();
        public OtherData(Form1 f1, bool CityorParents)
        {
            List<Parent> parents = new List<Parent>();
            List<Kid> kids = new List<Kid>();
            InitializeComponent();
            this.f1 = f1;
            if (CityorParents)
            {




                foreach (var u in data.kinderGarden)
                {
                    foreach (Kid kid in u.kids) kids.Add(kid);

                }
                foreach (Kid kid in kids)
                {

                    parents.Add(kid.Parent);

                }
                dataGridView1.DataSource = parents;
            }
            else
            {
                List<City> citys = new List<City>();
                foreach (var u in data.kinderGarden)
                {
                    citys.Add(u.City1);
                }
                dataGridView1.DataSource = citys;
            }








        }
    }
}
