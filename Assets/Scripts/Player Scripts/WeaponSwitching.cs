using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeaponIndex = 0;
    public GameObject selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousselectedWeaponIndex = selectedWeaponIndex;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeaponIndex >= transform.childCount - 1)
            {
                selectedWeaponIndex = 0;
            } 
            else
            {
                selectedWeaponIndex++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeaponIndex <= 0)
            {
                selectedWeaponIndex = transform.childCount - 1;
            }
            else
            {
                selectedWeaponIndex--;
            }
        }

        if (previousselectedWeaponIndex != selectedWeaponIndex);
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
                selectedWeapon = weapon.gameObject;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
