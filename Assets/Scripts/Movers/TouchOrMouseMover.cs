using UnityEngine;
using System;

namespace Gameplay.Movers
{
    public class TouchOrMouseMover : IMover
    {
        private IMovable _owner;
        private float _baseSpeed;
        private Camera _camera;

        private Tuple<float, float> _restricter;


        public TouchOrMouseMover(IMovable owner, float baseSpeed, float minX, float maxX)
        {
            _owner = owner;
            _baseSpeed = baseSpeed;

            _camera = Camera.main;
            _restricter = new Tuple<float, float>(minX, maxX);
        }

        public void Move()
        {
            bool doMove = false;
            Vector3 pos = Vector3.zero;

#if UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0)
            {
                pos = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
                doMove = true;
            }
#else
            if (Input.GetMouseButton(0))
            {
                pos = _camera.ScreenToWorldPoint(Input.mousePosition);
                doMove = true;
            }
#endif
            if (doMove)
            {
                int input = 0;

                if (pos.x > _owner.LocalPosition.x)
                    input = 1;
                else
                    input = -1;

                var nextPosition = _owner.LocalPosition + new Vector3(input * _baseSpeed, 0, 0) * Time.fixedDeltaTime;
                nextPosition.x = Mathf.Max(nextPosition.x, _restricter.Item1);
                nextPosition.x = Mathf.Min(nextPosition.x, _restricter.Item2);

                _owner.LocalPosition = nextPosition;
            }
        }
    }
}