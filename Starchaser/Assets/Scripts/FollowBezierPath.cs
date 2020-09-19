using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierPath : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    [SerializeField] List<GameObject> points;
    private float timeFactor = 0.0f;

    private void FixedUpdate()
    {
        if (timeFactor < 1.0f)
        {
            timeFactor += Time.fixedDeltaTime * speed;
            gameObject.transform.position = GetPositionOnTimeFactor(timeFactor);
        }
    }
    
    //IEnumerator Delay(float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //}

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Vector3 prevPosition = points[0].transform.position;
            Vector3 position;

            int numberOfPoints = 32;
            float t;
            for (int i = 0; i < numberOfPoints; i++)
            {
                t = i / (numberOfPoints - 1.0f);
                position = GetPositionOnTimeFactor(t);

                Gizmos.color = new Color(0.8f, 0.5f, 0.0f);
                Gizmos.DrawLine(prevPosition, position);
                prevPosition = position;
            }
        }
    }

    private Vector3 GetPositionOnTimeFactor(float t)
    {
        Vector3 currentPosition = new Vector3();
        float oneMinusT = 1.0f - t;

        for (int i = 0; i < points.Count; i++)
        {
            var scale = BinomialCalc(points.Count - 1, i, oneMinusT, t);
            currentPosition += scale * points[i].transform.position;
        }

        return currentPosition;
    }

    private int Factorial(int n)
    {
        if (n == 1 || n == 0)
            return 1;
        else if (n < 0)
        {
            return -1; // Cannot be determined
        }

        int curr = n;
        int result = 1;
        while (curr >= 2)
        {
            result *= curr;
            curr--;
        }
        return result;
    }
    private float BinomialCalc(int maxPow, int currentPow, float term1, float term2)
    {
        float coeff;
        coeff = Factorial(maxPow) / (Factorial(currentPow) * Factorial(maxPow - currentPow));
        return coeff * Mathf.Pow(term1, maxPow - currentPow) * Mathf.Pow(term2, currentPow); ;
    }
}
