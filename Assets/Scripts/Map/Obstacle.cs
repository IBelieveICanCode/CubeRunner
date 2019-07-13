using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Renderer obstacleRenderer;

    public ParticleSystem rubbles;
    //TODO: particle system in direction of player;

    private void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
    }

    public void Destroy(Vector3 currentFace)
    {
        LevelProgress.Instance.Score += 5;
        ParticleSystem myRubbles = Instantiate(rubbles, transform.position, Quaternion.identity);
        //Color color = new Color(obstacleRenderer.material.color.r, obstacleRenderer.material.color.g, obstacleRenderer.material.color.b, 1f);
        var main = myRubbles.main;
        Material mat = new Material(obstacleRenderer.material);
        myRubbles.GetComponent<ParticleSystemRenderer>().material = mat;
        myRubbles.transform.forward = currentFace;
        //main.startColor = color;
        myRubbles.Play();
        Destroy(gameObject);
    }

    void ChangeDirectionparticle()
    {

    }
}
