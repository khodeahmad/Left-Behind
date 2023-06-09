﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Rocket Platform's visuals, and launches the Rocket
/// </summary>
public class RocketPlatform : MonoBehaviour, IInteractable
{
    [SerializeField] MeshRenderer display;
    [SerializeField] Material onMaterial;
    [SerializeField] Material offMaterial;

    [SerializeField] ParticleSystem smokeParticles;
    [SerializeField] ScreenFade screenFade;

    [SerializeField] MeshRenderer rocketBase;
    [SerializeField] MeshRenderer rocketFuel;
    [SerializeField] MeshRenderer rocketSides;
    [SerializeField] MeshRenderer rocketFins;
    [SerializeField] MeshRenderer rocketTop;

    [SerializeField] GameObject RocketLigth;

    private int Scenes = 0;
    public static int ScenesMenu = 0;

    RocketFlameAnim flameAnim;
    RocketPath rocketPath;

    void Awake()
    {
        flameAnim = GetComponentInChildren<RocketFlameAnim>();
        rocketPath = GetComponentInChildren<RocketPath>();
        rocketBase.enabled = false;
        rocketFuel.enabled = false;
        rocketSides.enabled = false;
        rocketFins.enabled = false;
        rocketTop.enabled = false;
        RocketLigth.SetActive(false);
        Scenes = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        ScenesMenu = Scenes;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRocketComplete())
        {
            display.material = onMaterial;
        }
        else
        {
            display.material = offMaterial;
        }
    }
    bool IsRocketComplete()
    {
        return (rocketBase.enabled && rocketFuel.enabled && rocketSides.enabled && rocketFins.enabled && rocketTop.enabled);
    }
    public void Interact()
    {
        if (IsRocketComplete())
        {
            RocketLigth.SetActive(true);
            LaunchRocket();
        }
    }

    private void LaunchRocket()
    {
        CameraFollow.target = rocketFuel.gameObject;
        smokeParticles.Play();
        flameAnim.Ignite();
        rocketPath.ignite = true;
        rocketBase.transform.parent = null;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        Invoke(nameof(SlowHideHook), 3f);

        Invoke(nameof(EndGame), 6f);
    }
    void SlowHideHook()
    {
        screenFade.SlowHide();
    }
    void EndGame()
    {
        Scenes++;

        if (Scenes < 9)
        {
            StartMenu.SaveLevel(new LevelData(Scenes));
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(Scenes);
    }
    [ContextMenu("Complete rocket")]
    public void CompleteRocket()
    {
        rocketBase.enabled = true;
        rocketFuel.enabled = true;
        rocketSides.enabled = true;
        rocketFins.enabled = true;
        rocketTop.enabled = true;
    }
    public void AddPart(RocketPart.Type partType)
    {
        switch (partType)
        {
            case RocketPart.Type.Base:
                rocketBase.enabled = true;
                return;
            case RocketPart.Type.Fuel:
                rocketFuel.enabled = true;
                return;
            case RocketPart.Type.Sides:
                rocketSides.enabled = true;
                return;
            case RocketPart.Type.Fins:
                rocketFins.enabled = true;
                return;
            case RocketPart.Type.Top:
                rocketTop.enabled = true;
                return;
        }
    }
}
