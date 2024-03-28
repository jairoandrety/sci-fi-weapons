using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Action<int, int> OnUpdateAmmo;

    public WeaponSetup setup;
    public Bullet bullet;
    public PowerEffect powerEffect;

    public abstract void Init();
    public abstract void Setup(WeaponSetup setup);
    public abstract void Shoot();
    public abstract void Reload();
}
