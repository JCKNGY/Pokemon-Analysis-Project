namespace PokemonAnalysisProject.Core
{
  public enum CardType
    {
        Pokemon,
        Trainer,
        Energy
        }

    public class Card
    {
        public string Name { get; set; }
        public string Set { get; set; }
        public string Rarity { get; set; }

        public CardType CardType { get; set; }
        public string CollectorCardId { get; set; }


        public virtual bool IsValid() => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Set) && !string.IsNullOrEmpty(Rarity);
    }  
}
