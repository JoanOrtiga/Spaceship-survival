using System;

namespace SpaceShipSurvival
{
    public interface PooledObject //Bullet
    {
        public GameObjectPooler GameObjectPooler { get; set; }
        public void Restart();
        public void DestroyObject();
    }
}