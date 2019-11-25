using QLGiaiBDKhoaCNTT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBDKhoaCNTT.DAO
{
    class RoundDAO
    {
        private static RoundDAO instance;

        public static RoundDAO Instance
        {
            get { if (instance == null) instance = new RoundDAO(); return RoundDAO.instance; }
            private set { RoundDAO.instance = value; }
        }

        private RoundDAO() { }

        public List<Round> GetListRound()
        {
            List<Round> list = new List<Round>();

            string query = "select * from roundmatch";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Round round = new Round(item);
                list.Add(round);
            }

            return list;
        }
        public bool InsertRound(string nameRound, int numberofteam)
        {
            string query = string.Format("INSERT dbo.RoundMatch VALUES  ( N'{0}', {1})", nameRound, numberofteam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool checkRound()
        {
            string query = string.Format("select count(*) from roundmatch");
            int result = (int)DataProvider.Instance.ExecuteScalar(query);

            return result > 0;
        }
    }
}
