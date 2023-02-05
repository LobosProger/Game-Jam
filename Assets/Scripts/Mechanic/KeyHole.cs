using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    public int keyID;
    public bool isSolved { get; private set; }
    [SerializeField] private KeyHole parentHole;

    public bool OnHoleFill(Block block)
    {
        if (parentHole != null && !parentHole.isSolved)
            return false;

        if(this.keyID == block.keyID)
        {
            Debug.Log("Fill");
            isSolved = true;
            return true;
        }
        return false;
    }
}
