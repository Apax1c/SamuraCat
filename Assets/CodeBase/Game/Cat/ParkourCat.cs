﻿using SamuraCat.Constants;

namespace CodeBase.Game.Cat
{
    public class ParkourCat : Cat
    {
        public override CatType Type { get; protected set; } = CatType.Parkour;
    }
}