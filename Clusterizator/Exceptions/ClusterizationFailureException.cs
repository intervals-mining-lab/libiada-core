namespace Clusterizator.Exceptions
{
    using System;

    public class ClusterizationFailureException : ApplicationException
    {
        public ClusterizationFailureException(string message) : base(message)
        {
        }
    }
}
