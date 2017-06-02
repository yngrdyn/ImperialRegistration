using NUnit.Framework;
using Moq;
using Telerik.JustMock;
using Mock = Telerik.JustMock.Mock;
using Data;
using Logic;

namespace ImperialRegister_API_UnitTest
{
    [TestFixture]
    public class Logic
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestRegisterRebel_WithValidResponse()
        {
            var mockData = getMockForRegisterRebel();
            var logic = new RebelRegister(mockData.Object);

            var result = logic.RegisterRebel("Yngrid", "Tatooine");

            mockData.Verify(m => m.registerRebel(It.IsAny<string>(), It.IsAny<string>()), Times.Once());

            Assert.AreEqual(result.Status, true.ToString());

            mockData.Reset();
        }

        [Test]
        public void TestRegisterRebel_WithInvalidResponse()
        {
            var mockData = new Mock<IRebelRegisterData>();
            mockData.Setup(x => x.registerRebel(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var logic = new RebelRegister(mockData.Object);

            var result = logic.RegisterRebel("Yngrid", "Tatooine");

            mockData.Verify(m => m.registerRebel(It.IsAny<string>(), It.IsAny<string>()), Times.Once());

            Assert.AreEqual(result.Status, false.ToString());

            mockData.Reset();
        }

        [Test]
        public void TestRegisterRebel_WithEmptyUsername()
        {
            var mockData = getMockForRegisterRebel();
            var logic = new RebelRegister(mockData.Object);

            var result = logic.RegisterRebel(null, It.IsAny<string>());

            mockData.Verify(m => m.registerRebel(It.IsAny<string>(), It.IsAny<string>()), Times.Never());

            mockData.Reset();
        }

        [Test]
        public void TestRegisterRebel_WithEmptyPlanet()
        {
            var mockData = getMockForRegisterRebel();
            var logic = new RebelRegister(mockData.Object);

            var result = logic.RegisterRebel(It.IsAny<string>(), null);

            mockData.Verify(m => m.registerRebel(It.IsAny<string>(), It.IsAny<string>()), Times.Never());

            mockData.Reset();
        }

        private Mock<IRebelRegisterData> getMockForRegisterRebel()
        {
            var mockData = new Mock<IRebelRegisterData>();

            mockData.Setup(x => x.registerRebel(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
 
            return mockData;
        }

    }
}
