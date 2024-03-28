using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSetup", menuName = "Weapons/Setup", order = 1)]
public class WeaponSetup : ScriptableObject
{
    public Bullet bullet;
    public PowerEffect powerEffect;

    public float rateOfFire = 1;
    public int totalAmmo = 1;
    public bool applyGravity = false;
    public float bulletSpeed = 1;
}
