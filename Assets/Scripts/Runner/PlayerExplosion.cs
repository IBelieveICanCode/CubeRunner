using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion: MonoBehaviour
{
    private Renderer playerRenderer;
    public ParticleSystem playerExplosion;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    public void InvokeExplosion()
    {
        //GameObject obstacleParticles = Instantiate(playerExplosion.gameObject, transform.position, Quaternion.identity) as GameObject;
        GameObject obstacleParticles = Instantiate(playerExplosion.gameObject, transform.position, Quaternion.identity) as GameObject;
        Color color = new Color(playerRenderer.material.color.r, playerRenderer.material.color.g, playerRenderer.material.color.b, 1f);
        var main = obstacleParticles.GetComponent<ParticleSystem>().main;
        main.startColor = color;
        obstacleParticles.transform.forward = -GetComponent<CubeControl>().currentFace.normalized;
        obstacleParticles.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
