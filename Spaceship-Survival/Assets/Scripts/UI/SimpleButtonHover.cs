using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;


namespace SpaceShipSurvival
{
    public class SimpleButtonHover : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
    {
        [SerializeField] private float duration;
        [SerializeField] private Vector3 finalScale;
        private Vector3 initialScale;
        private bool mouseIn;

        public Ease easeing;

        private void Awake()
        {
            initialScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(finalScale, duration).SetEase(easeing);
            mouseIn = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(initialScale, duration).SetEase(easeing);
            mouseIn = false;
        }
    }
}

public static class ExtensionMethods
{
    
}
