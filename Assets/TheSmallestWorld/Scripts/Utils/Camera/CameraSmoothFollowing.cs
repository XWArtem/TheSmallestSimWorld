using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollowing : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

    [SerializeField] private Vector3 offset;

    [SerializeField] private float damping;

    private Vector3 movePosition;

    private Vector3 velocity;

    private void LateUpdate()
    {
        movePosition = new Vector3(targetTransform.position.x + offset.x, targetTransform.position.y + offset.y, offset.z);
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, offset.z), movePosition, ref velocity, damping);
    }
}
