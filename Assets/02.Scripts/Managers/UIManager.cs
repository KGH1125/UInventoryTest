using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    UIMainMenu uIMainMenu;
    [SerializeField]
    UIStatus uIStatus;
    [SerializeField]
    UIInventory uIInventory;

}
