namespace Segmentator.Model
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using Segmentator.Base.Collectors;
    using Segmentator.Base.Sequencies;
    using Segmentator.Interfaces;

    public class MainOutputData
    {
        private ComplexChain chain;
        private FrequencyDictionary alphabet;
        private Dictionary<String, String> parameters = new Dictionary<String, String>();

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

        public Dictionary<String, String> GetParameters()
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
        public void AddInfo(IIdentifiable what, Double value)
        {
            this.parameters.Add(what.GetName(), value.ToString());
        }
    }
}