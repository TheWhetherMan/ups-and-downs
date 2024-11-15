namespace UpsAndDowns.GameLogic;

public class House : Asset
{
    public House(int yearPurchased)
    {
        AssetType = Enums.AssetTypes.House;
        YearPurchased = yearPurchased;
    }

    public override double ConvertToLifePoints()
    {
        throw new NotImplementedException();
    }
}