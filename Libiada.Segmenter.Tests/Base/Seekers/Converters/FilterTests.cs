namespace Libiada.Segmenter.Tests.Base.Seekers.Converters;

using System.Text;

using Segmenter.Base.Seekers.Converters;
using Segmenter.Base.Sequences;

/// <summary>
/// The filter test.
/// </summary>
[TestFixture]
public class FilterTests
{
    /// <summary>
    /// The string 1.
    /// </summary>
    private string str1;

    /// <summary>
    /// The string 2.
    /// </summary>
    private string str2;

    /// <summary>
    /// The list.
    /// </summary>
    private List<string> list;

    /// <summary>
    /// The set up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        str1 = "A";
        str2 = "TA";
        list = ["ABABAB", "ABATAT", "TABABAB", "ABTABAB", "ABABAB", "ABABAB", "ABABAB"];
    }

    /// <summary>
    /// The filterout test.
    /// </summary>
    [Test]
    public void FilteroutTest()
    {
        var chain = new ComplexChain(list);
        var filter = new Filter(chain);
        int hits = filter.FilterOut(str1);

        // TODO: find out why this code is not used
        var sb = new StringBuilder(list.Count);
        foreach (string s in list)
        {
            sb.Append(s);
        }

        string result = filter.GetChain().ToString();
        string buf = chain.ToString();
        Assert.That(buf.Length - result.Length, Is.EqualTo(hits));

        filter = new Filter(chain);
        hits = filter.FilterOut(str2);

        filter.GetChain().ToString();
        chain.ToString();
        Assert.That(hits, Is.EqualTo(3));
    }

    /// <summary>
    /// The replace test.
    /// </summary>
    [Test]
    public void ReplaceTest()
    {
        var chain = new ComplexChain(list);
        var filter = new Filter(chain);
        int hits = filter.Replace(str2, "-");

        var sb = new StringBuilder(list.Count);
        foreach (string s in list)
        {
            sb.Append(s);
        }

        string result = filter.GetChain().ToString();
        string buf = chain.ToString();
        Assert.That(buf.Length - result.Length, Is.EqualTo(hits));
    }
}
