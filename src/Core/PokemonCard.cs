namespace PokemonAnalysisProject.Core
{   
    public enum PokemonType
    {
        Colorless,
        Darkness,
        Dragon,
        Fairy,
        Fighting,
        Fire,
        Grass,
        Lightning,
        Metal,
        Psychic,
        Water
    }
    public enum PokemonStage
    {
        Basic,
        Stage1,
        Stage2,
        Mega
    }
    
   public class PokemonCard : Card
    {
    public int HP { get; set; }
    public PokemonType PokemonType { get; set; }   // Fire, Water, Grass etc.
    public PokemonStage Stage { get; set; }          // Basic, Stage 1, Stage 2, Mega
    public string EvolvesFrom { get; set; }    // name of the previous stage
    public List<Attack> Attacks { get; set; }
    public string Weakness { get; set; }
    public string Resistance { get; set; }
    public int RetreatCost { get; set; }

    public PokemonCard()
    {
        HP = 0;
        PokemonType = PokemonType.Colorless;
        Stage = PokemonStage.Basic;
        EvolvesFrom = string.Empty;
        Attacks = new List<Attack>();
        Weakness = string.Empty;
        Resistance = string.Empty;
        RetreatCost = 0;
    }


    public override bool IsValid() =>
        base.IsValid() && HP > 0;
    } 
}
