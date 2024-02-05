using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int level = 1;
    public int currentExp = 0;
    public int requiredExp = 10;

    public int gold = 1000;

    public int baseAtk = 10;
    public int currentAtk = 10;
    public int baseDef = 10;
    public int currentDef = 10;
    public int baseHp = 100;
    public int currentHp = 100;
    public int baseCrt = 5;
    public int currentCrt = 5;

    private void Awake()
    {
    }

    public void GetPlayerExp(int amount)
    {
        currentExp += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        while (currentExp >= requiredExp)
        {
            currentExp -= requiredExp;
            PlayerLevelUp();
            SetRequiredExp();
        }
    }

    private void PlayerLevelUp()
    {
        level++;
        baseAtk += 10;
        baseDef += 10;
        baseHp += 50;
        baseCrt += 5;
        UpdateStats();
    }

    private void UpdateStats()
    {
        currentAtk = baseAtk;
        currentDef = baseDef;
        currentHp = baseHp;
        currentCrt = baseCrt;
    }

    private void SetRequiredExp()
    {
        requiredExp = (int)(requiredExp + requiredExp * (1.3f * level));
    }
}
