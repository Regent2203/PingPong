using Gameplay.Fields;
using Gameplay.Walls;
using UnityEngine;

namespace Gameplay
{    
    public class Wall : MonoBehaviour
    {
        protected Vector2 _startPoint;
        private Vector2 _endPoint;
        [SerializeField]
        private WallType _type;

        private BoxCollider2D _bc;
        private SpriteRenderer _sr;

        private ICollisioner _ballCollisioner;


        private void Awake()
        {
            _bc = GetComponent<BoxCollider2D>();
            _sr = GetComponent<SpriteRenderer>();
        }

        protected virtual void Start()
        {
            _ballCollisioner = WallFactory.GetCollisioner(_type);
            _sr.color = WallFactory.GetColor(_type);
        }

        public void Init(WallSetup wallSetup)
        {
            _startPoint = wallSetup.StartPoint;
            _endPoint = wallSetup.EndPoint;
            _type = wallSetup.Type;

            UpdateSize();
        }

        /// <summary>
        /// Changes the shape of a sprite (and collider) to represent a line between two points
        /// </summary>
        private void UpdateSize()
        {
            transform.position = _startPoint;

            var rotation = transform.localEulerAngles;
            rotation.z = Vector2.SignedAngle(Vector2.right, _endPoint - _startPoint);
            transform.localEulerAngles = rotation;

            var spriteSize = _sr.size;
            spriteSize.x = Vector2.Distance(_startPoint, _endPoint);
            _sr.size = spriteSize;

            var bcSize = _bc.size;
            bcSize.x = spriteSize.x;
            _bc.size = bcSize;

            var bcOffset = _bc.offset;
            bcOffset.x = spriteSize.x / 2;
            _bc.offset = bcOffset;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var obj = collision.gameObject;
            if (obj.CompareTag("Ball"))
            {
                _ballCollisioner.Collide(collision);
            }
        }
    }
}