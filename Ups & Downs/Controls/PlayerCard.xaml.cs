using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;

namespace UpsAndDowns.Controls;

public partial class PlayerCard : UserControl, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private Player? _player;
    public Player? Player
    {
        get { return _player; }
        set { _player = value; OnPropertyChanged(); }
    }

    private int _reflectedCashMoney;
    public int ReflectedCashMoney
    {
        get { return _reflectedCashMoney; }
        set { _reflectedCashMoney = value; OnPropertyChanged(); }
    }

    private int _reflectedLifePoints;
    public int ReflectedLifePoints
    {
        get { return _reflectedLifePoints; }
        set { _reflectedLifePoints = value; OnPropertyChanged(); }
    }

    // Timers
    private readonly TimeSpan _updateIntervalFast = TimeSpan.FromMilliseconds(10);
    private readonly TimeSpan _updateIntervalSlow = TimeSpan.FromMilliseconds(40);
    private readonly Timer _timerCash;
    private readonly Timer _timerLife;

    // Sounds
    private SoundLooper _cashLooper;
    private SoundLooper _lifePointsLooper;

    public PlayerCard()
    {
        InitializeComponent();
        DataContextChanged += PlayerCard_DataContextChanged;
        _timerCash = new Timer(UpdatePlayerStatsCashMoney, null, _updateIntervalFast, _updateIntervalFast);
        _timerLife = new Timer(UpdatePlayerStatsLifePoints, null, _updateIntervalFast, _updateIntervalFast);
        _cashLooper = new SoundLooper("UpsAndDowns.Resources.Sounds.banknote-counter.wav");
        _lifePointsLooper = new SoundLooper("UpsAndDowns.Resources.Sounds.retro_coin_extended.wav");
    }

    private void PlayerCard_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
    {
        if (DataContext is Player player)
            Player = player;
    }

    private void UpdatePlayerStatsCashMoney(object? _)
    {
        if (Player is null)
            return;

        if (ReflectedCashMoney != Player.CashMoney)
        {
            int diffSign = Math.Sign(Player.CashMoney - ReflectedCashMoney);
            int diffAbs = Math.Abs(Player.CashMoney - ReflectedCashMoney);

            if (diffAbs > 10000)
                ReflectedCashMoney += 1000 * diffSign;
            if (diffAbs > 1000)
                ReflectedCashMoney += 100 * diffSign;
            else if (diffAbs > 100)
                ReflectedCashMoney += 10 * diffSign;
            else
                ReflectedCashMoney += 1 * diffSign;

            if (_cashLooper.Playing is false)
                _cashLooper.Play();
        }
        else if (_cashLooper.Playing is true)
        {
            _cashLooper.Stop();
        }
    }

    private void UpdatePlayerStatsLifePoints(object? _)
    {
        if (Player is null)
            return;

        if (ReflectedLifePoints != Player.LifePoints)
        {
            int diffSign = Math.Sign(Player.LifePoints - ReflectedLifePoints);
            int diffAbs = (int)Math.Abs(Player.LifePoints - ReflectedLifePoints);

            if (diffAbs > 10000)
                ReflectedLifePoints += 1000 * diffSign;
            if (diffAbs > 1000)
                ReflectedLifePoints += 100 * diffSign;
            else if (diffAbs > 100)
                ReflectedLifePoints += 10 * diffSign;
            else
                ReflectedLifePoints += 1 * diffSign;

            //if (_lifePointsLooper.Playing is false)
            //    _lifePointsLooper.Play();
        }
        else if (_lifePointsLooper.Playing is true)
        {
            //_lifePointsLooper.Stop();
        }
    }
}