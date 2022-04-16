using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    // how much money you have, it's per level
    public static int money;
    // bitcoin carries through levels
    public static int bitcoin;
    // gunlevel is what level your gun is, starts at 0, can be upgraded
    // this can be expanded on more for different gun types, but for
    // simplicity sake, we do one gun with stats upgrades for now
    public static int gunlevel;
    // Start is called before the first frame update

    
    void Start()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        } else
        {
            money = 100;
        }

        if (PlayerPrefs.HasKey("bitcoin"))
        {
            bitcoin = PlayerPrefs.GetInt("bitcoin");
        }
        else
        {
            bitcoin = 0;
        }

        if (PlayerPrefs.HasKey("gunlevel"))
        {
            gunlevel = PlayerPrefs.GetInt("gunlevel");
        }
        else
        {
            gunlevel = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (LevelManager.isGameOver && LevelManager.isWon)
        {
            PlayerPrefs.SetInt("bitcoin", bitcoin);
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("gunlevel", gunlevel);
            PlayerPrefs.Save();
        }
    }

    public void AddMoney(int add)
    {
        money += add;
    }

    public void SubMoney(int sub)
    {
        money -= sub;
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddBitcoin(int add)
    {
        bitcoin += add;
    }

    public void SubBitcoin(int sub)
    {
        bitcoin -= sub;
    }
}
