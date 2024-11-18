using UpsAndDowns.GameLogic.Misc;

namespace UpsAndDowns.GameLogic;

public static class Constants
{
    public static int CardsRightSideOffset = 660;

    public static int CardsSecondRowOffset = 200;
    public static int CardsThirdRowOffset = 400;

    public static List<CardPosPoint> PlayerCardPositions = new()
    {
        new CardPosPoint(0,                     0),                    // Player 1
        new CardPosPoint(CardsRightSideOffset,  0),                    // Player 2
        new CardPosPoint(0,                     CardsSecondRowOffset), // Player 3
        new CardPosPoint(CardsRightSideOffset,  CardsSecondRowOffset), // Player 4
        new CardPosPoint(0,                     CardsThirdRowOffset),  // Player 5
        new CardPosPoint(CardsRightSideOffset,  CardsThirdRowOffset)   // Player 6
    };
}