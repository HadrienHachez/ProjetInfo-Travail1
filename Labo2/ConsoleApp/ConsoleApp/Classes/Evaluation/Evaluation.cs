using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Evaluation
    {
        public virtual int Note()
        {
            return 0;
        }

        public Evaluation()
        { }

        public override string ToString()
        {
            return string.Format("{0}", Note());
        }
    }
}
