using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;

    private float _StartY;
    private float _minimumReachedY;

    private void Start()
    {
        _StartY = Player.transform.position.y;
    }
    private void Update()
    {
        _minimumReachedY = Mathf.Min(_minimumReachedY, Player.transform.position.y);
        float finishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_StartY, finishY, _minimumReachedY);
        Slider.value = t;
    }
}
