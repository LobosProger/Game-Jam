using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [HideInInspector] public Rect rect;

    void Start()
    {
        rect = this.GetComponent<RectTransform>().rect;
        GeneralFunctions.AddHole(this);
    }

    private void Update()
    {
        Debug.Log(GeneralFunctions.CheckAllHoles());
    }

    public void OnHoleFill()
    {
        Debug.Log("Hole Fill");
    }
}
