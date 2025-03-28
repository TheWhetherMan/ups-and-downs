using UpsAndDowns.GameLogic.Assets;
using UpsAndDowns.GameLogic.Events;
using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.GameLogic.Misc;
using UpsAndDowns.BusinessLogic;
using UpsAndDowns.Hardware;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UpsAndDowns.GameLogic;

public class Player : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private bool _movedThisTurn;
    public bool MovedThisTurn
    {
        get { return _movedThisTurn; }
        set 
        { 
            _movedThisTurn = value; 
            PlayerStatusText = value ? "" : "Waiting";
            OnPropertyChanged(); }
    }

    private string _playerStatusText = "Waiting";
    public string PlayerStatusText
    {
        get { return _playerStatusText; }
        set { _playerStatusText = value; OnPropertyChanged(); }
    }

    // Identification properties
    public string PlayerDisplayName => "Player " + PlayerNumber;
    public int PlayerNumber { get; set; }

    // Core player properties
    public int CashMoney { get; set; } = 0;
    public double LifePoints { get; set; } = 0;

    // Special/auxiliary properties
    public EducationLevels EducationLevel { get; set; } = EducationLevels.Secondary;
    public int CareerLevel { get; set; } = 0;
    public int Salary { get; set; } = 0;
    public int SalaryOffset { get; set; } = 0;
    public bool Married { get; set; } = false;
    public int Children { get; set; } = 0;
    public List<Asset> Assets { get; set; } = new();
    public SpaceTypes CurrentSpace { get; set; } = SpaceTypes.Start;

    public Player(int playerNumber)
    {
        PlayerNumber = playerNumber;
    }

    public void AdvanceYear()
    {
        MovedThisTurn = false;
        CashMoney += Salary + SalaryOffset;

        // Base life points per year
        LifePoints += 100;
        // Life points from marriage
        LifePoints += Married ? Constants.LIFE_POINTS_MARRIED_YEARLY_BONUS : 0;
        // Life points from children
        LifePoints += Children * Constants.LIFE_POINTS_CHILDREN_YEARLY_BONUS;
    }

    public void ApplyGameEvent(GameEvent? eve, LuckyStars luck)
    {
        if (eve is null)
        {
            Logger.Log("Player.ApplyGameEvent: Null event given!");
            return;
        }

        if (eve.CashMoneyChange is int cash)
            CashMoney += eve.GetCashMoneyModifier(luck).ModifyCashMoney(cash);

        if (eve.LifePointsChange is int life)
            LifePoints += eve.GetLifePointsModifier(luck).ModifyLifePoints(life);

        if (eve.CareerChange is not null)
            CareerLevel += eve.GetCareerChangeModifier(luck).ModifyCareerLevel();

        if (eve.SalaryChange is int salary)
            Salary += eve.GetSalaryModifier(luck).ModifySalary(salary);

        if (eve.LuckyStarsChange is int stars)
        {
            TicketSettings ticket = new TicketSettings()
            {
                Quantity = Math.Abs(stars),
                PlayerNumber = PlayerNumber,
                CurrentEvent = eve
            };

            if (stars > 0)
                new PrintLuckyStarTicket().PrintTicket(ticket);
            else if (stars < 0)
                new PrintUnluckyStarTicket().PrintTicket(ticket);
            else
                Logger.Log("Player.ApplyGameEvent: Zero stars given!", eve);
        }

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
            Car newCar = new Car(GameManager.Instance.CurrentYear, carType);
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
            House newHouse = new House(GameManager.Instance.CurrentYear, houseType);
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
        LifePoints += educationChange * Constants.LIFE_POINTS_GRADUATION_BONUS;
        Logger.Log($"{PlayerDisplayName} => GainOrLoseEducation: +(" + educationChange + ") =>" + EducationLevel);
    }

    public void PromoteOrDemoteCareer(int careerChange)
    {
        CareerLevel += careerChange;
        LifePoints += careerChange * Constants.LIFE_POINTS_CAREER_PROMOTION_BONUS;
        Logger.Log($"{PlayerDisplayName} => PromoteOrDemoteCareer: +(" + careerChange + ") =>" + CareerLevel);
    }

    public void CelebrateMarriageOrAnniversary()
    {
        Married = true;
        LifePoints += Constants.LIFE_POINTS_MARRIED_YEARLY_BONUS * 2;
        CashMoney += GameManager.Instance.PlayerCount * Constants.CASH_MONEY_MARRIED_GIFTS_BONUS;
        Logger.Log($"{PlayerDisplayName} => CelebrateMarriageOrAnniversary");
    }

    public void AddChildren(int numberOfChildren)
    {
        Children += numberOfChildren;
        LifePoints += Constants.LIFE_POINTS_CHILDREN_YEARLY_BONUS * 2;
        Logger.Log($"{PlayerDisplayName} => AddChildren: {numberOfChildren} children added!");
    }

    public double ConvertAllAssetsToLifePoints()
    {
        double points = LifePoints;
        points += CashMoney * 0.001;
        points += (int)EducationLevel * Constants.LIFE_POINTS_EDUCATION_LEVEL_FINAL_BONUS;
        points += CareerLevel * Constants.LIFE_POINTS_CAREER_LEVEL_FINAL_BONUS;
        points += Married ? Constants.LIFE_POINTS_MARRIED_FINAL_BONUS : 0;
        points += Children * Constants.LIFE_POINTS_CHILDREN_FINAL_BONUS;
        points += Assets.Sum(asset => asset.ConvertToLifePoints());
        LifePoints = points;
        return points;
    }

    private void CheckCurrentState()
    {
        if (CareerLevel < 0) CareerLevel = 0;
        if (Salary < 0) Salary = 0;
        if (Children < 0) Children = 0;
    }
}