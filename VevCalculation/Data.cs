﻿using System.Collections.Generic;

namespace VevCalculation
{
    public class Data
    {
        public Data()
        {
            this.CashFlow = new List<double>
                                 {
                                     8857444,
                                     8995164,
                                     9289183,
                                     9610355,
                                     9936777,
                                     10243523,
                                     10524059,
                                     10784898,
                                     11019379,
                                     11222219,
                                     11390332,
                                     11519598,
                                     11614588,
                                     11672081,
                                     11687036,
                                     11667187,
                                     11614105,
                                     11532480,
                                     11425895,
                                     11289067,
                                     11122619,
                                     10926573,
                                     10702137,
                                     10453686,
                                     10184781,
                                     9896222,
                                     9590049,
                                     9267929,
                                     8931844,
                                     8583278,
                                     8221975,
                                     7850515,
                                     7472801,
                                     7091916,
                                     6709406,
                                     6327313,
                                     5947914,
                                     5574100,
                                     5208584,
                                     4853431,
                                     4510338,
                                     4180949,
                                     3866751,
                                     3568566,
                                     3286826,
                                     3021563,
                                     2772469,
                                     2538981,
                                     2320350,
                                     2115770,
                                     1924411,
                                     1745478,
                                     1578237,
                                     1422031,
                                     1276287,
                                     1140510,
                                     1014272,
                                     897207,
                                     789001,
                                     689381,
                                     598104,
                                     514942,
                                     439665,
                                     372030,
                                     311763,
                                     258553,
                                     212044,
                                     171833,
                                     137476,
                                     108494,
                                     84381,
                                     64613,
                                     48665,
                                     36015,
                                     26162,
                                     18636,
                                     13004,
                                     8879,
                                     5926,
                                     3863,
                                     2456,
                                     1522,
                                     919,
                                     539,
                                     308,
                                     170,
                                     92,
                                     48,
                                     24,
                                     12,
                                     6,
                                     3,
                                     1,
                                     1,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                     0,
                                 };

            this.YieldCurve = new List<double>
                                  {
                                      -0.297,
                                      -0.324,
                                      -0.241,
                                      -0.205,
                                      -0.135,
                                      -0.078,
                                      0.013,
                                      0.08,
                                      0.139,
                                      0.214,
                                      0.263,
                                      0.304,
                                      0.358,
                                      0.404,
                                      0.444,
                                      0.478,
                                      0.509,
                                      0.536,
                                      0.56,
                                      0.582,
                                      0.591,
                                      0.605,
                                      0.623,
                                      0.644,
                                      0.666,
                                      0.69,
                                      0.716,
                                      0.741,
                                      0.768,
                                      0.794,
                                      0.82,
                                      0.846,
                                      0.872,
                                      0.897,
                                      0.922,
                                      0.947,
                                      0.97,
                                      0.994,
                                      1.016,
                                      1.038,
                                      1.06,
                                      1.081,
                                      1.101,
                                      1.12,
                                      1.139,
                                      1.158,
                                      1.176,
                                      1.193,
                                      1.21,
                                      1.226,
                                      1.242,
                                      1.257,
                                      1.272,
                                      1.286,
                                      1.3,
                                      1.314,
                                      1.327,
                                      1.34,
                                      1.352,
                                      1.364,
                                      1.376,
                                      1.387,
                                      1.398,
                                      1.408,
                                      1.419,
                                      1.429,
                                      1.439,
                                      1.448,
                                      1.457,
                                      1.466,
                                      1.475,
                                      1.484,
                                      1.492,
                                      1.5,
                                      1.508,
                                      1.516,
                                      1.523,
                                      1.531,
                                      1.538,
                                      1.545,
                                      1.552,
                                      1.558,
                                      1.565,
                                      1.571,
                                      1.577,
                                      1.583,
                                      1.589,
                                      1.595,
                                      1.6,
                                      1.606,
                                      1.611,
                                      1.617,
                                      1.622,
                                      1.627,
                                      1.632,
                                      1.637,
                                      1.642,
                                      1.646,
                                      1.651,
                                      1.655,
                                  };
        }

        public IList<double> CashFlow { get; }

        public IList<double> YieldCurve { get; }
    }
}