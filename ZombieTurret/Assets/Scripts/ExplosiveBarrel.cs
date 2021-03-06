﻿using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : AbstractEnemy {
    public GameObject explosion;
    public float explosionRadius;

    protected override void Attack()
    {
    }

    private new void OnDeath() {
        _movementDisposable.Dispose();
        Destroy(gameObject);
    }

    protected override void DistanceToPlayer(float distance)
    {
    }

    protected override void Movement()
    {
    }

    public void OnDestroy()
    {
        AudioSingleton.Instance.playSounds(SoundTypes.Explosion);
        Instantiate(explosion, transform.position, Quaternion.identity);
        var hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (var i in hits)
        {
            var abstractEnemy = i.GetComponent<AbstractEnemy>();
            if (abstractEnemy != null &&
                (abstractEnemy._gameObjectType == ObjectType.Knight ||
                abstractEnemy._gameObjectType == ObjectType.Ranged))
            {
                abstractEnemy.applyDamage(100);
            }
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
