using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticleSystemRotation : MonoBehaviour {
    ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        ParticleSystem.MainModule psmain = ps.main;
        psmain.startSizeZMultiplier = transform.rotation.eulerAngles.z;
    }
}
