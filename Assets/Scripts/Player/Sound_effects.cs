using UnityEngine;

public class Sound_effects : MonoBehaviour
{
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource walk;
    [SerializeField] private AudioSource death_hit;
    [SerializeField] private AudioSource death_song;

    public void jump_play()
    {
        jump.Play();
    }

    public void walk_play()
    {
        walk.Play();
    }

    public void death_hit_play()
    {
        death_hit.Play();
    }

    public void death_song_play()
    {
        death_song.Play();
    }
}
