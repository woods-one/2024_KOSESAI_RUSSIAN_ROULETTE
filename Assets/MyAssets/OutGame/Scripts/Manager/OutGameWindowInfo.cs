using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roulette.OutGame
{
    public class OutGameWindowInfo
    {
        private readonly bool _isSoloPlay;
        public bool IsSoloPlay =>_isSoloPlay;
        
        public OutGameWindowInfo(bool isSoloPlay = default)
        {
            _isSoloPlay = isSoloPlay;
        }
    }
}