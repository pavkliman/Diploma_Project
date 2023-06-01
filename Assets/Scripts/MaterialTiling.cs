using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTiling : MonoBehaviour
{
    public float speed = 1.0f; // �������� ��������� Offset Y
    public Renderer[] renderers; // ������ ���������� � �����������

    private float offset = 0.0f;

    private void Start()
    {
        StartCoroutine(UpdateOffset());
    }

    private System.Collections.IEnumerator UpdateOffset()
    {
        while (true)
        {
            offset += speed * Time.deltaTime;

            // ������� ����� ������ � ���������� ��������� Offset Y
            Vector2 newOffset = new Vector2(0.0f, offset);

            // ���������� �� ���� ���������� � �������
            for (int i = 0; i < renderers.Length; i++)
            {
                // ����������� ����� �������� Offset Y ������� ��������� � ���������
                renderers[i].material.mainTextureOffset = newOffset;
            }

            yield return null;
        }
    }
}
