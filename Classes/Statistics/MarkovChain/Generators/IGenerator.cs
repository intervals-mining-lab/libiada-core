namespace ChainAnalises.Classes.Statistics.MarkovChain.Generators
{
    ///<summary>
    /// Интерфейс для генероторов псевдосулайно величины
    ///</summary>
    public interface IGenerator
    {
        ///<summary>
        /// Переустановить стартовое число.
        ///</summary>
        void Resert();

        ///<summary>
        /// Получить следующие значение псевдослучаной величины.
        ///</summary>
        ///<returns>[0..1] значение</returns>
        double Next();
    }
}