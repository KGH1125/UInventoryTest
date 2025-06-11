using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public Character Player { get; private set; }

    #region 테스트용
    [SerializeField] private string testPlayerName = "test";
    [SerializeField] private int testItemStat = 100;
    [SerializeField] private Sprite testItemSprite;
    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            Player = new Character(testPlayerName);

            Item item = new(testItemStat, testItemStat, testItemStat, testItemStat);
            item.icon = testItemSprite;
            Player.AddItem(item);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
