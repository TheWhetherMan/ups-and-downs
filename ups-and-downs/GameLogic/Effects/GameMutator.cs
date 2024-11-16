namespace UpsAndDowns.GameLogic.Effects;

/// <summary>
/// Can be introduced at various points during a game, 
/// and will affect different gameplay factors for varying durations (years)
/// </summary>
public abstract class GameMutator
{
    public required int YearAdded { get; init; }
    public required int YearsInEffect { get; init; }
}