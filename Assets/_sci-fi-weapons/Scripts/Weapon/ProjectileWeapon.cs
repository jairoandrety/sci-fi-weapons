using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] private Transform shootOrigin;

    [SerializeField] private float rateOfFire = 1;
    [SerializeField] private int ammo = 1;
    [SerializeField] private float bulletSpeed;

    private int currentAmmo = 0;
    private float currentRateOfFire = 0;

    private bool isShooting= false;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        this.bullet = setup.bullet;
        this.powerEffect = setup.powerEffect;

        this.rateOfFire = setup.rateOfFire;
        this.ammo = setup.totalAmmo;
        this.bulletSpeed = setup.bulletSpeed;

        Reload();
    }

    public override void Setup(WeaponSetup setup)
    {
        this.setup = setup;
        Init();
    }

    public override void Reload()
    {
        currentAmmo = ammo;
        OnUpdateAmmo?.Invoke(currentAmmo, ammo);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            currentRateOfFire = rateOfFire;
            isShooting = true;
        }

        if(Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }

        if(isShooting)
        { 
            if (currentAmmo > 0)
            {
                currentRateOfFire += 1 * Time.deltaTime;
                if (currentRateOfFire >= rateOfFire)
                {
                    Shoot();
                    currentRateOfFire = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
    }

    public override void Shoot()
    {
        if (currentAmmo < 0)
            return;

        Bullet bulletShooted = Instantiate(bullet, shootOrigin.transform.position, shootOrigin.transform.rotation);
        bulletShooted.Init(setup.powerEffect, setup.applyGravity, setup.bulletSpeed);
        currentAmmo -= 1;
        OnUpdateAmmo?.Invoke(currentAmmo, ammo);
    }
}