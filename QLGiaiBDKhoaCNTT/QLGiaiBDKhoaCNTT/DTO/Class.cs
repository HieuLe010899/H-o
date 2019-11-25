using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBDKhoaCNTT.DTO
{
    class Class
    {
        public Class(string ClassID,int TotalGoals,int Scores)
        {
            this.ClassID = classID;
            this.TotalGoals = totalGoals;
            this.Scores = scores;
        }

        public Class(DataRow row)
        {
            this.ClassID = row["classID"].ToString();
            this.TotalGoals = (int)row["totalGoals"];
            this.Scores = (int)row["scores"];
        }

        private string classID;

        public string ClassID
        {
            get { return classID; }
            set { classID = value; }
        }

        private int totalGoals;

        public int TotalGoals
        {
            get { return totalGoals; }
            set { totalGoals = value; }
        }

        private int scores;

        public int Scores
        {
            get { return scores; }
            set { scores = value; }
        }
    }
}
