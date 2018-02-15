namespace ECS.Test.Unit
{
    class FakeHeater : IHeater
    {
        private bool _heaterIsOn;

        public bool selfTestResult
        {
            set;
            get;
        }

        public bool RunSelfTest()
        {
            return selfTestResult;
        }

        public void TurnOff()
        {
            _heaterIsOn = false;
        }

        public void TurnOn()
        {
            _heaterIsOn = true;
        }

        public bool IsOn()
        {
            return _heaterIsOn;
        }
    }
}