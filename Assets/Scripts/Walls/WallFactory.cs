using UnityEngine;

namespace Gameplay.Walls
{
    public static class WallFactory
    {
        public static ICollisioner GetCollisioner(WallType type)
        {
            switch (type)
            {
                case WallType.Reflect:
                    return new ReflectCollisioner();
                case WallType.Score:
                    return new ScoreCollisioner();
                default:
                    Debug.LogError($"Unknown {nameof(WallType)} {type} in {nameof(WallFactory)}!");
                    return null;
            }
        }

        public static Color GetColor(WallType type)
        {
            switch (type)
            {
                case WallType.Reflect:
                    return Color.white;
                case WallType.Score:
                    return Color.yellow;
                default:
                    return Color.red;
            }
        }
    }
}