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

                // �ı� ���� �ڵ�
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
