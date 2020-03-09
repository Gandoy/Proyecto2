using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private void Mute ()
    {
        AudioListener.volume = 0;
    }
    private void Unmute ()
    {
        AudioListener.volume = 1;
    }
}
