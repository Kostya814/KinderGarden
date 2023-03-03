using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinderGarden
{
    partial class DatabaseKinds : Form
    {
        public DatabaseKinds(List<Kid> kinds)
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = kinds;


        }

        private void DatabaseKinds_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();

        }
    }
}
