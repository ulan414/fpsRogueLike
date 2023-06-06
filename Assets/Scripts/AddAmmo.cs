using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class AddAmmo : MonoBehaviour
{
    RetrieveAllGrades retrieveAllGrades;
    [SerializeField] int AddAmmoTotal;
    public AudioClip soundClip;
    private AudioSource audioSource;

    void Awake()
    {
        GameObject targetObject = GameObject.Find("RetrieveUpgrades");
        retrieveAllGrades = targetObject.GetComponent<RetrieveAllGrades>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Perform your desired action here when collision with "Player" occurs
            Debug.Log("Collision with Player detected!");
            retrieveAllGrades.AddTotalAmmoGun(AddAmmoTotal);
            audioSource = GetComponent<AudioSource>();
            audioSource = gameObject.AddComponent<AudioSource>();
            StartCoroutine(PlaySoundAndDestroy());
        }
    }
    private System.Collections.IEnumerator PlaySoundAndDestroy()
    {
        // Set the audio clip to play
        audioSource.clip = soundClip;

        // Play the audio clip
        audioSource.Play();

        // Wait for the sound to finish playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Destroy the object after the sound finishes
        Destroy(gameObject);
    }
}
