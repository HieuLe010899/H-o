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
    public partial class FormSchedule : Form
    {
        static string id = "";
        public FormSchedule()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            txbRound.ReadOnly = true;
            txbTeam.ReadOnly = true;
            txbTeamSpeacial.ReadOnly = true;
            btnOK.Hide();
            LoadRound();
            if (RoundDAO.Instance.checkRound())
            {
                DesignDTGV();
            }
            else
            {
                
            }
        }
        void LoadRound()
        {
            List<Round> listRound = RoundDAO.Instance.GetListRound();
            cbbRound.DataSource = listRound;
            cbbRound.DisplayMember = "roundName";
        }
        void DesignDTGV()
        {
            dtgSchedule.Columns["ClassA"].Width = 400;
            dtgSchedule.Columns["ClassB"].Width = 400;
            dtgSchedule.Columns["RoundName"].Visible = false;
            dtgSchedule.Columns["scoreA"].Visible = false;
            dtgSchedule.Columns["scoreB"].Visible = false;
            dtgSchedule.Columns["roundDate"].Visible = false;
            dtgSchedule.Columns["roundTime"].Visible = false;
        }
        void LoadDetailByRound(string roundName)
        {
            dtgSchedule.DataSource = DetailDAO.Instance.GetDetailByRound(roundName);
        }
        private void CbbRound_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Round selected = cb.SelectedItem as Round;
            id = selected.RoundName;
            LoadDetailByRound(id);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            txbRound.ReadOnly = false;
            txbTeam.ReadOnly = false;
            btnOK.Show();
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            string nameround = txbRound.Text;
            int number = Convert.ToInt32(txbTeam.Text);
            if (nameround == "" || txbTeam.Text == null || IsNumber(txbTeam.Text) == false)
            {
                MessageBox.Show("Fail");
            }
            else
            {
                if (RoundDAO.Instance.InsertRound(nameround, number))
                {
                    MessageBox.Show("Success");
                    if (insertRound != null)
                        insertRound(this, new EventArgs());
                    btnOK.Hide();
                    txbRound.Text = "";
                    txbTeam.Text = "";
                    txbRound.ReadOnly = true;
                    txbTeam.ReadOnly = true;
                    LoadRound();
                    DesignDTGV();
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }

        }
        private event EventHandler insertRound;
        public event EventHandler InsertRound
        {
            add { insertRound += value; }
            remove { insertRound -= value; }
        }
        private event EventHandler insertDetail;
        public event EventHandler InsertDetail
        {
            add { insertDetail += value; }
            remove { insertDetail -= value; }
        }
        private void BtnSchedule_Click(object sender, EventArgs e)
        {
            List<string> listClass1 = new List<string>();
            List<string> listClass2 = new List<string>();
            string roundName = id;
            int numberOfTeam;
            string queryGetNOT = string.Format("select numberOfTeam from RoundMatch where roundName = N'{0}'", roundName);
            numberOfTeam = (int)DataProvider.Instance.ExecuteScalar(queryGetNOT);
            string query = string.Format("SELECT TOP({0})* into SORTCLASS FROM class ORDER BY TotalGoals, Scores", numberOfTeam);
            int exe = DataProvider.Instance.ExecuteNonQuery(query);
            if (numberOfTeam < 2)
            {
                MessageBox.Show("Không có team nào ");
                return;
            }
            int numberOfList = 0;
            if (numberOfTeam % 2 == 0)
            {
                numberOfList = numberOfTeam / 2;
                while (listClass1.Count < numberOfList)
                {
                    string query1 = string.Format("SELECT TOP 1 ClassID from SORTCLASS ORDER BY NEWID()");
                    string result1 = (string)DataProvider.Instance.ExecuteScalar(query1);
                    if (listClass1.Contains(result1))
                    {
                        ;
                    }
                    else
                    {
                        listClass1.Add(result1);
                    }

                }
                while (listClass2.Count < numberOfList)
                {
                    string query2 = string.Format("SELECT TOP 1 ClassID from SORTCLASS ORDER BY NEWID()");
                    string result2 = (string)DataProvider.Instance.ExecuteScalar(query2);
                    if (listClass2.Contains(result2))
                    {
                        ;
                    }
                    else
                    {
                        if (listClass1.Contains(result2))
                        {
                            ;
                        }
                        else
                        {
                            listClass2.Add(result2);
                        }
                    }

                }
                string queryDel = string.Format("drop table sortclass");
                int del = DataProvider.Instance.ExecuteNonQuery(queryDel);
                for (int i = 0; i < numberOfList; i++)
                {
                    if (DetailDAO.Instance.InsertDetail(roundName, listClass1[i], listClass2[i]))
                    {
                        if (insertDetail != null)
                            insertDetail(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
                LoadDetailByRound(id);
            }
            else
            {
                numberOfList = (numberOfTeam / 2) +1;
                while (listClass1.Count < numberOfList)
                {
                    string query1 = string.Format("SELECT TOP 1 ClassID from SORTCLASS ORDER BY NEWID()");
                    string result1 = (string)DataProvider.Instance.ExecuteScalar(query1);
                    if (listClass1.Contains(result1))
                    {
                        ;
                    }
                    else
                    {
                        listClass1.Add(result1);
                    }

                }
                while (listClass2.Count < numberOfList - 1)
                {
                    string query2 = string.Format("SELECT TOP 1 ClassID from SORTCLASS ORDER BY NEWID()");
                    string result2 = (string)DataProvider.Instance.ExecuteScalar(query2);
                    if (listClass2.Contains(result2))
                    {
                        ;
                    }
                    else
                    {
                        if (listClass1.Contains(result2))
                        {
                            ;
                        }
                        else
                        {
                            listClass2.Add(result2);
                        }
                    }

                }
                string queryDel = string.Format("drop table sortclass");
                int del = DataProvider.Instance.ExecuteNonQuery(queryDel);
                for (int i = 0; i < numberOfList - 1; i++)
                {
                    if (DetailDAO.Instance.InsertDetail(roundName, listClass1[i], listClass2[i]))
                    {
                        if (insertDetail != null)
                            insertDetail(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
                txbTeamSpeacial.Text = listClass1[numberOfList - 1];
                LoadDetailByRound(id);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
