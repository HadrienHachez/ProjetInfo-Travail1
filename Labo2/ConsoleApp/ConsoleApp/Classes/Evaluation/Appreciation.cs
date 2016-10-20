using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Appreciation : Evaluation
    {
        private string appreciation;

        public override int Note()
        {
            return appreciationToNote(appreciation);
        }

        public void setAppreciation(string word)
        {
            appreciation = word;
        }

        private int appreciationToNote(string apprec) 
        {
            List<String> listApprec = new List<String>() {"N", "C", "B", "TB", "X"};
            List<int> listNote = new List<int>() { 4, 8, 12, 16, 20 };

            if(listApprec.Contains(apprec))
                return listNote[listApprec.FindIndex(x => x == apprec)];
            else
                return -1;
        }

        public Appreciation() : base()
        { }
    }
}
