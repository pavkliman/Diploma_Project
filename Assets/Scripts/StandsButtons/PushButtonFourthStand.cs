using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PushButtonFourthStand : MonoBehaviour
{
    public static Action<int> OnButtonClick;

    [SerializeField] private XRSimpleInteractable simpleInteractable;

    [SerializeField] private ParticleSystem _flareEffect;
    [SerializeField] private Outline _objectOutline;
    [SerializeField] private int _warningCode;

    private bool _isPressed = false;

    private void Awake()
    {
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!_isPressed)
        {
            _isPressed = true;
            _objectOutline.enabled = true;

            _flareEffect.Play();
            OnButtonClick?.Invoke(_warningCode);

        }
        else
        {
            _isPressed = false;
            _objectOutline.enabled = false;

            _flareEffect.Stop();
        }
    }
}
