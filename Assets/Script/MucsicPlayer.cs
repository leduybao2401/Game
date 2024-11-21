using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MucsicPlayer : MonoBehaviour
{
    public AudioSource introlSource, loopSource;
    // Start is called before the first frame update
    void Start()
    {
        introlSource.Play();
        loopSource.PlayScheduled(AudioSettings.dspTime + introlSource.clip.length);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
