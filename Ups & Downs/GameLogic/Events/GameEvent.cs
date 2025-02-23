using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

/// <summary></summary>
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

    public CashMoneyModifier GetCashMoneyModifier(ModifierLevel modLevel) 
        => new() { ModifierLevel = modLevel };

    public LifePointsModifier GetLifePointsModifier(ModifierLevel modLevel) 
        => new() { ModifierLevel = modLevel };

    public CareerModifer GetCareerChangeModifier(ModifierLevel modLevel)
        => CareerChange > 0 
            ? new CareerPromotionModifier() { ModifierLevel = modLevel }
            : new CareerDemotionModifier() { ModifierLevel = modLevel };

    public SalaryModifier GetSalaryModifier(ModifierLevel modLevel)
        => new() { ModifierLevel = modLevel };
}