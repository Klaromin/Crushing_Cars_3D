using UnityEngine;
using UnityEngine.Serialization;

namespace NoSurrenderCase.Game
{
    public class JoystickPlayerExample : MonoBehaviour
    {
        [SerializeField] private  float _speed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private VariableJoystick _variableJoystick;
        [SerializeField] public Rigidbody rb;
        [SerializeField] private Vector3 _direction;

        public void FixedUpdate()
        {
            _direction = Vector3.forward * _variableJoystick.Vertical + Vector3.right * _variableJoystick.Horizontal;
            transform.forward = Vector3.Lerp(transform.forward, _direction, Time.deltaTime * _rotateSpeed);
            transform.position += transform.forward * (_speed * Time.deltaTime);
        }
    }
}
