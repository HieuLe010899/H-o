using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBDKhoaCNTT.DTO
{
    class Members
    {

        public Members(string memberID, string nameMember, string classID)
        {
            this.MemberID = memberID;
            this.NameMember = nameMember;
            this.ClassID = classID;
        }

        public Members(DataRow row)
        {
            this.MemberID = row["MemberID"].ToString();
            this.NameMember = row["NameMember"].ToString();
            this.ClassID = row["ClassID"].ToString();
        }


        private string memberID;

        public string MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }
        private string nameMember;

        public string NameMember
        {
            get { return nameMember; }
            set { nameMember = value; }
        }
        private string classID;

        public string ClassID
        {
            get { return classID; }
            set { classID = value; }
        }
    }
}
