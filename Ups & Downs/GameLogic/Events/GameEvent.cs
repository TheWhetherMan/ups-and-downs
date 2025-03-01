using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

/// <summary>A general-purpose event that can alter money, life points, career, and salary</summary>
public record GameEvent
{
    /// <summary>The user-facing description of the event</summary>
    public required string Description { get; init; }
    /// <summary>Increment or decrement the player's cash money by this much</summary>
    public int? CashMoneyChange { get; init; }
    /// <summary>Increment or decrement the player's life points by this much</summary>
    public int? LifePointsChange { get; init; }
    /// <summary>Increment or decrement the player's career status by this much</summary>
    public int? CareerChange { get; init; }
    /// <summary>Increment or decrement the player's salary by this much</summary>
    public int? SalaryChange { get; init; }
    /// <summary>Give the player a ticket for this many (un)lucky stars</summary>
    public int? LuckyStarsChange { get; init; }

    public CashMoneyModifier GetCashMoneyModifier(LuckyStars modLevel) 
        => new() { LuckyStarsFactor = modLevel };

    public LifePointsModifier GetLifePointsModifier(LuckyStars modLevel) 
        => new() { LuckyStarsFactor = modLevel };

    public CareerModifer GetCareerChangeModifier(LuckyStars modLevel)
        => CareerChange > 0 
            ? new CareerPromotionModifier() { LuckyStarsFactor = modLevel }
            : new CareerDemotionModifier() { LuckyStarsFactor = modLevel };

    public SalaryModifier GetSalaryModifier(LuckyStars modLevel)
        => new() { LuckyStarsFactor = modLevel };
}