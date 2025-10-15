using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    int horizontal;
    int vertical;
    private void Awake()
    {
        animator = GetComponent<Animator>();

        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimationValues(float horizontalMovement, float verticalMovement)
    {
        float snappedHorizontal = 0;
        float snappedVertical = 0;

        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            snappedHorizontal = 0.5f;

        } else if(horizontalMovement > .55f){
            snappedHorizontal = 1f;
        }
        else if(horizontalMovement < 0 && horizontalMovement > -.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if(horizontalMovement < -0.55) 
        { snappedHorizontal = -1f; } 
        else 
        { snappedHorizontal = 0; }



        if (verticalMovement > 0 && verticalMovement < .55f){
            snappedVertical = .5f;
        } else if (verticalMovement > .55){
            snappedVertical = 1f;
        }
        else if (verticalMovement < 0 && verticalMovement > -.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalMovement < -0.55) { snappedVertical = -1f; } else { snappedVertical = 0; }


        animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);

        animator.SetFloat(vertical, snappedVertical,0.1f,Time.deltaTime);
    }
}
