using DG.Tweening;
using UnityEngine;

public class CharacterLookAtArea : MonoBehaviour
{
    private Vector3 targetLocation;
    private Vector3 vectorToTarget;
    private Vector3 rotatedVectorToTarget;
    private Transform targetTransform;

    private Quaternion targetRotation;
    private float startRotationZ;

    private bool isRotation;

    private void Start()
    {
        startRotationZ = transform.parent.transform.localEulerAngles.z;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ConstValues.PlayerTag))
        {
            targetTransform = collision.gameObject.transform;
            isRotation = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ConstValues.PlayerTag))
        {
            isRotation = false;
            ResetRotation();
        }
    }

    private void Update()
    {
        if (!isRotation) 
        { 
            return; 
        }
        targetLocation = targetTransform.transform.position;
        vectorToTarget = targetLocation - transform.position;
        rotatedVectorToTarget = Quaternion.Euler(0f, 0f, 180f) * vectorToTarget;
        targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

        transform.parent.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 200f * Time.deltaTime);
    }

    private void ResetRotation()
    {
        transform.parent.transform.DORotate(new Vector3(0f, 0f, startRotationZ), 0.4f);
    }
}
