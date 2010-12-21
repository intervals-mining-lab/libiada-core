using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Calculate;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.Additional
{
    [TestFixture]
    class TestAnswerFactory
    {
        [Test]
        public void TestCreateAnswer()
        {
            Answer result;
            result = AnswerFactory.CreateAnswer(WebServiceType.Alphabet);
            Assert.IsInstanceOf(new AnswerObjects().GetType(),result);
            result = AnswerFactory.CreateAnswer(WebServiceType.Calculate);
            Assert.IsInstanceOf(new AnswerChain().GetType(), result);
            result = AnswerFactory.CreateAnswer(WebServiceType.Clusterization);
            Assert.IsInstanceOf(new AnswerClusterization().GetType(), result);
            result = AnswerFactory.CreateAnswer(WebServiceType.MarkovChain);
            Assert.IsInstanceOf(new AnswerMarkovChain().GetType(), result);
            result = AnswerFactory.CreateAnswer(WebServiceType.PhantomChain);
            Assert.IsInstanceOf(new AnswerPhantomChains().GetType(), result);
            result = AnswerFactory.CreateAnswer(WebServiceType.Segmentation);
            Assert.IsInstanceOf(new AnswerSegmentation().GetType(), result);
        }
    }
}
