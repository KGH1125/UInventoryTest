using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AttackData;
    [SerializeField] private TextMeshProUGUI DefenseData;
    [SerializeField] private TextMeshProUGUI HealthData;
    [SerializeField] private TextMeshProUGUI CriticalData;

    private Character player;

    private void Awake()
    {
        player = GameManager.instance.Player;
    }
    private void Start()
    {
        UpdateUIStatus();
    }

    public void UpdateUIStatus()
    {
        AttackData.text = $"{player.Attack}";
        DefenseData.text = $"{player.Defense}";
        HealthData.text = $"{player.Health}";
        CriticalData.text = $"{player.Critical}";
    }
}
