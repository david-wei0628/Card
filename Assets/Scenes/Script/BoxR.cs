using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var Cub in this.GetComponentsInChildren<Collider>())
        {
            Box.Add(Cub.gameObject);
        }
    }

    List<GameObject> Box = new List<GameObject>();
    List<GameObject> Ost = new List<GameObject>();
    List<GameObject> Tse = new List<GameObject>();
    GameObject Boc;
    Vector3 MoveVector;
    int TargetBox=0;
    //Vector3 Boc;
    int Ram;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            for (int i = 0; i < Box.Count; i++)
            {
                Ram = Random.Range(0, Box.Count);
                Boc = Box[i];
                Box[i] = Box[Ram];
                Box[Ram] = Boc;
            }            
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            TargetBox = 0;
            for (int i = 0; i < Box.Count; i++)
            {
                Box[i].GetComponent<Collider>().enabled = false;
                OneD();
                Box[i].GetComponent<Collider>().enabled = true;
            }
            TargetBox = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CLOT();
        }

        if (Input.GetKeyDown("="))
        {
            RE();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Ost.Clear();
            Tse.Clear();
            TargetBox = 0;
            //while (TargetBox < Box.Count)
            for(int i = 0; i < Box.Count; i++)
            {
                Box[i].GetComponent<Collider>().enabled = false;
                AtoB();
                if (i % 2 == 0)
                {
                    Ost.Add(Box[i]);
                }
                else
                {
                    Tse.Add(Box[i]);
                }
                Box[i].GetComponent<Collider>().enabled = true;
            }
            TargetBox = 0;
        }
    }

    //private void OnGUI()
    //{
    //    Event e = Event.current;
    //    switch (e.keyCode)
    //    {
    //        case KeyCode.UpArrow:
    //            Box[0].transform.position = Vector3.Lerp(Box[0].transform.position, Vector3.up, 1.0f);
    //            Box[0].transform.position += Vector3.left * Time.deltaTime * 10;
    //            break;
    //        case KeyCode.Space:
    //            for (int i = 0; i < Box.Count; i++)
    //            {
    //                Debug.Log(Box[i].name);
    //            }
    //            break;
    //        default:
    //            Debug.Log("i");
    //            break;
    //        case KeyCode.Q:
    //            for (int i = 0; i < Box.Count; i++)
    //            {
    //                MoveVector = new Vector3(-7.0f + (i / 2) * 3, 0.5f, (i % 2) * 2 - 5.0f);
    //                Box[i].transform.position = Vector3.LerpUnclamped(Box[i].transform.position, MoveVector, 0.5f);
    //            }
    //            break;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    Debug.Log(Time.time);

    //}

    void AtoB()
    {        
        MoveVector = new Vector3(-7.0f + (TargetBox / 2) * 3, 0.5f, (TargetBox % 2) * 2 - 5.0f);
        Box[TargetBox].transform.position = Vector3.Slerp(Box[TargetBox].transform.position, MoveVector, 0.02f);
        if (Vector3.Distance(Box[TargetBox].transform.position, MoveVector) > 0.1f)
        {
            Invoke("AtoB", 0.01f);
        }
        else
        {
            TargetBox++;
        }

    }

    void OneD()
    {
        MoveVector = new Vector3(2 * (TargetBox - 4f), 0.5f, 0);
        Box[TargetBox].transform.position = Vector3.Slerp(Box[TargetBox].transform.position, MoveVector, 0.02f);
        if (Vector3.Distance(Box[TargetBox].transform.position, MoveVector) > 0.1f)
        {
            Invoke("OneD", 0.01f);
        }
        else
        {
            TargetBox++;
        }
    }

    void CLOT()
    {
        Box[TargetBox].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 100);
        //Tse[Random.Range(0, Tse.Count)].transform.position -= new Vector3(1, 0, 1);
        if(TargetBox<Box.Count-1)
        {
            TargetBox++;
        }
        else
        {
            TargetBox = 0;
        }
    }

    private void RE()
    {
        Vector3 vector3 = new Vector3(0,10f,0);
        for(int i = 0; i < Box.Count; i++)
        {
            Box[i].transform.position += vector3; 
        }
    }
}
