using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _nameItem;
    [SerializeField] private float _weightItem;
    [SerializeField] private Image _assetImage;
    [SerializeField] private GameObject _prefab;


    public int Id => _id;
    public string NameItem => _nameItem;
    public Image AssetImage => _assetImage;
    public GameObject prefub => _prefab;
    public float WeightItem => _weightItem;


}
