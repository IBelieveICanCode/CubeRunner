using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ParticleSystem rubbles;
    //TODO: particle system in direction of player;
    public void Destroy()
    {
        LevelProgress.Instance.Score += 5;
        Instantiate(rubbles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
