using System;
using System.Collections.Generic;

namespace LibiadaCore.TimeSeries
{
    public interface ITimeSeriesComparer
    {
        List<double> GetDistance(double[] firstTimeSerie, double[] secondTimeSerie);
    }
}