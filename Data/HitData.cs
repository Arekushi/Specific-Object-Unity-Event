using System;
using UnityEngine;
using UnityEngine.Events;

namespace Arekushi.SpecificUnityEvent
{
    public class HitData
    {

        public GameObject aggressor;
        public GameObject victim;
        public int damage;

        public HitData(GameObject aggressor, GameObject victim, int damage)
        {
            this.aggressor = aggressor;
            this.victim = victim;
            this.damage = damage;
        }
    }

}
