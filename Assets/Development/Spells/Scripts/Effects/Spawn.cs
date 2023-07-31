using System;
using System.Collections;
using System.Collections.Generic;
using Spells;
using UnityEngine;

public class Spawn : Effect
{
    public GameObject Prefab;
    private GameObject Instance; 
    private ISpellInit Init;
    private void Awake()
    {
        Instance = Instantiate(Instance);
        Init = Instance.GetComponent<ISpellInit>();
        Instance.SetActive(false);
    }

    public override void Apply(Collider target)
    {
        Instance.transform.position = target.transform.position;
        Init.Init(spellData);
        Instance.SetActive(true);
    }
}
