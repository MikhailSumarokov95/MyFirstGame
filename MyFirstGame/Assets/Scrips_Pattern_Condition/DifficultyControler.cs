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
            Difficulty = 0;
        }

        public int DefinitionDifficulty(int scoreRound)
        {
            if (scoreRound > 0) Difficulty++;
            else Difficulty = 0;
            return Difficulty;
        }
    }
}
