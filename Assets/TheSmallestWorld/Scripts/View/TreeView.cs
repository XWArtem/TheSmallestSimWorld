using System.Collections.Generic;
using UnityEngine;

public class TreeView : MonoBehaviour
{
    [SerializeField] private List<Sprite> treesColorOne, treesColorTwo, treesColorThree, treesColorFour;

    private SpriteRenderer spriteRenderer;

    public void Init(int treeTypeIndex)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (treeTypeIndex)
        {
            case 0:
                spriteRenderer.sprite = treesColorOne[Random.Range(0, treesColorOne.Count - 1)];
                break;
            case 1:
                spriteRenderer.sprite = treesColorTwo[Random.Range(0, treesColorTwo.Count - 1)];
                break;
            case 2:
                spriteRenderer.sprite = treesColorThree[Random.Range(0, treesColorThree.Count - 1)];
                break;
            case 3:
                spriteRenderer.sprite = treesColorFour[Random.Range(0, treesColorFour.Count - 1)];
                break;
            default:
                spriteRenderer.sprite = treesColorOne[Random.Range(0, treesColorOne.Count - 1)];
                break;
        }

        spriteRenderer.sortingOrder += 20;
    }
}