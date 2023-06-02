using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class PushButtonTherdStand : MonoBehaviour
{
    public static Action<int> OnButtonClick;

    [SerializeField] private XRSimpleInteractable simpleInteractable;

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
            OnButtonClick?.Invoke(_warningCode);

        }
        else
        {
            _isPressed = false;
            _objectOutline.enabled = false;
            OnButtonClick?.Invoke(0);

        }
    }
}
