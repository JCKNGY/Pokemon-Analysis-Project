namespace PokemonAnalysisProject.Core
{
    public class Ability
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public string AbilityType { get; set; }

        public Ability()
        {
            Name = string.Empty;
            Effect = string.Empty;
            AbilityType = "Ability";
        }

        public override string ToString() => $"[{AbilityType}] {Name}: {Effect}";
    }
}
