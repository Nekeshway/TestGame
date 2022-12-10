using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeed : MonoBehaviour
{
public float speed = 0.01f;

private void FixedUpdate()
{
transform.Translate(Vector3.forward *speed); 
}
}
