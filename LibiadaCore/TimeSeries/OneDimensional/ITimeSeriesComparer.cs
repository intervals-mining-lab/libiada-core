using System;
using System.Collections.Generic;

namespace LibiadaCore.TimeSeries
{
    public interface ITimeSeriesComparer
    {
        double GetDistance(double[] firstTimeSerie, double[] secondTimeSerie);
    }
}