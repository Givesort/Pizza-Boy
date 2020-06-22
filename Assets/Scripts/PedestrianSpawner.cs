using UnityEngine;

enum SpawnPoint
{
    TOPLEFT,
    TOPRIGHT,
    BOTTOMLEFT,
    BOTTOMRIGHT
}


public class PedestrianSpawner : MonoBehaviour
{
    public GameObject pedestrian;

    public Transform topLeftSpawnPoint;
    public Transform topRightSpawnPoint;
    public Transform bottomLeftSpawnPoint;
    public Transform bottomRightSpawnPoint;

    [SerializeField] private float maxTime;
    [SerializeField] private float midTime;
    [SerializeField] private float minTime;
    [SerializeField] private float timerReductionOne;
    [SerializeField] private float timerReductionTwo;

    private float currentTime;
    private float timer = 0;

    private void Start()
    {
        currentTime = maxTime;
        SpawnPedestrian();
    }

    private void Update()
    {
        if (timer > currentTime)
        {
            // Reset timer and reduce time for next pedestrian to spawn
            timer = 0;

            if (currentTime > midTime)
            {
                currentTime = Mathf.Max(currentTime * timerReductionOne, midTime);
            }
            else
            {
                currentTime = Mathf.Max(currentTime * timerReductionTwo, minTime);
            }
            SpawnPedestrian();
        }

        timer += Time.deltaTime;
    }

    private void SpawnPedestrian()
    {
        var spawnPoint = (SpawnPoint)Random.Range(0, 4);

        switch (spawnPoint)
        {
            case SpawnPoint.TOPLEFT:
                SpawnPedestrian(topLeftSpawnPoint, Vector3.right);
                break;
            case SpawnPoint.TOPRIGHT:
                SpawnPedestrian(topRightSpawnPoint, Vector3.left);
                break;
            case SpawnPoint.BOTTOMLEFT:
                SpawnPedestrian(bottomLeftSpawnPoint, Vector3.right);
                break;
            case SpawnPoint.BOTTOMRIGHT:
                SpawnPedestrian(bottomRightSpawnPoint, Vector3.left);
                break;
        }

    }

    private void SpawnPedestrian(Transform spawnPoint, Vector3 direction)
    {
        GameObject ped = Instantiate(pedestrian);
        ped.GetComponent<Pedestrian>().direction = direction;
        ped.transform.position = spawnPoint.position;
        if (direction == Vector3.right)
        {
            ped.GetComponent<SpriteRenderer>().sortingOrder = 20;
        }
        else
        {
            ped.GetComponent<SpriteRenderer>().sortingOrder = 15;
            ped.transform.localScale = new Vector3(-1, 1, 1);
        }    

        Destroy(ped, 12);
    }
}
