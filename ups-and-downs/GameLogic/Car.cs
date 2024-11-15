namespace UpsAndDowns.GameLogic;

public class Car : Asset
{
    public Car(int yearPurchased)
    {
        AssetType = Enums.AssetTypes.Car;
        YearPurchased = yearPurchased;
    }
    
    public override double ConvertToLifePoints()
    {
        throw new NotImplementedException();
    }
}