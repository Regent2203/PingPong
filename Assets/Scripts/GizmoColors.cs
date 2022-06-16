using Gameplay.Walls;
using UnityEngine;


public static class GizmoColors
{
    public static Color GetColorForWall(WallType type)
    {
        switch (type)
        {
            case WallType.Reflect:
                return Color.yellow;
            case WallType.Score:
                return Color.red;
            default:
                return Color.white;
        }
    }
}