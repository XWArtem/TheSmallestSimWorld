using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private const string PlayerTag = "Player";
    [SerializeField] private List<Transform> doors;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            OpenDoors();
        }
    }

    private void OpenDoors()
    {
        foreach(Transform door in doors)
        {
            door.DOLocalRotate(Vector3.zero, 0.8f).
                SetEase(Ease.OutElastic, 0.4f);
        }
    }
}
