using UnityEngine;

public class ScrollingCamara : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 posicionCamara = transform.position;
        posicionCamara.x = Mathf.Max(posicionCamara.x,player.position.x);
        transform.position = posicionCamara;
    }
}
