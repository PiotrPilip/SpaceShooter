using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
	public Ship(Vector3 a, Vector3 p, float maxS)
	{
        velocity = new Vector3(1.0f, 2.0f, 0.0f);
        acceleration = a;
        _maxSpeed = maxS;
        position = p;
	}
    private float _maxSpeed;
    public float maxSpeed { get { return _maxSpeed; } }
    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 position;
}
