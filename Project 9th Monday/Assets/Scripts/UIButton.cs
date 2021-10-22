using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] private Color defaultColor, onHoverColor;
    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
        image.color = defaultColor;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        image.color = onHoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        ResetColor();
    }

    public void ResetColor() {
        if(image)
            image.color = defaultColor;
    }

}
