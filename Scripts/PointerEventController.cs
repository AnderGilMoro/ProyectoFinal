using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEventController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
 		eventData.pointerEnter.GetComponent<EnemyController>().onShoot = true;
 		Debug.Log("onShoot true");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
 		eventData.pointerEnter.GetComponent<EnemyController>().onShoot = false;
 		Debug.Log("onShoot false");
    }
}
