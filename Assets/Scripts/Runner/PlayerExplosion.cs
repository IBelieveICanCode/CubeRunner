using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion: MonoBehaviour
{
    public ParticleSystem playerExplosion;

    private void Start()
    {
        GameController.Instance.GameOverEvent.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        GameObject obstacleParticles = Instantiate(playerExplosion.gameObject, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}
