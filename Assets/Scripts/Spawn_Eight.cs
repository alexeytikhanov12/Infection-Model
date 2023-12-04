using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Eight : MonoBehaviour
{
    public GameObject[] waypoints;
    public Move_Eight testEnemyPrefab;
    public Text textElement;
    public int healthy;
    public int patients;
    int rand;

    void Start()
    {
        textElement.text = $"���������� ��������: {healthy}" + Environment.NewLine + $"���������� �������: {patients}";
        StartCoroutine(Spawn_Cycle());
    }

    private IEnumerator Spawn_Cycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Move_Eight movie_ = Instantiate(testEnemyPrefab, waypoints[7].transform.position, Quaternion.identity);

            if (patients != 0 && healthy != 0)
            {
                rand = UnityEngine.Random.Range(1, 3);
            }
            else if (patients == 0 && healthy != 0)
            {
                rand = 2;
            }
            else if (patients != 0 && healthy == 0)
            {
                rand = 1;
            }
            else
            {
                yield break;
            }


            if (rand == 1 && patients != 0)
            {
                movie_.spriterenderer.color = Color.red;
                patients--;
            }
            else if (rand == 2 && healthy != 0)
            {
                healthy--;

            }
            textElement.text = $"���������� ��������: {healthy}" + Environment.NewLine + $"���������� �������: {patients}";
            movie_.waypoints = waypoints;
        }
    }
}
