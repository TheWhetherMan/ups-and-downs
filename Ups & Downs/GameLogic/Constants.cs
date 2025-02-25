using UpsAndDowns.GameLogic.Misc;

namespace UpsAndDowns.GameLogic;

public static class Constants
{
    public static Dictionary<int, string> LuckyStarDescriptions = new()
    {
        { -3, "Miserable Luck!" },
        { -2, "Terrible Luck!" },
        { -1, "Bad Luck" },
        {  0, "No Luck" },
        {  1, "Some Luck" },
        {  2, "Good Luck!" },
        {  3, "Great Luck!" },
    };
}