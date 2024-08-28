using SamuraCat.Constants;

namespace CodeBase.Game.Cat
{
    public class DefaultCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Default;
    }
}