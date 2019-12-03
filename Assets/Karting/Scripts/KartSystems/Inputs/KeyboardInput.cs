using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// A basic keyboard implementation of the IInput interface for all the input information a kart needs.
    /// </summary>
    public class KeyboardInput : MonoBehaviour, IInput
    {
        public float Acceleration
        {
            get { return m_Acceleration; }
        }
        public float Steering
        {
            get { return m_Steering; }
        }
        public bool BoostPressed
        {
            get { return m_BoostPressed; }
        }
        public bool FirePressed
        {
            get { return m_FirePressed; }
        }
        public bool HopPressed
        {
            get { return m_HopPressed; }
        }
        public bool HopHeld
        {
            get { return m_HopHeld; }
        }

        public KeyCode touchePourAvancer;
        public KeyCode touchePourReculer;
        public KeyCode touchePourTournerGauche;
        public KeyCode touchePourTournerDroite;
        public KeyCode touchePourSauter;
        public KeyCode touchePourBoost;
        public KeyCode touchePourCubeArriere;

        float m_Acceleration;
        float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
        bool m_BoostPressed;
        bool m_FirePressed;

        bool m_FixedUpdateHappened;

        public GameObject Cube;
        
        void Update ()
        {
            if (Input.GetKeyDown(touchePourCubeArriere))
            {
                Instantiate(Cube, transform.position - transform.forward * 3, Quaternion.identity);
            }
            
            
            if (Input.GetKey (touchePourAvancer))
                m_Acceleration = 1f;
            else if (Input.GetKey (touchePourReculer))
                m_Acceleration = -1f;
            else
                m_Acceleration = 0f;

            if (Input.GetKey (touchePourTournerGauche) && !Input.GetKey (touchePourTournerDroite))
                m_Steering = -1f;
            else if (!Input.GetKey (touchePourTournerGauche) && Input.GetKey (touchePourTournerDroite))
                m_Steering = 1f;
            else
                m_Steering = 0f;

            m_HopHeld = Input.GetKey (touchePourSauter);

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            m_HopPressed |= Input.GetKeyDown (touchePourSauter);
            m_BoostPressed |= Input.GetKeyDown (touchePourBoost);
            m_FirePressed |= Input.GetKeyDown (KeyCode.RightControl);
        }

        void FixedUpdate ()
        {
            m_FixedUpdateHappened = true;
        }
    }
}