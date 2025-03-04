using _Project.Scripts.InventoryQuest;
using Scriptable_Objects;
using TMPro;
using UnityEngine;

namespace Items
{
    public class Book : Item
    {
        private const string ReadItStatus = "Прочитано";

        private BookData _bookData;

        private bool _readIt;

        private void Awake()
        {

            _bookData = ItemData as BookData;

            //WeightItem = ItemData.WeightItem;
            
            Stackable = _bookData.Stackable;
        }

        public override void ItemEffect()
        {
            _readIt = true;
            StatusText.GetComponent<TMP_Text>().text = ReadItStatus;
        }
        
        
    }
}