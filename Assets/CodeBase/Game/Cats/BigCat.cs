using CodeBase.StaticData;

namespace CodeBase.Game.Cats
{
    public class BigCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Big;
    }
}