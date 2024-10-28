using System.Collections;
using UnityEngine;

public class MovementSoundsScript : MonoBehaviour
{
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        StartCoroutine(PlayFootstepSound());
    }
    
    // Coroutine to play the footstep sound at intervals
    private IEnumerator PlayFootstepSound()
    {
        while (true)
        {
            if (_characterController.velocity.x > 0.1 || _characterController.velocity.z > 0.1)
            {
                var randomSoundNumber = Random.Range(1, 3);
                SoundManager.Instance.Play("grass-footstep-" + randomSoundNumber); // Play the footstep sound
                Debug.Log("Sound was played");
            }
            yield return new WaitForSeconds(0.6f); // Wait for 1 second before playing the next sound
        }
    }
}