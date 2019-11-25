using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBDKhoaCNTT.DTO
{
    class Round
    {
        public Round(string roundName, int numberofteam)
        {
            this.RoundName = roundName;
            this.Numberofteam = numberofteam;
        }

        public Round(DataRow row)
        {
            this.RoundName = row["roundName"].ToString();
            this.Numberofteam = (int)row["numberofteam"];
        }

        private string roundName;

        public string RoundName
        {
            get { return roundName; }
            set { roundName = value; }
        }

        private int numberofteam;

        public int Numberofteam
        {
            get { return numberofteam; }
            set { numberofteam = value; }
        }

    }
}
