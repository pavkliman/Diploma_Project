using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PushButtonSixStand : MonoBehaviour
{
    public static Action<int> OnButtonClick;

    [SerializeField] private XRSimpleInteractable simpleInteractable;

    [SerializeField] private ParticleSystem _smokeEffect;
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

            _smokeEffect.Play();
            OnButtonClick?.Invoke(_warningCode);

        }
        else
        {
            _isPressed = false;
            OnButtonClick?.Invoke(0);

            _smokeEffect.Stop();
        }
    }
}
