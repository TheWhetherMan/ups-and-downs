using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Assets;
using UpsAndDowns.GameLogic.Effects;
using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.GameLogic.Misc;

public class Player
{
    public string PlayerDisplayName => "Player " + PlayerNumber;

    public int PlayerNumber { get; set; }
    public int CashMoney { get; set; } = 0;
    public double LifePoints { get; set; } = 0;
    public EducationLevels EducationLevel { get; set; } = EducationLevels.Secondary;
    public int CareerLevel { get; set; } = 0;
    public int Salary { get; set; } = 0;
    public int SalaryOffset { get; set; } = 0;
    public bool Married { get; set; } = false;
    public int Children { get; set; } = 0;
    public List<Asset> Assets { get; set; } = new();
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
        CashMoney += Salary + SalaryOffset;
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

    public void BuyOrSellCar(Cars carType, bool buying)
    {
        if (buying) 
        {
            Car newCar = new Car(GameManager.Instance.CurrentYear);
            AddAsset(newCar);
            CashMoney -= newCar.InitialValue;
        }
        else 
        {
            foreach (Asset asset in Assets)
            {
                if (asset is Car carAsset && 
                    carAsset.CarType == carType)
                {
                    CashMoney += (int)carAsset.GetSellPrice();
                    Assets.Remove(asset);
                    break;
                }
            }
        }
    }

    public void BuyOrSellHouse(Houses houseType, bool buying)
    {
        if (buying) 
        {
            House newHouse = new House(GameManager.Instance.CurrentYear);
            AddAsset(newHouse);
            CashMoney -= newHouse.InitialValue;
        }
        else 
        {
            foreach (Asset asset in Assets)
            {
                if (asset is House houseAsset && 
                    houseAsset.HouseType == houseType)
                {
                    CashMoney += (int)houseAsset.GetSellPrice();
                    Assets.Remove(asset);
                    break;
                }
            }
        }
    }

    public void GainOrLoseEducation(int educationChange)
    {
        EducationLevel += educationChange;
    }

    public void PromoteOrDemoteCareer(int careerChange)
    {
        CareerLevel += careerChange;
    }

    public double ConvertAllAssetsToLifePoints()
    {
        double points = LifePoints;
        points += CashMoney * 0.001;
        points += CareerLevel * 200;
        points += Married ? 2000 : 0;
        points += Children * 1000;
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