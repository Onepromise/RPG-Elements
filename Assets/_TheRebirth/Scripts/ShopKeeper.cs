using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{

    private bool canOpen;

    public string[] ItemsForSale = new string[40];



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canOpen && Input.GetButtonDown("Interact") && PlayerController.instance.canMove && !Shop.instance.shopMenu.activeInHierarchy)
        {
            Debug.Log("I see you");
            Shop.instance.itemsForSale = ItemsForSale;
            Shop.instance.OpenShop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }
    }

}
