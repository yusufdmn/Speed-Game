using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ways : MonoBehaviour
{
    float posX;
    public ParticleSystem crushParticles;

    public float tSpeed;
    float t;

    Vector3 left;
    Vector3 right;

    bool shouldMove;

    void Start()
    {
        int rndNumber = Random.Range(0, 5);
        if (rndNumber < 2)
        {
            shouldMove = true;
            tSpeed = Random.Range(0.2f, 0.55f);
        }
        
        
        posX = transform.position.x;
        float c = Random.Range(0.4f, 0.8f);
        left = new Vector3(posX - c , transform.position.y, transform.position.z);
        right = new Vector3(posX + c, transform.position.y, transform.position.z);

    }


    void Update()
    {

        if (shouldMove)
        {
            MyLerp();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            crushParticles.transform.position = new Vector3(collision.gameObject.transform.position.x, crushParticles.transform.position.y, crushParticles.transform.position.z);
            crushParticles.Play();
            shouldMove = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(gameObject, 3);
        }

    }

    void MyLerp()
    {
        t += Time.deltaTime * tSpeed;
        transform.position = Vector3.Lerp(right, left, t);

        if (t >= 1)
        {
            var a = right;
            var b = left;
            right = b;
            left = a;
            t = 0;
        }
    }
    
}
