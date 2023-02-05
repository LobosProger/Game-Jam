using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path
{
    [SerializeField, HideInInspector]
    List<Vector2> points;

    public Path(Vector2 centre)
    {
        points = new List<Vector2>()
        {
            centre + Vector2.left,
            centre + (Vector2.left + Vector2.up) * 0.5f,
            centre + (Vector2.right + Vector2.down) * 0.5f,
            centre + Vector2.right
        };
    }

    public Vector2 this[int i]{get { return points[i]; }}

    public int NumPoints { get { return points.Count; } }

    public int NumSegment { get { return (points.Count - 4) / 3 + 1; } }

    public void AddSegment(Vector2 anchorPos)
    {
        //The forth segment, being the second control point of an anchor
        points.Add(points[points.Count-1] * 2 - points[points.Count - 2]);
        points.Add((points[points.Count - 1] + anchorPos)/2f);
        points.Add(anchorPos);
    }

    //i - is a segmentIndex, segment is basically 4 points of path, 2 anchor and 2 control, that craetes a 1 curve
    public Vector2[] GetPointsInSegment(int i)
    {
        return new Vector2[] {points[i * 3], points[i * 3 + 1], points[i * 3 + 2], points[i * 3 + 3] };
    }

    public void MovePoint(int i, Vector2 pos)
    {
        points[i] = pos;
    }
}
