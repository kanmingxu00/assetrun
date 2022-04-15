using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    string[,] upgradeStrings = new string[3, 5]
        {
            { "heal-20-20", "movespeed-1-10", "heal-10-10", "movespeed-2-22", "movespeed-3-35"},
            { "rof-1-1", "damage-2-1", "clip-2-1", "rspeed-1-1", "damage-5-2" },
            { "rof-1-0", "damage-2-0", "clip-2-0", "rspeed-1-0", "damage-5-0" }
        };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string upgrades(int upgradeNumber, int shopNumber)
    {
        
        return upgradeStrings[shopNumber, upgradeNumber];
    }

    // upgrade and shop numbers, shopnumber is 0 or 1 for money/bitcoin
    public string getUpgrade(int upgradeNumber, int shopNumber)
    {
        string upgradestring = upgrades(upgradeNumber, shopNumber);
        string[] upgradessplit = upgradestring.Split('-');
        string name;
        switch(upgradessplit[0])
        {
            case "heal":
                name = "Health";
                break;
            case "movespeed":
                name = "Speed";
                break;
            case "rof":
                name = "Fire Rate";
                break;
            case "damage":
                name = "Damage";
                break;
            case "clip":
                name = "Magazine Size";
                break;
            case "rspeed":
                name = "Reload Speed";
                break;
            default:
                name = "ERROR";
                break;
        }
        return "+" + upgradessplit[1] + " " + name + ", " + upgradessplit[2];
    }

    public int getUpgradeCost(int upgradeNumber, int shopNumber)
    {
        string upgradestring = upgrades(upgradeNumber, shopNumber);
        string[] upgradessplit = upgradestring.Split('-');
        int cost = int.Parse(upgradessplit[2]);
        return cost;
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
        else if (shopNumber == 1)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>().moveSpeed += .3f;
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Database>().SubBitcoin(1);
        } else
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>().moveSpeed += 1.0f;
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Database>().SubBitcoin(2);
        }
        // Allocate shopNumber to these upgrade buttons
        /**
         if (shopNumber == 3)
        {
            increaseDamage(weapon1)
        }
        elif (shopNumber == 4)
        {
            increaseDamage(weapon2)
        }
        ...
         */
    }

    public void increaseDamage(GameObject weapon)
    {
        Gun weaponComponent;
        weaponComponent = weapon.GetComponent<Gun>();
        weaponComponent.damage += 20;

    }
}
