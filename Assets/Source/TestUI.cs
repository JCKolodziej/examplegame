using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace Assets.Source
{
    class TestUI: MonoBehaviour
    {
        /*public GameObject Obj;*/

        public TextMeshProUGUI TextObject;
        public void OnButtonClick(string text)
        {
            //Obj.SetActive(!Obj.activeSelf);
            TextObject.text = text;
        }
    }
}
