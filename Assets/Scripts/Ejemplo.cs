using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        bool pressKeyDer = Input.GetKey(KeyCode.RightArrow);
        bool pressKeyIzq = Input.GetKey(KeyCode.LeftArrow);
        bool pressKeyUp = Input.GetKey(KeyCode.UpArrow);
        bool pressKeyDown = Input.GetKey(KeyCode.DownArrow);
        bool pressKeyD = Input.GetKey(KeyCode.D);
        bool pressKeyA = Input.GetKey(KeyCode.A);

        if (pressKeyDer)
        {
            Vector2 movimiento = new Vector2(0.1f * speed, 0);
            transform.Translate(movimiento, Space.World);
        }

        if (pressKeyIzq)
        {
            Vector2 movimiento = new Vector2(-0.1f * speed, 0);
            transform.Translate(movimiento, Space.World);
        }

        if (pressKeyUp)
        {
            Vector2 movimiento = new Vector2(0, 0.1f * speed);
            transform.Translate(movimiento, Space.World);
        }

        if (pressKeyDown)
        {
            Vector2 movimiento = new Vector2(0, -0.1f * speed);
            transform.Translate(movimiento, Space.World);
        }

        if (pressKeyD)
        {
            Vector3 rotacion = new Vector3(0, 0, -0.1f * 12);
            transform.Rotate(rotacion);
        }

        if (pressKeyA)
        {
            Vector3 rotacion = new Vector3(0, 0, 0.1f * 12);
            transform.Rotate(rotacion);
        }
    }
}
