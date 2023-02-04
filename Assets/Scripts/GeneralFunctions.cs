using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralFunctions
{
    static List<KeyHole> allholes = new List<KeyHole>();

    public static bool CheckAllHoles(/*Block block*/)
    {
        //Debug.Log(block.transform.position + " " + allholes.Count);
        foreach (KeyHole hole in allholes)
        {
            if (hole.rect.Contains(Input.mousePosition))
            {
                hole.OnHoleFill();
                return true;
            }
        }

        return false;
    }

    public static void AddHole(KeyHole hole)
    {
        allholes.Add(hole);
    }
}

/*public static bool CheckAllHoles(Block block)
    {
        //Debug.Log(block.transform.position + " " + allholes.Count);
        foreach (KeyHole hole in allholes)
        {
            if (hole.rect.Contains(block.transform.position))
            {
                hole.OnHoleFill();
                return true;
            }
        }

        return false;
    }*/