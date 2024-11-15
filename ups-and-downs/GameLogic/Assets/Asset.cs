namespace UpsAndDowns.GameLogic.Assets;

public abstract class Asset
{
    public Enums.AssetTypes AssetType { get; init; }
    public int YearPurchased { get; init; }
    public int InitialValue { get; init; }

    public abstract double ConvertToLifePoints();
}