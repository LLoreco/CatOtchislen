using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image[] images; // Массив из 3 Image: [0], [1], [2]
    public float fadeSpeed = 3f; // Скорость изменения Alpha
    public float delayBetweenTransitions = 0.3f; // Задержка между 0→1 и 1→2

    private bool isHovering;
    private Coroutine currentAnimation;

    private void Start()
    {
        // Начальное состояние: только первый Image виден
        SetAlpha(images[0], 1f);
        SetAlpha(images[1], 0f);
        SetAlpha(images[2], 0f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        if (currentAnimation != null) StopCoroutine(currentAnimation);
        currentAnimation = StartCoroutine(AnimateForward());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        if (currentAnimation != null) StopCoroutine(currentAnimation);
        currentAnimation = StartCoroutine(AnimateBackward());
    }

    // Анимация вперёд: 0 → 1 → 2
    private IEnumerator AnimateForward()
    {
        yield return FadeImage(images[0], 0f); // Убираем 0
        yield return FadeImage(images[1], 1f); // Показываем 1
        yield return new WaitForSeconds(delayBetweenTransitions);
        yield return FadeImage(images[1], 0f); // Убираем 1
        yield return FadeImage(images[2], 1f); // Показываем 2
    }

    // Анимация назад: 2 → 1 → 0
    private IEnumerator AnimateBackward()
    {
        yield return FadeImage(images[2], 0f); // Убираем 2
        yield return FadeImage(images[1], 1f); // Показываем 1
        yield return new WaitForSeconds(delayBetweenTransitions);
        yield return FadeImage(images[1], 0f); // Убираем 1
        yield return FadeImage(images[0], 1f); // Показываем 0
    }

    // Плавное изменение Alpha для Image
    private IEnumerator FadeImage(Image image, float targetAlpha)
    {
        float startAlpha = image.color.a;
        float elapsed = 0f;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * fadeSpeed;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed);
            SetAlpha(image, newAlpha);
            yield return null;
        }

        SetAlpha(image, targetAlpha); // Финализация
    }

    // Установка Alpha для Image
    private void SetAlpha(Image image, float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}
