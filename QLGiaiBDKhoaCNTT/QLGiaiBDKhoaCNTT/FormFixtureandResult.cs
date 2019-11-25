using QLGiaiBDKhoaCNTT.DAO;
using QLGiaiBDKhoaCNTT.DTO;
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
    public partial class FormFixtureandResult : Form
    {
        static string id = "";
        public FormFixtureandResult()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            txbClassA.ReadOnly = true;
            txbClassB.ReadOnly = true;
            panelFixture.Hide();
            LoadRound();
            if (RoundDAO.Instance.checkRound())
            {
                checkDetail(id);
            }
            else
            {
                btnEditInfo.Enabled = false;
            }
        }
        void checkDetail(string roundName)
        {
            if (DetailDAO.Instance.checkDetail(roundName))
            {
                btnEditInfo.Enabled = true;
            }
            else
            {
                btnEditInfo.Enabled = false;
            }
        }
        void LoadDetailByRound(string roundName)
        {
            dtgSchedule.DataSource = DetailDAO.Instance.GetDetailByRound(roundName);
            checkDetail(roundName);
        }
        void LoadRound()
        {
            List<Round> listRound = RoundDAO.Instance.GetListRound();
            cbbRound.DataSource = listRound;
            cbbRound.DisplayMember = "roundName";
        }
        private void CbbRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Round selected = cb.SelectedItem as Round;
            id = selected.RoundName;
            LoadDetailByRound(id);
            txbScoreA.DataBindings.Clear();
            txbScoreB.DataBindings.Clear();
            txbClassA.DataBindings.Clear();
            txbClassB.DataBindings.Clear();
            dtp.DataBindings.Clear();
            txbTime.DataBindings.Clear();
            AddTeamBlinding();
        }
        void AddTeamBlinding()
        {
            txbScoreA.DataBindings.Add(new Binding("Text", dtgSchedule.DataSource, "ScoreA", true, DataSourceUpdateMode.Never));
            txbScoreB.DataBindings.Add(new Binding("Text", dtgSchedule.DataSource, "ScoreB", true, DataSourceUpdateMode.Never));
            txbClassA.DataBindings.Add(new Binding("Text", dtgSchedule.DataSource, "classA", true, DataSourceUpdateMode.Never));
            txbClassB.DataBindings.Add(new Binding("Text", dtgSchedule.DataSource, "classB", true, DataSourceUpdateMode.Never));
            dtp.DataBindings.Add(new Binding("Text", dtgSchedule.DataSource, "roundDate", true, DataSourceUpdateMode.Never));
            txbTime.DataBindings.Add(new Binding("Text", dtgSchedule.DataSource, "roundTime", true, DataSourceUpdateMode.Never));
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnEditInfo_Click(object sender, EventArgs e)
        {
            panelFixture.Show();
            int scoreA = Convert.ToInt32(txbScoreA.Text);
            int scoreB = Convert.ToInt32(txbScoreB.Text);
            string classA = txbClassA.Text;
            string classB = txbClassB.Text;
            if (scoreA != 0 && scoreB != 0)
            {
                if (scoreA > scoreB)
                {
                    if (ClassDAO.Instance.UpdateClassR(classA, ClassDAO.Instance.getScore(classA) - 3, ClassDAO.Instance.getTotalGoals(classA) - 1))
                    {
                        ;
                    }
                }
                else if (scoreA < scoreB)
                {
                    if (ClassDAO.Instance.UpdateClassR(classB, ClassDAO.Instance.getScore(classB) - 3, ClassDAO.Instance.getTotalGoals(classB) - 1))
                    {
                        ;
                    }
                }
                else
                {
                    if (ClassDAO.Instance.UpdateClassR(classA, ClassDAO.Instance.getScore(classA) - 1, ClassDAO.Instance.getTotalGoals(classA)))
                    {
                        ;
                    }
                    if (ClassDAO.Instance.UpdateClassR(classB, ClassDAO.Instance.getScore(classB) - 1, ClassDAO.Instance.getTotalGoals(classB)))
                    {
                        ;
                    }
                }
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int scoreA = Convert.ToInt32(txbScoreA.Text);
            int scoreB = Convert.ToInt32(txbScoreB.Text);
            string roundTime = txbTime.Text;
            DateTime roundDate = dtp.Value;
            string classA = txbClassA.Text;
            string classB = txbClassB.Text;
            if (scoreA > scoreB)
            {
                updateDetailF(id, classA, classB, scoreA, scoreB, roundDate, roundTime);
                if (ClassDAO.Instance.UpdateClassR(classA, ClassDAO.Instance.getScore(classA) + 3, ClassDAO.Instance.getTotalGoals(classA) + 1))
                {
                    ;
                }
            }
            else if (scoreA < scoreB)
            {
                updateDetailF(id, classA, classB, scoreA, scoreB, roundDate, roundTime);
                if (ClassDAO.Instance.UpdateClassR(classB, ClassDAO.Instance.getScore(classB) + 3, ClassDAO.Instance.getTotalGoals(classB) + 1))
                {
                    ;
                }
            }
            else
            {
                updateDetailF(id, classA, classB, scoreA, scoreB, roundDate, roundTime);
                if (ClassDAO.Instance.UpdateClassR(classA, ClassDAO.Instance.getScore(classA) + 1, ClassDAO.Instance.getTotalGoals(classA)))
                {
                    ;
                }
                if (ClassDAO.Instance.UpdateClassR(classB, ClassDAO.Instance.getScore(classB) + 1, ClassDAO.Instance.getTotalGoals(classB)))
                {
                    ;
                }
            }
            panelFixture.Hide();
        }
        void updateDetailF(string roundName, string classA, string classB, int scoreA, int scoreB, DateTime roundDate, string roundTime)
        {
            if (DetailDAO.Instance.UpdateDetail(roundName, classA,classB,scoreA,scoreB,roundDate,roundTime))
            {
                MessageBox.Show("Success");
                LoadDetailByRound(id);
                if (updateDetail != null)
                    updateDetail(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
        private event EventHandler updateClass;
        public event EventHandler UpdateClass
        {
            add { updateClass += value; }
            remove { updateClass -= value; }
        }
        private event EventHandler updateDetail;
        public event EventHandler UpdateDetail
        {
            add { updateDetail += value; }
            remove { updateDetail -= value; }
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
