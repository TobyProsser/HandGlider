using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPanelScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Back()
    {
        AudioManager.instance.Play("Click");
        this.gameObject.SetActive(false);
    }
}
