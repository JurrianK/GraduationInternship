﻿using System.Collections.Generic;

namespace UltimateForwardRateCalculator
{
    public static class Data
    {
        public static IEnumerable<double> CashFlows =>
            new List<double>
                {
                    8857443.96557542,
                    8995163.96810744,
                    9289182.76358561,
                    9610354.87519806,
                    9936776.96917947,
                    10243523.14071360,
                    10524059.17117180,
                    10784898.35007040,
                    11019378.71885260,
                    11222219.12744240,
                    11390332.01252130,
                    11519598.31356060,
                    11614588.39492590,
                    11672080.80366180,
                    11687036.09911410,
                    11667187.25091750,
                    11614105.28379590,
                    11532480.01342380,
                    11425894.63527860,
                    11289066.61432090,
                    11122619.46693970,
                    10926572.50424440,
                    10702137.16320270,
                    10453686.40689830,
                    10184781.46174930,
                    9896221.83549417,
                    9590049.33108114,
                    9267929.29260154,
                    8931844.45543397,
                    8583277.89066898,
                    8221974.58515865,
                    7850515.28103779,
                    7472801.16289312,
                    7091915.86165620,
                    6709405.84034778,
                    6327313.19814172,
                    5947914.32543799,
                    5574099.57942896,
                    5208583.64973313,
                    4853431.01584119,
                    4510337.85900932,
                    4180949.49530387,
                    3866750.73017715,
                    3568565.87985774,
                    3286825.98142265,
                    3021563.41364082,
                    2772469.13504819,
                    2538981.10406752,
                    2320349.78687022,
                    2115769.62917662,
                    1924411.23715281,
                    1745478.42042968,
                    1578236.85140056,
                    1422030.74230775,
                    1276287.05314627,
                    1140509.61648651,
                    1014271.50262274,
                    897206.55404520,
                    789000.62552051,
                    689381.05363299,
                    598104.30877714,
                    514941.97375690,
                    439665.19475443,
                    372029.81788291,
                    311763.11711989,
                    258553.32154643,
                    212043.89127256,
                    171832.84454008,
                    137476.15251242,
                    108494.15587479,
                    84380.58272991,
                    64613.15610934,
                    48664.59083805,
                    36014.75545513,
                    26162.48112235,
                    18636.22546840,
                    13003.73684498,
                    8878.97323848,
                    5926.45141146,
                    3862.96545239,
                    2456.43093193,
                    1522.35686694,
                    918.62857675,
                    539.22356192,
                    307.62805689,
                    170.44232806,
                    91.64653503,
                    47.79896247,
                    24.17708872,
                    11.86066317,
                    5.64581541,
                    2.60986304,
                    1.17306287,
                    0.51346579,
                    0.21924198,
                    0.09147047,
                    0.03734038,
                    0.01492303,
                    0.00583381,
                    0.00222519,
                    0.00082422,
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
                    0
                };

        public static IDictionary<int, double> ShockDecrease =>
            new Dictionary<int, double>
                {
                    { 1, 0.49 },
                    { 2, 0.56 },
                    { 3, 0.61 },
                    { 4, 0.64 },
                    { 5, 0.67 },
                    { 6, 0.70 },
                    { 7, 0.71 },
                    { 8, 0.73 },
                    { 9, 0.74 },
                    { 10, 0.75 },
                    { 11, 0.75 },
                    { 12, 0.75 },
                    { 13, 0.75 },
                    { 14, 0.75 },
                    { 15, 0.75 },
                    { 16, 0.76 },
                    { 17, 0.76 },
                    { 18, 0.76 },
                    { 19, 0.76 },
                    { 20, 0.76 },
                    { 21, 0.76 },
                    { 22, 0.76 },
                    { 23, 0.76 },
                    { 24, 0.76 },
                    { 25, 0.76 },
                    { 26, 0.76 },
                    { 27, 0.76 },
                    { 28, 0.76 },
                    { 29, 0.76 },
                    { 30, 0.76 },
                    { 31, 0.76 },
                    { 32, 0.76 },
                    { 33, 0.76 },
                    { 34, 0.76 },
                    { 35, 0.76 },
                    { 36, 0.76 },
                    { 37, 0.76 },
                    { 38, 0.76 },
                    { 39, 0.76 },
                    { 40, 0.76 },
                    { 41, 0.76 },
                    { 42, 0.76 },
                    { 43, 0.76 },
                    { 44, 0.76 },
                    { 45, 0.76 },
                    { 46, 0.76 },
                    { 47, 0.76 },
                    { 48, 0.76 },
                    { 49, 0.76 },
                    { 50, 0.76 },
                    { 51, 0.76 },
                    { 52, 0.76 },
                    { 53, 0.76 },
                    { 54, 0.76 },
                    { 55, 0.76 },
                    { 56, 0.76 },
                    { 57, 0.76 },
                    { 58, 0.76 },
                    { 59, 0.76 },
                    { 60, 0.76 }
                };

