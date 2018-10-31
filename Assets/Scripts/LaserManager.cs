using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour {

    HashSet<Laser> lasers;

    public static LaserManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        lasers = new HashSet<Laser>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateLasers();
	}

    void UpdateLasers()
    {
        foreach(Laser laser in lasers)
        {
            laser.UpdateLaser();
        }
    }

    public void AddLaser(Laser laser)
    {
        lasers.Add(laser);
    }

    //this gets called by a block object which wants to know which lasers are hitting it
    public HashSet<Laser> GetInputLasers(BlockObject blockObject)
    {
        HashSet<Laser> lasersToReturn = new HashSet<Laser>();

        foreach (Laser laser in lasers)
        {
            if(laser.destinationBlock == blockObject)
            {
                lasersToReturn.Add(laser);
            }
        }

        return lasersToReturn;
    }
}
