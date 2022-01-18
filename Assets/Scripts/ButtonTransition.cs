using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.Play(5);
        transform.DORotate(new Vector3(0, 0, 8), .4f).SetEase(Ease.OutExpo);
        transform.DOScale(new Vector3(1.15f, 1.15f, 1), .4f).SetEase(Ease.OutExpo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DORotate(Vector3.zero, .4f).SetEase(Ease.OutExpo);
        transform.DOScale(Vector3.one, .4f).SetEase(Ease.OutExpo);
    }
}