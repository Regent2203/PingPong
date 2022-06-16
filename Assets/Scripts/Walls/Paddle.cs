using Gameplay.Movers;
using UnityEngine;

namespace Gameplay
{
    public class Paddle : Wall, IMovable
    {
        [Header("Paddle")]
        [SerializeField]
        private string _axisName = ""; //only used when Mover is KeyboardMover
        [SerializeField]
        private float _baseSpeed = 6.0f;
        [SerializeField]
        private Transform _minX;
        [SerializeField]
        private Transform _maxX;

        public IMover Mover { get; protected set; }

        public Vector3 LocalPosition
        {
            get { return transform.localPosition; }
            set { transform.localPosition = value; }
        }


        protected override void Start()
        {
            //uncomment any one line here
            //Mover = new KeyboardMover(this, _axisName, _baseSpeed, _minX.position.x, _maxX.position.x); //keyboard
            Mover = new TouchOrMouseMover(this, _baseSpeed, _minX.position.x, _maxX.position.x); //touch/mouse input            

            base.Start();
            //don't need anymore
            GameObject.Destroy(_minX.gameObject);
            GameObject.Destroy(_maxX.gameObject);
        }

        private void FixedUpdate()
        {
            Mover.Move();
        }
    }
}