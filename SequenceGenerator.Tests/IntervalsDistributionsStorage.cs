using LibiadaCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceGenerator.Tests
{
    public static class IntervalsDistributionsStorage
    {
        public static int[][] Orders => new int[][] {
                new [] { 1,1,1,1 },
                new [] { 1,1,1,2 },
                new [] { 1,1,2,1 },
                new [] { 1,1,2,2 },
                new [] { 1,1,2,3 },
                new [] { 1,2,1,1 },
                new [] { 1,2,1,2 },
                new [] { 1,2,1,3 },
                new [] { 1,2,2,1 },
                new [] { 1,2,2,2 },
                new [] { 1,2,2,3 },
                new [] { 1,2,3,1 },
                new [] { 1,2,3,2 },
                new [] { 1,2,3,3 },
                new [] { 1,2,3,4 }
            };

        public static Dictionary<Link, IntervalsDistribution[]> IntervalsDistributions =>
            new Dictionary<Link, IntervalsDistribution[]>()
            {
                { Link.None, new IntervalsDistribution[]
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {2,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {2,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>()),
                    }
                },
                { Link.Start, new IntervalsDistribution[]
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {3,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {2,3 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {2,2 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {2,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {2,1 },
                            { 3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            { 2,2 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {2,1 },
                            {3,1 },
                            {4,1 }
                        }),
                    }
                },
                { Link.End, new IntervalsDistribution[]
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {2,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            { 2,3 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            { 2,2 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {2,1 },
                            { 3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1},
                            { 2,2 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {3,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {2,1 },
                            {3,1 },
                            {4,1 }
                        }),
                    }
                },
                { Link.Both, new IntervalsDistribution[]
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,5 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {2,2 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 },
                            {3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {2,1 },
                            {3,2 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {2,2 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            { 2,3 },
                            {3,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {2,2 },
                            {3,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {2,2 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,2 },
                            { 3,3 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2},
                            { 2,3 },
                            {3,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,3 },
                            {2,1 },
                            {3,2 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,2 },
                            {3,2 },
                            {4,2 }
                        }),
                    }
                },
                { Link.Cycle, new IntervalsDistribution[]
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,2 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            { 3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,2 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {4,4 }
                        }),
                    }
                },
                { Link.CycleStart, new IntervalsDistribution[]
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,2 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            { 3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,2 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {4,4 }
                        }),
                    }
                },
                { Link.CycleEnd, new IntervalsDistribution[]
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,4 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,2 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {3,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,2 },
                            {2,1 },
                            {4,1 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            { 3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {2,2 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,1 },
                            {3,1 },
                            {4,2 }
                        }),
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {4,4 }
                        }),
                    }
                }
            };
    }
}
