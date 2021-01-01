using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public float rotationMin = -100f;
    public float rotationMax = 100f;
    public float enemyRotateSpeed = 3f;
    public float enemyStopTime = 0.5f;
    private Vector3 temp;
    private Vector3 minR;
    private Vector3 maxR;
    private bool isR = false;
    private int index_temp = 0;
    private List<Vector3> vecterlist;
    private void Start()
    {

        temp = new Vector3(0, this.transform.rotation.y, 0);
        minR = new Vector3(0, this.transform.rotation.y + rotationMin, 0);
        maxR = new Vector3(0, this.transform.rotation.y + rotationMax, 0);
        CreateVectorList();
    }
    private void CreateVectorList()
    {
        vecterlist = new List<Vector3>();
        vecterlist.Add(minR);
        vecterlist.Add(temp);
        vecterlist.Add(maxR);
        vecterlist.Add(temp);
    }
    private void LateUpdate()
    {
        if (!isR)
        {
            isR = true;
            RotateLean(index_temp);
        }
    }
    private void RotateLean(int _index)
    {
        var seq = LeanTween.sequence();
        seq.append(enemyStopTime);
        seq.append(LeanTween.rotate(this.gameObject, vecterlist[_index], enemyRotateSpeed).setOnComplete(() => sss()));

    }
    private void sss()
    {
        isR = false;
        index_temp++;
        if (index_temp == vecterlist.Count)
        {
            index_temp = 0;
        }

    }
}
