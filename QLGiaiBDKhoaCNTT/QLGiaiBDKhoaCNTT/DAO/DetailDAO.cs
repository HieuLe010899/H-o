using QLGiaiBDKhoaCNTT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBDKhoaCNTT.DAO
{
    class DetailDAO
    {
        private static DetailDAO instance;

        public static DetailDAO Instance
        {
            get { if (instance == null) instance = new DetailDAO(); return DetailDAO.instance; }
            private set { DetailDAO.instance = value; }
        }

        private DetailDAO() { }

        public List<Detail> GetDetailByRound(string roundName)
        {
            List<Detail> list = new List<Detail>();

            string query = "select * from Detail where roundName = N'" + roundName +"'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Detail detail = new Detail(item);
                list.Add(detail);
            }

            return list;
        }
        public bool InsertDetail(string roundName, string classA, string classB)
        {
            string query = string.Format("INSERT dbo.detail VALUES  (N'{0}','{1}','{2}',0,0,getdate(),'')", roundName, classA, classB);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateDetail(string roundName, string classA, string classB,int scoreA , int scoreB , DateTime roundDate , string roundTime)
        {
            string query = string.Format("update dbo.detail SET scoreA = {3} , scoreB = {4},roundDate = '{5}',roundTime = '{6}' WHERE roundName = N'{0}' and classA = '{1}' and classB = '{2}'", roundName, classA, classB, scoreA, scoreB, roundDate, roundTime);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool checkDetail(string roundName)
        {
            string query = string.Format("select count(*) from Detail where roundName = N'{0}'",roundName);
            int result = (int)DataProvider.Instance.ExecuteScalar(query);

            return result > 0;
        }
    }
}
