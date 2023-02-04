using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace NoSurrenderCase.Game
{
    public class Player : MonoBehaviour
    {
        
        public float Speed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private VariableJoystick _variableJoystick;
        [SerializeField] public Rigidbody rb;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _pushForce = 10f;

        public void FixedUpdate()
        {
            _direction = Vector3.forward * _variableJoystick.Vertical + Vector3.right * _variableJoystick.Horizontal;
            transform.forward = Vector3.Lerp(transform.forward, _direction, Time.deltaTime * _rotateSpeed);
            transform.position += transform.forward * (Speed * Time.deltaTime);
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Contestant")
            {
                Vector3 pushDirection = transform.position - collision.transform.position;;
                pushDirection = pushDirection.normalized;
                rb.AddForce(pushDirection * _pushForce, ForceMode.Impulse);
                
            }
        }



    }
}
