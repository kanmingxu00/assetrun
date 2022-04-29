using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    string[,] upgradeStrings = new string[3, 7]
        {
            { "heal-20-20", "movespeed-1-10", "heal-10-10", "movespeed-2-22", "movespeed-3-35", "rof-1-30", "rof-2-50", },
            { "rof-1-1", "damage-2-1", "rspeed-1-1", "clip-2-1", "damage-5-2", "rspeed-2-2", "rspeed-3-3" },
            { "rof-1-0", "damage-2-0", "clip-15-0", "rspeed-2-0", "damage-5-0", "clip-30-0", "rspeed-3-0" }
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
        return (name == "Reload Speed" ? "-" : "+") + upgradessplit[1] + " " + name + ", " + upgradessplit[2];
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
        GameObject weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder");
        int selectedWeapon = weaponHolder.GetComponent<WeaponSwitching>().selectedWeapon;
        Transform child = weaponHolder.transform.GetChild(selectedWeapon);
        
        string upgradestring = upgrades(upgradeNumber, shopNumber);
        string[] upgradessplit = upgradestring.Split('-');

        int cost = int.Parse(upgradessplit[2]);
        int value = int.Parse(upgradessplit[1]);
        switch (upgradessplit[0])
        {
            case "heal":
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Heal(value);
                break;
            case "movespeed":
                GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>().moveSpeed += value;
                break;
            case "rof":
                child.GetComponent<Gun>().fireRate += value;
                break;
            case "damage":
                child.GetComponent<Gun>().damage += value;
                break;
            case "clip":
                child.GetComponent<Gun>().maxAmmo += value;
                break;
            case "rspeed":
                child.GetComponent<Gun>().reloadTime -= value;
                break;
            default:
                name = "ERROR";
                break;
        }
        if (shopNumber == 0)
        {
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Database>().SubMoney(cost);
        }
        else if (shopNumber == 1)
        {
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Database>().SubBitcoin(cost);
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
