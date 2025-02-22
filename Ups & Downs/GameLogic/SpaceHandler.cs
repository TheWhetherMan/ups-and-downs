using System.Diagnostics;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic
{
    public class SpaceHandler
    {
        public void HandleNormalSpace(BoardZones zone)
        {
            Debug.WriteLine($"SpaceHandler.HandleNormalSpace: {zone}");
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

        public void HandleSpecialSpace(SpaceTypes spaceType)
        {
            Debug.WriteLine($"SpaceHandler.HandleSpecialSpace: {spaceType}");
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
}
