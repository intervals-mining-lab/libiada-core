using System;

namespace Segmentation.Classes.Model
{
    /// <summary>
    /// Contains all input parameters
    /// </summary>
    public class Input
    {
        public Input()
        {
        }

        public double getPrecision()
        {
            return precision;
        }

        public void setPrecision(double precision)
        {
            this.precision = precision;
        }

        public double getStep()
        {
            return step;
        }

        public void setStep(double step)
        {
            this.step = step;
        }

        public double getLeftBound()
        {
            return leftBound;
        }

        public void setLeftBound(double leftBound)
        {
            this.leftBound = leftBound;
        }

        public double getRightBound()
        {
            return rightBound;
        }

        public void setRightBound(double rightBound)
        {
            this.rightBound = rightBound;
        }

        public int getBalance()
        {
            return balance;
        }

        public void setBalance(int balance)
        {
            this.balance = balance;
        }

        public int getWindowlength()
        {
            return windowlength;
        }

        public void setWindowlength(int windowlength)
        {
            this.windowlength = windowlength;
        }

        public int getWindowdec()
        {
            return windowdec;
        }

        public void setWindowdec(int windowdec)
        {
            this.windowdec = windowdec;
        }

        public String getChainName()
        {
            return chainName;
        }

        public void setChainName(String chainName)
        {
            this.chainName = chainName;
        }

        public int getAlgorithm()
        {
            return algorithm;
        }

        public void setAlgorithm(int algorithm)
        {
            this.algorithm = algorithm;
        }

        public int getThresholdMethod()
        {
            return thresholdMethod;
        }

        public void setThresholdMethod(int thresholdMethod)
        {
            this.thresholdMethod = thresholdMethod;
        }

        public int getStopCriterion()
        {
            return stopCriterion;
        }

        public void setStopCriterion(int stopCriterion)
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
        private int seeker;
        private String chainName;

        public String getChain()
        {
            return chain;
        }

        public void setChain(String chain)
        {
            this.chain = chain;
        }

        private String chain;


        public int getSeeker()
        {
            return seeker;
        }

        public void setSeeker(int seeker)
        {
            this.seeker = seeker;
        } 
    }
}