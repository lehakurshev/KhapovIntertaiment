using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenu_StartGame: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;

    public void IWasClicked()
    {
        Debug.Log("Clicked");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _source.PlayOneShot(_clip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
