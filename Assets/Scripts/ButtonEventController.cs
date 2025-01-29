using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonEventController : MonoBehaviour
{
    public UnityEvent buttonActionEvent;
    private Button button;
    private float _actionDelay = 0.1f;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => StartCoroutine(HandleButtonClick()));
    }

    private IEnumerator HandleButtonClick()
    {
        yield return new WaitForSecondsRealtime(_actionDelay);
        buttonActionEvent?.Invoke();
    }
}
