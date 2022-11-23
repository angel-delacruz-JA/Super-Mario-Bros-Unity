using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public static SelectPlayer Instance;

    public List<Personajes> personajes;

    private void Awake()
    {
        if (SelectPlayer.Instance == null)
        {
            SelectPlayer.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

