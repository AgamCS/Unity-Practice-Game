using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    static WeaponManager _instance;
    public static WeaponManager Instance {get {return _instance;}}

    WeaponInput _primaryWeapon;
    WeaponInput _secondaryWeapon;
    WeaponInput _equippedWeapon;

    public WeaponInput PrimaryWeapon {get {return _primaryWeapon;}}
    public WeaponInput SecondaryWeapon {get {return _secondaryWeapon;}}
    public WeaponInput EquippedWeapon {get {return _equippedWeapon;}}

    // Create an instance of this class if one does not exist, if one does, then destory this object
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        SwitchInput();
    }

    // Switch between primary and secondary weapons using keybinds
    void SwitchInput()
    {
        if (Input.GetButtonDown("Primary Weapon"))
        {
            SwitchWeapons(_primaryWeapon);
        }
        else if (Input.GetButtonDown("Secondary Weapon"))
        {
            SwitchWeapons(_secondaryWeapon);
        }
    }

    
    public void SwitchWeapons(WeaponInput newWeapon)
    {
        _equippedWeapon = newWeapon;
    }

}
