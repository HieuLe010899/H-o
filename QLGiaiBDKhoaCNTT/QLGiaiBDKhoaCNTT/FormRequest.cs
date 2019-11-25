using QLGiaiBDKhoaCNTT.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGiaiBDKhoaCNTT
{
    public partial class FormRequest : Form
    {
        public FormRequest()
        {
            InitializeComponent();
        }

        private void btnCreSea_Click(object sender, EventArgs e)
        {
            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Btninfo_Click(object sender, EventArgs e)
        {
            FormMember n = new FormMember();
            this.Hide();
            n.ShowDialog();
            this.Show();
        }

        private void BtnClass_Click(object sender, EventArgs e)
        {
            FormClass f = new FormClass();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void BtnSchedule_Click(object sender, EventArgs e)
        {
            FormSchedule f = new FormSchedule();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void BtnFixandRes_Click(object sender, EventArgs e)
        {
            FormFixtureandResult f = new FormFixtureandResult();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            FormReport f = new FormReport();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
