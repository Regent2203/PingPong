using UnityEngine;
using System;

namespace Gameplay.Movers
{
    public class KeyboardMover : IMover
    {
        private IMovable _owner;
        private string _axisName;
        private float _baseSpeed;

        private Tuple<float, float> _restricter;


        public KeyboardMover(IMovable owner, string axisName, float baseSpeed, float minX, float maxX)
        {
            _owner = owner;
            _axisName = axisName;
            _baseSpeed = baseSpeed;

            _restricter = new Tuple<float, float>(minX, maxX);
        }

        public void Move()
        {
            var input = Input.GetAxis(_axisName);

            if (input != 0)
            {
                var nextPosition = _owner.LocalPosition + new Vector3(input * _baseSpeed, 0, 0) * Time.fixedDeltaTime;
                nextPosition.x = Mathf.Max(nextPosition.x, _restricter.Item1);
                nextPosition.x = Mathf.Min(nextPosition.x, _restricter.Item2);

                _owner.LocalPosition = nextPosition;
            }
        }
    }
}