using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public Character Player { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            Player = new Character("test");

            Item item = new (99, 98, 97, 96);
            Player.AddItem(item);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
