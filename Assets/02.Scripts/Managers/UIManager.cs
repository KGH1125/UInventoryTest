using UnityEngine;

public class UIManager : MonoBehaviour
{
    //싱글톤
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            uIMainMenu.OpenMainMenu();

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private UIMainMenu uIMainMenu;
    [SerializeField] private UIStatus uIStatus;
    [SerializeField] private UIInventory uIInventory;

    public UIMainMenu UIMainMenu => uIMainMenu;
    public UIStatus UIStatus => uIStatus;
    public UIInventory UIInventory => uIInventory;

   
}
