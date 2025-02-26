using Character;
using Items;
using Scriptable_Objects;
using UnityEngine;

namespace Items
{
    public class Mace : Item
    {
        [SerializeField] private MaceData _maceData;
        [SerializeField] private GameObject _hand_r;

        private void Awake()
        {
            base.Awake();
            Stackable = _maceData.Stackable;
        }

        internal override void ClickAddItemPanelAction(GameObject slot)
        {
            Debug.Log($"ClickAddItemPanelAction: {slot.name}");
            if (InventoryObject.InventoryMaxWeight >= InventoryObject.CurrentWeight + _maceData.WeightItem)
            {
                NewItem = Instantiate(gameObject, slot.transform);
                TextNewItem = NewItem.GetComponent<Mace>().StatusText;

                InventoryObject.AddWeightInInventory(_maceData.WeightItem);
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

            Vector3 positionPrefab = new(0.04f, -0.05f, -0.38f);
            Quaternion rotationPrefab = Quaternion.Euler(-22.03f, 102.94f, 88.974f);

            GameObject newMace = Instantiate(_maceData.Prefub, _hand_r.transform);
            newMace.transform.localPosition = positionPrefab;
            newMace.transform.localRotation = rotationPrefab;

            Destroy(gameObject);
            InventoryObject.RemoveInFroInventory(_maceData.WeightItem);
        }
    }
}