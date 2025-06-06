using UnityEngine;
public enum STAT
{
    Attack,// 공격력
    Defense,// 방어력
    Health,// 체력
    Critical// 치명타
}

public class Charater : MonoBehaviour
{
    [SerializeField]
    private int attack;//공격력
    [SerializeField]
    private int defense;//방어력
    [SerializeField]
    private int health;//체력
    [SerializeField]
    private int critical;//치명타
    //private EquipItem[] items;//소지한 아이템들

    //플레이어 정보 가져오기
    public int GetPlayerStat(STAT stat)
    {
        switch (stat)
        {
            case STAT.Attack: return attack;
            case STAT.Defense: return defense;
            case STAT.Health: return health;
            case STAT.Critical: return critical;
        }
        return -1;
    }

    //플레이어 정보 더하기
    public void AddPlayerStat(STAT stat, int value)
    {
        switch (stat)
        {
            case STAT.Attack: attack += value; break;
            case STAT.Defense: defense += value; break;
            case STAT.Health: health += value; break;
            case STAT.Critical: critical += value; break;
        }
    }

    //플레이어 정보 빼기
    public void subtractPlayerStat(STAT stat, int value)
    {
        switch (stat)
        {
            case STAT.Attack: attack -= value < 0 ? attack = 0 : attack -= value; break;
            case STAT.Defense: defense -= value < 0 ? defense = 0 : defense -= value; break;
            case STAT.Health: health -= value < 0 ? health = 0 : health -= value; break;
            case STAT.Critical: critical -= value < 0 ? critical = 0 : critical -= value; break;
        }
    }

}
