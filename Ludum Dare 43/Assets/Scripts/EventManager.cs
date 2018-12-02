using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    [SerializeField] private GameObject _shipEncounterSplashPrefab;

    [SerializeField] private GameObject _shopPrefab;
    
    private GameObject _canvas;
    
    private void Start()
    {
        _canvas = GameObject.Find("Canvas");
    }

    public void ShopEncounter()
    {
        var shop = Instantiate(_shopPrefab, _canvas.transform);
        shop.GetComponent<Animator>().SetTrigger("ShopOpened");
        GameManager.Instance.InShop = true;
    }
    
    public void ShipEncounter()
    {
        var shipEncounterSplash = Instantiate(_shipEncounterSplashPrefab, _canvas.transform);
       
        ShipManager.Instance.BreakRandomPartOfType(2);
        
        StartCoroutine(KillObject(shipEncounterSplash, 3f));
    }
    
    private IEnumerator KillObject(Object obj, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(obj);
    }
}