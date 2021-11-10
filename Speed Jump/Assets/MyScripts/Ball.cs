using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public CanvasGame canvasGame;

    public AudioSource crushhSound;
    public AudioSource winSound;

    public GameObject effectEndSign;
    public GameObject lastEffects;

    public GameObject mainCamera;

    Rigidbody rb;

    Vector3 vectorUp;
    Vector3 vectorRight;
    Vector3 vectorLeft;
    Vector3 vectorForward;
    public float speedUp;
    public float speedSide;
    public float speedForward;


    void Start()
    {

        vectorUp = new Vector3(0, speedUp, 0);
        vectorForward = new Vector3(0, speedUp, speedForward);

        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveSide();

        FailCheck();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CanvasGame.isStarted = true;
            canvasGame.RemoveSwipe();
        }
        if (Input.touchCount > 0)
        {

            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                CanvasGame.isStarted = true;
                canvasGame.RemoveSwipe();
            }
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.layer)
        {
            case 10:
                if (CanvasGame.isStarted)
                {
                    rb.AddForce(vectorForward);
                }
                else
                {
                    rb.AddForce(vectorUp);
                }
                break;
            case 9:
                crushhSound.Play();
                rb.isKinematic = true;
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;
                
                rb.AddForce(vectorForward);

                break;
            case 11:
                winSound.Play();
                StartCoroutine(LevelEnded());
                break;
        }
    }


    void FailCheck()
    {
        if(gameObject.transform.position.y < -3)
        {
            CanvasGame.isFailed = true;
            canvasGame.PopUpPanelFail();
            mainCamera.transform.parent = null;
        }
    }

    IEnumerator LevelEnded()
    {
        Time.timeScale = 1;
        CanvasGame.isEnded = true;
        effectEndSign.SetActive(false);
        lastEffects.SetActive(true);
        lastEffects.transform.position = new Vector3(transform.position.x, lastEffects.transform.position.y, lastEffects.transform.position.z);
        yield return new WaitForSeconds(1);
        canvasGame.PopUpPanelEnd();
    }

    void MoveSide()
    {

        if (CanvasGame.isStarted & !CanvasGame.isFailed & !CanvasGame.isEnded)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                float width = Screen.width / 2.0f;

                Vector3 pos = touch.position;
                pos.x = (pos.x - width);

                transform.Translate(new Vector3( pos.x, 0, 0) * Time.deltaTime* speedSide);

            }

        }
        
        if (CanvasGame.isStarted & !CanvasGame.isFailed & !CanvasGame.isEnded)
        {
            transform.Translate(new Vector3(Input.mousePosition.x / Screen.width / 70, 0, 0));
        }

    }


    
}
