using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieCarrom
{
    public class Striker : MonoBehaviour
    {
        [Range(1, 5)]
        [SerializeField] private int _maxIterations = 3;

        [SerializeField] private float _maxDistance = 10f;
        //[SerializeField] GameObject aim;

        [SerializeField] GameObject strikerMover;
        public bool moving;

        public int pawnIndex = 0;

        Vector2 spawnPos = new Vector2(0, -2.8f);
        Vector2 pos;
        LineRenderer line;
        int count;
        bool startAim;

        // Use this for initialization
        void Start()
        {
            line = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        [System.Obsolete]
        void Update()
        {
            if (GetComponent<Rigidbody2D>().velocity.x > .5f ||
                GetComponent<Rigidbody2D>().velocity.y > .5f ||
                GetComponent<Rigidbody2D>().velocity.x < -.5f ||
                GetComponent<Rigidbody2D>().velocity.y < -.5f)
            {
                moving = true;
                return;
            }
            if(GetComponent<Rigidbody2D>().velocity.x < .5f &&
                GetComponent<Rigidbody2D>().velocity.y < .5f &&
                GetComponent<Rigidbody2D>().velocity.x > -.5f &&
                GetComponent<Rigidbody2D>().velocity.y > -.5f && moving)
            {
                foreach(Pawn pawn in FindObjectsOfType<Pawn>())
                {
                    if (pawn.moving)
                    {
                        return;
                    }
                }
                moving = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.position = spawnPos;
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (Camera.main.ScreenToWorldPoint(touch.position).y > -4f)
                        {
                            pos = touch.position;
                            startAim = true;
                        }
                        
                        break;
                    case TouchPhase.Moved:
                        if (startAim)
                        {
                            Vector2 direction = pos - touch.position;
                            count = 0;
                            line.SetVertexCount(1);
                            line.SetPosition(0, transform.position);
                            line.enabled = true;
                            RayCast(transform.position, -direction);
                        }
                        else
                        {
                            transform.position = new Vector3(
                                    Mathf.Clamp(Camera.main.ScreenToWorldPoint(touch.position).x, -2.3f, 2.3f), -2.8f, 0);
                        }
                        //Debug.DrawLine(transform.position, direction, Color.green);
                        break;
                    case TouchPhase.Ended:
                        if (startAim)
                        {
                            GetComponent<Rigidbody2D>().AddForce((pos - touch.position)*.5f);
                            startAim = false;
                        }
                        break;
                }
            }
        }

        [System.Obsolete]
        private bool RayCast(Vector2 position, Vector2 direction)
        {
            RaycastHit2D hit = Physics2D.Raycast(position, direction, _maxDistance);
            if (hit && count <= _maxIterations - 1)
            {
                count++;
                var reflectAngle = Vector2.Reflect(direction, hit.normal);
                line.SetVertexCount(count + 1);
                line.SetPosition(count, hit.point);
                RayCast(hit.point + reflectAngle, reflectAngle);
                return true;
            }

            if (hit == false)
            {
                line.SetVertexCount(count + 2);
                line.SetPosition(count + 1, position + direction * _maxDistance);
            }
            return false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("Poll"))
            {
                Destroy(gameObject);
                FindObjectOfType<ManageScene>().GameOver();
            }
            if (collision.gameObject.name.Contains("Pawn"))
            {
                if (pawnIndex == 0)
                {
                    pawnIndex = collision.gameObject.GetComponent<Pawn>().pawnIndex;
                }
                else if(pawnIndex!= collision.gameObject.GetComponent<Pawn>().pawnIndex)
                {
                    FindObjectOfType<LifeCounter>().UpdateLife();
                }
            }
        }
    }
}