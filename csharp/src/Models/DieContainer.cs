// prob name this shit something else

namespace DiceGame3.Models
{
    public class DieContainer
    {
        public Guid DiceId { get; set; }
        public string DiceName { get; set; }
        public Die Die { get; set; }

        public DieContainer(string diceName, Die die)
        {
            DiceId = Guid.NewGuid();
            DiceName = diceName;
            Die = die;
        }

        public DieContainer(Guid diceId, string diceName, Die die)
        {
            DiceId = diceId;
            DiceName = diceName;
            Die = die;
        }
    }
}