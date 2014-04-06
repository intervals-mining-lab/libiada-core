namespace Segmenter.Model
{
    using System.Collections.Generic;

    public class Algorithm
    {
        protected List<MainOutputData> results = new List<MainOutputData>();
        protected List<Input> inputs = new List<Input>();

        public Algorithm(IEnumerable<Input> parameters)
        {
            this.inputs = new List<Input>(parameters);
        }

        public Algorithm(Input input)
        {
            this.inputs.Add(input);
        }

        public Algorithm()
        {
        }

        /// <summary>
        /// Executes segmentation in a separate thread with notifying all observers
        /// </summary>
        public void Run()
        {
            this.Slot();
        } 

        public void Add(IEnumerable<Input> input)
        {
            this.inputs.AddRange(input);
        }

        /// <summary>
        /// Execute segmentation
        /// </summary>
        public void Slot()
        {
            foreach (Input input in this.inputs)
            {
                Algorithm algorithm = AlgorithmFactory.Make(input.Algorithm, input);
                algorithm.Slot();
                List<MainOutputData> res = algorithm.Upload();
                this.results.Add(res[0]);
                res.RemoveAt(0);
            }
        }

        /// <summary>
        /// Returns characteristics of the chains and its
        /// </summary>
        /// <returns>list of characteristics</returns>
        public List<MainOutputData> Upload()
        {
            return this.results;
        }
    }
}