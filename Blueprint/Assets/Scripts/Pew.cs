using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pew : MonoBehaviour
{
    LineRenderer lineRenderer;

    bool visible;

    // Start is called before the first frame update
    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate() // ���������� 60 ��� � �������, ��� ��� �����������
    {

        if (visible)
        {
            visible = false;
        }
        else
        {

            gameObject.SetActive(false);

        }

        

    }

    public void Show(Vector3 from, Vector3 to) 
    {
        lineRenderer.SetPositions(new Vector3[] { from, to });
        visible = true;
        gameObject.SetActive(true);
    }

}
