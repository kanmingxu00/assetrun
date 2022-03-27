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
        money = 100;
        bitcoin = 0;
        gunlevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
