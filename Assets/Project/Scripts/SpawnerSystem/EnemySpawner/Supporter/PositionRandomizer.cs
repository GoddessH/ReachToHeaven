using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public class PositionRandomizer
{
    //
    [SerializeField] private Vector2 m_outerBound;
    [SerializeField] private Vector2 m_innerBound;

    private Rigidbody2D m_playerRigid;

    public void Init(Rigidbody2D playerRigid)
        => m_playerRigid = playerRigid;

    public Vector2 RandomizePosition(GameObject gameObject)
    {
        gameObject.transform.position = m_playerRigid.transform.position;

        Rectangle rightRectangle = new Rectangle(m_innerBound.x, m_outerBound.x, -m_innerBound.y, m_innerBound.y);
        Rectangle topRectangle = new Rectangle(-m_outerBound.x, m_outerBound.x, m_innerBound.y, m_outerBound.y);

        float totalArea = rightRectangle.Area + topRectangle.Area;

        float scaleRight = rightRectangle.Area / totalArea;

        float res = Random.value;

        if (res <= scaleRight)
        {
            float xPos = Random.Range(m_innerBound.x, m_outerBound.x);
            float yPos = Random.Range(-m_innerBound.y, m_innerBound.y);
            Vector2 result = new Vector2(xPos, yPos);
            if (Random.value <= 0.5f) result *= -1;
            return result;
        }
        else
        {
            float yPos = Random.Range(m_innerBound.y, m_outerBound.y);
            float xPos = Random.Range(-m_innerBound.x, m_innerBound.x);
            Vector2 result = new Vector2(xPos, yPos);
            if (Random.value <= .5f) result *= -1;
            return result;
        }
    }
    

}
