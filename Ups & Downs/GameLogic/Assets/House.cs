using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Assets;

public class House : Asset
{
    public Houses HouseType { get; set; } = Houses.Apartment;

    public House(int yearPurchased, int initialValue)
    {
        AssetType = AssetTypes.House;
        YearPurchased = yearPurchased;
        InitialValue = initialValue;
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