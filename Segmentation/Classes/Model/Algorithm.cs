using System;
using System.Collections.Generic;
using Segmentation.Classes.Base;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Model
{
    public class Algorithm : IIdentifiable
    {
        protected List<MainOutputData> results = new List<MainOutputData>();
        protected List<Input> inputs = new List<Input>();
        protected Formalism formalismType;


        /// <summary>
        /// Executes segmentation in a separate thread with notifying all observers
        /// </summary>
        public void run()
        {
            slot();
        }

        public Algorithm(List<Input> parameters)
        {
            inputs = new List<Input>(parameters);
        }

        public Algorithm(Input input)
        {
            inputs.Add(input);
        }

        public Algorithm()
        {
        }

        public void add(List<Input> input)
        {
            inputs.AddRange(input);
        }

        /// <summary>
        /// Execute segmentation
        /// </summary>
        public void slot()
        {
            foreach (Input input in inputs)
            {
                Algorithm algorithm = AlgorithmFactory.make(input.getAlgorithm(), input);
                algorithm.slot();
                List<MainOutputData> res = algorithm.upload();
                results.Add(res[0]);
                res.RemoveAt(0);
            }
        }

        /// <summary>
        /// Returns characteristics of the chains and its
        /// </summary>
        /// <returns>list of characteristics</returns>
        public List<MainOutputData> upload()
        {
            return results;
        }

        public String GetName()
        {
            return formalismType.ToString();
        }
    }
}