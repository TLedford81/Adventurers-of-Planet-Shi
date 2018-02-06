using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public Slider healthSlider, hungerSlider, thirstSlider, sanitySlider, energySlider;
    public AudioClip[] soundEffects;
    public float loseHungerEvery, loseThirstEvery;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Remove 1 Point of Hunger Every X Seconds (Defined in Editor)
        InvokeRepeating("LowerHunger", loseHungerEvery, loseHungerEvery);
        InvokeRepeating("LowerThirst", loseThirstEvery, loseThirstEvery);
    }

    void Update()
    {

        //Regain Energy by consuming Hunger / Thirst
        if(energySlider.value > energySlider.maxValue)
        {
            //StartCoroutine();
        }

        ///////////////////////////////////
        // Play Sounds when Low on Stats
        // - Hunger: Stomach Rumble
        // - Thirst: Coughing?
        // - Sanity: Laughing
        // - Energy: Panting
        ///////////////////////////////////

        if(hungerSlider.value <= 20)
        {
            audioSource.clip = soundEffects[0];
            audioSource.Play();
        }
        if (thirstSlider.value <= 20)
        {
            audioSource.clip = soundEffects[1];
            audioSource.Play();
        }
        if (sanitySlider.value <= 20)
        {
            audioSource.clip = soundEffects[2];
            audioSource.Play();
        }
        if (energySlider.value <= 20)
        {
            audioSource.clip = soundEffects[3];
            audioSource.Play();
        }
    }

    void LowerHunger() { hungerSlider.value -= 1; }

    void LowerThirst() { thirstSlider.value -= 1; }

//    void LowerEnergy()
//    {
//        energySlider.value -= 1;
//    }
}
