using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts
{
    public static class GameHandler
    {
        private static int Life = 3;
        private static int BearLife = 20;
        private static int Score = 0;

        public static bool HasCheckpoint;
        public static Vector3 LatestCheckpointPosition;

        #region Lifes      
        public static void AddBearLifes(int lifes)
        {
            BearLife += lifes;
        }
        public static void ReduceBearLife()
        {
            BearLife = BearLife-1;
        }
        public static int GetBearLifes()
        {
            return BearLife;
        }
        public static bool HasBearLifes()
        {
            return GetBearLifes() > 0;
        }
   

        public static void ResetLatestCheckpointPosition()
        {
            LatestCheckpointPosition = new Vector3(-18.8f, -3.67f);
        }

        public static void AddLife()
        {
            Life++;
        }
        public static void ReduceLife()
        {
            Life--;
        }
        public static int GetLifes()
        {
            return Life;
        }
        public static bool HasLifes()
        {
            return GetLifes() > 0;
        }
        #endregion

        #region Score
        public static void AddScore(int pointsAmount = 10)
        {
            Score += pointsAmount;
        }
        public static void ClearScore()
        {
            Score = 0;
        }
        public static int GetScore()
        {
            return Score;
        }
        #endregion  
    }
}
