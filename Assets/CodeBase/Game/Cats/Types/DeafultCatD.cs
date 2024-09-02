using CodeBase.StaticData;

namespace CodeBase.Game.Cats.Types
{
    public class DefaultCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Default;
    }
}