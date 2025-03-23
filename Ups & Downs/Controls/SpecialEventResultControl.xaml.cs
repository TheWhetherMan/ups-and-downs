using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Controls
{
    public partial class SpecialEventResultControl : UserControl
    {
        private SpaceTypes _currentSpaceType;
        private Houses _houseType;
        private Cars _carType;

        public SpecialEventResultControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        internal void UpdateForSpecialSpace(SpaceTypes landedSpace)
        {
            // Reset controls to default state
            ConfirmButton.Visibility = Visibility.Visible;
            SetAllPanelsVisibility(Visibility.Collapsed);

            // Set up for the specific space type
            _currentSpaceType = landedSpace;
            switch (landedSpace)
            {
                case SpaceTypes.Car:
                    HandleCarResult(); break;
                case SpaceTypes.House:
                    HandleHouseResult(); break;
                case SpaceTypes.Promotion:
                    HandlePromotionResult(); break;
                case SpaceTypes.Education:
                    HandleEducationResult(); break;
                case SpaceTypes.Children:
                    HandleChildrenResult(); break;
                case SpaceTypes.Marriage:
                    HandleMarriageResult(); break;
            }
        }

        private void SetAllPanelsVisibility(Visibility visibility)
        {
            BuyCarPanel.Visibility = visibility;
            BuyHousePanel.Visibility = visibility;
        }

        private void HandleCarResult()
        {
            SpecialSpaceHeader.Text = "What kind of car?";
            SpecialSpaceSubHeader.Text = "Cars move you farther on the board each turn!";
            BuyCarPanel.Visibility = Visibility.Visible;
            ConfirmButton.Visibility = Visibility.Collapsed;
        }

        private void HandleHouseResult()
        {
            SpecialSpaceHeader.Text = "Are you buying a house?";
            SpecialSpaceSubHeader.Text = "Houses gain value every year!";
            BuyHousePanel.Visibility = Visibility.Visible;
            ConfirmButton.Visibility = Visibility.Collapsed;
        }

        private void HandlePromotionResult()
        {
            SpecialSpaceHeader.Text = "Promotion acquired!";
            SpecialSpaceSubHeader.Text = "You'll get more money for your salary each year!";
        }

        private void HandleEducationResult()
        {
            SpecialSpaceHeader.Text = "Degree acquired";
            SpecialSpaceSubHeader.Text = "You'll get more money for your salary each year!";
        }

        private void HandleChildrenResult()
        {
            SpecialSpaceHeader.Text = "Congratulations!";
            SpecialSpaceSubHeader.Text = "Children give you lots of life points over time!";
        }

        private void HandleMarriageResult()
        {
            SpecialSpaceHeader.Text = "Congratulations!";
            SpecialSpaceSubHeader.Text = "Being married gives you lots of life points over time, " +
                "all players are happy to pitch in some money, too!";
        }

        private void CarButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button carButton)
            {
                switch (carButton.Content)
                {
                    case "Economy":
                        _carType = Cars.Economy; break;
                    case "Luxury":
                        _carType = Cars.Luxury; break;
                    case "Exotic":
                        _carType = Cars.Exotic; break;
                }

                CompleteTurn();
            }
        }

        private void HouseButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button houseButton)
            {
                switch (houseButton.Content)
                {
                    case "Fixer-Upper":
                        _houseType = Houses.FixerUpper; break;
                    case "Starter":
                        _houseType = Houses.Starter; break;
                    case "Luxury":
                        _houseType = Houses.Luxury; break;
                    case "Mansion":
                        _houseType = Houses.Mansion; break;
                }

                CompleteTurn();
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            CompleteTurn();
        }

        private void CompleteTurn()
        {
            switch (_currentSpaceType)
            {
                case SpaceTypes.Car:
                    GameManager.Instance.CurrentPlayer.BuyOrSellCar(_carType, true); break;
                case SpaceTypes.House:
                    GameManager.Instance.CurrentPlayer.BuyOrSellHouse(_houseType, true); break;
                case SpaceTypes.Promotion:
                    GameManager.Instance.CurrentPlayer.PromoteOrDemoteCareer(1); break;
                case SpaceTypes.Education:
                    GameManager.Instance.CurrentPlayer.GainOrLoseEducation(1); break;
                case SpaceTypes.Children:
                    GameManager.Instance.CurrentPlayer.AddChildren(1); break;
                case SpaceTypes.Marriage:
                    GameManager.Instance.HandleMarriageForCurrentPlayer(); break;
            }

            GameManager.Instance.PlayerTurnCompleted = true;
            GameManager.Instance.CurrentPlayer.MovedThisTurn = true;
            WeakReferenceMessenger.Default.Send(new Messages.SpecialSpaceCompletedMessage());
        }
    }
}
