using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBDKhoaCNTT.DTO
{
    class Detail
    {
        public Detail(string roundName, string classA, string classB, int scoreA, int scoreB, DateTime? roundDate, string roundTime)
        {
            this.RoundName = roundName;
            this.ClassA = classA;
            this.ClassB = classB;
            this.ScoreA = scoreA;
            this.ScoreB = scoreB;
            this.RoundDate = roundDate;
            this.RoundTime = roundTime;
        }

        public Detail(DataRow row)
        {
            this.RoundName = row["roundName"].ToString();
            this.ClassA = row["classA"].ToString();
            this.ClassB = row["classB"].ToString();
            this.ScoreA = (int)row["scoreA"];
            this.ScoreB = (int)row["scoreB"];
            this.RoundDate = (DateTime?)row["RoundDate"];
            this.RoundTime = row["roundTime"].ToString();
        }

        private string roundName;

        public string RoundName
        {
            get { return roundName; }
            set { roundName = value; }
        }

        private string classA;

        public string ClassA
        {
            get { return classA; }
            set { classA = value; }
        }

        private string classB;

        public string ClassB
        {
            get { return classB; }
            set { classB = value; }
        }

        private int scoreA;

        public int ScoreA
        {
            get { return scoreA; }
            set { scoreA = value; }
        }

        private int scoreB;

        public int ScoreB
        {
            get { return scoreB; }
            set { scoreB = value; }
        }

        private DateTime? roundDate;

        public DateTime? RoundDate
        {
            get { return roundDate; }
            set { roundDate = value; }
        }

        private string roundTime;

        public string RoundTime
        {
            get { return roundTime; }
            set { roundTime = value; }
        }
    }
}
