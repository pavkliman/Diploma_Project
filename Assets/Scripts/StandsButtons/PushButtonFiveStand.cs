using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class PushButtonFiveStand : MonoBehaviour
{
    public static Action<bool> OnShowWaterFlow;

    [SerializeField] private XRSimpleInteractable simpleInteractable;
    [SerializeField] private ParticleSystem _flareEffect;

    private bool _isPressed = false;

    private void Awake()
    {
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    /*
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!_isPressed)
            {
                _isPressed = true;
                OnShowWaterFlow?.Invoke(true);
                _flareEffect.Play();

            }
            else
            {
                _isPressed = false;
                OnShowWaterFlow?.Invoke(false);
                _flareEffect.Stop();
            }
        }
    }*/

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!_isPressed)
        {
            _isPressed = true;
            OnShowWaterFlow?.Invoke(true);
            _flareEffect.Play();
        }
        else
        {
            _isPressed = false;
            OnShowWaterFlow?.Invoke(false);
            _flareEffect.Stop();

        }
    }
}
