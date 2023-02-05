using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyHole : MonoBehaviour
{
    public int keyID;
    public bool isSolved { get; private set; }
    [SerializeField] private KeyHole parentHole;

    private GameAction onHoleFill;
    private GameAction onHoleNoFit;

    private void Start()
    {
        onHoleFill = new GameAction();
        onHoleNoFit = new GameAction();

        onHoleFill += OnSuccessfulHoleFill;
    }

    public bool OnHoleFill(Block block)
    {
        if (parentHole != null && !parentHole.isSolved)
            goto NoFit;

        if(this.keyID == block.keyID)
        {
            onHoleFill.Invoke();
            return true;
        }

        NoFit:
        onHoleNoFit.Invoke();
        return false;
    }

    private void OnSuccessfulHoleFill()
    {
        Debug.Log("Fill");
        isSolved = true;
    }
}
