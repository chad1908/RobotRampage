using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    //scnenes
    public const string SceneBattle = "Battle";
    public const string SceneMenu = "MainMenu";

    // Gun Types
    public const string Pistol = "Pistol";
    public const string Shotgun = "Shotgun";
    public const string AssaultRifle = "AssaultRifle";

    //Robot Types
    public const string Redrobot = "Redrobot";
    public const string Bluerobot = "Bluerobot";
    public const string Yellowrobot = "Yellowrobot";

    // Pickup Types
    public const int PickupPistolAmmo = 1;
    public const int PickupAssaultAmmo = 2;
    public const int PickupShotgunAmmo = 3;
    public const int PickupHealth = 4;
    public const int PickupArmour = 5;

    //Misc
    public const string Game = "Game";
    public const float CameraDefaultZoom = 60f;

    public static readonly int[] AllPickupTypes = new int[5]
    {
       PickupPistolAmmo,
       PickupAssaultAmmo,
       PickupShotgunAmmo,
       PickupHealth,
       PickupArmour
    };
}

