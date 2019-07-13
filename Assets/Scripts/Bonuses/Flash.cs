using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : TimeDependentBonus
{
    [Range (0.1f, 0.5f)]
    public float accel = 0.1f; 
    [Range(0, 1)]
    public float deltaSpeed;
    public float boostKoef = 1.5f;
    protected override void UseBonus(CubeControl cube)
    {
        cube.enumerator = FlashEffect(cube);
        base.UseBonus(cube);
    }

    IEnumerator FlashEffect(CubeControl cube)
    {
        int iterationCount = 0;
        float basicSpeed = cube.Speed;
        float basicKoef = 1f;
        while (basicKoef < boostKoef)
        {
            basicKoef += accel;
            cube.Speed = basicSpeed * basicKoef;
            yield return new WaitForSeconds(deltaSpeed);
            iterationCount++;
        }
        cube.Speed = basicSpeed * boostKoef;

        yield return new WaitForSeconds(bonusDuration - 2 * (iterationCount * deltaSpeed));
        cube.Speed /= boostKoef;

        basicKoef = boostKoef;
        while (basicKoef > 1)
        {
            basicKoef -= accel;
            cube.Speed = basicSpeed * basicKoef;
            yield return new WaitForSeconds(deltaSpeed);
        }
        cube.Speed = basicSpeed;
    }
}
