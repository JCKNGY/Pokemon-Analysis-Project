namespace PokemonAnalysisProject.Core
{
    public enum TrainerType
    {
        Supporter,
        Item,
        Tool,
        Stadium
    }

    public class TrainerCard : Card
    {
        public TrainerType TrainerType { get; set; }
        public string Effect { get; set; }

        public TrainerCard()
        {
            CardType = CardType.Trainer;
            TrainerType = TrainerType.Item;
            Effect = string.Empty;
        }

        public override bool IsValid() => base.IsValid();
    }
}
