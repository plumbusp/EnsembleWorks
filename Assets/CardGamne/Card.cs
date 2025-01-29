using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector2 newPos;
    Vector2 offset;
    public Transform defaultParent;
    GameObject tempCard;
    Transform tempCardParent;
    
    private void Start()
    {
        tempCard = GameObject.Find("TempCardGO");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        defaultParent = tempCardParent = transform.parent;

        tempCard.transform.SetParent(tempCardParent);
        tempCard.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(defaultParent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        newPos = eventData.position;
        transform.position = newPos + offset;
        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        tempCard.transform.SetParent(GameObject.Find("Canvas").transform);
        tempCard.transform.position = new Vector2(3071, 3071);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetParent(defaultParent);
        transform.SetSiblingIndex(tempCard.transform.GetSiblingIndex());
    }

    private void CheckPosition()
    {
        // Get child count of current parent
        // compare transfom position of a grabble card with each
        int newIndex = tempCardParent.childCount;

        for (int i = 0; i < tempCardParent.childCount; i++)
        {
            if (transform.position.x < tempCardParent.GetChild(i).transform.position.x)
            {
                newIndex = i;
                if(tempCard.transform.GetSiblingIndex() < newIndex)
                    newIndex--;
                break;
            }
        }
        tempCard.transform.SetSiblingIndex(newIndex);
    }

}
