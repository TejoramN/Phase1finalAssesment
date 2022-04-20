using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj
{
    internal class Teachers
    {
        private int empid;
        private string empname;
        private int empgrade;
        private string empsection;

        public int Empid
        {

            get { return empid; }
            set { empid = value; }
        }
        public string Empname
        {

            get { return empname; }
            set { empname = value; }
        }
        public int Empgrade
        {

            get { return empgrade; }
            set { empgrade = value; }
        }
        public string Empsection
        {

            get { return empsection; }
            set { empsection = value; }
        }
    }
}

