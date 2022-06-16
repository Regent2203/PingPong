using UnityEngine;

namespace Gameplay
{
    public class ReflectCollisioner : ICollisioner
    {        
        public void Collide(Collision2D collision)
        {
            var movable = collision.gameObject.GetComponent<IMovable>();
            if (movable != null)
            {
                if (movable.Mover is IReflectable reflectable)
                    reflectable.Reflect(collision.GetContact(0).normal);
            }                
        }
    }
}