using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    public int keyID;

    void Start()
    {

    }

    public bool OnHoleFill(Block block)
    {
        if(this.keyID == block.keyID)
        {
            Debug.Log("Fill");
            return true;
        }
        return false;
    }
}
