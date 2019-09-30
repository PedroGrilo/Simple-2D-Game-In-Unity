using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour{

    private static int hearts = 1;
    private static int coins = 0;
    private static int fireball = 3;

    public static int Coins{
        get => coins;
        set => coins = value;
    }

    public static int Hearts{
        get => hearts;
        set => hearts = value;
    }

    public static int Fireball{
        get => fireball;
        set => fireball = value;
    }
}
