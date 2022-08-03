using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 AtoB = new Vector3(0,0.5f,10f);
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            MMv();
        }
        //this.transform.position = Vector3.Lerp(this.transform.position,AtoB,0.1f);
        if (Input.GetKey(KeyCode.V))
        {
            Debug.Log("1");
            this.transform.position = Vector3.Lerp(this.transform.position, AtoB, 0.02f);
        }
    }


    void MMv()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, AtoB, 0.04f);
        if (Vector3.Distance(this.transform.position, AtoB) > 0.1f)
        {
            //MMC();
            Invoke("MMv", 0.05f);
        }
    }

    void MMC()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, AtoB, 0.02f);
        if (Vector3.Distance(this.transform.position, AtoB) > 0.1f)
        {
            //Invoke($"MMv{55}", 0.05f);
            Invoke("MMv", 0.05f);
            //MMv();
        }
        //Debug.Log("1");
    }
}
