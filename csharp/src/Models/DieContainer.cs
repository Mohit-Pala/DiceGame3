// prob name this shit something else

namespace DiceGame3.Models
{
    public class DieContainer
    {
        public int DiceId { get; set; }
        public string DiceName { get; set; }
        public Die Die { get; set; }

        public DieContainer(int diceId, string diceName, Die die)
        {
            DiceId = diceId;
            DiceName = diceName;
            Die = die;
        }
    }
}