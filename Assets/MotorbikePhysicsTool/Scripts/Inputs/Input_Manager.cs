using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gadd420
{
    public class Input_Manager : MonoBehaviour
    {
        public bool combineLeanAndSteering;
        public bool combineBrakeInputs;
        public Joystick VerticalJoystick;
        public Joystick HorizontalJoystick;
        public float inputSmoothingTime = 0.5f;

        float vInputTime;
        float hzInputTime;

        //A&D
        protected float hzInput;

        public float HzInput
        {
            get { return hzInput; }
        }

        //W&S
        protected float vInput;

        public float VInput
        {
            get { return vInput; }
        }

        //LMouse & RMouse
        protected float leanInput;

        public float LeanInput
        {
            get { return leanInput; }
        }

        //LShift && LCtrl
        protected float wheelieInput;

        public float WheelieInput
        {
            get { return wheelieInput; }
        }

        //FrontBreak
        protected float frontBreakInput;

        public float FrontBreakInput
        {
            get { return frontBreakInput; }
        }

        private void Start()
        {
            vInput = 0;
            hzInput = 0;
        }

        void Update()
        {
            
            VerticalInput();
            HZInput();
            GetLeanValue();
            GetLeanBackValue();
            FrontBreak();
        }


        protected virtual void VerticalInput()
        {
            vInput = VerticalJoystick.Vertical;





        }

        protected virtual void HZInput()
        {
            hzInput = HorizontalJoystick.Horizontal;
        }

        protected virtual void GetLeanValue()
        {
            hzInput = HorizontalJoystick.Horizontal; 
        }

        protected virtual void GetLeanBackValue()
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    wheelieInput = -1;
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    wheelieInput = 1;
                }
            }
            else
            {
                wheelieInput = 0;
            }
        }

        protected virtual void FrontBreak()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                frontBreakInput = 1;
            }
            else
            {
                frontBreakInput = 0;
            }
        }
    }
}