﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Player_Colisions{
    public class PlayerColisionManager : MonoBehaviour{
        private static Dictionary<string, Action<Collision2D>> _collisionDictionary = new Dictionary<string, Action<Collision2D>>();
        
        private void OnCollisionEnter2D(Collision2D other) {
            string gameTag = other.gameObject.tag;

            if (_collisionDictionary.ContainsKey(gameTag)) _collisionDictionary[gameTag]?.Invoke(other);
            
            else print("Essa colisao nao esta no dicionario");
        }

        public static void SubscribeColisionInDictionary(string key, Action<Collision2D> action) {
            if(!_collisionDictionary.ContainsKey(key)) 
                _collisionDictionary.Add(key, action);
            else {
                _collisionDictionary[key] += action;
            }
        }
        public static void UnsubscribeColisionInDictionary(string key, Action<Collision2D> action) {
            if (_collisionDictionary.ContainsKey(key))
                _collisionDictionary[key] -= action;
        }
    }
}