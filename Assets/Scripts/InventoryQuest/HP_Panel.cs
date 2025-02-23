using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HP_Panel : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int HP;

    [SerializeField] private Slider _hpSlider;
    [SerializeField] private TMP_Text _hpCharacterTMP;

    private void Awake()
    {
        HP = maxHealth;
        _hpSlider.maxValue = maxHealth;
        EditHPPanel(HP);
    }

    private void GetDamage(int damage)
    {
        if (HP - damage < 0)
        {
            HP = 0;
            EditHPPanel(HP);
        }
        else if (HP > 0)
        {
            HP -= damage;
            EditHPPanel(HP);
        }
    }

    public void Heal(int healCount)
    {
        if (HP < maxHealth)
        {
            HP += healCount;
            EditHPPanel(HP);
        }

        if (HP >= maxHealth)
        {
            HP = maxHealth;
            EditHPPanel(HP);
        }
    }

    private void EditHPPanel(int hp)
    {
        _hpSlider.value = hp;
        _hpCharacterTMP.text = $"{hp}/{maxHealth}";
    }

    public void Get25Damage() => GetDamage(25);
}