        public static IDictionary<int, double> ShockIncrease =>
            new Dictionary<int, double>
                {
                    { 1, 2.05 },
                    { 2, 1.79 },
                    { 3, 1.65 },
                    { 4, 1.55 },
                    { 5, 1.49 },
                    { 6, 1.44 },
                    { 7, 1.40 },
                    { 8, 1.37 },
                    { 9, 1.35 },
                    { 10, 1.34 },
                    { 11, 1.33 },
                    { 12, 1.33 },
                    { 13, 1.33 },
                    { 14, 1.33 },
                    { 15, 1.33 },
                    { 16, 1.32 },
                    { 17, 1.32 },
                    { 18, 1.32 },
                    { 19, 1.32 },
                    { 20, 1.32 },
                    { 21, 1.32 },
                    { 22, 1.32 },
                    { 23, 1.32 },
                    { 24, 1.32 },
                    { 25, 1.32 },
                    { 26, 1.32 },
                    { 27, 1.32 },
                    { 28, 1.32 },
                    { 29, 1.32 },
                    { 30, 1.32 },
                    { 31, 1.32 },
                    { 32, 1.32 },
                    { 33, 1.32 },
                    { 34, 1.32 },
                    { 35, 1.32 },
                    { 36, 1.32 },
                    { 37, 1.32 },
                    { 38, 1.32 },
                    { 39, 1.32 },
                    { 40, 1.32 },
                    { 41, 1.32 },
                    { 42, 1.32 },
                    { 43, 1.32 },
                    { 44, 1.32 },
                    { 45, 1.32 },
                    { 46, 1.32 },
                    { 47, 1.32 },
                    { 48, 1.32 },
                    { 49, 1.32 },
                    { 50, 1.32 },
                    { 51, 1.32 },
                    { 52, 1.32 },
                    { 53, 1.32 },
                    { 54, 1.32 },
                    { 55, 1.32 },
                    { 56, 1.32 },
                    { 57, 1.32 },
                    { 58, 1.32 },
                    { 59, 1.32 },
                    { 60, 1.32 }
                };

        public static IDictionary<int, double> OriginalYieldCurve =>
            new Dictionary<int, double>
                {
                    { 1, -0.324 },
                    { 2, -0.297 },
                    { 3, -0.241 },
                    { 4, -0.205 },
                    { 5, -0.135 },
                    { 6, -0.078 },
                    { 7, 0.013 },
                    { 8, 0.08 },
                    { 9, 0.139 },
                    { 10, 0.214 },
                    { 11, 0.263 },
                    { 12, 0.304 },
                    { 13, 0.358 },
                    { 14, 0.404 },
                    { 15, 0.444 },
                    { 16, 0.478 },
                    { 17, 0.509 },
                    { 18, 0.536 },
                    { 19, 0.56 },
                    { 20, 0.582 },
                    { 21, 0.591 },
                    { 22, 0.605 },
                    { 23, 0.623 },
                    { 24, 0.644 },
                    { 25, 0.666 },
                    { 26, 0.69 },
                    { 27, 0.716 },
                    { 28, 0.741 },
                    { 29, 0.768 },
                    { 30, 0.794 },
                    { 31, 0.82 },
                    { 32, 0.846 },
                    { 33, 0.872 },
                    { 34, 0.897 },
                    { 35, 0.922 },
                    { 36, 0.947 },
                    { 37, 0.97 },
                    { 38, 0.994 },
                    { 39, 1.016 },
                    { 40, 1.038 },
                    { 41, 1.06 },
                    { 42, 1.081 },
                    { 43, 1.101 },
                    { 44, 1.12 },
                    { 45, 1.139 },
                    { 46, 1.158 },
                    { 47, 1.176 },
                    { 48, 1.193 },
                    { 49, 1.21 },
                    { 50, 1.226 },
                    { 51, 1.242 },
                    { 52, 1.257 },
                    { 53, 1.272 },
                    { 54, 1.286 },
                    { 55, 1.3 },
                    { 56, 1.314 },
                    { 57, 1.327 },
                    { 58, 1.34 },
                    { 59, 1.352 },
                    { 60, 1.364 },
                    { 61, 1.376 },
                    { 62, 1.387 },
                    { 63, 1.398 },
                    { 64, 1.408 },
                    { 65, 1.419 },
                    { 66, 1.429 },
                    { 67, 1.439 },
                    { 68, 1.448 },
                    { 69, 1.457 },
                    { 70, 1.466 },
                    { 71, 1.475 },
                    { 72, 1.484 },
                    { 73, 1.492 },
                    { 74, 1.5 },
                    { 75, 1.508 },
                    { 76, 1.516 },
                    { 77, 1.523 },
                    { 78, 1.531 },
                    { 79, 1.538 },
                    { 80, 1.545 },
                    { 81, 1.552 },
                    { 82, 1.558 },
                    { 83, 1.565 },
                    { 84, 1.571 },
                    { 85, 1.577 },
                    { 86, 1.583 },
                    { 87, 1.589 },
                    { 88, 1.595 },
                    { 89, 1.6 },
                    { 90, 1.606 },
                    { 91, 1.611 },
                    { 92, 1.617 },
                    { 93, 1.622 },
                    { 94, 1.627 },
                    { 95, 1.632 },
                    { 96, 1.637 },
                    { 97, 1.642 },
                    { 98, 1.646 },
                    { 99, 1.651 },
                    { 100, 1.655 }
                };
    }
}