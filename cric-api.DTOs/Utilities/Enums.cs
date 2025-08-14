using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.DTOs.Utilities
{
    public static class Enums
    {
        public enum PlayerRole
        {
            Batsman,
            Bowler,
            WicketKeeper,
            AllRounder
        }

        public enum SortDirection
        {
            ASC, DESC
        }

        public enum TypeOfMatch
        {
            Test,
            ODI,
            T20,
        }
    }
}