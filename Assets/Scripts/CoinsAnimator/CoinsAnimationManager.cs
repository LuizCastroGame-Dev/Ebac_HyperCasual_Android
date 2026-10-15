using DG.Tweening;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAnimationManager : MonoBehaviour
{
    public static CoinsAnimationManager Instance;

    public List<ItemCollactableCoin> itens;

    [Header("Animations")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        itens = new List<ItemCollactableCoin>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartAnimations();
        }
    }

    public void RegisterCoin(ItemCollactableCoin i)
    {
        if(!itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    private void Sort()
    {
        itens = itens.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }

        Sort();
        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }

    }
}
