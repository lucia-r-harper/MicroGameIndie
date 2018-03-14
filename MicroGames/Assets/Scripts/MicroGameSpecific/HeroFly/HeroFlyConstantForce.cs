using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlyConstantForce : MonoBehaviour
{
    private ConstantForce2D constantForce2D;
    private const float difficultyScale = 50;
	// Use this for initialization
	void Start ()
    {
        constantForce2D = GetComponent<ConstantForce2D>();
        constantForce2D.force = new Vector2(constantForce2D.force.x + MetaGameManager.Difficulty / difficultyScale, 0);
	}
}
