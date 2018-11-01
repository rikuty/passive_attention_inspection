using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace aaa
{
    public class GameData : MonoBehaviour
    {

        
        public static GameData Instance { get; private set; }

        public string id { get; private set; }
        public DateTime dateTime { get; private set; }
        public float x { get; private set; }
        public float y { get; private set; }



        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }


        public void Init(string id, DateTime dateTime, float x, float y)
        {
            this.id = id;
            this.dateTime = dateTime;
            this.x = x;
            this.y = y;
        }
    }
}
