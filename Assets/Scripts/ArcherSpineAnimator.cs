using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;

public class ArcherSpineAnimator : MonoBehaviour
{

    private SkeletonAnimation _skeletonAnimation;
    [SerializeField] Archer _archer;
    [SerializeField] Transform _rotatingBone;

    [SerializeField] private AnimationReferenceAsset _idle,_attackStart,_attackTarget, _attackFinish;
    private string IDLE = "Idle";
    private string ATTACK_START = "attack_start";
    private string ATTACK_TARGET = "attack_target";
    private string ATTACK_FINISH = "attack_finish";

    private string currentState;
    // Start is called before the first frame update
    private void OnEnable()
    {
       
    }
    private void OnDisable()
    {
        InputHandler.instance.OnMouseLeftPressed -= StartOfShooting;
    }
    private void Awake()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
    }
    void Start()
    {
        InputHandler.instance.OnMouseLeftPressed += StartOfShooting;
        InputHandler.instance.OnMouseLeftRelease += Shooting;
        currentState = IDLE;
        SetCharacterState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        RotateArcherBody();
    }

    //changing the animation
    private void SetAnimation(AnimationReferenceAsset animation,bool loop,float timeScale) {
        Spine.TrackEntry animationEntry = _skeletonAnimation.state.SetAnimation(0, animation, loop);
        animationEntry.TimeScale = timeScale;
        animationEntry.Complete += AnimationEntry_Complate;

    }
    private void AnimationEntry_Complate(Spine.TrackEntry tranEntry)
    {
        if(currentState.Equals(ATTACK_START))
        {
            SetCharacterState(ATTACK_TARGET);
        }
        if(currentState.Equals(ATTACK_FINISH))
        {
            SetCharacterState(IDLE);
        }
    }
    private void SetCharacterState(string state)
    {
        if (state.Equals(IDLE))
        {
            SetAnimation(_idle, true, 1f);
        }
        if(state.Equals(ATTACK_START))
        {
            SetAnimation(_attackStart, false, 1f);
        }
        if (state.Equals(ATTACK_TARGET))
        {
            SetAnimation (_attackTarget, true, 1f);
        }
        if (state.Equals(ATTACK_FINISH))
        {
            SetAnimation(_attackFinish, false, 1f);
        }
        currentState = state;
    }

    private void StartOfShooting()
    {
        SetCharacterState(ATTACK_START);

       // Debug.Log("wow");
    }
    private void Shooting()
    {
        SetCharacterState(ATTACK_FINISH);
      //  Debug.Log("wowow");
    }
    private void RotateArcherBody()
    {
        float _angle = _archer.GetActualAngle();
        _rotatingBone.transform.rotation = Quaternion.Euler(0f, 0f, _angle + 90);
    }
}
