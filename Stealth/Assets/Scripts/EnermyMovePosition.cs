using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMovePosition : MonoBehaviour
{
    public List<Transform> movePositions;
    public float moveSpeed = 1;
    private void Start()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        bool isMoving = false;
        while (!isMoving)
        {
            for (int i = 0; i < movePositions.Count; i++)
            {
                Vector3 oldPos = this.transform.position;
                transform.LookAt(LokAtPosition(movePositions[i].position));
                while (MoveToNextNode(movePositions[i].position))
                {
                    isMoving = true;
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);
                isMoving = false;
                if (i == movePositions.Count - 1)
                {
                    i = 0;
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
}
