using QLGiaiBDKhoaCNTT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBDKhoaCNTT.DAO
{
    class MembersDAO
    {
        private static MembersDAO instance;

        public static MembersDAO Instance
        {
            get { if (instance == null) instance = new MembersDAO(); return MembersDAO.instance; }
            private set { MembersDAO.instance = value; }
        }

        private MembersDAO() { }

        public List<Members> GetMembersByClassID(string classID)
        {
            List<Members> list = new List<Members>();

            string query = "select * from Members where ClassID =" + classID;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Members member = new Members(item);
                list.Add(member);
            }

            return list;
        }
        public List<Members> GetListMembers()
        {
            List<Members> list = new List<Members>();

            string query = "select * from Members";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Members member = new Members(item);
                list.Add(member);
            }

            return list;
        }

        public bool InsertMember(string memberID, string nameMember, string classID)
        {
            string query = string.Format("INSERT dbo.Members VALUES  ( N'{0}',  N'{1}' ,  N'{2}')", memberID, nameMember ,classID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateMember(string memberID, string nameMember)
        {
            int result;
            string query = string.Format("UPDATE Members SET nameMember = '{0}' WHERE memberID = '{1}'", nameMember, memberID);
            result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMember(string memberID)
        {

            string query = string.Format("Delete Members where memberID = {0}", memberID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
