using System.Net.Http.Json;

namespace PokemonAnalysisProject.Core
{
    public class TcgApiClient
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "https://api.tcgdex.net/v2/en";

        public TcgApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<Card?> GetCardAsync(string cardId)
        {
            var dto = await _http.GetFromJsonAsync<CardDto>($"{BaseUrl}/cards/{cardId}");
            if (dto == null) return null;

            return dto.Category switch
            {
                "Pokemon" => MapToPokemonCard(dto),
                "Trainer" => MapToTrainerCard(dto),
                "Energy"  => MapToEnergyCard(dto),
                _         => null
            };
        }

        private static PokemonCard MapToPokemonCard(CardDto dto)
        {
            var card = new PokemonCard
            {
                Name = dto.Name,
                Set = dto.Set?.Name ?? string.Empty,
                Rarity = dto.Rarity ?? string.Empty,
                CollectorCardId = dto.Id,
                CardType = CardType.Pokemon,
                HP = dto.Hp ?? 0,
                Stage = ParseStage(dto.Stage),
                PokemonType = ParsePokemonType(dto.Types?.FirstOrDefault()),
                EvolvesFrom = dto.EvolveFrom ?? string.Empty,
                RetreatCost = dto.Retreat ?? 0,
                Weakness = dto.Weaknesses?.FirstOrDefault()?.Type ?? string.Empty,
            };

            if (dto.Abilities != null)
            {
                foreach (var a in dto.Abilities)
                {
                    card.Abilities.Add(new Ability
                    {
                        Name = a.Name,
                        Effect = a.Effect ?? string.Empty,
                        AbilityType = a.Type ?? "Ability"
                    });
                }
            }

            if (dto.Attacks != null)
            {
                foreach (var a in dto.Attacks)
                {
                    card.Attacks.Add(new Attack(
                        name: a.Name,
                        damage: a.Damage?.ToString() ?? string.Empty,
                        energyCost: a.Cost ?? new List<string>(),
                        effect: a.Effect ?? string.Empty
                    ));
                }
            }

            return card;
        }

        private static TrainerCard MapToTrainerCard(CardDto dto)
        {
            return new TrainerCard
            {
                Name = dto.Name,
                Set = dto.Set?.Name ?? string.Empty,
                Rarity = dto.Rarity ?? string.Empty,
                CollectorCardId = dto.Id,
                CardType = CardType.Trainer,
                TrainerType = ParseTrainerType(dto.TrainerType),
                Effect = dto.Effect ?? string.Empty,
            };
        }

        private static EnergyCard MapToEnergyCard(CardDto dto)
        {
            return new EnergyCard
            {
                Name = dto.Name,
                Set = dto.Set?.Name ?? string.Empty,
                Rarity = dto.Rarity ?? string.Empty,
                CollectorCardId = dto.Id,
                CardType = CardType.Energy,
                EnergyType = dto.EnergyType == "Special" ? EnergyType.Special : EnergyType.Basic,
                Effect = dto.Effect ?? string.Empty,
            };
        }

        private static PokemonStage ParseStage(string? stage) => stage switch
        {
            "Stage1" => PokemonStage.Stage1,
            "Stage2" => PokemonStage.Stage2,
            "MEGA"   => PokemonStage.Mega,
            _        => PokemonStage.Basic,
        };

        private static PokemonType ParsePokemonType(string? type) => type switch
        {
            "Fire"      => PokemonType.Fire,
            "Water"     => PokemonType.Water,
            "Grass"     => PokemonType.Grass,
            "Lightning" => PokemonType.Lightning,
            "Psychic"   => PokemonType.Psychic,
            "Fighting"  => PokemonType.Fighting,
            "Darkness"  => PokemonType.Darkness,
            "Metal"     => PokemonType.Metal,
            "Dragon"    => PokemonType.Dragon,
            "Fairy"     => PokemonType.Fairy,
            _           => PokemonType.Colorless,
        };

        private static TrainerType ParseTrainerType(string? trainerType) => trainerType switch
        {
            "Supporter" => TrainerType.Supporter,
            "Tool"      => TrainerType.Tool,
            "Stadium"   => TrainerType.Stadium,
            _           => TrainerType.Item,
        };
    }
}
