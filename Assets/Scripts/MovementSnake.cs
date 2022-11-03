using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovementSnake : MonoBehaviour
    {
        public float SnakeSpeed = 4;
        public float Sensitivity = 15;


        public Game Game;

        private Camera mainCamera;
        private Rigidbody _rb;

        private float _speed;


        private void Start()
        {
            mainCamera = Camera.main;
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            if (Game.GameOver)
            {
                _speed = 0;
            }
            if (Input.GetMouseButton(0))
            {
                //float rotateX = Input.GetAxis("Mouse Y");
                float rotateY = Input.GetAxis("Mouse X");
                _speed += rotateY * Sensitivity;
            }
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(_speed) > 4)
            {
                _speed = 4 * Mathf.Sign(_speed);
            }
            _rb.velocity = new Vector3(_speed * 5, 0, SnakeSpeed);
            _speed = 0;
        }

    }
}



 
    

   