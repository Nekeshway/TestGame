using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCarR : MonoBehaviour
{
    public GameObject[] Objects;
    public Transform ObjCar2;
  
    

    private bool exit;
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

            GameObject car = Instantiate(Objects[rand], ObjCar2.transform.position, transform.rotation);
            Destroy(car, 15);
            yield return new WaitForSeconds(3);

        }

    }
}
