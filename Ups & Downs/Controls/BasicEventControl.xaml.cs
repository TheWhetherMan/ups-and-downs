using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Events;

namespace UpsAndDowns.Controls
{
    public partial class BasicEventControl : UserControl
    {
        private ObservableCollection<string>? _eventChanges;
        public ObservableCollection<string> EventChanges
        {
            get { return _eventChanges ?? []; }
            set { _eventChanges = value; }
        }

        private GameEvent? _activeEvent;
        private int _luckyStars = 0;

        public BasicEventControl()
        {
            InitializeComponent();
            DataContext = this;
            EventChanges = new ObservableCollection<string>();
        }

        internal void UpdateForEvent(GameEvent gameEvent)
        {
            _luckyStars = 0;
            _activeEvent = gameEvent;
            EventChanges.Clear();
            EventDescriptionHeader.Text = gameEvent.Description;
            AddEventHints(gameEvent);
        }

        private void AddEventHints(GameEvent gameEvent)
        {
            if (gameEvent.CashMoneyChange is int cash)
            {
                EventChanges.Add("Cash Money");
                //if (cash > 0)
                //    EventChanges.Add("+Cash Money");
                //else if (cash < 0)
                //    EventChanges.Add("-Cash Money");
            }

            if (gameEvent.LifePointsChange is int lifePoints)
            {
                EventChanges.Add("Life Points");
                //if (lifePoints > 0)
                //    EventChanges.Add("+Life Points");
                //else if (lifePoints < 0)
                //    EventChanges.Add("-Life Points");
            }

            if (gameEvent.CareerChange is int career)
            {
                EventChanges.Add("Career");
                //if (career > 0)
                //    EventChanges.Add("+Career");
                //else if (career < 0)
                //    EventChanges.Add("-Career");
            }

            if (gameEvent.SalaryChange is int salary)
            {
                EventChanges.Add("Salary");
                //if (salary > 0)
                //    EventChanges.Add("+Salary");
                //else if (salary < 0)
                //    EventChanges.Add("-Salary");
            }
        }

        private void RemoveLuckButton_Click(object sender, RoutedEventArgs e)
        {
            _luckyStars--;
            UpdateLuckyStarIcons();
        }

        private void AddLuckButton_Click(object sender, RoutedEventArgs e)
        {
            _luckyStars++;
            UpdateLuckyStarIcons();
        }

        private void UpdateLuckyStarIcons()
        {
            // Clamp the lucky stars value between -3 and 3
            _luckyStars = Math.Clamp(_luckyStars, -3, 3);

            // Only visible when there are no (un)lucky stars in play
            Star00.Visibility = _luckyStars == 0 ? Visibility.Visible : Visibility.Collapsed;

            // Only show the lucky stars that are relevant based on lucky stars value
            StarN3.Visibility = _luckyStars <= -3 ? Visibility.Visible : Visibility.Collapsed;
            StarN2.Visibility = _luckyStars <= -2 ? Visibility.Visible : Visibility.Collapsed;
            StarN1.Visibility = _luckyStars <= -1 ? Visibility.Visible : Visibility.Collapsed;
            StarP1.Visibility = _luckyStars >=  1 ? Visibility.Visible : Visibility.Collapsed;
            StarP2.Visibility = _luckyStars >=  2 ? Visibility.Visible : Visibility.Collapsed;
            StarP3.Visibility = _luckyStars >=  3 ? Visibility.Visible : Visibility.Collapsed;

            // Set luck description based on lucky stars value
            LuckDescriptionText.Text = Constants.LuckyStarDescriptions[_luckyStars];
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new Messages.GoToBasicEventsResultsMessage() 
            { 
                ActiveEvent = _activeEvent, 
                LuckyStars = _luckyStars
            });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new Messages.BackToPlayerTurnScreenMessage());
        }
    }
}
