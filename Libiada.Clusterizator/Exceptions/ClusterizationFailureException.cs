using System;

namespace Clusterizator.Exceptions
{
    public class ClusterizationFailureException : ApplicationException
    {
        public ClusterizationFailureException(string message) : base(message)
        {
        }
    }
}
