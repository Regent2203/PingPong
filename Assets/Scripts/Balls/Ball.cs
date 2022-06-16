using UnityEngine;
using Gameplay.Movers;

namespace Gameplay
{
    public class Ball : MonoBehaviour, IMovable, IResetable
    {
        private Vector3 _initialPosition;

        [SerializeField]
        private float _baseSpeed = 5.0f;
        [SerializeField]
        private Vector2 _direction = Vector2.down;

        public Vector3 LocalPosition
        {
            get { return transform.localPosition; }
            set { transform.localPosition = value; }
        }

        public IMover Mover { get; protected set; }


        private void Start()
        {
            Mover = new LinearMover(this, _baseSpeed, _direction);
        }

        private void FixedUpdate()
        {
            Mover.Move();
        }


        public void Reset() //some lazy hardcoded numbers here
        {
            var offsetX = Random.Range(0, 3.0f);
            transform.position = _initialPosition + new Vector3(offsetX, 0, 0);

            var newScale = Random.Range(0.5f, 1.5f);
            transform.localScale = new Vector3(newScale, newScale, newScale);

            var newSpeed = Random.Range(2.0f, 5.0f);
            var newDir = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-1.0f, 1.0f));
            newDir.y = Mathf.Min(0.5f, Mathf.Abs(newDir.y)) * Mathf.Sign(newDir.y);            
            Mover = new LinearMover(this, newSpeed, newDir);
        }
    }
}