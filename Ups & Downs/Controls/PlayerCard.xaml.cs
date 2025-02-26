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

    private readonly TimeSpan _updateIntervalFast = TimeSpan.FromMilliseconds(10);
    private readonly TimeSpan _updateIntervalSlow = TimeSpan.FromMilliseconds(50);
    private readonly Timer _timerFast;
    private readonly Timer _timerSlow;
    private SoundLooper _soundLooper;

    public PlayerCard()
    {
        InitializeComponent();
        DataContextChanged += PlayerCard_DataContextChanged;
        _timerFast = new Timer(UpdatePlayerStatsFast, null, _updateIntervalFast, _updateIntervalFast);
        _timerSlow = new Timer(UpdatePlayerStatsSlow, null, _updateIntervalSlow, _updateIntervalSlow);
        _soundLooper = new SoundLooper("UpsAndDowns.Resources.Sounds.banknote-counter.wav");
    }

    private void PlayerCard_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
    {
        if (DataContext is Player player)
            Player = player;
    }

    private void UpdatePlayerStatsFast(object? _)
    {
        if (Player is null)
            return;

        if (ReflectedCashMoney != Player.CashMoney)
        {
            int diffSign = Math.Sign(Player.CashMoney - ReflectedCashMoney);
            int diffAbs = Math.Abs(Player.CashMoney - ReflectedCashMoney);

            if (diffAbs > 1000)
                ReflectedCashMoney += 100 * diffSign;
            if (diffAbs > 100)
                ReflectedCashMoney += 10 * diffSign;
            else
                ReflectedCashMoney += 1 * diffSign;

            if (_soundLooper.Playing is false)
                _soundLooper.Play();
        }
        else
        {
            if (_soundLooper.Playing is true)
                _soundLooper.Stop();
        }
    }

    private void UpdatePlayerStatsSlow(object? _)
    {
        if (Player is null)
            return;

        if (ReflectedLifePoints != Player.LifePoints)
        {
            if (ReflectedLifePoints < Player.LifePoints)
                ReflectedLifePoints++;
            else
                ReflectedLifePoints--;
        }
    }
}