using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Slider hpSlider;

    public Slider Mana;

    public void SetHUD(Unit unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

        Mana.maxValue = unit.maxMana;
        Mana.value = unit.currentMana;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void SetMana(int mana)
    {
        Mana.value = mana;
    }
}
