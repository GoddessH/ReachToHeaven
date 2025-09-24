using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class ShowImageBySpritePivot : MonoBehaviour
{
    //

    private void Awake()
    {
        Image characterImage = GetComponent<Image>();
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector2 normalizeSpritePivot = new Vector2(
            characterImage.sprite.pivot.x / characterImage.sprite.rect.width,
            characterImage.sprite.pivot.y / characterImage.sprite.rect.height);

        rectTransform.pivot = normalizeSpritePivot;
    }
}
