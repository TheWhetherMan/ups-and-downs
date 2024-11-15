namespace UpsAndDowns.GameLogic.Assets;

public class House : Asset
{
    public House(int yearPurchased, int initialValue)
    {
        AssetType = Enums.AssetTypes.House;
        YearPurchased = yearPurchased;
        InitialValue = initialValue;
    }

    public override double ConvertToLifePoints()
    {
        throw new NotImplementedException();
    }
}