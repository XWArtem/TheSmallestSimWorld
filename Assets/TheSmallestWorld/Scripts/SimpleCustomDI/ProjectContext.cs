using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    [SerializeField] private MainHero mainHero;
    [SerializeField] private InputHandButton inputHandButton;
    [SerializeField] private List<Vendor> vendors = new List<Vendor>();
    [SerializeField] private LevelSceneController levelSceneController;

    private void Awake()
    {
        mainHero.Init(inputHandButton);

        foreach(var vendor in vendors)
        {
            vendor.Init(mainHero);
        }







        levelSceneController.Init(); // must be the last on queue
    }
}
