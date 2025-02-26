using Character;
using Scriptable_Objects;
using UnityEngine;

namespace Items
{
    public class Shield : Item
    {
        
        [SerializeField] private ShieldData _shieldData;
        [SerializeField] private GameObject _hand_r;

        private void Awake()
        {
            base.Awake();
            Stackable = _shieldData.Stackable;
        }

        internal override void ClickAddItemPanelAction(GameObject slot)
        {
            if (InventoryObject.InventoryMaxWeight >= InventoryObject.CurrentWeight + _shieldData.WeightItem)
            {
                NewItem = Instantiate(gameObject, slot.transform);
                TextNewItem = NewItem.GetComponent<Shield>().StatusText;

                InventoryObject.AddWeightInInventory(_shieldData.WeightItem);
                TextNewItem.SetActive(true);
            }
        }

        internal override void ClickInventoryPanelAction()
        {
            GameObject handRight = GameObject.FindGameObjectWithTag("Hand_r");
            bool hasChildWithTag = false;
            GameObject otherWeapon = null;
            foreach (Transform child in handRight.transform)
            {
                if (child.CompareTag("Weapon")) // Проверка тега
                {
                    hasChildWithTag = true;
                    otherWeapon = child.gameObject;
                    break; // Если нашли, можно сразу выйти из цикла
                }
            }

            if (hasChildWithTag && otherWeapon != null)
            {
                otherWeapon.GetComponent<Weapon>().ReturnItemInInventory();
            }

            Vector3 positionPrefab = new(0.37f, 0, -0.23f);
            Quaternion rotationPrefab = Quaternion.Euler(-72, -282, 36);

            GameObject newShield = Instantiate(_shieldData.Prefab, _hand_r.transform);
            newShield.transform.localPosition = positionPrefab;
            newShield.transform.localRotation = rotationPrefab;

            Destroy(gameObject);
            InventoryObject.RemoveInFroInventory(_shieldData.WeightItem);
        }
    }
}