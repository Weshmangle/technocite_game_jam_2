using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundManager Instance;

    private void Update()
    {
        // Test de la fonction PlaySound
            PlaySound("DESTROY_CARD");
            PlaySound("PICK_CARD");
    }

    public void PlaySound(string nameSound)
    {
        // to do
        // play ressource sound
    }
}