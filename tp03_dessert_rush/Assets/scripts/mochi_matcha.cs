using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mochi_matcha : MonoBehaviour
{
        public GameObject fraise;
        public GameObject mangues;
        public GameObject chocolat;
        public GameObject matcha;
        public Transform spawnPoint;


        public void apparition()
        {
            Instantiate(matcha, spawnPoint);
        }
}
