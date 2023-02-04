using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 10.0f;
    private Transform target;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _pushForce = 10f;

    private void Update()
    {
        Transform nearestTarget = FindNearestTarget();
        if (nearestTarget != null)
        {
            target = nearestTarget;
            FollowTarget();
            FaceTarget();
        }
    }

    private Transform FindNearestTarget()
    {
        GameObject[] contestants = GameObject.FindGameObjectsWithTag("Contestant");

        Transform nearestTarget = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject contestant in contestants)
        {
            float distance = Vector3.Distance(transform.position, contestant.transform.position);
            if (contestant != gameObject && distance < closestDistance)
            {
                closestDistance = distance;
                nearestTarget = contestant.transform;
            }
        }

        return nearestTarget;
    }

    private void FollowTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        _rigidbody.AddForce(direction * (speed * Time.deltaTime), ForceMode.Impulse);
    }

    private void FaceTarget()
    {
        Vector3 targetDirection = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Contestant")
        {
            Vector3 pushDirection = transform.position - collision.transform.position;;
            pushDirection = pushDirection.normalized;
            _rigidbody.AddForce(pushDirection * _pushForce, ForceMode.Impulse);
            
        }
    }
}
