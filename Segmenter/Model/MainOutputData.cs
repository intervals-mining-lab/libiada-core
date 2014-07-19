﻿namespace Segmenter.Model
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequences;
    using Segmenter.Interfaces;

    /// <summary>
    /// The main output data.
    /// </summary>
    public class MainOutputData
    {
        /// <summary>
        /// The chain.
        /// </summary>
        private ComplexChain chain;

        /// <summary>
        /// The alphabet.
        /// </summary>
        private FrequencyDictionary alphabet;

        /// <summary>
        /// The parameters.
        /// </summary>
        private Dictionary<string, string> parameters = new Dictionary<string, string>();

        /// <summary>
        /// The get chain.
        /// </summary>
        /// <returns>
        /// The <see cref="Chain"/>.
        /// </returns>
        public Chain GetChain()
        {
            return this.chain;
        }

        /// <summary>
        /// The set chain.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        public void SetChain(ComplexChain chain)
        {
            this.chain = chain;
        }

        /// <summary>
        /// The get frequency dictionary.
        /// </summary>
        /// <returns>
        /// The <see cref="FrequencyDictionary"/>.
        /// </returns>
        public FrequencyDictionary GetFrequencyDictionary()
        {
            return this.alphabet;
        }

        /// <summary>
        /// The set frequency dictionary.
        /// </summary>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        public void SetFrequencyDictionary(FrequencyDictionary alphabet)
        {
            this.alphabet = alphabet;
        }

        /// <summary>
        /// The get parameters.
        /// </summary>
        /// <returns>
        /// The <see cref="Dictionary"/>.
        /// </returns>
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