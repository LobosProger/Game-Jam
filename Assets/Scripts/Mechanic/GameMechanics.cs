using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    int lives = 3;
    public static GameMechanics instance;

    void Awake()
    {
        if (instance != null)
            Debug.Log("GameMechanics have second example");
        instance = this;
    }

    public void LiveDecrease()
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void IncorrectFitEffect()
    {

    }

    void GameOver()
    {
        
    }
}
