using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject coinPrefab;
    
    private List<GameObject> coins = new List<GameObject>();

    private int coinsAmountOnScene;

    private const string CoinName = "Coin";

    private void OnEnable()
    {
        
    }

    public void Init()
    {
        coinsAmountOnScene = 0;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            SpawnObject(i);
        }
        while (coinsAmountOnScene < 3)
        {
            TryActivateCoin();
        }
    }

    public void SpawnObject(int coinIndex)
    {
        Debug.Log("Spawn coin");
        var newCoin = Instantiate(coinPrefab, spawnPoints[coinIndex].transform.position, Quaternion.identity, transform);
        newCoin.name = $"{CoinName}_{coinIndex}";
        newCoin.SetActive(false);
        coins.Add(newCoin);
        newCoin.GetComponent<Coin>().RegisterParentSpawner(this, coinIndex);
    }

    private void TryActivateCoin(int excludeIndex = 99)
    {
        int index = Random.Range(0, coins.Count);
        if (coins[index].activeSelf || index == excludeIndex)
        {
            TryActivateCoin();
        }
        else
        {
            coins[index].SetActive(true);
            coinsAmountOnScene++;
        }
    }

    public void OnDispose(int index)
    {
        coins[index].SetActive(false);
        TryActivateCoin(index);
    }
}
