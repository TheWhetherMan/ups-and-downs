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
    EndOfYear,
}

public enum LuckyStars
{
    Miserable = -3,
    Terrible      = -2,
    Poor     = -1,
    Neutral  = 0,
    Okay     = 1,
    Good     = 2,
    Great    = 3
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
    Secondary = 1,
    College = 2,
    Masters = 3,
    Doctorate = 4
}

public enum AssetTypes
{
    Car,
    House
}

public enum Cars
{
    Economy,
    Sports,
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
    ///<summary>All players roll their dice -- the player with the highest roll gets a bonus</summary>
    PartyPinata,
    ///<summary>All players gain demerits</summary>
    DarkCurse,
    ///<summary>All players gain favors</summary>
    LuckyBreak,
    ///<summary>All players roll their dice -- lowest or low roller(s) go back to start</summary>
    BackToStart,
}

public enum TicketTypes
{
    LuckyStars,
    Lottery
}