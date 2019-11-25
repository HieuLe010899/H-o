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
    public partial class FormMember : Form
    {
        string id = "";
        public FormMember()
        {
            InitializeComponent();
            LoadFormMembers();
        }
        void LoadFormMembers()
        {
            LoadClass();
            DesignDTGV();
            //AddTeamBlinding();
        }
        void DesignDTGV()
        {
            dtgv.Columns["MemberID"].Width = 160;
            dtgv.Columns["NameMember"].Width = 166;
            dtgv.Columns["ClassID"].Width = 150;
            dtgv.Columns["MemberID"].HeaderText = "ID";
            dtgv.Columns["NameMember"].HeaderText = "Name";
            dtgv.Columns["ClassID"].HeaderText = "Class";

        }
        void AddTeamBlinding()
        {
            txbIdMember.DataBindings.Add(new Binding("Text", dtgv.DataSource, "MemberID", true, DataSourceUpdateMode.Never));
            txbNameMember.DataBindings.Add(new Binding("Text", dtgv.DataSource, "NameMember", true, DataSourceUpdateMode.Never));
        }
        void LoadClass()
        {
            List<Class> listClassID = ClassDAO.Instance.GetListClass();
            cbbClass.DataSource = listClassID;
            cbbClass.DisplayMember = "ClassID";
        }
        void LoadListMemberByClass(string ClassID)
        {
            dtgv.DataSource = MembersDAO.Instance.GetMembersByClassID(ClassID);
        }
        private void CbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Class selected = cb.SelectedItem as Class;
            id = selected.ClassID;
            LoadListMemberByClass(id);
            txbIdMember.DataBindings.Clear();
            txbNameMember.DataBindings.Clear();
            AddTeamBlinding();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private event EventHandler insertMember;
        public event EventHandler InsertMember
        {
            add { insertMember += value; }
            remove { insertMember -= value; }
        }

        private event EventHandler deleteMember;
        public event EventHandler DeleteMember
        {
            add { deleteMember += value; }
            remove { deleteMember -= value; }
        }

        private event EventHandler updateMember;
        public event EventHandler UpdateMember
        {
            add { updateMember += value; }
            remove { updateMember -= value; }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string memberID = txbIdMember.Text;
            string memberName = txbNameMember.Text;
            string classID = id;
            if (MembersDAO.Instance.InsertMember(memberID, memberName, classID))
            {
                MessageBox.Show("Success");
                LoadListMemberByClass(id);
                if (insertMember != null)
                    insertMember(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string memberID = txbIdMember.Text;
            if (MembersDAO.Instance.DeleteMember(memberID))
            {
                MessageBox.Show("Success");
                LoadListMemberByClass(id);
                if (deleteMember != null)
                    deleteMember(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string memberID = txbIdMember.Text;
            string memberName = txbNameMember.Text;
            if (MembersDAO.Instance.UpdateMember(memberID,memberName))
            {
                MessageBox.Show("Success");
                LoadListMemberByClass(id);
                if (updateMember != null)
                    updateMember(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
