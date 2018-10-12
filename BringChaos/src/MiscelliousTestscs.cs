using NUnit.Framework;

namespace BringChaos.src
{
    [TestFixture]
    public class MiscelliousTestscs
    {
        [Test]
        public void Should_Create_PointsTo()
        {
            Assert.DoesNotThrow(() => new PointsTo);   
        }
    }
}
