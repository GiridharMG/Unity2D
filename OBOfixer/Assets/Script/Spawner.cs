using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OboFixer
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] Transform[] spawnPositions;
        [SerializeField] Transform[] endPositions;

        [SerializeField] GameObject[] floorHoles;
        [SerializeField] GameObject[] floorFixers;

        GameObject hole;
		GameObject fixer;

		int index;

        // Update is called once per frame
        void Update()
        {
            if (hole == null)
            {
                index = Random.Range(0, floorFixers.Length);
                hole = Instantiate(floorHoles[index], spawnPositions[index].position, Quaternion.identity);
                if(fixer != null)
				{
					Destroy(fixer);
				}
                fixer = Instantiate(floorFixers[index]);
            }
            if (hole.transform.position != endPositions[index].position)
            {
                hole.transform.position = Vector2.MoveTowards(hole.transform.position,
                                endPositions[index].position, (FindObjectOfType<CountScore>().Score/100 + 2) * Time.deltaTime);
            } else
            {
                Destroy(hole);
            }

        }
		public void RotateRight()
		{
            Rotate(90);
            Incriment(1);
		}
		public void RotateLeft()
		{
            Rotate(-90);
            Incriment(-1);
        }
        void Incriment(int i)
        {
            if(fixer.GetComponent<Fixer>().angleIndex == 0 && i < 0)
            {
                fixer.GetComponent<Fixer>().angleIndex = 4;
            }
            fixer.GetComponent<Fixer>().angleIndex = (fixer.GetComponent<Fixer>().angleIndex + i) % 4;
        }
        void Rotate(int angle)
        {
            fixer.transform.rotation = Quaternion.AngleAxis(fixer.transform.eulerAngles.z + angle,Vector3.forward);
        }
        public void MoveRight()
		{
			fixer.transform.position = new Vector2(fixer.transform.position.x + 1, fixer.transform.position.y);
		}
		public void MoveLeft()
		{
			fixer.transform.position = new Vector2(fixer.transform.position.x - 1, fixer.transform.position.y);
		}
		public void DropDown()
		{
            fixer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			fixer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -25);
		}
	}
}