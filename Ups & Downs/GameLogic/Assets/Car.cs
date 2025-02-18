using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Assets;

public class Car : Asset
{
    public Cars CarType { get; set; } = Cars.Basic;

    public Car(int yearPurchased, int initialValue)
    {
        AssetType = Enums.AssetTypes.Car;
        YearPurchased = yearPurchased;
        InitialValue = initialValue;
    }
    
    public override double ConvertToLifePoints()
    {
        throw new NotImplementedException();
    }
}