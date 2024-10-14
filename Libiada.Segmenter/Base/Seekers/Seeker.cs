namespace Libiada.Segmenter.Base.Seekers;

using Interfaces;

/// <summary>
/// Searching for occurrences of a sequence
/// </summary>
public class Seeker : Interfaces.Seeker
{
    /// <summary>
    /// The result.
    /// </summary>
    protected List<int> result;

    /// <summary>
    /// The iterator.
    /// </summary>
    protected IIterator iterator;

    /// <summary>
    /// The first.
    /// </summary>
    private int first = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Seeker"/> class.
    /// </summary>
    /// <param name="where">
    /// The where.
    /// </param>
    public Seeker(IIterator where)
    {
        iterator = where;
    }

    /// <summary>
    /// Gets the arrangement.
    /// </summary>
    public List<int> Arrangement
    {
        get { return new List<int>(result); }
    }

    /// <summary>
    /// The seek.
    /// </summary>
    /// <param name="required">
    /// The required.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int Seek(List<string> required)
    {
        result = [];
        while (iterator.HasNext())
        {
            List<string> sequence = iterator.Next();
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i].Equals(required[first]))
                {
                    result.Add(i);
                }
            }
        }

        iterator.Reset();
        return result.Count;
    }

    /// <summary>
    /// The custom iterator.
    /// </summary>
    /// <param name="iterator">
    /// The iterator.
    /// </param>
    public void CustomIterator(IIterator iterator)
    {
        this.iterator = iterator;
    }
}
