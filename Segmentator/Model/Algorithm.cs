namespace Segmentator.Model
{
    using System.Collections.Generic;

    public class Algorithm
    {
        protected List<MainOutputData> Results = new List<MainOutputData>();
        protected List<Input> Inputs = new List<Input>();

        /// <summary>
        /// Executes segmentation in a separate thread with notifying all observers
        /// </summary>
        public void Run()
        {
            this.Slot();
        }

        public Algorithm(IEnumerable<Input> parameters)
        {
            this.Inputs = new List<Input>(parameters);
        }

        public Algorithm(Input input)
        {
            this.Inputs.Add(input);
        }

        public Algorithm()
        {
        }

        public void Add(IEnumerable<Input> input)
        {
            this.Inputs.AddRange(input);
        }

        /// <summary>
        /// Execute segmentation
        /// </summary>
        public void Slot()
        {
            foreach (Input input in this.Inputs)
            {
                Algorithm algorithm = AlgorithmFactory.Make(input.GetAlgorithm(), input);
                algorithm.Slot();
                List<MainOutputData> res = algorithm.Upload();
                this.Results.Add(res[0]);
                res.RemoveAt(0);
            }
        }

        /// <summary>
        /// Returns characteristics of the chains and its
        /// </summary>
        /// <returns>list of characteristics</returns>
        public List<MainOutputData> Upload()
        {
            return this.Results;
        }
    }
}