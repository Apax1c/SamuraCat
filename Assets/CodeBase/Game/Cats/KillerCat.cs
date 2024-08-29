using CodeBase.StaticData;

namespace CodeBase.Game.Cats
{
    public class KillerCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Killer;
    }
}