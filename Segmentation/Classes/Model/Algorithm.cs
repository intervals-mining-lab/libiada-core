using System.Collections.Generic;
using Segmentation.Classes.Base;

namespace Segmentation.Classes.Model
{
    public class Algorithm
    {
        protected List<MainOutputData> results = new List<MainOutputData>();
        protected List<Input> inputs = new List<Input>();
        protected Formalism formalismType;


        /// <summary>
        /// Executes segmentation in a separate thread with notifying all observers
        /// </summary>
        public void Run()
        {
            Slot();
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

        public void Add(List<Input> input)
        {
            inputs.AddRange(input);
        }

        /// <summary>
        /// Execute segmentation
        /// </summary>
        public void Slot()
        {
            foreach (Input input in inputs)
            {
                Algorithm algorithm = AlgorithmFactory.Make(input.GetAlgorithm(), input);
                algorithm.Slot();
                List<MainOutputData> res = algorithm.Upload();
                results.Add(res[0]);
                res.RemoveAt(0);
            }
        }

        /// <summary>
        /// Returns characteristics of the chains and its
        /// </summary>
        /// <returns>list of characteristics</returns>
        public List<MainOutputData> Upload()
        {
            return results;
        }
    }
}