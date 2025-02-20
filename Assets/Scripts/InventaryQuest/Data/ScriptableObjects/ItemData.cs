using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private string _nameItem;
    [SerializeField] private float _weightItem;
    [SerializeField] private bool _stackable;
    [SerializeField] private Sprite _assetImage;


    public string NameItem => _nameItem;
    public Sprite AssetImage => _assetImage;
    public bool Stackable => _stackable;
    public float WeightItem => _weightItem;


}
