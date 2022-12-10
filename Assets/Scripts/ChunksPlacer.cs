using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    public Transform Capsule;
    public GameObject[] ChunkPrefabs;
    public Chunk FirstChunk;
    private List<Chunk> spawnedChunks = new List<Chunk>();

    void Start() 
    {
       spawnedChunks.Add(FirstChunk); 
 
    }

    // Update is called once per frame
    private void Update()
    {
     
        if (Capsule.position.z > spawnedChunks[spawnedChunks.Count -1].End.position.z - 30)
        {
          
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
    
        GameObject newChunk1 = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        Chunk newChunk = newChunk1.GetComponent<Chunk>();
      
        newChunk.gameObject.transform.position = spawnedChunks[spawnedChunks.Count -1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk); 
        if (spawnedChunks.Count >= 3)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

}
