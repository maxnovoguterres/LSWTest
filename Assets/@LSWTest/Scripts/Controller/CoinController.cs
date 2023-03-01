using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CoinController : Shared.Controller<CoinController>
    {
        [HideInInspector] public int currentCoins;

        public int initialCoins;

        void Start ()
        {
            AddCoins(initialCoins);
        }

        public void AddCoins(int coins)
        {
            currentCoins += coins;
        }

        public void RemoveCoins (int coins)
        {
            currentCoins -= coins;
        }
    }
}