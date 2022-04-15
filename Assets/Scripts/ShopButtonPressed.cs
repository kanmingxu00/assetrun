using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopButtonPressed : MonoBehaviour
{
    public int ButtonNumber;
    public GameObject shopKeeper;
    private Button MyButton = null;
    public int shopNumber = 0;
    private int cost;
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponentInChildren<Text>();
        text.text = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Upgrades>().getUpgrade(ButtonNumber, shopNumber);
        cost = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Upgrades>().getUpgradeCost(ButtonNumber, shopNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        if (Database.money >= cost)
        {
            shopKeeper.GetComponent<MoneyShopScript>().ButtonPressed(ButtonNumber, shopNumber);
            gameObject.SetActive(false);
        } else
        {
            Debug.Log("NOT ENOUGH MONEY");
        }
    }
}
