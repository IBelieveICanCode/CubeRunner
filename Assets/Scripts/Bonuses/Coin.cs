using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Bonus
{
    protected override void UseBonus(CubeControl cube)
    {
        LevelProgress.Instance.Coins++;
        base.UseBonus(cube);
    }
}
