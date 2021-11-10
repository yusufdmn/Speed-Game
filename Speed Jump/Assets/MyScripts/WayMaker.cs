using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayMaker : MonoBehaviour
{
    public GameObject wayPref;
    public GameObject endWay;

    public float distance;
    public float distanceForward;
    Vector3 lastWayPos;

    int level;

    int wayCount;

    void Start()
    {

        level = PlayerPrefs.GetInt("level");

        SetWayCount();
        lastWayPos = Vector3.zero;
        float[] array = { -distance/2, distance/2 };

        MakeWayS(-distance / 2);  // FIRST WAY

        for (int i = 0; i < wayCount; i++)
        {
            float direction = lastWayPos.x + array[Random.Range(0, 2)];
            MakeWayS(direction);
        }
        MakeEndWay();

    }


    void MakeWayS(float direction)
    {
        Vector3 newWayTransform = new Vector3(direction , wayPref.transform.position.y, lastWayPos.z + distanceForward);
        GameObject newWay = GameObject.Instantiate(wayPref, newWayTransform, Quaternion.identity);
        lastWayPos = newWay.transform.position;
    }

    void MakeEndWay()
    {
        Vector3 endWayTransform = new Vector3(lastWayPos.x, endWay.transform.position.y, lastWayPos.z + distanceForward);
        endWay.transform.position = endWayTransform;
    }

    void SetWayCount()
    {
        if (level < 5)
        {
            wayCount = Random.Range(12, 16);
        }
        else if (level < 10)
        {
            wayCount = Random.Range(14, 18);
        }
        else if (level < 15)
        {
            wayCount = Random.Range(16, 20);
        }
        else if (level < 20)
        {
            wayCount = Random.Range(18, 22);
        }
        else if (level < 30)
        {
            wayCount = Random.Range(20, 24);
        }
        else if (level < 40)
        {
            wayCount = Random.Range(22, 26);
        }
        else if (level < 50)
        {
            wayCount = Random.Range(24, 28);
        }
        else
        {
            wayCount = Random.Range(26, 30);
        }

    }
}