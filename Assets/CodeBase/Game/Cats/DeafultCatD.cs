using CodeBase.StaticData;

namespace CodeBase.Game.Cats
{
    public class DefaultCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Default;
    }
}