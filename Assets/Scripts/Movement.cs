using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {

    public static float dragForce = 0.01f;
    // Use this for initialization
    void Start() {
        HeroShip = new Ship(new Vector3(0.0f, 0.0f, 0.0f), this.transform.position,5.0f);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            HeroShip.acceleration.x -= 1.0f;
            HeroShip.velocity = accelerateShip(HeroShip.acceleration, HeroShip.velocity, Time.deltaTime);
            HeroShip.position = changeShipPosition(HeroShip.acceleration, HeroShip.position, HeroShip.velocity, Time.deltaTime);
            this.transform.position = HeroShip.position;

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            HeroShip.acceleration.x += 1.0f;
            HeroShip.velocity = accelerateShip(HeroShip.acceleration, HeroShip.velocity, Time.deltaTime);
            HeroShip.position = changeShipPosition(HeroShip.acceleration, HeroShip.position, HeroShip.velocity, Time.deltaTime);
            this.transform.position = HeroShip.position;

        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            HeroShip.acceleration.y += 10.0f;
            HeroShip.velocity = accelerateShip(HeroShip.acceleration, HeroShip.velocity, Time.deltaTime);
            HeroShip.position = changeShipPosition(HeroShip.acceleration, HeroShip.position, HeroShip.velocity, Time.deltaTime);
            this.transform.position = HeroShip.position;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            HeroShip.acceleration.y -= 1.0f;
            HeroShip.velocity = accelerateShip(HeroShip.acceleration, HeroShip.velocity, Time.deltaTime);
            HeroShip.position = changeShipPosition(HeroShip.acceleration, HeroShip.position, HeroShip.velocity, Time.deltaTime);
            this.transform.position = HeroShip.position;
        }
        else
        {
            HeroShip.position = HeroShip.velocity * Time.deltaTime + HeroShip.position;
            HeroShip.velocity = useResistivForce(HeroShip);
            this.transform.position = HeroShip.position;
        }
        HeroShip.acceleration = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private Vector3 useResistivForce(Ship heroShip)
    {
        if (isMoving(heroShip))
        {
            return slowTheShip(heroShip.velocity);
        }
        else
            return heroShip.velocity;
    }
    private Vector3 slowTheShip(Vector3 velocity)
    {
        velocity -= velocity * dragForce;
        return velocity;
    }

    private static bool isMoving(Ship heroShip)
    {
        return heroShip.velocity.magnitude > 0.0f;
    }

    private Vector3 changeShipPosition(Vector3 acceleration , Vector3 position, Vector3 velocity, float dt)
    {
        if (isMaxSpeed(velocity))
            position = acceleration * dt * dt * 0.5f + velocity * dt + position;
        else
            position = velocity * dt;
        return position;
    }

    private Vector3 accelerateShip(Vector3 acceleration, Vector3 velocity, float dt)
    {
        if (isMaxSpeed(velocity))
            velocity = acceleration * dt + velocity;
        return velocity;
    }

    private bool isMaxSpeed(Vector3 v)
    {
        if ( v.magnitude <= 7.0f )
            return true;
        else
            return false;
    }
    private Ship HeroShip;
}


