namespace Libiada.Segmenter.PoemsSegmenter;

public class PartialOrlovCriterion
{
    private Dictionary<string, int> consonancesDictionary;
    private string text;

    public PartialOrlovCriterion(Dictionary<string, int> consonancesDictionary, string text)
    {
        this.consonancesDictionary = consonancesDictionary;
        this.text = text;
    }

    public double TheoreticalDictionaryVolume()
    {
        double K = CalculateK();
        double B = CalculateB(K);
        double Z = calculateZ();
        Console.WriteLine("Z: " + Z);
        return K * Z - B;
    }

    public double CalculateP1()
    {
        double maxEntriesNumber = consonancesDictionary.Values.Max(); // максимальное количество вхождений
        Console.WriteLine("F1: " + maxEntriesNumber);
        double sumEntries = consonancesDictionary.Sum(v => v.Value); // сумма всех вхождений
        return maxEntriesNumber / sumEntries;
    }

    public double CalculateK()
    {
        double maxEntriesNumber = consonancesDictionary.Values.Max();
        double Z = calculateZ();
        string textWithoutSpaces = text.Replace(" ", "");
        return 1 / Math.Log(maxEntriesNumber);
    }

    public double CalculateB(double K)
    {
        double frequenceMaxEntriesNumber = CalculateP1();
        Console.WriteLine("P1: " + frequenceMaxEntriesNumber);
        return (K / frequenceMaxEntriesNumber) - 1;

    }

    public double calculateZ()
    {
        return consonancesDictionary.Sum(v => v.Value); // сумма всех вхождений
    }
}
