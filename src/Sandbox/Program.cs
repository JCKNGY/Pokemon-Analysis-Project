using PokemonAnalysisProject.Core;
using PokemonAnalysisProject.Core.Probability;

// Probability Engine
Console.WriteLine("=== ProbabilityEngine ===");

double pmf = ProbabilityEngine.Pmf(60, 4, 7, 1);
Console.WriteLine($"Pmf(60,4,7,1)     = {pmf:F4}  (expect ~0.3363)");

double atLeast = ProbabilityEngine.AtLeast(60, 4, 7, 1);
Console.WriteLine($"AtLeast(60,4,7,1) = {atLeast:F4}  (expect ~0.3995)");

double none = ProbabilityEngine.None(60, 4, 7);
Console.WriteLine($"None(60,4,7)      = {none:F4}  (expect ~0.6005)");

//DrawRateCalculator
Console.WriteLine("\n=== DrawRateCalculator ===");

double opening = DrawRateCalculator.OpeningHandOdds(copiesInDeck: 4);
Console.WriteLine($"OpeningHandOdds(4 copies) = {opening:F4}");

double byTurn2First = DrawRateCalculator.OddsByTurn(copiesInDeck: 4, turn: 2, goingFirst: true);
Console.WriteLine($"OddsByTurn(4, turn 2, going first)  = {byTurn2First:F4}");

double byTurn2Second = DrawRateCalculator.OddsByTurn(copiesInDeck: 4, turn: 2, goingFirst: false);
Console.WriteLine($"OddsByTurn(4, turn 2, going second) = {byTurn2Second:F4}");

//ComboCalculator
Console.WriteLine("\n=== ComboCalculator ===");

double both = ComboCalculator.OddsOfBoth(copiesOfA: 4, copiesOfB: 3, cardsDrawn: 7);
Console.WriteLine($"OddsOfBoth(4 copies A, 3 copies B, 7 drawn) = {both:F4}");

//MulliganCalculator
Console.WriteLine("\n=== MulliganCalculator ===");

double mulligan = MulliganCalculator.MulliganOdds(basicCount: 8);
Console.WriteLine($"MulliganOdds(8 basics) = {mulligan:F4}");

//TcgApiClient
Console.WriteLine("\n=== TcgApiClient ===");

var http = new HttpClient();
var apiClient = new TcgApiClient(http);

// Pokemon — regular
Console.WriteLine("\n--- Pokemon: Furret (swsh3-136) ---");
PokemonCard? furret = (PokemonCard?)await apiClient.GetCardAsync("swsh3-136");
PrintPokemon(furret);

// Pokemon — with Ability
Console.WriteLine("\n--- Pokemon: Zamazenta V (swsh1-196) ---");
PokemonCard? zamazenta = (PokemonCard?)await apiClient.GetCardAsync("swsh1-196");
PrintPokemon(zamazenta);

// Trainer — Supporter
Console.WriteLine("\n--- Trainer (Supporter): Professor's Research (swsh1-178) ---");
TrainerCard? prof = (TrainerCard?)await apiClient.GetCardAsync("swsh1-178");
PrintTrainer(prof);

// Trainer — Item
Console.WriteLine("\n--- Trainer (Item): Metal Saucer (swsh1-170) ---");
TrainerCard? metalSaucer = (TrainerCard?)await apiClient.GetCardAsync("swsh1-170");
PrintTrainer(metalSaucer);

// Trainer — Tool
Console.WriteLine("\n--- Trainer (Tool): Air Balloon (swsh1-213) ---");
TrainerCard? airBalloon = (TrainerCard?)await apiClient.GetCardAsync("swsh1-213");
PrintTrainer(airBalloon);

// Energy — Special
Console.WriteLine("\n--- Energy (Special): Aurora Energy (swsh1-186) ---");
EnergyCard? aurora = (EnergyCard?)await apiClient.GetCardAsync("swsh1-186");
PrintEnergy(aurora);

// Energy — Special (classic)
Console.WriteLine("\n--- Energy (Special): Double Colorless Energy (base1-96) ---");
EnergyCard? dce = (EnergyCard?)await apiClient.GetCardAsync("base1-96");
PrintEnergy(dce);

// ── Helpers ────────────────────────────────────────────────────────────────

static void PrintPokemon(PokemonCard? card)
{
    if (card == null) { Console.WriteLine("  ERROR: null returned"); return; }
    Console.WriteLine($"  Name:     {card.Name}");
    Console.WriteLine($"  Set:      {card.Set}");
    Console.WriteLine($"  HP:       {card.HP}");
    Console.WriteLine($"  Type:     {card.PokemonType}");
    Console.WriteLine($"  Stage:    {card.Stage}");
    if (!string.IsNullOrEmpty(card.EvolvesFrom))
        Console.WriteLine($"  Evolves:  {card.EvolvesFrom}");
    Console.WriteLine($"  Retreat:  {card.RetreatCost}");
    if (!string.IsNullOrEmpty(card.Weakness))
        Console.WriteLine($"  Weakness: {card.Weakness}");
    if (card.Abilities.Count > 0)
    {
        Console.WriteLine($"  Abilities ({card.Abilities.Count}):");
        foreach (var a in card.Abilities) Console.WriteLine($"    * {a}");
    }
    Console.WriteLine($"  Attacks ({card.Attacks.Count}):");
    foreach (var a in card.Attacks) Console.WriteLine($"    - {a}");
    Console.WriteLine($"  IsValid:  {card.IsValid()}");
}

static void PrintTrainer(TrainerCard? card)
{
    if (card == null) { Console.WriteLine("  ERROR: null returned"); return; }
    Console.WriteLine($"  Name:    {card.Name}");
    Console.WriteLine($"  Set:     {card.Set}");
    Console.WriteLine($"  Subtype: {card.TrainerType}");
    Console.WriteLine($"  Effect:  {card.Effect}");
    Console.WriteLine($"  IsValid: {card.IsValid()}");
}

static void PrintEnergy(EnergyCard? card)
{
    if (card == null) { Console.WriteLine("  ERROR: null returned"); return; }
    Console.WriteLine($"  Name:    {card.Name}");
    Console.WriteLine($"  Set:     {card.Set}");
    Console.WriteLine($"  Type:    {card.EnergyType}");
    if (!string.IsNullOrEmpty(card.Effect))
        Console.WriteLine($"  Effect:  {card.Effect}");
    Console.WriteLine($"  IsValid: {card.IsValid()}");
}
