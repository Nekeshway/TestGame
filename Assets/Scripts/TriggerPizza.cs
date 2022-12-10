using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Gadd420;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class TriggerPizza : MonoBehaviour
{
    private PizzaCounter _pizza;
    private Sequence _sequence;
    public enum DoType
    {
        Jump
    }

    private bool jumpp;
    public DoType doType = DoType.Jump;
    public GameObject PizzaGameObject;
    private Transform ObjPizza;
    public GameObject SpawPoint;
    public bool Left;
    public bool Right;
    public void Start()
    {
        _pizza = FindObjectOfType<PizzaCounter>();
        ObjPizza = FindObjectOfType<PizzaPoint>().transform;
        jumpp = true;
    }

    private void OnTriggerEnter(Collider other)
    {
   
        if (jumpp = true && other.TryGetComponent(out Whellsc whellsc))
        {
            
            Destroy(SpawPoint);
            GameObject pizza = Instantiate(PizzaGameObject, ObjPizza.transform.position, Quaternion.identity);
            if (Left)
            {
                pizza.GetComponent<Transform>().DOJump(
                    new Vector3(transform.position.x - 3, transform.position.y, transform.position.z), 3, 1, 0.5f);
            }

            if (Right)
            {
                pizza.GetComponent<Transform>().DOJump(
                    new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), 3, 1, 0.5f); 
            }

            _pizza.addValue(1);
            Destroy(pizza, 15);
            jumpp = false;
          
        }
    }
} 
   
