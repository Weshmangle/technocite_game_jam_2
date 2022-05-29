using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsManager : MonoBehaviour
{
    public static PrefabsManager Instance;
    public GameObject prefabCard;
    public GameObject particlesPrefab;

    private void Awake()
    {
        Instance = this;
    }
}
