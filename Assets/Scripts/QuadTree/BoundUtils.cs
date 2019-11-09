using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class BoundUtils {

    public static Bounds GetChildBound(Bounds b, Quadrant q)
    {
        Bounds res;
        switch (q)
        {
            case Quadrant.One:
                res= new Bounds(b.center + new Vector3(b.extents.x/2, 0, b.extents.z/2), new Vector3(b.extents.x,b.size.y,b.extents.z));
                break;
            case Quadrant.Two:
                res = new Bounds(b.center + new Vector3(-b.extents.x / 2, 0, b.extents.z / 2), new Vector3(b.extents.x, b.size.y, b.extents.z));
                break;
            case Quadrant.Three:
                res= new Bounds(b.center + new Vector3(-b.extents.x / 2, 0, -b.extents.z / 2), new Vector3(b.extents.x, b.size.y, b.extents.z));
                break;
            case Quadrant.Four:
                res= new Bounds(b.center + new Vector3(b.extents.x / 2, 0, -b.extents.z / 2), new Vector3(b.extents.x, b.size.y, b.extents.z));
                break;
            default:
                throw new Exception("Unknown Quadrant");
        }
        return res;
    } 
    
    public static bool Constains(Bounds b,Vector3 p)
    {
        return b.Contains(p);
    }

    public static bool Intersects(Bounds b,Bounds p)
    {
        return b.Intersects(p);
    }
}

public enum Quadrant
{
    One,
    Two,
    Three,
    Four
}
