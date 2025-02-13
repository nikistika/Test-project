using UnityEngine;

public abstract class BaseCharacterScriptableObject : ScriptableObject
{

    [SerializeField] private string _characterName;
    [SerializeField, Min(0)] private int _health;
    [SerializeField, Min(0)] private float _speedAttack;
    [SerializeField, Min(0)] private int _damageMin;
    [SerializeField] private int _damageMax;

    public string CharacterName => _characterName;
    public int Health => _health;
    public float SpeedAttack => _speedAttack;
    public int DamageMin => _damageMin;
    public int DamageMax => _damageMax;

}
