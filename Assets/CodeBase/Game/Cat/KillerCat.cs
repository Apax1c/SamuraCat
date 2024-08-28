using SamuraCat.Constants;

namespace CodeBase.Game.Cat
{
    public class KillerCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Killer;
    }
}