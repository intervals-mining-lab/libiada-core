namespace Segmentator.Model
{
    using System;

    /// <summary>
    /// Contains all input parameters
    /// </summary>
    public class Input
    {
        public double GetPrecision()
        {
            return this.precision;
        }

        public void SetPrecision(double precision)
        {
            this.precision = precision;
        }

        public double GetStep()
        {
            return this.step;
        }

        public void SetStep(double step)
        {
            this.step = step;
        }

        public double GetLeftBound()
        {
            return this.leftBound;
        }

        public void SetLeftBound(double leftBound)
        {
            this.leftBound = leftBound;
        }

        public double GetRightBound()
        {
            return this.rightBound;
        }

        public void SetRightBound(double rightBound)
        {
            this.rightBound = rightBound;
        }

        public int GetBalance()
        {
            return this.balance;
        }

        public void SetBalance(int balance)
        {
            this.balance = balance;
        }

        public int GetWindowlength()
        {
            return this.windowlength;
        }

        public void SetWindowlength(int windowlength)
        {
            this.windowlength = windowlength;
        }

        public int GetWindowdec()
        {
            return this.windowdec;
        }

        public void SetWindowdec(int windowdec)
        {
            this.windowdec = windowdec;
        }

        public String GetChainName()
        {
            return this.chainName;
        }

        public void SetChainName(String chainName)
        {
            this.chainName = chainName;
        }

        public int GetAlgorithm()
        {
            return this.algorithm;
        }

        public void SetAlgorithm(int algorithm)
        {
            this.algorithm = algorithm;
        }

        public int GetThresholdMethod()
        {
            return this.thresholdMethod;
        }

        public void SetThresholdMethod(int thresholdMethod)
        {
            this.thresholdMethod = thresholdMethod;
        }

        public int GetStopCriterion()
        {
            return this.stopCriterion;
        }

        public void SetStopCriterion(int stopCriterion)
        {
            this.stopCriterion = stopCriterion;
        }

        private double precision;
        private double step;
        private double leftBound;
        private double rightBound;
        private int balance;
        private int windowlength;
        private int windowdec;
        private int algorithm;
        private int stopCriterion;
        private int thresholdMethod;
        public int seeker;
        private String chainName;

        public String GetChain()
        {
            return this.chain;
        }

        public void SetChain(String chain)
        {
            this.chain = chain;
        }

        private String chain;
    }
}