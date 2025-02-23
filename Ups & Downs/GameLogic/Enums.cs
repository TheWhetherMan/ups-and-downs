namespace UpsAndDowns.GameLogic.Enums;

public enum GameStates
{
    ConfiguringGame,
    WaitingToStart,
    AtHomeScreen,
    LotterySelection,
    LotteryResults,
    PlayerTurn,
    Completed,
}

public enum ModifierLevel
{
    Terrible,
    Bad,
    Poor,
    Neutral,
    Okay,
    Good,
    Great
}

public enum SpaceTypes
{
    Start,
    Blank,
    Event,
    Car,
    House,
    Promotion,
    Education,
    Children,
    Marriage
}

public enum BoardZones
{
    Green,
    Blue,
    Yellow,
    Pink
}

public enum EducationLevels
{
    Secondary,
    College,
    Masters,
    Doctorate
}

public enum AssetTypes
{
    Car,
    House
}

public enum Cars
{
    Basic,
    Luxury,
    Exotic
}

public enum Houses
{
    FixerUpper,
    Starter,
    Luxury,
    Mansion
}

public enum LotteryResults
{
    NoWinner,
    Winner
}
    
public enum EndOfYearEvents
{
    PartyPinata,    // All players roll their dice -- the player with the highest roll gets a bonus
    DarkCurse,      // All players gain demerits
    LuckyBreak,     // All players gain favors
    BackToStart,    // All players roll their dice -- the player with the lowest roll goes back to start
}