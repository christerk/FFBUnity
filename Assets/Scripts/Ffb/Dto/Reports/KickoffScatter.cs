﻿namespace Fumbbl.Ffb.Dto.Reports
{
    public class KickoffScatter : Report
    {
        public string reportId;
        public int[] ballCoordinateEnd;
        public string scatterDirection;
        public int rollScatterDirection;
        public int rollScatterDistance;

        public KickoffScatter() : base("kickoffScatter") { }
    }
}
