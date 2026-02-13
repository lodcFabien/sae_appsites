using UnityEngine;
using UnityEngine.UI;

public class ZoneScreenView : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;

    public void SetBackgoundImage(Sprite bakcground)
    {
        _backgroundImage.sprite =  bakcground;
    }
}
