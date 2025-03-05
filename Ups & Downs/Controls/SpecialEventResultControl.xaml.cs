using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Controls
{
    public partial class SpecialEventResultControl : UserControl
    {
        private SpaceTypes _spaceType;

        public SpecialEventResultControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        internal void UpdateForSpecialSpace(SpaceTypes space)
        {
            _spaceType = space;
            switch (space)
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

        private void HandleCarResult()
        {
            SpecialSpaceHeader.Text = "Are you buying a car?";
            SpecialSpaceSubHeader.Text = "This will allow you to move farther on the board each turn!";
        }

        private void HandleHouseResult()
        {
            SpecialSpaceHeader.Text = "Are you buying a car?";
            SpecialSpaceSubHeader.Text = "This will allow you to move farther on the board each turn!";
        }

        private void HandlePromotionResult()
        {
            SpecialSpaceHeader.Text = "Are you buying a car?";
            SpecialSpaceSubHeader.Text = "This will allow you to move farther on the board each turn!";
        }

        private void HandleEducationResult()
        {
            SpecialSpaceHeader.Text = "Are you buying a car?";
            SpecialSpaceSubHeader.Text = "This will allow you to move farther on the board each turn!";
        }

        private void HandleChildrenResult()
        {
            SpecialSpaceHeader.Text = "Are you buying a car?";
            SpecialSpaceSubHeader.Text = "This will allow you to move farther on the board each turn!";
        }

        private void HandleMarriageResult()
        {
            SpecialSpaceHeader.Text = "Are you buying a car?";
            SpecialSpaceSubHeader.Text = "This will allow you to move farther on the board each turn!";
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new Messages.SpecialSpaceCompletedMessage());
        }
    }
}
