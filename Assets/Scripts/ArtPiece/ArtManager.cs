using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ArtManager : MonoBehaviour
{
    public static ArtManager Instance;
    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        BEACH,
        SNOW
    }

    public List<ArtSetup> artSetup;

    private void Awake()
    {
        Instance = this;
    }

    public ArtSetup GetSetupByType(ArtType artType)
    {
        //return artSetup.ForEach(i => i.artType = artType);
        return artSetup.Find(i => i.artType == artType);
    }
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}
