using UpsAndDowns.BusinessLogic;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic;

public class SpaceHandler
{
    /// <summary>
    /// Handles the normal spaces on the board (i.e. the blank colored ones)
    /// </summary>
    /// <param name="zone">What color of space was landed on?</param>
    public void HandleNormalSpace(BoardZones zone)
    {
        Logger.Log($"SpaceHandler.HandleNormalSpace", zone);
        switch (zone)
        {
            case BoardZones.Green:
                break;
            case BoardZones.Blue:
                break;
            case BoardZones.Yellow:
                break;
            case BoardZones.Pink:
                break;
        }
    }

    /// <summary>
    /// Handles the special spaces on the board (i.e. the ones with icons)
    /// </summary>
    /// <param name="spaceType">What type of special space was landed on?</param>
    public void HandleSpecialSpace(SpaceTypes spaceType)
    {
        Logger.Log($"SpaceHandler.HandleSpecialSpace", spaceType);
        switch (spaceType)
        {
            case SpaceTypes.Start:
                break;
            case SpaceTypes.Event:
                break;
            case SpaceTypes.Car:
                break;
            case SpaceTypes.House:
                break;
            case SpaceTypes.Promotion:
                break;
            case SpaceTypes.Education:
                break;
            case SpaceTypes.Children:
                break;
            case SpaceTypes.Marriage:
                break;
        }
    }
}
