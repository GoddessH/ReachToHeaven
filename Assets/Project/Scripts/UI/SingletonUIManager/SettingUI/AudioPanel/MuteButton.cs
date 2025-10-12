
public class MuteButton : ButtonToggle
{
    //
    public void Mute()
    {
        IsActive = false;
        m_image.sprite = m_deactiveSprite;
    }
}
