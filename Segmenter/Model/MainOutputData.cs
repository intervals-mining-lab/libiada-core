namespace Segmenter.Model
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequencies;
    using Segmenter.Interfaces;

    public class MainOutputData
    {
        private ComplexChain chain;
        private FrequencyDictionary alphabet;
        private Dictionary<string, string> parameters = new Dictionary<string, string>();

        public Chain GetChain()
        {
            return this.chain;
        }

        public void SetChain(ComplexChain chain)
        {
            this.chain = chain;
        }

        public FrequencyDictionary GetFrequencyDictionary()
        {
            return this.alphabet;
        }

        public void SetFrequencyDictionary(FrequencyDictionary alphabet)
        {
            this.alphabet = alphabet;
        }

        public Dictionary<string, string> GetParameters()
        {
            return this.parameters;
        }

        /// <summary>
        /// Allows you add an additional information about research
        /// </summary>
        /// <param name="what">parameter name</param>
        /// <param name="value">string value</param>
        public void AddInfo(IIdentifiable what, IIdentifiable value)
        {
            this.parameters.Add(what.GetName(), value.GetName());
        }

        /// <summary>
        /// Allows to add an additional information about research
        /// </summary>
        /// <param name="what">parameter name</param>
        /// <param name="value">digit value</param>
        public void AddInfo(IIdentifiable what, IDefinable value)
        {
            this.parameters.Add(what.GetName(), value.GetValue().ToString());
        }

        /// <summary>
        /// Allows to add an additional information about research
        /// </summary>
        /// <param name="what">parameter name</param>
        /// <param name="value">digit calculated value</param>
        public void AddInfo(IIdentifiable what, double value)
        {
            this.parameters.Add(what.GetName(), value.ToString());
        }
    }
}