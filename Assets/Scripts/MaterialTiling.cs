using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTiling : MonoBehaviour
{
    public float speed = 1.0f; // —корость изменени€ Offset Y
    public Renderer[] renderers; // ћассив рендереров с материалами

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

            // —оздаем новый вектор с измененным значением Offset Y
            Vector2 newOffset = new Vector2(0.0f, offset);

            // ѕроходимс€ по всем рендерерам в массиве
            for (int i = 0; i < renderers.Length; i++)
            {
                // ѕрисваиваем новое значение Offset Y каждому материалу в рендерере
                renderers[i].material.mainTextureOffset = newOffset;
            }

            yield return null;
        }
    }
}
