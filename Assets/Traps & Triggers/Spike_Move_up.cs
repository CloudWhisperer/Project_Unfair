using System.Collections;
using UnityEngine;

public class Spike_Move_up : MonoBehaviour
{
    [SerializeField] private GameObject spike;

    private Vector3 start_pos;
    private Vector3 end_pos;
    public float Time_To_Show;

    enum move_out_direction { Left, Right, Up, Down };
    [SerializeField] private move_out_direction direction;

    private void Start()
    {
        start_pos = spike.transform.position;
        end_pos = spike.transform.position + new Vector3(0f, .9f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(direction)
        {
            case move_out_direction.Left:
                end_pos = spike.transform.position + new Vector3(-0.9f, 0f, 0f);
                break;

            case move_out_direction.Right:
                end_pos = spike.transform.position + new Vector3(0.9f, 0f, 0f);
                break;

            case move_out_direction.Up:
                end_pos = spike.transform.position + new Vector3(0f, 0.9f, 0f);
                break;

            case move_out_direction.Down:
                end_pos = spike.transform.position + new Vector3(0f, -0.9f, 0f);
                break;
        }
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MoveObject(start_pos, end_pos, Time_To_Show));
        }
    }

    private IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            spike.transform.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        spike.transform.position = target;
        Destroy(this.gameObject);
    }
}
