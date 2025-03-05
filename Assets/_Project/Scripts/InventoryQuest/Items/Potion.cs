using Scriptable_Objects;
using TMPro;

namespace Items
{
    public class Potion : Item
    {
        private PotionData _potionData;

        private void Awake()
        {
            _potionData = ItemData as PotionData;
            Stackable = _potionData.Stackable;
        }

        public override void ItemEffect()
        {
            PanelHP.Heal(_potionData.HealQuantity);
            RemoveItemFromStack(1);
            InventoryMenu.RemoveWeightFromInventory(_potionData.WeightItem);
            if (CurrentCount <= 0) Destroy(gameObject);
            StatusText.GetComponent<TMP_Text>().text = $"{CurrentCount}/{_potionData.MaxCount}";
        }
    }
}