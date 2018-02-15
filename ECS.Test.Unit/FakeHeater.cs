namespace ECS.Test.Unit
{
    class FakeHeater : IHeater
    {
        private bool _heaterIsOn;
        private bool _selfTest;

        private bool SelfTest
        {
            get { return _selfTest; }
            set { _selfTest = value; }
        }

        public bool RunSelfTest()
        {
            return _selfTest;
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