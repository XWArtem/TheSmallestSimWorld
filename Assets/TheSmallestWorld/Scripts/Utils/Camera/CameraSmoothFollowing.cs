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

    private float initOffsetZ = -15f;

    private void Start()
    {
        transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, targetTransform.position.z + initOffsetZ);
    }

    private void LateUpdate()
    {
        movePosition = new Vector3(targetTransform.position.x + offset.x, targetTransform.position.y + offset.y, offset.z);
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, transform.position.z), movePosition, ref velocity, damping);
    }
}
