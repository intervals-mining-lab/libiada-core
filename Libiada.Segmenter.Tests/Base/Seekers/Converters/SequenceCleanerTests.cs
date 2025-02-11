﻿namespace Libiada.Segmenter.Tests.Base.Seekers.Converters;

using Segmenter.Base.Seekers.Converters;
using Segmenter.Base.Sequences;

/// <summary>
/// The filter sequence test.
/// </summary>
[TestFixture]
public class SequenceCleanerTests
{
    /// <summary>
    /// The filterout test.
    /// </summary>
    [Test]
    public void FilteroutTest()
    {
        // TODO: refactor this to use testcase
        List<string> list1 =
            [
                "ABABAB",
                "ABATAT",
                "TABABAB",
                "ABTABAB",
                "ABABAB",
                "ABABAB",
                "ABABAB"
            ];
        List<string> listSequence1 = ["ABATAT", "TABABAB"];
        List<string> listSequence2 = ["ABABAB", "ABABAB"];
        List<string> listSequence3 = ["ABABAB"];
        List<string> result1 = ["ABABAB", "ABTABAB", "ABABAB", "ABABAB", "ABABAB"];
        List<string> result2 = ["ABABAB", "ABATAT", "TABABAB", "ABTABAB", "ABABAB"];
        List<string> result3 = ["ABATAT", "TABABAB", "ABTABAB"];

        SequenceCleaner firstCleaner = new(new ComplexSequence(list1));
        SequenceCleaner secondCleaner = new(new ComplexSequence(list1));
        SequenceCleaner thirdCleaner = new(new ComplexSequence(list1));

        firstCleaner.FilterOut(listSequence1);
        secondCleaner.FilterOut(listSequence2);
        thirdCleaner.FilterOut(listSequence3);

        Assert.Multiple(() =>
        {
            Assert.That(new ComplexSequence(result1), Is.EqualTo(firstCleaner.GetSequence()));
            Assert.That(new ComplexSequence(result2), Is.EqualTo(secondCleaner.GetSequence()));
            Assert.That(new ComplexSequence(result3), Is.EqualTo(thirdCleaner.GetSequence()));
        });
    }
}
