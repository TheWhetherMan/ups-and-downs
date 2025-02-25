using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

/// <summary>This is the variable that a player can influence during an event</summary>
public abstract record GameEventModifier
{
    public required LuckyStars LuckyStarsFactor { get; init; }

    public readonly Dictionary<int, double> GainModifiers = new()
    {
        { -3, 0.0 },
        { -2, 0.5 },
        { -1, 0.75 },
        {  0, 1.0 },
        {  1, 1.25 },
        {  2, 1.5 },
        {  3, 2.0 },
    };

    public readonly Dictionary<int, double> LossModifiers = new()
    {
        { -3, 2.0 },
        { -2, 1.5 },
        { -1, 1.25 },
        {  0, 1.0 },
        {  1, 0.75 },
        {  2, 0.5 },
        {  3, 0.0 },
    };

    public virtual int ModifyCashMoney(int cashChange) => 0;
    public virtual int ModifyLifePoints(int lifePointsChange) => 0;
    public virtual int ModifyCareerLevel() => 0;
    public virtual int ModifySalary(int salaryAdjustment) => 0;
}

public sealed record CashMoneyModifier : GameEventModifier
{
    public override int ModifyCashMoney(int cashChange)
    {
        double cash = cashChange;
        cash *= cashChange > 0 
            ? GainModifiers[(int)LuckyStarsFactor] 
            : LossModifiers[(int)LuckyStarsFactor];

        return (int)cash;
    }
}

public sealed record LifePointsModifier : GameEventModifier
{
    public override int ModifyLifePoints(int lifePointsChange)
    {
        double lifePoints = lifePointsChange;
        lifePoints *= lifePointsChange > 0
            ? GainModifiers[(int)LuckyStarsFactor]
            : LossModifiers[(int)LuckyStarsFactor];

        return (int)lifePoints;
    }
}

public abstract record CareerModifer : GameEventModifier;

public sealed record CareerPromotionModifier : CareerModifer
{
    public override int ModifyCareerLevel() 
    {
        switch (LuckyStarsFactor)
        {
            case LuckyStars.Miserable: 
                return -1;                                      // Instant demotion
            case LuckyStars.Terrible: 
                return new Random().Next(0, 1) == 0 ? -1 : 0;   // 50% chance of demotion
            case LuckyStars.Poor:
                return new Random().Next(0, 1) == 0 ? 0 : 1;    // 50% chance of no promotion 
            case LuckyStars.Neutral:
                return 1;                                       // Base promotion
            case LuckyStars.Okay:
                return new Random().Next(0, 4) == 0 ? 1 : 2;    // 25% chance of double promotion
            case LuckyStars.Good:
                return new Random().Next(0, 1) == 0 ? 1 : 2;    // 50% chance of double promotion
            case LuckyStars.Great:
                return 2;                                       // Instant double promotion
            default:
                throw new Exception("CareerPromotionModifier: Invalid modifier level: " + LuckyStarsFactor);
        }
    }
}

public sealed record CareerDemotionModifier : CareerModifer
{
    public override int ModifyCareerLevel() 
    {
        switch (LuckyStarsFactor)
        {
            case LuckyStars.Miserable: 
                return -2;                                      // Instant double demotion
            case LuckyStars.Terrible: 
                return new Random().Next(0, 1) == 0 ? -1 : -2;  // 50% chance of double demotion
            case LuckyStars.Poor:
                return new Random().Next(0, 4) == 0 ? -1 : -2;  // 25% chance of double demotion 
            case LuckyStars.Neutral:
                return -1;                                      // Base demotion            
            case LuckyStars.Okay:
                return new Random().Next(0, 4) == 0 ? 0 : -1;   // 25% chance of avoiding demotion
            case LuckyStars.Good:
                return new Random().Next(0, 1) == 0 ? 0 : -1;   // 50% chance of avoiding demotion
            case LuckyStars.Great:
                return 1;                                       // Instant promotion
            default:
                throw new Exception("CareerDemotionModifier: Invalid modifier level: " + LuckyStarsFactor);
        }
    }
}

public sealed record SalaryModifier : GameEventModifier
{
    public override int ModifySalary(int salaryAdjustment)
    {
        double salaryChange = salaryAdjustment;
        salaryChange *= salaryAdjustment > 0
            ? GainModifiers[(int)LuckyStarsFactor]
            : LossModifiers[(int)LuckyStarsFactor];

        return (int)salaryChange;
    }
}