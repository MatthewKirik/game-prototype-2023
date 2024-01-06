using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Character
{
    public class BulletScript : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject, 5);    
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}
