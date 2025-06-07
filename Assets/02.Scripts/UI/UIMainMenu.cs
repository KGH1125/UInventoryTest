using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject UIStatusButton;
    [SerializeField] private GameObject UIInventoryButton;
    [SerializeField] private GameObject BackButton;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerLevel;
    [SerializeField] private TextMeshProUGUI playerCurExp;
    [SerializeField] private TextMeshProUGUI playerMaxExp;
    [SerializeField] private Image playerLevelBar;
    [SerializeField] private TextMeshProUGUI playerGold;

    private Character player;
    private void Start()
    {
        UIStatusButton.GetComponent<Button>().onClick.AddListener(OpenStatus);
        UIInventoryButton.GetComponent<Button>().onClick.AddListener(OpenInventory);
        BackButton.GetComponent<Button>().onClick.AddListener(OpenMainMenu);

        player = GameManager.instance.Player;
        SetMainUI();
    }
    //UI Player data 세팅
    private void SetMainUI()
    {
        playerName.text = player.PlayerName;
        playerLevel.text = $"{player.PlayerLevel}";
        playerCurExp.text = $"{player.CurrentExp}";
        playerMaxExp.text = $"{player.MaxExp}";
        playerGold.text = $"{player.Gold}";
        playerLevelBar.fillAmount = player.CurrentExp / player.MaxExp;
    }
    //메인으로 버튼
    public void OpenMainMenu()
    {
        ShowPanel(null);
        SetMainButtonsVisible(true);
    }

    //캐릭터 스탯창 버튼
    public void OpenStatus()
    {
        ShowPanel(UIManager.Instance.UIStatus.gameObject);
        SetMainButtonsVisible(false);
    }

    //인벤토리 버튼
    public void OpenInventory()
    {
        ShowPanel(UIManager.Instance.UIInventory.gameObject);
        SetMainButtonsVisible(false);
    }

    //해당 창 띄우기
    private void ShowPanel(GameObject panelToShow)
    {
        UIManager.Instance.UIStatus.gameObject.SetActive(false);
        UIManager.Instance.UIInventory.gameObject.SetActive(false);

        if (panelToShow != null)
            panelToShow.SetActive(true);
    }

    //메인에 있는 버튼 토글
    private void SetMainButtonsVisible(bool showMainButtons)
    {
        SetCanvasGroup(UIStatusButton.GetComponent<CanvasGroup>(), showMainButtons);
        SetCanvasGroup(UIInventoryButton.GetComponent<CanvasGroup>(), showMainButtons);
        SetCanvasGroup(BackButton.GetComponent<CanvasGroup>(), !showMainButtons);
    }

    //버튼 투명도,클릭감지 관리
    private void SetCanvasGroup(CanvasGroup group, bool visible)
    {
        group.alpha = visible ? 1f : 0f;
        group.interactable = visible;
        group.blocksRaycasts = visible;
    }
}
