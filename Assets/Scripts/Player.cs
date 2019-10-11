using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int armor;
    public GameUI gameUI;
    private GunEquipper gunEquipper;
    private Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        int healthDamage = amount;
        if (armor > 0)
        {
        int effectiveArmor = armor * 2;
        effectiveArmor -= healthDamage;
        // If there is still armor, don't need to process
        // health damage
        if (effectiveArmor > 0)
        {
        armor = effectiveArmor / 2;
        return;
        }
            armor = 0;
        }
        health -= healthDamage;
        Debug.Log("Health is " + health);
        if (health <= 0)
        {
            Debug.Log("GameOver");
        }
    }

    private void pickUpHealth()
    {
        health += 50;
        if (health > 200)
        {
            health = 200;
        }
    }
    private void PickUpArmor()
    {
        armor += 15;
    }
    // 2
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
    }
    private void pickUpPisolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
    }
    private void pickUpShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
    }

    public void PickUpItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.PickUpArmour:
                PickUpArmor();
                break;
            case Constants.PickUpHealth:
                pickUpHealth();
                break;
            case Constants.PickUpAssaultRifleAmmo:
                pickupAssaultRifleAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                pickUpPisolAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                pickUpShotgunAmmo();
                break;
            default:
                Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
}
