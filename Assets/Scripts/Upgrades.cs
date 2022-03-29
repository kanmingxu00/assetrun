using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // upgrade and shop numbers, shopnumber is 0 or 1 for money/bitcoin
    public string getUpgrade(int upgradeNumber, int shopNumber)
    {
        if (shopNumber == 0) {
            return "heal"; // these values will be stored in a database,
            // as well as be coded like movespeed-1-20 for values/cost
        } else
        {
            return "movespeed";
        }
    }

    // upgrade and shop numbers, shopnumber is 0 or 1 for money/bitcoin
    // this will be changed
    public void useUpgrade(int upgradeNumber, int shopNumber)
    {
        if (shopNumber == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Heal(20);
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Database>().SubMoney(20);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>().moveSpeed += .3f;
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Database>().SubBitcoin(2);
        }
    }
}
