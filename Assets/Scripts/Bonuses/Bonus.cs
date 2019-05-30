using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public abstract class Bonus : MonoBehaviour
public class Bonus : MonoBehaviour
{
    public string Name = "None";
    public BonusType Type = BonusType.None;
    //public abstract void DoSomething();

    public Bonus()
    {
         
    }

    public Bonus(BonusType type, string name)
    {
        this.Type = type;
        this.Name = name;
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
    Knight
}
