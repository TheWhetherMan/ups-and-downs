using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

/// <summary>This is the variable that a player can influence during an event</summary>
public abstract record GameEventModifier
{
    public required LuckyStars LuckyStarsFactor { get; init; }
    public readonly double[] PercentageModifiers = { 0.00, 0.50, 0.75, 1.00, 1.25, 1.50, 2.00 };

    public virtual int ModifyCashMoney(int cashChange) => 0;
    public virtual int ModifyLifePoints(int lifePointsChange) => 0;
    public virtual int ModifyCareerLevel() => 0;
    public virtual int ModifySalary(int salaryAdjustment) => 0;
}

public sealed record CashMoneyModifier : GameEventModifier
{
    public override int ModifyCashMoney(int cashChange) 
        => (int)(cashChange * cashChange > 0 
            ? PercentageModifiers[(int)LuckyStarsFactor] 
            : PercentageModifiers[6 - (int)LuckyStarsFactor]);
}

public sealed record LifePointsModifier : GameEventModifier
{
    public override int ModifyLifePoints(int lifePointsChange) 
        => (int)(lifePointsChange * lifePointsChange > 0 
            ? PercentageModifiers[(int)LuckyStarsFactor] 
            : PercentageModifiers[6 - (int)LuckyStarsFactor]);
}

public abstract record CareerModifer : GameEventModifier;

public sealed record CareerPromotionModifier : CareerModifer
{
    public override int ModifyCareerLevel() 
    {
        switch (LuckyStarsFactor)
        {
            case LuckyStars.Terrible: 
                return -1;                                      // Instant demotion
            case LuckyStars.Bad: 
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
            case LuckyStars.Terrible: 
                return -2;                                      // Instant double demotion
            case LuckyStars.Bad: 
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
        => (int)(salaryAdjustment * salaryAdjustment > 0 
            ? PercentageModifiers[(int)LuckyStarsFactor] 
            : PercentageModifiers[6 - (int)LuckyStarsFactor]);
}