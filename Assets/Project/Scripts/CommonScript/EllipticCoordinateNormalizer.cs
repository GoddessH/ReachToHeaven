using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[Serializable]
public class EllipticCoordinateNormalizer
{
    //

    [SerializeField] private float m_widthAxis, m_heightAxis;
    public float WidthAxis { get => m_widthAxis; }
    public float HeightAxis { get => m_heightAxis; }

    private float CalculateScale(Vector2 coordinate, Vector2 center)
    {
        if (coordinate == center) return 0;

        float kX = Mathf.Pow((coordinate.x - center.x) / m_widthAxis, 2),
            kY = Mathf.Pow((coordinate.y - center.y) / m_heightAxis, 2);

        return 1 / Mathf.Sqrt(kX + kY);
    }

    public Vector2 ConvertToEllipticCoordinate(Vector2 coordinate, Vector2 center)
    {
        float scale = CalculateScale(coordinate, center);
        Vector2 ellipticDirection = (coordinate - center) * scale;
        return center + ellipticDirection;
    }

}
