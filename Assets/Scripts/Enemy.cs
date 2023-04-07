using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
   // [SerializeField]
    //private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if bottom of screen
        //respawn at top with a new random x position
        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
            //Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //if other is Player
        //damage the player
        //destroy Us
        if (other.tag == "Player")
        {
            //damage player
            //other.transform.GetComponent<Player>().Damage();
            //other.transform.GetComponent<MeshRender>().material.color();
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        //if other is laser
        //destroy laser
        //destroy Us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}