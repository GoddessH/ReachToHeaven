using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AnimatorController : MonoBehaviour
{
    //
    private Animator m_characterAnimator;
    public Animator CharacterAnimator { get => m_characterAnimator; }

    private void Awake()
    {
        m_characterAnimator = GetComponent<Animator>();
    }

    public void UpdateDirection(Vector2 direction)
    {
        m_characterAnimator.SetFloat("xDirection", direction.x);
        m_characterAnimator.SetFloat("yDirection", direction.y);
    }
}
