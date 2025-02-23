using System.Windows.Controls;
using UpsAndDowns.GameLogic.Events;

namespace UpsAndDowns.Controls;

public partial class EndOfYearEventRoulette : UserControl
{
    public List<EndOfYearEvent> EndOfYearEvents { get; set; }
    
    public EndOfYearEventRoulette()
    {
        InitializeComponent();
        EndOfYearEvents = [];
    }

    public void BuildEndOfYearEventRoulette()
    {
        
    }
}