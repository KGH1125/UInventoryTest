using System.Collections.Generic;
using UnityEngine;

public enum STAT
{
    Attack,    // 공격력
    Defense,   // 방어력
    Health,    // 체력
    Critical   // 치명타
}

public class Character
{
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Critical { get; private set; }

    public List<Item> Inventory { get; private set; }
    public string PlayerName { get; private set; }
    public int PlayerLevel { get; private set; }
    public int CurrentExp { get; private set; }
    public int MaxExp { get; private set; }
    public int Gold { get; private set; }

    public Character(string name)
    {
        PlayerName = name;
        SetData();
    }

    private void SetData()
    {
        //stat정보
        Attack = 1;
        Defense = 0;
        Health = 10;
        Critical = 5;

        //기본정보
        PlayerLevel = 1;
        CurrentExp = 1;
        MaxExp = 10;
        Gold = 0;
        Inventory = new List<Item>();
    }

    //플레이어 스텟 더하기
    public void AddPlayerStat(STAT stat, int value)
    {
        switch (stat)
        {
            case STAT.Attack: Attack += value; break;
            case STAT.Defense: Defense += value; break;
            case STAT.Health: Health += value; break;
            case STAT.Critical: Critical += value; break;
        }
    }

    //플레이어 스텟 빼기
    public void SubtractPlayerStat(STAT stat, int value)
    {
        switch (stat)
        {
            case STAT.Attack: Attack = Mathf.Max(0, Attack - value); break;
            case STAT.Defense: Defense = Mathf.Max(0, Defense - value); break;
            case STAT.Health: Health = Mathf.Max(0, Health - value); break;
            case STAT.Critical: Critical = Mathf.Max(0, Critical - value); break;
        }
    }

    //플레이어 이름 바꾸기
    public void SetPlayerName(string name) => PlayerName = name;

    //플레이어 경험치 획득
    public void AddPlayerExp(int exp)
    {
        CurrentExp += exp;
        if (CurrentExp >= MaxExp)
        {
            CurrentExp -= MaxExp;
            MaxExp += 10;
            PlayerLevel++;
        }
    }

    //플레이어 골드 획득
    public void AddPlayerGold(int value) => Gold += value;

    //플레이어 골드 소모
    public bool SpendPlayerGold(int value)
    {
        if (Gold >= value)
        {
            Gold -= value;
            return true;
        }
        return false;
    }

    //인벤토리에 아이템 추가
    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    //아이템 장착
    public void Equip(Item item)
    {
        item.isEquipped = true;
        AddPlayerStat(STAT.Attack, item.itemAttack);
        AddPlayerStat(STAT.Defense, item.itemDefense);
        AddPlayerStat(STAT.Health, item.itemHealth);
        AddPlayerStat(STAT.Critical, item.itemCritical);
    }

    //아이템 해제
    public void UnEquip(Item item)
    {
        item.isEquipped = false;
        SubtractPlayerStat(STAT.Attack, item.itemAttack);
        SubtractPlayerStat(STAT.Defense, item.itemDefense);
        SubtractPlayerStat(STAT.Health, item.itemHealth);
        SubtractPlayerStat(STAT.Critical, item.itemCritical);
    }
}
