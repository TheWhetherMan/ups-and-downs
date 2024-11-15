using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Assets;
using UpsAndDowns.GameLogic.Enums;

public class Player
{
    public int PlayerNumber { get; private set; }
    public int CashMoney { get; private set; } = 0;
    public double LifePoints { get; private set; } = 0;
    public SpaceTypes CurrentSpace { get; private set; } = SpaceTypes.Start;
    public EducationLevels EducationLevel { get; private set; } = EducationLevels.Secondary;
    public List<Asset> Assets { get; private set; } = new();

    public double ConvertAllAssetsToLifePoints()
    {
        double points = LifePoints;
        points += CashMoney * 0.01;
        points += Assets.Sum(asset => asset.ConvertToLifePoints());
        LifePoints = points;
        return points;
    }
    
    public void AddAsset(Asset asset)
    {
        Assets.Add(asset);
    }
}