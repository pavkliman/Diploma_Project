using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTiling : MonoBehaviour
{
    public float _speed = 1.0f; // �������� ��������� Offset Y
    public Renderer[] _renderers; // ������ ���������� � �����������

    private float _offset = 0.0f;
    private IEnumerator _waterFlow;

    private void Awake()
    {
        PushButtonFiveStand.OnShowWaterFlow += IsStartWaterFlow;
    }

    private void IsStartWaterFlow(bool isStart)
    {
        if (_waterFlow == null)
        {
            _waterFlow = UpdateOffset();
        }

        if (isStart)
        {
            foreach (var a in _renderers)
            {
                a.gameObject.SetActive(true);
            }

            StartCoroutine(UpdateOffset());
        }
        else
        {
            foreach (var a in _renderers)
            {
                a.gameObject.SetActive(false);
            }

            StopAllCoroutines();
            _waterFlow = null;
        }
    }

    private IEnumerator UpdateOffset()
    {
        while (true)
        {
            _offset += _speed * Time.deltaTime;

            // ������� ����� ������ � ���������� ��������� Offset Y
            Vector2 newOffset = new Vector2(0.0f, _offset);
            // ���������� �� ���� ���������� � �������
            for (int i = 0; i < _renderers.Length; i++)
            {
                // ����������� ����� �������� Offset Y ������� ��������� � ���������
                _renderers[i].material.mainTextureOffset = newOffset;
            }

            yield return null;
        }
    }
}
