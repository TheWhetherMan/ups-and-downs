using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Assets;

public class Car : Asset
{
    public Cars CarType { get; set; } = Cars.Economy;

    public const int ECONOMY_CAR_PRICE = 10000;
    public const int LUXURY_CAR_PRICE = 50000;
    public const int EXOTIC_CAR_PRICE = 200000;

    public Car(int yearPurchased)
    {
        AssetType = AssetTypes.Car;
        YearPurchased = yearPurchased;
        switch (CarType)
        {
            case Cars.Economy:
                InitialValue = ECONOMY_CAR_PRICE; break;
            case Cars.Luxury:
                InitialValue = LUXURY_CAR_PRICE; break;
            case Cars.Exotic:
                InitialValue = EXOTIC_CAR_PRICE; break;
        }
    }

    public override double GetSellPrice()
    {
        throw new NotImplementedException();
    }

    public override double ConvertToLifePoints()
    {
        throw new NotImplementedException();
    }
}