using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public abstract class Bonus : MonoBehaviour
public abstract class Bonus : MonoBehaviour
{
    public string Name = "None";
    public BonusType Type = BonusType.None;
    //public abstract void DoSomething();

    public virtual void OnTriggerEnter(Collider other)
    {
        CubeControl cube = other.GetComponent<CubeControl>();
        if (cube != null)
            UseBonus(cube);
    }
    protected virtual void UseBonus(CubeControl cube)
    {
        Destroy(gameObject);
    }
}

public enum BonusType
{ 
    None,
    Ice,
    Flash,
    Destroyer,
    Climber,
    Jumper,
    Knight,
    Coin,
    Reverse
}
