namespace PokemonAnalysisProject.Core
{
    public enum EnergyType
    {
        Basic,
        Special
    }

    public class EnergyCard : Card
    {
        public EnergyType EnergyType { get; set; }
        public string Effect { get; set; }

        public EnergyCard()
        {
            CardType = CardType.Energy;
            EnergyType = EnergyType.Basic;
            Effect = string.Empty;
        }

        public override bool IsValid() => base.IsValid();
    }
}
