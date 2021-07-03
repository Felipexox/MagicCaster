using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Component;
using GamePlay.Model;
using UnityEngine;

namespace GamePlay.Logic
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CharacterComponent[] Characters = new CharacterComponent[0];
        
        private CharacterComponent[] InGameCharacters;
        private void Start()
        {
            InGameCharacters = new CharacterComponent[Characters.Length];
            
            for (int i = 0; i < Characters.Length; i++)
            {
                InGameCharacters[i] = Instantiate(Characters[i]);
                InGameCharacters[i].Initialize(new Character
                {
                   Velocity = 10
                });
            }
        }
    }

}
