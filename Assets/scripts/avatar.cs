using UnityEngine;

public class avatar : MonoBehaviour
{
    private Alteruna.Avatar _avatar;
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();

        if (!_avatar.IsMe)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_avatar.IsMe)
            return;
    }
}
