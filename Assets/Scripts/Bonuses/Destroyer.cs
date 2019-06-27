using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : TimeDependentBonus
{
    protected override void UseBonus(CubeControl cube)
    {
        // cube.BonusEvent += () => StartCoroutine(PlayerIsDestroyer());
        cube.enumerator = PlayerIsDestroyer(cube);
        base.UseBonus(cube);
    }

    IEnumerator PlayerIsDestroyer(CubeControl cube)
    {
        cube.isDestroyer = true;
        yield return new WaitForSeconds(bonusDuration);
        cube.isDestroyer = false;
    }
}
