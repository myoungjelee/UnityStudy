using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonEx : MonoBehaviour
{
    private static SingletonEx instance;

    public static SingletonEx Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject singletonObject = new GameObject();
                instance = singletonObject.AddComponent<SingletonEx>();

                // 파괴 방지 코드
                DontDestroyOnLoad(singletonObject);
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
