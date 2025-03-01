using CommunityToolkit.Mvvm.Messaging;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.BusinessLogic;
using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.GameLogic.Events;

namespace UpsAndDowns.Controls
{
    public partial class BasicEventResultsControl : UserControl
    {
        private GameEvent? _activeEvent;
        private int _stars = 0;

        public BasicEventResultsControl()
        {
            InitializeComponent();
        }

        internal void UpdateResultsForEvent(GameEvent? eve, int luckyStars)
        {
            if (eve == null)
            {
                Logger.Log("UpdateResultsForEvent: ActiveEvent is null!");
                return;
            }

            _activeEvent = eve;
            UpdateLuckyStarIcons(luckyStars);

            if (eve.CashMoneyChange is int cash)
            {
                CashBeforeText.Text = "$$" + cash.ToString();
                CashAfterText.Text = "$$" + eve.GetCashMoneyModifier((LuckyStars)_stars).ModifyCashMoney(cash).ToString();
                CashBeforeText.Visibility = Visibility.Visible;
                CashAfterText.Visibility = Visibility.Visible;
            }
            else
            {
                CashBeforeText.Visibility = Visibility.Hidden;
                CashAfterText.Visibility = Visibility.Hidden;
            }

            if (eve.LifePointsChange is int life)
            {
                LifeBeforeText.Text = "LP" + life.ToString();
                LifeAfterText.Text = "LP" + eve.GetLifePointsModifier((LuckyStars)_stars).ModifyLifePoints(life).ToString();
                LifeBeforeText.Visibility = Visibility.Visible;
                LifeAfterText.Visibility = Visibility.Visible;
            }
            else
            {
                LifeBeforeText.Visibility = Visibility.Hidden;
                LifeAfterText.Visibility = Visibility.Hidden;
            }

            if (eve.CareerChange is int career)
            {
                CareerBeforeText.Text = "Career: " + career.ToString();
                CareerAfterText.Text = "Career: " + eve.GetCareerChangeModifier((LuckyStars)_stars).ModifyCareerLevel().ToString();
                CareerBeforeText.Visibility = Visibility.Visible;
                CareerAfterText.Visibility = Visibility.Visible;
            }
            else
            {
                CareerBeforeText.Visibility = Visibility.Hidden;
                CareerAfterText.Visibility = Visibility.Hidden;
            }

            if (eve.SalaryChange is int salary)
            {
                SalaryBeforeText.Text = "Salary: " + salary.ToString();
                SalaryAfterText.Text = "Salary: " + eve.GetSalaryModifier((LuckyStars)_stars).ModifySalary(salary).ToString();
                SalaryBeforeText.Visibility = Visibility.Visible;
                SalaryAfterText.Visibility = Visibility.Visible;
            }
            else
            {
                SalaryBeforeText.Visibility = Visibility.Hidden;
                SalaryAfterText.Visibility = Visibility.Hidden;
            }
        }

        private void UpdateLuckyStarIcons(int stars)
        {
            _stars = stars;

            // Clamp the lucky stars value between -3 and 3
            _stars = Math.Clamp(_stars, -3, 3);

            // Only visible when there are no (un)lucky stars in play
            Star00.Visibility = _stars == 0 ? Visibility.Visible : Visibility.Collapsed;

            // Only show the lucky stars that are relevant based on lucky stars value
            StarN3.Visibility = _stars <= -3 ? Visibility.Visible : Visibility.Collapsed;
            StarN2.Visibility = _stars <= -2 ? Visibility.Visible : Visibility.Collapsed;
            StarN1.Visibility = _stars <= -1 ? Visibility.Visible : Visibility.Collapsed;
            StarP1.Visibility = _stars >=  1 ? Visibility.Visible : Visibility.Collapsed;
            StarP2.Visibility = _stars >=  2 ? Visibility.Visible : Visibility.Collapsed;
            StarP3.Visibility = _stars >=  3 ? Visibility.Visible : Visibility.Collapsed;

            // Set luck description based on lucky stars value
            LuckDescriptionText.Text = Constants.LuckyStarDescriptions[_stars];
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            GameManager.Instance.PlayerTurnCompleted = true;
            GameManager.Instance.CurrentPlayer.MovedThisTurn = true;
            GameManager.Instance.CurrentPlayer.ApplyGameEvent(_activeEvent, (LuckyStars)_stars);
            WeakReferenceMessenger.Default.Send(new Messages.PlayerTurnCompletedMessage());
        }
    }
}
