using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{

    [SerializeField] private GameObject _puzzle;
    [SerializeField] private PolygonCollider2D _halfPuzzleCol;
    [SerializeField] private SpriteRenderer _halfPuzzleSprite;
    [SerializeField] private GameObject _peacePuzzle;
    [SerializeField] private GameObject _ghostWall;
    [SerializeField] private GameObject _fracture;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Puzzle"))
        {
            _puzzle.SetActive(true);
            _halfPuzzleCol.enabled = false;
            _halfPuzzleSprite.enabled = false;
            _peacePuzzle.SetActive(false);
            StartCoroutine(AfterTime(0.5f));
            IEnumerator AfterTime(float timeInSec)
            {
                yield return new WaitForSeconds(timeInSec);
                _fracture.SetActive(true);
            }
            StartCoroutine(ExecuteAfterTime(3f));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
                yield return new WaitForSeconds(timeInSec);
                _ghostWall.SetActive(false);
                _fracture.SetActive(false);
            }
        }
    }
}
