using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Test.Unit
{
    class FakeTempSensor:ITempSensor
    {
        public int temp_
        { set;
          get;
        }

        public bool selfTestResult
        {
            set;
            get;
        }

        public int GetTemp()
        {
            return temp_;
        }

        public bool RunSelfTest()
        {
            return selfTestResult;
        }
    }
}
