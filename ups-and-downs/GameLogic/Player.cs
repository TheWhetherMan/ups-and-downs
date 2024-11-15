using UpsAndDowns.GameLogic;

public class Player
{
	public int PlayerNumber { get; private set; }
	public int CashMoney { get; private set; } = 0;
	public int LifePoints { get; private set; } = 0;
	public Enums.SpaceTypes CurrentSpace { get; set; } = Enums.SpaceTypes.Start;
	public Enums.EducationLevels EducationLevel { get; set; } = Enums.EducationLevels.Secondary;
	public List<Asset> Assets { get; set; } = new();
	
	public double ConvertAllAssetsToLifePoints()
	{
		double points = LifePoints;
		points += CashMoney * 0.01;
		points += Assets.Sum(asset => asset.ConvertToLifePoints());
		return points;
	}
}