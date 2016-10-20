using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Cote : Evaluation
    {
        private int note;

        public override int Note()
        {
            return note;
        }

        public void SetNote(int cote)
        {
            note = cote;
        }

        public Cote() : base()
        { }
    }
}
