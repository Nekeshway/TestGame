using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateCar : MonoBehaviour
{
   
    public GameObject[] Objects;
    public Transform ObjCar1;
    private bool exit;
    public bool Left;
    public bool Right;
    void Start()
    {
        exit = false;
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            if (exit)
            {
                yield break;
            }

            int rand = Random.Range(0, Objects.Length - 1);
            if (Left)
            {
                GameObject car = Instantiate(Objects[rand], ObjCar1.transform.position, new Quaternion(0, 90, 0, 90));
                   Destroy(car,15);
            }

            if (Right)
            {
                GameObject car = Instantiate(Objects[rand], ObjCar1.transform.position, transform.rotation );
                Destroy(car,15);
            }

       
            yield return new WaitForSeconds(5);
          
        }

    }




}
    

