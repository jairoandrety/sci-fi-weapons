using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    public Weapon Weapon => weapon;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            WeaponStack weaponStack = other.GetComponent<WeaponStack>();
            if(weaponStack != null)
            {
                Weapon.Setup(weaponStack.WeaponSetup);
            }
        }
    }
}
