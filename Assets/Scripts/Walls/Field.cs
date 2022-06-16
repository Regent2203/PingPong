using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Fields;

namespace Gameplay
{
    public class Field : MonoBehaviour
    {
        [SerializeField]
        private Wall _wallPrefab;
        [SerializeField]
        private Transform _wallsHolder;
        [SerializeField]
        private List<WallSetup> _walls = new List<WallSetup>();


        private void Start()
        {
            CreateWalls();
        }

        private void CreateWalls()
        {
            if (_wallPrefab == null)
            {
                Debug.LogError($"No {nameof(_wallPrefab)} assigned for {this.name}!", this);
                return;
            }


            foreach (var wallSetup in _walls)
            {
                wallSetup.CreateWall(_wallPrefab, _wallsHolder);
            }            
            _walls.Clear();
        }

        private void OnDrawGizmos()
        {
            foreach (var w in _walls)
            {
                w.DrawGizmos();
            }
        }
    }
}
