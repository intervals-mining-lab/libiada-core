namespace LibiadaCoreTest.Classes.Root.IntervalsManagers
{
    using LibiadaCore.Classes.Root;

    using NUnit.Framework;

    [TestFixture]
    class CongenericIntervalsManagerTest : AbstractIntervalsManagerTest
    {
        [TestCase(0, Link.Start)]
        [TestCase(0, Link.End)]
        [TestCase(0, Link.Both)]
        [TestCase(0, Link.Cycle)]
        [TestCase(0, Link.None)]
        [TestCase(1, Link.Start)]
        [TestCase(1, Link.End)]
        [TestCase(1, Link.Both)]
        [TestCase(1, Link.Cycle)]
        [TestCase(1, Link.None)]
        public void CongenericIntervalsManagerCreationNoneLinkTest(int index, Link link)
        {
            IntervalsManagerTest(index, link);
        }
    }
}
