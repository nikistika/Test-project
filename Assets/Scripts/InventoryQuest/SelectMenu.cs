using UnityEngine;

namespace InventaryQuest
{
    public class SelectMenu : MonoBehaviour
    {
        
        public void OpenCloseSelectMenu()
        {
            gameObject.SetActive(!gameObject.activeSelf); 
        }
        
    }
}