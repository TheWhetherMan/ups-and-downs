using UpsAndDowns.GameLogic.Assets;
using UpsAndDowns.GameLogic.Effects;
using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.GameLogic.Misc;

public class Player
{
    public int PlayerNumber { get; private set; }
    public int CashMoney { get; private set; } = 0;
    public double LifePoints { get; private set; } = 0;
    public EducationLevels EducationLevel { get; private set; } = EducationLevels.Secondary;
    public int CareerLevel { get; private set; } = 0;
    public int Salary { get; private set; } = 0;
    public bool Married { get; private set; } = false;
    public int Children { get; private set; } = 0;
    public List<Asset> Assets { get; private set; } = new();
    public SpaceTypes CurrentSpace { get; set; } = SpaceTypes.Start;
    public CardPosPoint CardPosition { get; set; } = new(0, 0);
    public bool MovedThisTurn { get; set; } = false;

    public Player(int playerNumber)
    {
        PlayerNumber = playerNumber;
    }

    public void AdvanceYear()
    {
        MovedThisTurn = false;
        CashMoney += Salary;
        LifePoints += 100;
    }

    public void ApplyGameEvent(GameEvent eve, ModifierLevel modLevel)
    {
        if (eve.CashMoneyChange is int cash)
            CashMoney += eve.GetCashMoneyModifier(modLevel).ModifyCashMoney(cash);

        if (eve.LifePointsChange is int life)
            LifePoints += eve.GetLifePointsModifier(modLevel).ModifyLifePoints(life);

        if (eve.CareerChange is not null)
            CareerLevel += eve.GetCareerChangeModifier(modLevel).ModifyCareerLevel();

        if (eve.SalaryChange is int salary)
            Salary += eve.GetSalaryModifier(modLevel).ModifySalary(salary);

        CheckCurrentState();
    }
    
    public void AddAsset(Asset asset)
    {
        Assets.Add(asset);
    }

    public double ConvertAllAssetsToLifePoints()
    {
        double points = LifePoints;
        points += CashMoney * 0.001;
        points += CareerLevel * 1000;
        points += Married ? 2000 : 0;
        points += Children * 2000;
        points += Assets.Sum(asset => asset.ConvertToLifePoints());
        LifePoints = points;
        return points;
    }

    private void CheckCurrentState()
    {
        if (LifePoints < 0) LifePoints = 0;
        if (CareerLevel < 0) CareerLevel = 0;
        if (Salary < 0) Salary = 0;
        if (Children < 0) Children = 0;
    }
}