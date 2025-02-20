namespace UpsAndDowns.GameLogic.Enums
{
    public enum GameStates
    {
        NotStarted,
        InProgress,
        LotterySelection,
        LotteryResults,
        PlayerTurn,
        Completed
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
        Luxury
    }

    public enum Houses
    {
        Apartment,
        House,
        Mansion
    }

    public enum LotteryResults
    {
        NoWinner,
        Winner
    }
}