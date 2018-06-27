using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trap : MonoBehaviour
{
    
    public GameObject door;
    public ItemManager itemkey;
    public GameObject text;
    public GameObject di;
    bool Textflag = false;
    float time;
    float timeMax = 60.0f;

    private GameObject player;
    ItemManager ItemScript;

    public AudioSource audioSource;
    [SerializeField]
    AudioClip audioClipDoor;

    void Start()
    {
        player = GameObject.Find("Player");
        ItemScript = player.GetComponent<ItemManager>();
        itemkey = itemkey.GetComponent<ItemManager>();
        audioSource = audioSource.GetComponent<AudioSource>();
        audioSource.clip = audioClipDoor;
    }
    void OnTriggerEnter(Collider other)
    {
      　//プレイヤーと当たっていたら
        if (other.gameObject.tag == "Player")
        { //鍵を持っていたら   
            if (itemkey.GetItemFlag(ItemManager.Item.Key) == true)
            {
                door.SetActive(false);
                di.SetActive(false);
                audioSource.Play();
                ItemScript.UseKey();
            }
            else
            {
                text.SetActive(true);
                time =0;
                Textflag = true;
            }
        }
    }
    void Update()
    {
        if(Textflag==true)
        {
            time += 1;
            if (time > timeMax)
            {
                text.SetActive(false);
                Textflag = false;
            }
        }
    }
}
