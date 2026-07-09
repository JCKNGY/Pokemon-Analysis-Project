namespace PokemonAnalysisProject.Core
{
    

public class Deck
{
    public List<Card> Cards { get; private set; }
    public const int DeckSize = 60;

    public Deck()
    {
        Cards = new List<Card>();
    }

    public bool IsValid(out string error)
    {
        if (Cards.Count != DeckSize)
        {
            error = $"Deck must have exactly 60 cards. Current count: {Cards.Count}";
            return false;
        }

        error = string.Empty;
        return true;
    }

    public void AddCard(Card card)
    {
        Cards.Add(card);
    }

    public int CountByName(string name) =>
        Cards.Count(c => c.Name == name);

    public int CountBasicPokemon() =>
        Cards.OfType<PokemonCard>().Count(c => c.Stage == PokemonStage.Basic);
}
}