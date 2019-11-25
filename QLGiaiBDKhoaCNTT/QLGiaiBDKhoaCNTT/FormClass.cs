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
    public partial class FormClass : Form
    {
        BindingSource classList = new BindingSource();
        public FormClass()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            DesignHide();
            dtgv.DataSource = classList;
            LoadListClass();
            DesignDTGV();
            AddClassBinding();
        }
        void LoadListClass()
        {
            classList.DataSource = ClassDAO.Instance.GetListClass();
        }
        void DesignDTGV()
        {
            dtgv.Columns["ClassID"].Width = 154;
            dtgv.Columns["TotalGoals"].Width = 154;
            dtgv.Columns["Scores"].Width = 154;

        }
        void DesignHide()
        {
            labelNewClass.Hide();
            txbNewClass.Hide();
            btnSubmit.Hide();
        }
        void DesignShowEdit()
        {
            labelNewClass.Show();
            txbNewClass.Show();
            btnSubmit.Show();
        }
        void AddClassBinding()
        {
            txbClass.DataBindings.Add(new Binding("Text", dtgv.DataSource, "ClassID", true, DataSourceUpdateMode.Never));

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string classID = txbClass.Text;
            if (ClassDAO.Instance.CheckClass(classID))
            {
                if (ClassDAO.Instance.InsertClass(classID))
                {
                    MessageBox.Show("Success");
                    LoadListClass();
                    if (insertClass != null)
                        insertClass(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            else
            {
                MessageBox.Show("Please check class");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string classID = txbClass.Text;
            if (ClassDAO.Instance.CheckMemberInClass(classID))
            {
                if (classID != "")
                {
                    if (ClassDAO.Instance.CheckClass(classID)==false)
                    {
                        if (ClassDAO.Instance.DeleteClass(classID))
                        {
                            MessageBox.Show("Success");
                            DesignHide();
                            LoadListClass();
                            if (deleteClass != null)
                                deleteClass(this, new EventArgs());
                        }
                        else
                        {
                            MessageBox.Show("Fail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check class");
                    }
                }
                else
                {
                    MessageBox.Show("Null");
                }
            }
            else
            {
                MessageBox.Show("Please check Member in Class");
            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string classID = txbClass.Text;
            if (ClassDAO.Instance.CheckMemberInClass(classID))
            {
                DesignShowEdit();
            }
            else
            {
                MessageBox.Show("Please check Member in Class");
            }
        }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string classID = txbClass.Text;
            string newClassID = txbNewClass.Text;
            if (newClassID != "")
            {
                if (ClassDAO.Instance.CheckClass(newClassID))
                {
                    if (ClassDAO.Instance.UpdateClass(classID, newClassID))
                    {
                        MessageBox.Show("Success");
                        DesignHide();
                        LoadListClass();
                        if (updateClass != null)
                            updateClass(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
                else
                {
                    MessageBox.Show("Please check class");
                }
            }
            else
            {
                MessageBox.Show("Null");
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private event EventHandler insertClass;
        public event EventHandler InsertClass
        {
            add { insertClass += value; }
            remove { insertClass -= value; }
        }

        private event EventHandler deleteClass;
        public event EventHandler DeleteClass
        {
            add { deleteClass += value; }
            remove { deleteClass -= value; }
        }

        private event EventHandler updateClass;
        public event EventHandler UpdateClass
        {
            add { updateClass += value; }
            remove { updateClass -= value; }
        }

    }
}
