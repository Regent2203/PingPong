using UnityEngine;

namespace Gameplay
{
    public interface IMovable
    {
        public Vector3 LocalPosition { get; set; }

        public IMover Mover { get; }
    }
}