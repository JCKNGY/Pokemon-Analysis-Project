namespace PokemonAnalysisProject.Core
{
    public class Attack
        {
        public string Name { get; set; } 

        public string Damage { get; set; }
        public string Effect { get; set; }
        public List<string> EnergyCost { get; set; }

        public Attack()
        {
            Name = string.Empty;
            Damage = string.Empty;
            Effect = string.Empty;
            EnergyCost = new List<string>();
        }
        public Attack(string name, string damage, List<string> energyCost, string effect = "") : this()
        {
            Name = name ?? string.Empty;
            Damage = damage ?? string.Empty;
            EnergyCost = energyCost ?? new List<string>();
            Effect = effect ?? string.Empty;
        }

        public int EnergyCostTotal => EnergyCost.Count;

        public bool IsValid() =>
            !string.IsNullOrWhiteSpace(Name);

        public override string ToString() =>
            $"{Name} - Cost: {EnergyCostTotal} - Damage: {Damage}";


    } 
}
