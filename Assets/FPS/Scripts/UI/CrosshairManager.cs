using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{
    public Image crosshairImage;
    public Sprite nullCrosshairSprite;
    public float crosshairUpdateshrpness = 5f;

    PlayerWeaponsManager m_WeaponsManager;
    bool m_WasPointingAtEnemy;
    RectTransform m_CrosshairRectTransform;
    CrosshairData m_CrosshairDataDefault;
    CrosshairData m_CrosshairDataTarget;
    CrosshairData m_CurrentCrosshair;

    void Start()
    {
        crosshairImage.enabled = true;
    }
}
