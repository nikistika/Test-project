using System.Collections;
using System.Collections.Generic;
using InventoryUI;
using Items;
using UnityEngine;

public class RightHandState : MonoBehaviour
{
    
    public GameObject CurrentWeapon { get; private set; }
    
    public void TakeWeapon(Item weapon, Vector3 position)
    {
        // var localPosition = gameObject.transform
        CurrentWeapon = Instantiate(weapon.gameObject, position, Quaternion.identity, transform);
    }

    public void RemoveWeapon()
    {
        Destroy(CurrentWeapon);
    }
    
}
