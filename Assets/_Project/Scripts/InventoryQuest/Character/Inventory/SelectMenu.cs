using UnityEngine;

namespace InventoryQuest
{
    public class SelectMenu : MonoBehaviour
    {
        public void OpenCloseSelectMenu()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}