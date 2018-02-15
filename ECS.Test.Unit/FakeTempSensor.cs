using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Test.Unit
{
    class FakeTempSensor:ITempSensor
    {
        public int GetTemp()
        {
            return 22;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
