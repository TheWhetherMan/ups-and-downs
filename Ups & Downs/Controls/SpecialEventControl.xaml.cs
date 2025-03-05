using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Controls
{
    public partial class SpecialEventControl : UserControl
    {
        private SpaceTypes _spaceType;

        public SpecialEventControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        internal void UpdateForSpecialSpace(SpaceTypes space)
        {
            _spaceType = space;
            switch (space)
            {

                // [TODO] SHOW/HIDE BUTTONS DEPENDING IF EXTRA STEPS ARE REQUIRED

                case SpaceTypes.Car:
                    SpecialSpaceHeader.Text = "Are you buying a car?";
                    SpecialSpaceSubHeader.Text = "This will allow you to move farther on the board each turn!";
                    break;
                case SpaceTypes.House:
                    SpecialSpaceHeader.Text = "Are you buying a house?";
                    SpecialSpaceSubHeader.Text = "Houses increase in value over time, and will be sold at the end of the game!";
                    break;
                case SpaceTypes.Promotion:
                    SpecialSpaceHeader.Text = "Got yourself a promotion?";
                    SpecialSpaceSubHeader.Text = "Promotions = more money!";
                    break;
                case SpaceTypes.Education:
                    SpecialSpaceHeader.Text = "Did you graduate from a school program?";
                    SpecialSpaceSubHeader.Text = "More education = more money!";
                    break;
                case SpaceTypes.Children:
                    SpecialSpaceHeader.Text = "Did you have one or more children?";
                    SpecialSpaceSubHeader.Text = "Children give you lots of life points each turn!";
                    break;
                case SpaceTypes.Marriage:
                    SpecialSpaceHeader.Text = "Are you getting married, or is it an anniversay?";
                    SpecialSpaceSubHeader.Text = "Getting married or celebrating an anniversary means life points and money from all other players!";
                    break;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new Messages.BackToPlayerTurnScreenMessage());
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new Messages.SpecialSpaceSelectedMessage() { Space = _spaceType });
        }
    }
}
