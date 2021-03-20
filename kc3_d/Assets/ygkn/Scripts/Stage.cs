using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] stageFragmentPrefabs;
    [SerializeField] RunningState runningState;

    Queue<Transform> stageFragmentQueue = new Queue<Transform>();
    Transform lastStageFragment;

    void Awake()
    {
        for (int index = 0; index < this.transform.childCount; index++) {
            AppendStageFragment(this.transform.GetChild(index));
        }
    }

    void Update()
    {
        if (runningState.GetState() != RunningState.GameState.Running) {
            return;
        }

        foreach (Transform stageFragment in stageFragmentQueue) {
            stageFragment.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if (stageFragmentQueue.Peek().transform.position.x < -10) {
            Destroy(stageFragmentQueue.Dequeue().gameObject);
        }

        if (lastStageFragment.transform.position.x < 18) {
            GameObject nextStageFragmentPrefab = stageFragmentPrefabs[Random.Range(0, stageFragmentPrefabs.Length)];

            AppendStageFragment(
                Instantiate(
                    stageFragmentPrefabs[0],
                    new Vector3(lastStageFragment.transform.position.x + 8.0f, 0, 0),
                    Quaternion.identity,
                    this.transform
                ).transform
            );

            AppendStageFragment(
                Instantiate(
                    nextStageFragmentPrefab,
                    new Vector3(lastStageFragment.transform.position.x + 8.0f, 0, 0),
                    Quaternion.identity,
                    this.transform
                ).transform
            );
        }
    }

    void AppendStageFragment(Transform stageFragment)
    {
        lastStageFragment = stageFragment;
        stageFragmentQueue.Enqueue(stageFragment);
    }
}
