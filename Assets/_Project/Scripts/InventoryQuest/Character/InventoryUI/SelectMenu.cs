using UnityEngine;

namespace InventoryUI
{
    
    public class SelectMenu : MonoBehaviour
    {
        public void OpenCloseSelectMenu()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}