using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
   private CharacterController controller;
       private Vector3 direction;
       public float forwardSpeed;
   
       private int desiredLane = 1;
       public float laneDistance = 4;
       void Start()
       {
           controller = GetComponent<CharacterController>();
       }
   

       void Update()
       {
           direction.z = forwardSpeed;
           
           if (Input.GetKeyDown(KeyCode.RightArrow))
           {
               desiredLane++;
               if (desiredLane == 3)
                   desiredLane = 2;
           }
           if (Input.GetKeyDown(KeyCode.LeftArrow))
           {
               desiredLane--;
               if (desiredLane == -1)
                   desiredLane = 0;
           }
   
           Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
           if (desiredLane == 0)
           {
               targetPosition += Vector3.left * laneDistance;
           }else if (desiredLane == 2)
           {
               targetPosition += Vector3.right * laneDistance;
           }
   
           transform.position = targetPosition; 
       }
   
       private void FixedUpdate()
       {
           controller.Move(direction*Time.deltaTime);
       }
}
