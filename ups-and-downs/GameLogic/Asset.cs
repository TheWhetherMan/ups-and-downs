namespace UpsAndDowns.GameLogic;

public abstract class Asset
{
    public Enums.AssetTypes AssetType { get; init; }
    public int YearPurchased { get; init; }

    public abstract double ConvertToLifePoints();
}