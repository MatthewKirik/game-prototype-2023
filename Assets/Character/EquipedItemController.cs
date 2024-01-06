using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Character
{
    public class EquipedItemController : MonoBehaviour
    {
        private MovementController movementController;

        public Transform item;

        void Start()
        {
            movementController = GetComponent<MovementController>();
        }

        void Update()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float zAngle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
            if (movementController.IsMirrored)
            {
                zAngle += 180;
            }

            float xAngle = 0;
            if (zAngle is > 90 or < -90)
            {
                xAngle = 180;
                zAngle = -zAngle;
            }

            item.eulerAngles = new Vector3(xAngle, 0, zAngle);
        }
    }
}
