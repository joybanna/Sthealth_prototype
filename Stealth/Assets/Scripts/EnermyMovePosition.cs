using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnermyMovePosition : MonoBehaviour
{
    public List<Transform> movePositions;
    public float moveSpeed = 1;
    public Transform eyeEnemy;
    public float enemyStopTime = 0.1f;
    public float enemyRotate = 0.5f;
    private int currentPoint = 0;
    private void Start()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        bool isMoving = false;

        while (!isMoving)
        {
            for (int i = currentPoint; i < movePositions.Count; currentPoint++)
            {
                RotationEnemy(LokAtPosition(movePositions[currentPoint].position));
                while (MoveToNextNode(movePositions[currentPoint].position))
                {
                    isMoving = true;
                    yield return null;
                }
                yield return new WaitForSeconds(enemyStopTime);
                isMoving = false;
                if (currentPoint == movePositions.Count - 1)
                {
                    currentPoint = 0;
                }
            }
        }
    }
    private bool MoveToNextNode(Vector3 _goal)
    {
        return _goal != (transform.position = Vector3.MoveTowards(transform.position, _goal, moveSpeed * Time.fixedDeltaTime));
    }
    private Vector3 LokAtPosition(Vector3 _pos)
    {
        return new Vector3(_pos.x, this.transform.position.y, _pos.z);
    }

    private void RotationEnemy(Vector3 _nextPos)
    {
        eyeEnemy.LookAt(_nextPos);
        Quaternion eyeRotate = eyeEnemy.rotation;
        Vector3 angleEuler = eyeRotate.eulerAngles;
        LeanTween.rotate(this.gameObject, angleEuler, enemyRotate);
    }

}
