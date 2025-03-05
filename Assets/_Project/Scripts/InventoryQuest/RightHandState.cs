using System.Collections;
using System.Collections.Generic;
using Character;
using InventoryUI;
using Items;
using Scriptable_Objects;
using UnityEngine;

public class RightHandState : MonoBehaviour
{
    
    public GameObject CurrentWeapon { get; private set; }
    
    public void TakeWeapon(Item weapon, Vector3 position, Quaternion rotation)
    {
        var weaponData = weapon.ItemData as WeaponData;
        CurrentWeapon = Instantiate(weaponData.Prefab, transform);
        CurrentWeapon.transform.localPosition = position;
        CurrentWeapon.transform.localRotation = rotation;
    }

    public void ReturnCurrentWeaponinInventory()
    {
        
    }

    public void RemoveWeapon()
    {
        Destroy(CurrentWeapon);
    }
    
}
