using SamuraCat.Constants;

namespace CodeBase.Game.Cats
{
    public class KatanaCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Katana;
    }
}