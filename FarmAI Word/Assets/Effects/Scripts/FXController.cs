using UnityEngine;

public class FXController : MonoBehaviour
{
    [Header("VFX")]
    public GameObject taskComplete;
    public GameObject plantationDeath;
    public Transform target;

    [Header("SFX")]
    public AudioClip[] audios;
    AudioSource au;
    float timeBySounds;

    private void Start()
    {
        au = GetComponent<AudioSource>();
    }
    private void Update()
    {

    }
    public void StartCompleteVFX()
    {
        Instantiate(taskComplete, target.transform.position, Quaternion.identity);
        au.PlayOneShot(audios[1]);
    }
    public void StartDeathVFX()
    {
        Instantiate(plantationDeath, new Vector3(target.transform.position.x,
            target.transform.position.y + 2, target.transform.position.z), Quaternion.identity);
        au.PlayOneShot(audios[2]);
        au.PlayOneShot(audios[3]);
    }
    public void StartAlert()
    {
        StartAlertSound();
    }
    private void StartAlertSound()
    {
        if(Time.time > timeBySounds)
        {
            timeBySounds = Time.time + 1;
            au.PlayOneShot(audios[0]);
        }
    }
    public void StartWaterSound()
    {
        if(!au.isPlaying)
        {
            au.PlayOneShot(audios[0]);
        }
    }
    public void StartWaterVFX()
    {
        if(Time.time > timeBySounds)
        {
            timeBySounds = Time.time + 0.5f;
            Instantiate(taskComplete, target.transform.position, Quaternion.identity);
        }
    }
    public void StartStepsSound()
    {
        if(Time.time > timeBySounds)
        {
            timeBySounds = Time.time + 0.35f;
            au.PlayOneShot(audios[Random.Range(0, audios.Length)]);
        }
    }
    public void StartTakeItem(int n)
    {
        au.PlayOneShot(audios[n]);
    }
}
