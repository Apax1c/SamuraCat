﻿using CodeBase.StaticData;

namespace CodeBase.Game.Cats.Types
{
    public class ParkourCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Parkour;
    }
}