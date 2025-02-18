using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Effects;

/// <summary>This is the variable that a player can influence during an event</summary>
public abstract record GameEventModifier
{
    public required ModifierLevel ModifierLevel { get; init; }
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
            ? PercentageModifiers[(int)ModifierLevel] 
            : PercentageModifiers[6 - (int)ModifierLevel]);
}

public sealed record LifePointsModifier : GameEventModifier
{
    public override int ModifyLifePoints(int lifePointsChange) 
        => (int)(lifePointsChange * lifePointsChange > 0 
            ? PercentageModifiers[(int)ModifierLevel] 
            : PercentageModifiers[6 - (int)ModifierLevel]);
}

public abstract record CareerModifer : GameEventModifier;

public sealed record CareerPromotionModifier : CareerModifer
{
    public override int ModifyCareerLevel() 
    {
        switch (ModifierLevel)
        {
            case ModifierLevel.Terrible: 
                return -1;                                      // Instant demotion
            case ModifierLevel.Bad: 
                return new Random().Next(0, 1) == 0 ? -1 : 0;   // 50% chance of demotion
            case ModifierLevel.Poor:
                return new Random().Next(0, 1) == 0 ? 0 : 1;    // 50% chance of no promotion 
            case ModifierLevel.Neutral:
                return 1;                                       // Base promotion
            case ModifierLevel.Okay:
                return new Random().Next(0, 4) == 0 ? 1 : 2;    // 25% chance of double promotion
            case ModifierLevel.Good:
                return new Random().Next(0, 1) == 0 ? 1 : 2;    // 50% chance of double promotion
            case ModifierLevel.Great:
                return 2;                                       // Instant double promotion
            default:
                throw new Exception("CareerPromotionModifier: Invalid modifier level: " + ModifierLevel);
        }
    }
}

public sealed record CareerDemotionModifier : CareerModifer
{
    public override int ModifyCareerLevel() 
    {
        switch (ModifierLevel)
        {
            case ModifierLevel.Terrible: 
                return -2;                                      // Instant double demotion
            case ModifierLevel.Bad: 
                return new Random().Next(0, 1) == 0 ? -1 : -2;  // 50% chance of double demotion
            case ModifierLevel.Poor:
                return new Random().Next(0, 4) == 0 ? -1 : -2;  // 25% chance of double promotion 
            case ModifierLevel.Neutral:
                return -1;                                      // Base demotion            
            case ModifierLevel.Okay:
                return new Random().Next(0, 4) == 0 ? 0 : 1;    // 25% chance of promotion
            case ModifierLevel.Good:
                return new Random().Next(0, 1) == 0 ? 0 : 1;    // 50% chance of promotion
            case ModifierLevel.Great:
                return 1;                                       // Instant promotion
            default:
                throw new Exception("CareerDemotionModifier: Invalid modifier level: " + ModifierLevel);
        }
    }
}

public sealed record SalaryModifier : GameEventModifier
{
    public override int ModifySalary(int salaryAdjustment) 
        => (int)(salaryAdjustment * salaryAdjustment > 0 
            ? PercentageModifiers[(int)ModifierLevel] 
            : PercentageModifiers[6 - (int)ModifierLevel]);
}