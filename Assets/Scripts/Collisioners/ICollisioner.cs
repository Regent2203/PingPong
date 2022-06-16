using UnityEngine;

namespace Gameplay
{
    public interface ICollisioner
    {
        public void Collide(Collision2D collision);
    }
}