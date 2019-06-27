using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeDependentBonus : Bonus
{
    [SerializeField]
    protected float bonusDuration = 10f;
}
