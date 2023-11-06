using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
    [SerializeField]
    private float vitesse;
    [SerializeField]
    private float RotateSpeed;
    [SerializeField]
    private float accelerationTime = 1.0f; // Temps d'accélération en secondes
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private float ThreasoldMove;
    private float smoothSpeed;
    [SerializeField]
    private Vector3 velocity;
    private float currentspeed;

    private void Update()
    {
        if (currentspeed == 0.5f)
        {
            // Réinitialise la vitesse à zéro
            smoothSpeed = 0;
        }
        else
        {
            // Calcule la nouvelle vitesse en fonction de la valeurFloat
            float targetSpeed = currentspeed > 0.5f ? vitesse : -vitesse;

            // Utilisez une interpolation linéaire pour accélérer en douceur
            smoothSpeed = Mathf.Lerp(smoothSpeed, targetSpeed, Time.deltaTime / accelerationTime);
        }

        // Appliquez le mouvement au Rigidbody
        rb.MovePosition(rb.position + transform.forward * smoothSpeed * Time.deltaTime);
        audioSource.volume = smoothSpeed / 4f;

    }

    public void Move(float valeurFloat)
    {
        currentspeed = valeurFloat;
    }

    public void HorizontalTrun(float valeurFloat)
    {
        if(valeurFloat > 0.3)
        {
            Debug.Log("TrunLeft");
            velocity = valeurFloat * Vector3.down;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(-velocity * RotateSpeed * Time.deltaTime));
        }
        else if (valeurFloat < -0.3) 
        {
            Debug.Log("TrunRight");
            velocity = valeurFloat * Vector3.up;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(velocity * RotateSpeed * Time.deltaTime));
        }
    }

    public void VerticalTrun(float valeurFloat)
    {
        if (valeurFloat > 0.3)
        {
            Debug.Log("Up");
            velocity = valeurFloat * Vector3.right;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(-velocity * RotateSpeed * Time.deltaTime));
        }
        else if (valeurFloat < -0.3)
        {
            Debug.Log("Down");
            velocity = valeurFloat * Vector3.left;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(velocity * RotateSpeed * Time.deltaTime));
        }
    }
}
