using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlay : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();
        if (card)
            card.defaultParent = transform;
    }
}
