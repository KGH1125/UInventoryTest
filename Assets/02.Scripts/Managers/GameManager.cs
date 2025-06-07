using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance{ get; private set; }
    public Character Player { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Player = new Character("test");
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
