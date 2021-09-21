using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{
    public Vector3 randomZone = Vector3.one * 5;
    public GameObject greyPrefab;
    public GameObject bluePrefab;

    private int cubeNbr = 1;
    private List<GameObject> cubes = new List<GameObject>();

    [HideInInspector]
    public int score = 0;

    public int scoreMax = 30;

    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;

    private void Start() {
        StartCoroutine(PopCubes());
        StartCoroutine(UpdatePopRate());
    }

    private IEnumerator PopCubes() {
        while (true) {
            yield return new WaitForSeconds(1f);
            for (int n = 0; n < cubeNbr; n++) {
                PopCube();
            }
        }

    }

    private IEnumerator UpdatePopRate() {
        while (true) {
            yield return new WaitForSeconds(5f);
            cubeNbr++;
        }
    }

    private void PopCube() {

        if (cubes.Count >= 10) return;

        float x = Random.Range(0, randomZone.x);
        float y = Random.Range(0, randomZone.y);
        float z = Random.Range(0, randomZone.z);

        Vector3 position = new Vector3(x, y, z);

        GameObject cube;

        if (Random.Range(0, 5) == 0) {
            cube = Instantiate(
                bluePrefab, position, Quaternion.identity);
        }
        else {
            cube = Instantiate(
                greyPrefab, position, Quaternion.identity);
        }
        cube.GetComponent<CubeBehavior>().manager = this;
        cubes.Add(cube);
    }

    public void RemoveCube(GameObject cube) {
        CubeBehavior cubeBehavior = cube.GetComponent<CubeBehavior>();
        if (cubeBehavior.clicked) {
            score += cubeBehavior.value;
            if (score >= scoreMax) whenPlayerWins?.Invoke();
        }
        else {
            score -= cubeBehavior.value;
            if (score < 0) whenPlayerLose?.Invoke();
        }
        cubes.Remove(cube);
    }
}
