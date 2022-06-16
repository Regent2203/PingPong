using UnityEngine;

namespace Gameplay.Movers
{
    public class LinearMover : IMover, IReflectable
    {
        private IMovable _owner;
        private float _baseSpeed;
        private Vector2 _direction;

        private Vector3 _speed; //current speed


        public LinearMover(IMovable owner, float baseSpeed, Vector2 direction)
        {
            _owner = owner;
            _baseSpeed = baseSpeed;
            _direction = direction.normalized;

            CalculateSpeed();
        }

        public void Move()
        {
            _owner.LocalPosition += _speed * Time.fixedDeltaTime;
        }

        public void Reflect(Vector2 normal)
        {
            _speed = Vector2.Reflect(_speed, normal);            
        }

        private void CalculateSpeed()
        {
            _speed = _direction * _baseSpeed;
        }
    }
}