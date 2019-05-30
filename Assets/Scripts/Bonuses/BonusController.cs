using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public List<Bonus> bonuses = new List<Bonus> 
    { 
    new Bonus { Type = BonusType.Destroyer,Name="Destoyer" },
    new Bonus(BonusType.Flash,"Flash"),
    new Bonus { Name="Ice", Type = BonusType.Ice },
    new Bonus (BonusType.Jumper,"It's a jumper")
    };

    //This called indexer
    //How to call it look at GameController Start
    //Easy way to get bonus for spawn of any type
    //Also can contain set function
    public string this[BonusType type]
    { 
        get
        { 
            foreach(var b in bonuses)
            {
                if (b.Type == type)
                    return b.Name;
            }
            return "No such type bonus in this list";
        }
    }


}
