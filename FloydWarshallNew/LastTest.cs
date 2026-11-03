using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydWarshallNew
{
    internal class LastTest
    {
        public int size { get; set; }
        public double timeTaken { get; set; }

    
        public LastTest()
        {
            size = 0;
            timeTaken = 0.0;
        }

        public LastTest(int size, double timeTaken)
        {
            this.size = size;
            this.timeTaken = timeTaken;
        }


    }
}
