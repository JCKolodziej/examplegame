using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Source
{
    public class Pause:MonoBehaviour
    {
        //publiczne referencje
        public static void StopTime()
        {
            Time.timeScale = 0;
            GameObject.Find("PauseMenu").SetActive(true);
                    }

        public static void StartTime()
        {
            Time.timeScale = 1;
            GameObject.Find("PauseMenu").SetActive(false);
        }


    }
}
