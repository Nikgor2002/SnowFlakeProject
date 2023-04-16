using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rainflakes : MonoBehaviour
{
    public Material rainMaterial;
    public float particleSize = 0.1f;
    public Vector3 windDirection;
    public float temperature;

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
        mainModule.startSize = new ParticleSystem.MinMaxCurve(0.1f, 0.2f);
        mainModule.maxParticles = 1000000000;
        mainModule.loop = true;

        mainModule.simulationSpace = ParticleSystemSimulationSpace.Local;
        mainModule.scalingMode = ParticleSystemScalingMode.Shape;
        mainModule.gravityModifier = windDirection[1];

        emissionModule.rateOverTime = 30000f;
        
        if (temperature < 0f){
            particleSystem.Stop();
        }
    }

    void Update()
    {
        _tick += 0.002f;
        float y = _tick/10;
        Vector3 addVector = new Vector3(0f,y,0f);
        Vector3 Wind = new Vector3(windDirection[0]*_tick, 0f, windDirection[2]*_tick);
        Vector3 alfa = _startLocation - addVector + Wind;

        
        if (alfa[1] < -4.0f){
            alfa = _startLocation;
            _tick = 0f;
        }
        transform.localPosition = alfa;
        
    }
}