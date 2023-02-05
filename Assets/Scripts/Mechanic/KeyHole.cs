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
        GameMechanics.instance.AddKeyHole();

        onHoleFill += OnSuccessfulHoleFill;
        onHoleFill += EffectOnHoleFill;
        onHoleFill += GameMechanics.instance.SolveHole;

        onHoleNoFit += GameMechanics.instance.LiveDecrease;
        onHoleNoFit += GameMechanics.instance.IncorrectFitEffect;
    }

    public bool OnHoleFillAttempt(Block block)
    {
        if (parentHole != null && !parentHole.isSolved)
            return false;

        if (isSolved)
            return false;

        if(this.keyID == block.keyID)
        {
            onHoleFill.Invoke();
            return true;
        }

        onHoleNoFit.Invoke();
        return false;
    }

    private void OnSuccessfulHoleFill()
    {
        isSolved = true;
    }

    private void EffectOnHoleFill()
    {

    }
}
