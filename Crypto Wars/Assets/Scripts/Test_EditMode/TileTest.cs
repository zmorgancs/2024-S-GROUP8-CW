using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test
{
    public class TileTest
    {
        [Test]
        public void Tile_Create()
        {
            Tile.TileReference tile = new Tile.TileReference();
            Assert.IsNotNull(tile);
        }
    }
}
