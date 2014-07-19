namespace Segmenter.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// The algorithm.
    /// </summary>
    public class Algorithm
    {
        /// <summary>
        /// The results.
        /// </summary>
        protected List<MainOutputData> results = new List<MainOutputData>();

        /// <summary>
        /// The inputs.
        /// </summary>
        protected List<Input> inputs = new List<Input>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Algorithm"/> class.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        public Algorithm(IEnumerable<Input> parameters)
        {
            this.inputs = new List<Input>(parameters);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Algorithm"/> class.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        public Algorithm(Input input)
        {
            this.inputs.Add(input);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Algorithm"/> class.
        /// </summary>
        public Algorithm()
        {
        }

        /// <summary>
        /// Executes segmentation in a separate thread with notifying all observers.
        /// </summary>
        public void Run()
        {
            this.Slot();
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
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