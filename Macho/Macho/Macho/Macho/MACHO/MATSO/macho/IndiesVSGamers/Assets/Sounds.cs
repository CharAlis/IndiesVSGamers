using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public static Sounds Instance;

    void Awake() {
        Instance = this;
    }

    public void RocketLaucnher() {
        audioSource.clip = audioClips[6];
        audioSource.pitch = 1f;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void Gun() {
        audioSource.clip = audioClips[5];
        audioSource.pitch = 2f;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void Shotgun() {
        audioSource.clip = audioClips[3];
        audioSource.pitch = 1f;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void Magnum() {
        audioSource.clip = audioClips[2];
        audioSource.pitch = 1.2f;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayAK47() {
        audioSource.clip = audioClips[1];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayMinigun() {
        audioSource.clip = audioClips[0];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayLaser() {
        audioSource.clip = audioClips[4];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopAK47() {
        audioSource.Stop();
    }

    public void StopMinigun() {
        audioSource.Stop();
    }

    public void StopLaser() {
        audioSource.Stop();
    }
}
