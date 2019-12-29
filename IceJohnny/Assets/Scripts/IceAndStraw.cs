using UnityEngine;

public class IceAndStraw : MonoBehaviour {

    [SerializeField] GameObject ice;
    [SerializeField] Transform iceSpawnPoint;

    [SerializeField] GameObject straw;
    [SerializeField] Transform strawSpawnPoint;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                if (Input.touches[i].phase == TouchPhase.Ended)
                {
                    if (Camera.main.ScreenToWorldPoint(Input.touches[i].position).x < 0)
                    {
                        StrawSpawn();
                    }
                    else
                    {
                        IceSpawn();
                    }
                }
            }
        }
    }


    public void IceSpawn()
    {
        Vector2 pos1 = new Vector2(iceSpawnPoint.position.x, iceSpawnPoint.position.y - 1.5f);
        Vector2 pos2 = new Vector2(iceSpawnPoint.position.x, iceSpawnPoint.position.y - 1f);
        GameObject iceClone1 = Instantiate(ice, pos1, Quaternion.identity);
        GameObject iceClone2 = Instantiate(ice, pos2, Quaternion.identity);
        Destroy(iceClone1, 2);
        Destroy(iceClone2, 2);
    }

    public void StrawSpawn()
    {
        GameObject strawClone = Instantiate(straw, strawSpawnPoint.position, Quaternion.Euler(0, 180, 90));
        Destroy(strawClone, 2);
    }
}
