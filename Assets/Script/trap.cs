using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    
    public GameObject door;
    public ItemManager itemkey;
  
    void Start()
    {
        itemkey = itemkey.GetComponent<ItemManager>();
    }
        void OnTriggerEnter(Collider other)
    {
        if (itemkey.GetItemFlag(ItemManager.Item.Key)==true)
        {
              if (other.gameObject.tag == "Player")
             {
                   Debug.Log("ひらく");
               door.SetActive(false);
             }

        }
    }
}
