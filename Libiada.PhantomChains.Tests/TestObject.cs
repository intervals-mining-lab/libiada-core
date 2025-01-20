namespace Libiada.PhantomChains.Tests;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The object mother p message test.
/// </summary>
public class TestObject
{
    /// <summary>
    /// The p m 1.
    /// </summary>
    private readonly ValuePhantom pm1;

    /// <summary>
    /// The p m 2.
    /// </summary>
    private readonly ValuePhantom pm2;

    /// <summary>
    /// The sequence.
    /// </summary>
    private readonly Sequence sequence;

    /// <summary>
    /// The alpha.
    /// </summary>
    private readonly Alphabet alphabet = [(ValueString)"a", (ValueString)"b", (ValueString)"c"];

    /// <summary>
    /// The sequence 2.
    /// </summary>
    private readonly Sequence secondSequence;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestObject"/> class.
    /// </summary>
    public TestObject()
    {
        pm1 = [alphabet[2], alphabet[1]];
        pm2 = [alphabet[0]];

        sequence = new Sequence([1, 2, 2, 1, 2, 1, 2, 1, 2, 2], [NullValue.Instance(), PhantomMessageBc, PhantomMessageA]);

        secondSequence = new Sequence([alphabet[1], PhantomMessageA, PhantomMessageBc, alphabet[0], PhantomMessageBc]);
    }

    /// <summary>
    /// Gets the phantom message bc.
    /// </summary>
    public ValuePhantom PhantomMessageBc => (ValuePhantom)pm1.Clone();

    /// <summary>
    /// Gets the phantom message a.
    /// </summary>
    public ValuePhantom PhantomMessageA => (ValuePhantom)pm2.Clone();

    /// <summary>
    /// Gets the source sequence.
    /// </summary>
    public Sequence SourceSequence => (Sequence)sequence.Clone();

    /// <summary>
    /// Gets the unnormalized sequence.
    /// </summary>
    public Sequence UnnormalizedSequence => secondSequence;
}
