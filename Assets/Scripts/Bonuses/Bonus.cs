using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public abstract class Bonus : MonoBehaviour
public abstract class Bonus : MonoBehaviour
{
    public string Name = "None";
    public BonusType Type = BonusType.None;
    //public abstract void DoSomething();

    public abstract void OnTriggerEnter(Collider other);
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
    Coin
}
