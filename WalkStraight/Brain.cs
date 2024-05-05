using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class Brain : MonoBehaviour
{
    public int DNALength = 1;
    public float timeAlive;
    public float distanceTravelled;
    Vector3 startPosition;
    public DNA dna;

    private ThirdPersonCharacter m_Character;
    private Vector3 m_Move;
    private bool m_Jump;
    bool alive = true;

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void Init()
    {
        //initialise DNA
        //0 forward
        //1 back
        //2 left
        //3 right
        //4 jump
        //5 crouch
        dna = new DNA(DNALength, 6);
        m_Character = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
    }


    void Update()
    {

    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        // read DNA
        float h = 0;
        float v = 0;
        bool crouch = false;
        if (dna.GetGene(0) == 0) v = 1;
        else if (dna.GetGene(0) == 1) v = -1;
        else if (dna.GetGene(0) == 2) h = -1;
        else if (dna.GetGene(0) == 3) h = 1;
        else if (dna.GetGene(0) == 4) m_Jump = true;
        else if (dna.GetGene(0) == 5) crouch = true;

        m_Move = v * Vector3.forward + h * Vector3.right;
        m_Character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
        if (alive)
        {
            timeAlive += Time.deltaTime;
            distanceTravelled = Vector3.Distance(this.transform.position, startPosition);
        }
    }
}
