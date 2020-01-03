using System.Collections;
using UnityEngine;

public class WalkDetector : MonoBehaviour
{
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;

    public bool IsWalking { get; private set; } = false;

    bool isRightMoving = false;
    bool isLeftMoving = false;

    float prevLeftY = 0;
    float prevRightY = 0;

    void Update()
    {
        float leftDelta = leftHand.transform.position.y - prevLeftY;
        float rightDelta = rightHand.transform.position.y - prevRightY;

        if (leftDelta != 0)
            isLeftMoving = true;
        else
            StartCoroutine(LeftStopTimer());

        if (rightDelta != 0)
            isRightMoving = true;
        else
            StartCoroutine(RightStopTimer());

        if (isRightMoving && isLeftMoving && ((leftDelta < 0) != (rightDelta < 0)))
            IsWalking = true;
        else
            IsWalking = false;

        prevLeftY = leftHand.transform.position.y;
        prevRightY = rightHand.transform.position.y;
    }

    IEnumerator LeftStopTimer()
    {
        float cur = leftHand.transform.position.y;
        yield return new WaitForSeconds(0.2f);
        isLeftMoving = cur != leftHand.transform.position.y; 
    }

    IEnumerator RightStopTimer()
    {
        float cur = rightHand.transform.position.y;
        yield return new WaitForSeconds(0.2f);
        isRightMoving = cur != rightHand.transform.position.y;
    }
}