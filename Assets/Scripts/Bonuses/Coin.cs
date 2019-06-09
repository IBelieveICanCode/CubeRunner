using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Bonus
{
    public override void OnTriggerEnter(Collider other)
    {
        print("coin +1");
    }
}
