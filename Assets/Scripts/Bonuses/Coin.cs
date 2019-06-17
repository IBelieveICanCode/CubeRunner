using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Bonus
{

    public override void OnTriggerEnter(Collider other)
    {
        LevelProgress.Instance.Coins++;
        Destroy(gameObject);
    }

}
