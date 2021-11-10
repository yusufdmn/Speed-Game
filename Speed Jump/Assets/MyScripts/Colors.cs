using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{

    public Material wayMat;
    public Material firstWayMat;
    public Material ballMat;
    public Material EndWayMat;

    public Color[] backgroundColors;
    public Color[] wayColors;
    public Color[] firstWayColors;
    public Color[] ballColors;
    public Color[] EdnWayColors;

    public Camera mainCamera;

    public 

    void Start()
    {
        int index = Random.Range(0, ballColors.Length);

        ballMat.color = ballColors[index];
        wayMat.color = wayColors[index];
        firstWayMat.color = firstWayColors[index];
        EndWayMat.color = EdnWayColors[index];
        mainCamera.backgroundColor = backgroundColors[index];

        GameObject[] crushParticles = GameObject.FindGameObjectsWithTag("crush");
        for (int i = 0; i < crushParticles.Length; i++)
        {
            var main = crushParticles[i].GetComponent<ParticleSystem>().main;
            main.startColor = wayColors[index];
        }
    }


}
