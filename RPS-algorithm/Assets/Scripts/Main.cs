using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //add three objects
    public GameObject SphereA;
    public GameObject SphereB;
    public GameObject SphereC;

    private Vector3 vectorA;
    private Vector3 vectorB;
    private Vector3 vectorC; 

    public List<GameObject> gameObjList;

    // Start is called before the first frame update
    void Start()
    {
        gameObjList.Add(SphereA);
        gameObjList.Add(SphereB);
        gameObjList.Add(SphereC);

        vectorA = SphereA.transform.position;
        vectorB = SphereB.transform.position;
        vectorC = SphereC.transform.position; 
    }

    public void ResetAll()
    {
        SphereA.transform.position = vectorA;
        SphereB.transform.position = vectorB;
        SphereC.transform.position = vectorC;

        for (int i = 0; i < gameObjList.Count; i++)
        {
            gameObjList[i].GetComponent<SphereProperties>().ResetVelocity();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update velocity
        for (int i = 0; i < gameObjList.Count; i++)
        {
            gameObjList[i].GetComponent<SphereProperties>().UpdateVelocity();
        }

        //update position
                for (int i = 0; i < gameObjList.Count; i++)
        {
            gameObjList[i].GetComponent<SphereProperties>().UpdatePostion();
        }
    }
}
