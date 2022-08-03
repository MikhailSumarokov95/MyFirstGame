using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyMan.Game
{
    public class DifficultyControler : MonoBehaviour
    {
        public int Difficulty { get; private set; }

        private void Start()
        {
            Difficulty = 1;
        }

        public int UpDifficulty()
        {
            return Difficulty++;
        }

        public void ResetDifficulty()
        {
            Difficulty = 1;
        }
    }
}
