using UnityEngine;
using System;
using Gameplay.Walls;

namespace Gameplay.Fields
{
    [Serializable]
    public struct WallSetup
    {
        [SerializeField]
        private Transform _startPoint;
        [SerializeField]
        private Transform _endPoint;
        [SerializeField]
        private WallType _type;


        public bool IsValid => _startPoint != null && _endPoint != null;
        public Vector3 StartPoint => _startPoint.position;
        public Vector3 EndPoint => _endPoint.position;
        public WallType Type => _type;


        public void CreateWall(Wall wallPrefab, Transform wallsHolder)
        {
            var wall = GameObject.Instantiate(wallPrefab, wallsHolder);
            wall.Init(this);
        }

        public void DrawGizmos()
        {
            if (!IsValid)
                return;

            Gizmos.color = GizmoColors.GetColorForWall(Type);
            Gizmos.DrawLine(StartPoint, EndPoint);
        }
    }
}