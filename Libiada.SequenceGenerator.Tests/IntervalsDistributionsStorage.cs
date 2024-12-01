namespace Libiada.SequenceGenerator.Tests;

using Libiada.Core.Core;

public static class IntervalsDistributionsStorage
{
    public static int[][] Orders => [
            [1,1,1,1],
            [1,1,1,2],
            [1,1,2,1],
            [1,1,2,2],
            [1,1,2,3],
            [1,2,1,1],
            [1,2,1,2],
            [1,2,1,3],
            [1,2,2,1],
            [1,2,2,2],
            [1,2,2,3],
            [1,2,3,1],
            [1,2,3,2],
            [1,2,3,3],
            [1,2,3,4]
        ];

    public static Dictionary<Link, IntervalsDistribution[]> IntervalsDistributions =>
        new()
        {
            { Link.None, new IntervalsDistribution[]
                {
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 }
                    }),
                    new IntervalsDistribution().SetDistribution([]),
                }
            },
            { Link.Start, new IntervalsDistribution[]
                {
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 3,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,3 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,2 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 2,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,1 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,2 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,1 },
                        { 3,1 },
                        { 4,1 }
                    }),
                }
            },
            { Link.End, new IntervalsDistribution[]
                {
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 2,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,3 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,2 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,1 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1},
                        { 2,2 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 3,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 2,1 },
                        { 3,1 },
                        { 4,1 }
                    }),
                }
            },
            { Link.Both, new IntervalsDistribution[]
                {
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,5 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,4 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 2,2 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,4 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 2,1 },
                        { 3,2 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 2,2 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,3 },
                        { 3,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 2,2 },
                        { 3,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,4 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 2,2 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,2 },
                        { 3,3 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2},
                        { 2,3 },
                        { 3,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,3 },
                        { 2,1 },
                        { 3,2 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,2 },
                        { 3,2 },
                        { 4,2 }
                    }),
                }
            },
            { Link.Cycle, new IntervalsDistribution[]
                {
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,2 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,2 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 4,4 }
                    }),
                }
            },
            { Link.CycleStart, new IntervalsDistribution[]
                {
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,2 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,2 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 4,4 }
                    }),
                }
            },
            { Link.CycleEnd, new IntervalsDistribution[]
                {
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,4 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,2 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 3,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,2 },
                        { 2,1 },
                        { 4,1 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 2,2 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 1,1 },
                        { 3,1 },
                        { 4,2 }
                    }),
                    new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                        { 4,4 }
                    }),
                }
            }
        };

    public static Dictionary<Link, Dictionary<IntervalsDistribution, List<int[]>>> OrdersIntervalsDistributionsAccordance =>
        new()
        {
            { Link.None, new Dictionary<IntervalsDistribution, List<int[]>>()
                {
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 }
                            }),
                        new List<int[]>(){
                            Orders[0]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 }
                            }),
                        new List<int[]>(){
                            Orders[1],
                            Orders[3],
                            Orders[9]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,1 }
                            }),
                        new List<int[]>(){
                            Orders[2],
                            Orders[5]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 }
                            }),
                        new List<int[]>(){
                            Orders[4],
                            Orders[10],
                            Orders[13]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 2,2 }
                            }),
                        new List<int[]>(){
                            Orders[6]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 2,1 }
                            }),
                        new List<int[]>(){
                            Orders[7],
                            Orders[12]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[8]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[11]
                        }
                    },
                    {
                        new IntervalsDistribution(),
                        new List<int[]>(){
                            Orders[14]
                        }
                    }
                }
            },
            { Link.Start,new Dictionary<IntervalsDistribution, List<int[]>>()
                {
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,4 }
                            }),
                        new List<int[]>(){
                            Orders[0]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[1]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,1 },
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[2],
                            Orders[8],
                            Orders[13]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[3]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 3,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[4]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,2 }
                            }),
                        new List<int[]>(){
                            Orders[5]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,3 }
                            }),
                        new List<int[]>(){
                            Orders[6]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,2 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[7]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 2,1 }
                            }),
                        new List<int[]>(){
                            Orders[9]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[10]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,1 },
                            { 3,2 }
                            }),
                        new List<int[]>(){
                            Orders[11]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,2 },
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[12]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,1 },
                            { 3,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[14]
                        }
                    }
                }
            },
            { Link.End,new Dictionary<IntervalsDistribution, List<int[]>>()
                {
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,4 }
                            }),
                        new List<int[]>(){
                            Orders[0]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 2,1 }
                            }),
                        new List<int[]>(){
                            Orders[1]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,2 }
                            }),
                        new List<int[]>(){
                            Orders[2]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[3]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,1 },
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[4],
                            Orders[5],
                            Orders[8]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,3 }
                            }),
                        new List<int[]>(){
                            Orders[6]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,2 },
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[7]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[9]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[10]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,1 },
                            { 3,2 }
                            }),
                        new List<int[]>(){
                            Orders[11]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,2 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[12]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 3,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[13]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 2,1 },
                            { 3,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[14]
                        }
                    }
                }
            },
            { Link.Both,new Dictionary<IntervalsDistribution, List<int[]>>()
                {
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,5 }
                            }),
                        new List<int[]>(){
                            Orders[0]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,4 },
                            { 2,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[1],
                            Orders[9]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 2,2 },
                            { 3,1 }
                            }),
                        new List<int[]>(){
                            Orders[2],
                            Orders[5],
                            Orders[8]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,4 },
                            { 3,2 }
                            }),
                        new List<int[]>(){
                            Orders[3]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 2,1 },
                            { 3,2 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[4],
                            Orders[13]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,4 }
                            }),
                        new List<int[]>(){
                            Orders[6]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,3 },
                            { 3,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[7],
                            Orders[12]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,3 },
                            { 2,2 },
                            { 4,2 }
                            }),
                        new List<int[]>(){
                            Orders[10]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,2 },
                            { 3,3 }
                            }),
                        new List<int[]>(){
                            Orders[11]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,2 },
                            { 3,2 },
                            { 4,2 }
                            }),
                        new List<int[]>(){
                            Orders[14]
                        }
                    }
                }
            },
            { Link.Cycle, new Dictionary<IntervalsDistribution, List<int[]>>()
                {
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,4 }
                            }),
                        new List<int[]>(){
                            Orders[0]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[1],
                            Orders[2],
                            Orders[5],
                            Orders[9]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 3,2 }
                            }),
                        new List<int[]>(){
                            Orders[3],
                            Orders[8]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 3,1 },
                            { 4,2 }
                            }),
                        new List<int[]>(){
                            Orders[4],
                            Orders[10],
                            Orders[11],
                            Orders[13]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 2,4 }
                            }),
                        new List<int[]>(){
                            Orders[6]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 2,2 },
                            { 4,2 }
                            }),
                        new List<int[]>(){
                            Orders[7],
                            Orders[12]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 4,4 }
                            }),
                        new List<int[]>(){
                            Orders[14]
                        }
                    }
                }
            },
            { Link.CycleStart, new Dictionary<IntervalsDistribution, List<int[]>>()
                {
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            {1,4 }
                            }),
                        new List<int[]>(){
                            Orders[0]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[1],
                            Orders[2],
                            Orders[5],
                            Orders[9]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 3,2 }
                            }),
                        new List<int[]>(){
                            Orders[3],
                            Orders[8]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 3,1 },
                            { 4,2 }
                            }),
                        new List<int[]>(){
                            Orders[4],
                            Orders[10],
                            Orders[11],
                            Orders[13]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 2,4 }
                            }),
                        new List<int[]>(){
                            Orders[6]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 2,2 },
                            { 4,2 }
                            }),
                        new List<int[]>(){
                            Orders[7],
                            Orders[12]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 4,4 }
                            }),
                        new List<int[]>(){
                            Orders[14]
                        }
                    }
                }
            },
            { Link.CycleEnd, new Dictionary<IntervalsDistribution, List<int[]>>()
                {
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,4 }
                            }),
                        new List<int[]>(){
                            Orders[0]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 2,1 },
                            { 4,1 }
                            }),
                        new List<int[]>(){
                            Orders[1],
                            Orders[2],
                            Orders[5],
                            Orders[9]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,2 },
                            { 3,2 }
                            }),
                        new List<int[]>(){
                            Orders[3],
                            Orders[8]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 1,1 },
                            { 3,1 },
                            { 4,2 }
                            }),
                        new List<int[]>(){
                            Orders[4],
                            Orders[10],
                            Orders[11],
                            Orders[13]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 2,4 }
                            }),
                        new List<int[]>(){
                            Orders[6]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 2,2 },
                            { 4,2 }
                            }),
                        new List<int[]>(){
                            Orders[7],
                            Orders[12]
                        }
                    },
                    {
                        new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                            { 4,4 }
                            }),
                        new List<int[]>(){
                            Orders[14]
                        }
                    }
                }
            }
        };
}
