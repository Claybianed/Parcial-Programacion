using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovimiento : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] float fireRate2;

    bool TD = true;
    float minX, maxX, minY, maxY;
    float nextFire = 0;

   public bool gamePaused = false;
    public bool lento = false;

    [SerializeField] GameObject disparo;
    [SerializeField] GameObject disparo2;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSupDer.x - 0.7f;
        minX = esquinaInfIzq.x + 0.7f;
        maxY = esquinaSupDer.y - 0.7f;

        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.238f));
        minY = puntoX.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePaused==false && lento==false)
        {
            Moverse();

            if (TD == true)
            {
                Disparo();
            }

            else
            {
                Disparo2();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (TD)
                {
                    TD = false;
                }
                else
                {
                    TD = true;
                }
            }
        }

        else if(gamePaused == false && lento == true)
        {
            Moverse();

            if (TD == true)
            {
                Disparo();
            }

            else
            {
                Disparo2();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (TD)
                {
                    TD = false;
                }
                else
                {
                    TD = true;
                }
            }
        }

         
    }

    

    void Disparo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(disparo, transform.position - new Vector3(0, 1, 0), transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    void Disparo2()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            Instantiate(disparo2, transform.position - new Vector3(0, 1, 0), transform.rotation);
            nextFire = Time.time + fireRate2;
            Instantiate(disparo2, transform.position - new Vector3(0, 1.6f, 0), transform.rotation);
            nextFire = Time.time + fireRate2;
            Instantiate(disparo2, transform.position - new Vector3(0, 2.2f, 0), transform.rotation);
            nextFire = Time.time + fireRate2;
        }
    }

    void Moverse()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, dirV * Time.deltaTime * speed);
        transform.Translate(movimiento);

        if (transform.position.x > maxX)
            transform.position = new Vector2(maxX, transform.position.y);

        if (transform.position.x < minX)
            transform.position = new Vector2(minX, transform.position.y);

        if (transform.position.y > maxY)
            transform.position = new Vector2(transform.position.x, maxY);

        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }


    }
}
