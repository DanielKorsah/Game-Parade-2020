using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Directions
{
    Down,
    Up,
    Left,
    Right,
    None
};


public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private List<List<string>> animSets = new List<List<string>>();
    private List<string> animStates0 = new List<string>() { "WalkDown0", "WalkUp0", "WalkLeft0", "WalkRight0", "PlayerIdle0" };
    private List<string> animStates1 = new List<string>() { "WalkDown1", "WalkUp1", "WalkLeft1", "WalkRight1", "PlayerIdle1" };
    private List<string> animStates2 = new List<string>() { "WalkDown2", "WalkUp2", "WalkLeft2", "WalkRight2", "PlayerIdle2" };
    private List<string> animStates3 = new List<string>() { "WalkDown3", "WalkUp3", "WalkLeft3", "WalkRight3", "PlayerIdle3" };
    private string currentAnimaton;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        animSets.Add(animStates0);
        animSets.Add(animStates1);
        animSets.Add(animStates2);
        animSets.Add(animStates3);
    }


    public void ChangeAnimationState(Directions dir)
    {
        string newAnimation = animSets[CharacterInfo.PlayerSpriteIndex][(int)dir];
        if (currentAnimaton == newAnimation)
        {
            return;
        }
        else
        {
            animator.Play(newAnimation);
            currentAnimaton = newAnimation;
        }
    }
}
