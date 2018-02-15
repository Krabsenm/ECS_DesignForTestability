using System;

namespace ECS
{
    class FakeWindow : IWindow
    {
        public bool IsOpen;

        public bool SelfTestResult
        {
            set;
            get;
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
        }

        public bool RunSelfTest()
        {
            return SelfTestResult;
        }
    }
}