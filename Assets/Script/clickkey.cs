using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickkey : MonoBehaviour {

    public GameObject opUI;
    public GameObject loadUI;
    public GameObject textT;
    private Vector3 posloadUI;
    private Vector3 posopUI;

    void Start()
    {
        posopUI = opUI.GetComponent<RectTransform>().anchoredPosition;
        opUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(555, 0, 0);
    }
    public void openui()
    {
        posloadUI = loadUI.GetComponent<RectTransform>().anchoredPosition;
        loadUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(555, 0, 0);
        opUI.GetComponent<RectTransform>().anchoredPosition= posopUI;
        textT.SetActive(false);
    }

    public void cui()
    {
        loadUI.GetComponent<RectTransform>().anchoredPosition = posloadUI;
        opUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(555, 0, 0);
        textT.SetActive(true);
    }
    
}
