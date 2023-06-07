using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;
using System;

/// <summary>
/// Класс, демонстрирующий 
/// задымлённость камеры сгорания
/// </summary>
public class PushButtonSecondStand : MonoBehaviour
{
    public static Action<int> OnButtonClick;

    [SerializeField] private XRSimpleInteractable simpleInteractable;

    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private Outline _objectOutline;
    [SerializeField] private int _warningCode;

    private bool _isPressed = false;

    private void Awake()
    {
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
    }
    /// <summary>
    /// Проверка состояния кнопки
    /// </summary>
    /// <param name="args"></param>
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!_isPressed)
        {
            _isPressed = true;
            _objectOutline.enabled = true;

            _smokeEffect.Play();
            OnButtonClick?.Invoke(_warningCode);

        }
        else
        {
            _isPressed = false;
            _objectOutline.enabled = false;
            OnButtonClick?.Invoke(0);

            _smokeEffect.Stop();
        }
    }

}
