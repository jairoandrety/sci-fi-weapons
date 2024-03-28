using UnityEngine;

public class WeaponStack : MonoBehaviour
{
    [SerializeField] private WeaponSetup setup;

    public WeaponSetup WeaponSetup => setup;
}
