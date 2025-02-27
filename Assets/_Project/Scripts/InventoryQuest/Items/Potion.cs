using Scriptable_Objects;
using TMPro;
using UnityEngine;

namespace Items
{
    public class Potion : Item
    {
        
        public int CurrentCount;
        
        [SerializeField] private PotionData _potionData;
        
        private void Awake()
        {
            base.Awake();
            Stackable = _potionData.Stackable;
        }

        public override void ClickAddItemPanelAction(GameObject slot)
        {
            if (InventoryObject.InventoryMaxWeight >= InventoryObject.CurrentWeight + _potionData.WeightItem)
            {
                NewItem = Instantiate(gameObject, slot.transform);
                NewItem.GetComponent<Potion>().CurrentCount = 1;
                NewItem.GetComponent<Potion>().StatusText.GetComponent<TMP_Text>().text =
                    $"{NewItem.GetComponent<Potion>().CurrentCount}/{_potionData.MaxCount}";
                TextNewItem = NewItem.GetComponent<Potion>().StatusText;

                InventoryObject.AddWeightInInventory(_potionData.WeightItem);
                TextNewItem.SetActive(true);
            }
        }

        public override void ClickAddItemPanelAction(GameObject slot, int quantityItem)
        {
            if (InventoryObject.InventoryMaxWeight >= InventoryObject.CurrentWeight + _potionData.WeightItem)
            {
                var potion = slot.transform.GetChild(0).gameObject.GetComponent<Potion>();
                // potion = (potion == null) ? return : potion.GetComponent<Potion>();
                if (potion.CurrentCount + quantityItem <= _potionData.MaxCount)
                {
                    potion.CurrentCount += quantityItem;
                    InventoryObject.AddWeightInInventory(_potionData.WeightItem);

                    potion.StatusText.GetComponent<TMP_Text>().text = $"{potion.CurrentCount}/{_potionData.MaxCount}";
                }
                else if (potion.CurrentCount + quantityItem > _potionData.MaxCount)
                {
                    potion.gameObject.tag = FULL_STACK;
                    OnClickIcon();
                }
            }
        }

        protected override void ClickInventoryPanelAction()
        {
            PanelHP.Heal(_potionData.HealQuantity);
            CurrentCount -= 1;
            InventoryObject.RemoveInFroInventory(_potionData.WeightItem);
            if (CurrentCount <= 0) Destroy(gameObject);
            StatusText.GetComponent<TMP_Text>().text = $"{CurrentCount}/{_potionData.MaxCount}";
        }
    }
}