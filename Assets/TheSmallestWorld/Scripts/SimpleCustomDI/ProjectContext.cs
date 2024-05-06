using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    [SerializeField] private MainHero mainHero;
    [SerializeField] private InputHandButton inputHandButton;
    [SerializeField] private List<Vendor> vendors = new List<Vendor>();
    [SerializeField] private LevelSceneController levelSceneController;
    [SerializeField] private PopupShopController vendorController;
    [SerializeField] private ResourcesDisplay resourcesDisplay;
    [SerializeField] private List<TreeView> trees;

    private void Awake()
    {
        mainHero.Init(inputHandButton);

        foreach(var vendor in vendors)
        {
            vendor.Init(mainHero);
        }

        int treesIndex = Random.Range(0, 4);

        foreach(var tree in trees)
        {
            tree.Init(treesIndex);
        }

        vendorController.Init();
        resourcesDisplay.Init();




        levelSceneController.Init(); // must be the last on queue
    }
}
