using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;
    public List<Material> materials;
    public List<ColorSetup> colorSetups;
    private void Awake()
    {
        Instance = this;
    }

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
        var setup = colorSetups.Find(i => i.artType == artType);

        for (int i = 0; i < materials.Count; i++)
        {
            {
                materials[i].SetColor("_BaseColor", setup.colors[i]);
            }
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}