using System.Text.Json.Serialization;

namespace PokemonAnalysisProject.Core
{
    public class CardDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("rarity")]
        public string? Rarity { get; set; }

        [JsonPropertyName("hp")]
        public int? Hp { get; set; }

        [JsonPropertyName("types")]
        public List<string>? Types { get; set; }

        [JsonPropertyName("stage")]
        public string? Stage { get; set; }

        [JsonPropertyName("evolveFrom")]
        public string? EvolveFrom { get; set; }

        [JsonPropertyName("retreat")]
        public int? Retreat { get; set; }

        [JsonPropertyName("attacks")]
        public List<AttackDto>? Attacks { get; set; }

        [JsonPropertyName("weaknesses")]
        public List<WeaknessDto>? Weaknesses { get; set; }

        [JsonPropertyName("abilities")]
        public List<AbilityDto>? Abilities { get; set; }


        [JsonPropertyName("trainerType")]
        public string? TrainerType { get; set; }


        [JsonPropertyName("energyType")]
        public string? EnergyType { get; set; }

  
        [JsonPropertyName("effect")]
        public string? Effect { get; set; }

        [JsonPropertyName("set")]
        public SetDto? Set { get; set; }
    }

    public class AttackDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("cost")]
        public List<string>? Cost { get; set; }

        [JsonPropertyName("damage")]
        public int? Damage { get; set; }

        [JsonPropertyName("effect")]
        public string? Effect { get; set; }
    }

    public class AbilityDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("effect")]
        public string? Effect { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }

    public class WeaknessDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;
    }

    public class SetDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
