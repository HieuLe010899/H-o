using QLGiaiBDKhoaCNTT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBDKhoaCNTT.DAO
{
    class ClassDAO
    {
        private static ClassDAO instance;

        public static ClassDAO Instance
        {
            get { if (instance == null) instance = new ClassDAO(); return ClassDAO.instance; }
            private set { ClassDAO.instance = value; }
        }

        private ClassDAO() { }

        public List<Class> GetListClass()
        {
            List<Class> list = new List<Class>();

            string query = "select * from class";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Class food = new Class(item);
                list.Add(food);
            }

            return list;
        }
        public bool CheckClass(string classID)
        {
            string query = string.Format("select count(*) from Class where ClassID = N'{0}'", classID);
            int result = (int)DataProvider.Instance.ExecuteScalar(query);

            return result == 0;
        }
        public bool CheckMemberInClass(string classID)
        {
            string query = string.Format("select count(*) from Members where ClassID = N'{0}'", classID);
            int result = (int)DataProvider.Instance.ExecuteScalar(query);

            return result == 0;
        }
        public bool InsertClass(string classID)
        {
            string query = string.Format("INSERT dbo.Class VALUES  ( N'{0}', 0 , 0)", classID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        
        public bool UpdateClass(string classID,string classIDNew)
        {
            int result;
            string query = string.Format("UPDATE Class SET ClassID = '{0}' WHERE ClassID = '{1}'", classIDNew, classID);
            result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateClassR(string classID,int scores,int totalGoals)
        {
            int result;
            string query = string.Format("UPDATE Class SET scores = {0} , totalGoals = {1} WHERE ClassID = '{2}'", scores,totalGoals, classID);
            result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int  getScore(string classID)
        {
            int result;
            string query = string.Format("select scores from class where classID = '{0}'",  classID);
            result = (int)DataProvider.Instance.ExecuteScalar(query);
            return result;
        }
        public int getTotalGoals(string classID)
        {
            int result;
            string query = string.Format("select totalGoals from class where classID = '{0}'", classID);
            result = (int)DataProvider.Instance.ExecuteScalar(query);
            return result;
        }
        public bool DeleteClass(string classID)
        {

            string query = string.Format("Delete Class where ClassID = {0}", classID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
