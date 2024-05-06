using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    [SerializeField] private MainHero mainHero;
    [SerializeField] private InputHandButton inputHandButton;
    [SerializeField] private List<Vendor> vendors = new List<Vendor>(); // there may be more vendors in the future for sure
    [SerializeField] private LevelSceneController levelSceneController;
    [SerializeField] private PopupShopController vendorController;
    [SerializeField] private ResourcesDisplay resourcesDisplay;
    [SerializeField] private List<TreeView> trees;
    [SerializeField] private CoinsSpawner coinsSpawner;
    [SerializeField] private TrashCan trashCan;

    private void Awake()
    {
        mainHero.Init(inputHandButton);

        foreach(var vendor in vendors)
        {
            vendor.Init(mainHero);
        }
        trashCan.Init(mainHero);

        int treesIndex = Random.Range(0, 4);

        foreach(var tree in trees)
        {
            tree.Init(treesIndex);
        }

        vendorController.Init();
        
        resourcesDisplay.Init();
        coinsSpawner.Init();



        levelSceneController.Init(); // must be the last on queue
    }
}
