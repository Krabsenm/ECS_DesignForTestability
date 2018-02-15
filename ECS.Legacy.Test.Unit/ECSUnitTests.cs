using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ECS.Legacy.Test.Unit
{
    [TestFixture]
    public class ECSUnitTests
    {
        [Test]
        public void ctor_test()
        {
            var uut = new ECS(1);

            var result = uut.GetThreshold();

            Assert.That(result, Is.EqualTo(1));
        }



    }
}
