using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int lives = 2;  // Número de vidas del bloque, puedes ajustar este valor en el inspector de Unity.

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void Hit()
    {
        lives--;

        if (lives <= 0)
        {
            gameManager.BrickDestroyed(); // Notifica al GameManager que el bloque fue destruido
            Destroy(gameObject);  // Destruye el bloque cuando las vidas llegan a cero
        }
        else
        {
            // Aquí puedes cambiar el color o apariencia del bloque, si quieres.
            Debug.Log("Bloque golpeado. Vidas restantes: " + lives);
        }
    }
}

