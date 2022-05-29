using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundManager Instance;

    public string pathFilesSound;

    private void Update()
    {
        PlaySound("DESTROY_CARD");
        PlaySound("PICK_CARD");
    }

    public void PlaySound(string nameSound)
    {
        // to do
        // play ressource sound
    }
}