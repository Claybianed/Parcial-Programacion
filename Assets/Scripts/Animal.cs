using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] int numDisparos;
    public bool lento = false;
    float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaSupIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaSupIzq.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (movingRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0), Space.World);
        }
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0), Space.World);


        if (transform.position.x > maxX)
        {
            movingRight = false;
        }
        else if (transform.position.x < minX)
            movingRight = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject colisionando = collision.gameObject;

        if (colisionando.tag == "Disparo")
        {
            ReducirVida();
            if (gm.lento == true)
            {
                numDisparos = 1;
                Destroy(this.gameObject);
                gm.ReducirNumEnemigos();
            }
            else
            {
                if (numDisparos < 1)
                {

                    Destroy(this.gameObject);
                    gm.ReducirNumEnemigos();
                }
            }
            
            
        }

        else if(colisionando.tag == "Disparo2")
        {
            
            ReducirVida();
            if (numDisparos < 1)
            {

                Destroy(this.gameObject);
                gm.ReducirNumEnemigos();
            }
        }
    }

    void ReducirVida()
    {

        numDisparos = numDisparos - 1;
    }
}
