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
        Instantiate(playerExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
