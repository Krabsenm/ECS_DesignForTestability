using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    [TestFixture]
    public class ECSUnitTests
    {
        private ECS UUT;
        private FakeTempSensor tempSensor = new FakeTempSensor();
        private FakeHeater heater = new FakeHeater();
        private FakeWindow window = new FakeWindow();

        [SetUp]
        public void SetUp()
        {
            UUT = new ECS(25, tempSensor, heater, window);
        }

        [Test]
        public void CtorTest_GetThreshold_Returns25()
        {
            Assert.That(UUT.GetThreshold(), Is.EqualTo(25));
        }

        [Test]
        public void RegulateTest_TempUnderThreshold_HeaterIsOn()
        {
            tempSensor.temp_ = 24;
            UUT.Regulate();
            Assert.That(heater.IsOn(), Is.True);
        }

        [Test]
        public void RegulateTest_TempOnThreshold_HeaterIsOff()
        {
            tempSensor.temp_ = 25;
            UUT.Regulate();
            Assert.That(heater.IsOn(), Is.False);
        }

        [Test]
        public void RegulateTest_TempOverThreshold_HeaterIsOff()
        {
            tempSensor.temp_ = 26;
            UUT.Regulate();
            Assert.That(heater.IsOn(), Is.False);
        }

        [Test]
        public void SetGetThresholdTest_ThresholdIs30()
        {
            UUT.SetThreshold(30);

            Assert.That(UUT.GetThreshold(), Is.EqualTo(30));
        }

        [Test]
        public void GetCurTempTest_SetTempTo15_Returns15()
        {
            tempSensor.temp_ = 15;

            Assert.That(UUT.GetCurTemp(), Is.EqualTo(15));
        }

        [TestCase(true, true, true, true)]
        [TestCase(false, true, true, false)]
        [TestCase(true, false, true, false)]
        [TestCase(true, true, false, false)]
        [TestCase(false, false, false, false)]
        public void RunSelfTestTests(bool tempSensorStatus, bool heaterStatus, bool windowStatus, bool expectedValue)
        {
            tempSensor.selfTestResult = tempSensorStatus;
            heater.selfTestResult = heaterStatus;
            window.SelfTestResult = windowStatus;

            var result = UUT.RunSelfTest();

            if (expectedValue == true)
                Assert.That(result, Is.True);
            else
                Assert.That(result, Is.False);
        }

        [Test]
        public void RegulateTest_TempOverThreshold_WindowIsOpen()
        {
            tempSensor.temp_ = 26;
            UUT.Regulate();
            Assert.That(window.IsOpen, Is.True);
        }

        [Test]
        public void RegulateTest_TempOnThreshold_WindowIsClosed()
        {
            tempSensor.temp_ = 25;
            UUT.Regulate();
            Assert.That(window.IsOpen, Is.False);
        }

        [Test]
        public void RegulateTest_TempUnderThreshold_WindowIsClosed()
        {
            tempSensor.temp_ = 24;
            UUT.Regulate();
            Assert.That(window.IsOpen, Is.False);
        }
    }
}
