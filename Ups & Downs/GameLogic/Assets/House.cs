using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Assets;

public class House : Asset
{
    public Houses HouseType { get; set; } = Houses.FixerUpper;

    public const int FIXER_UPPER_HOME_PRICE = 100000;
    public const int STARTER_HOME_PRICE = 250000;
    public const int LUXURY_HOME_PRICE = 500000;
    public const int MANSION_HOME_PRICE = 1000000;

    public House(int yearPurchased)
    {
        AssetType = AssetTypes.House;
        YearPurchased = yearPurchased;
        switch (HouseType)
        {
            case Houses.FixerUpper:
                InitialValue = FIXER_UPPER_HOME_PRICE; break;
            case Houses.Starter:
                InitialValue = STARTER_HOME_PRICE; break;
            case Houses.Luxury:
                InitialValue = LUXURY_HOME_PRICE; break;
            case Houses.Mansion:
                InitialValue = MANSION_HOME_PRICE; break;
        }
    }

    public override double GetSellPrice()
    {
        double sellPrice = InitialValue;
        sellPrice += YearsOwned * (0.04 * InitialValue);
        return sellPrice;
    }

    public override double ConvertToLifePoints()
    {
        return InitialValue * YearsOwned * 0.0005;
    }
}