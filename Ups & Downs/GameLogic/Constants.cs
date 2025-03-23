using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.GameLogic.Misc;

namespace UpsAndDowns.GameLogic;

public static class Constants
{
    // Initial
    public static int CASH_MONEY_MARRIED_GIFTS = 5000;
    // Yearly
    public static int LIFE_POINTS_MARRIED_YEARLY_BONUS = 1500;
    public static int LIFE_POINTS_CHILDREN_YEARLY_BONUS = 500;
    public static int LIFE_POINTS_EDUCATION_LEVEL_YEARLY_BONUS = 200;
    public static int LIFE_POINTS_CAREER_LEVEL_YEARLY_BONUS = 100;
    // Final
    public static int LIFE_POINTS_MARRIED_FINAL_BONUS = 1500;
    public static int LIFE_POINTS_CHILDREN_FINAL_BONUS = 1000;
    public static int LIFE_POINTS_EDUCATION_LEVEL_FINAL_BONUS = 200;
    public static int LIFE_POINTS_CAREER_LEVEL_FINAL_BONUS = 100;

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