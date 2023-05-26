using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class Snowflake : MonoBehaviour
{

    public Material snowMaterial;
    public float particleSize = 0.1f;
    public Vector3 windDirection;
    public float temperature;
    public float countSnowflake;
    


    private ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.EmissionModule emissionModule;
    private ParticleSystemRenderer particleSystemRenderer;
    private float _tick = 0;
    private Vector3 _startLocation;

    void Start()
    {
        _startLocation = transform.localPosition;
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;
        emissionModule = particleSystem.emission;
        particleSystemRenderer = GetComponent<ParticleSystemRenderer>();

        mainModule.startLifetime = new ParticleSystem.MinMaxCurve(25f, 30f);
        mainModule.startSpeed = new ParticleSystem.MinMaxCurve(0.2f, 0.3f);
        mainModule.startSize = new ParticleSystem.MinMaxCurve(0.1f, 0.15f);
        mainModule.maxParticles = 1000000000;
        mainModule.loop = true;


        mainModule.simulationSpace = ParticleSystemSimulationSpace.Local;
        mainModule.scalingMode = ParticleSystemScalingMode.Shape;
        mainModule.gravityModifier = windDirection[1];

        emissionModule.rateOverTime = countSnowflake;
        
        // Добавляем компонент Rotation over lifetime и настраиваем его параметры
        ParticleSystem.RotationOverLifetimeModule rotationModule = particleSystem.rotationOverLifetime;
        rotationModule.enabled = true;
        rotationModule.z = windDirection[2]/3f;
        rotationModule.x = windDirection[0]/3f;
        rotationModule.y = windDirection[1]/3f;

        if (temperature >= 3f)
        {
            particleSystem.Stop();
        }

    }

    void Update()
    {
        _tick += 0.001f;
        
        float x = (float)((0.4f) * Math.Sin(_tick));
        float y = _tick / 10;
        float z = (float)((0.4f) * Math.Cos(_tick));
        Vector3 addVector = new Vector3(x, y, z);
        Vector3 Wind = new Vector3(windDirection[0] * _tick, 0f, windDirection[2] * _tick);
        Vector3 alfa = _startLocation - addVector + Wind;


        if (alfa[1] < -7.0f)
        {
            alfa = _startLocation;
            _tick = 0f;
        }
        transform.localPosition = alfa;

    }
}