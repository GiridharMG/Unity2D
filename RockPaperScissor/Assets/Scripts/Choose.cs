using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choose : MonoBehaviour {

    [SerializeField] Image[] images;
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI text;

	public void OnClickBrock()
    {
        Image brock = Instantiate(images[0],new Vector2(-250, 0), Quaternion.Euler(0, 0, -90), canvas.transform);
        brock.rectTransform.anchoredPosition = new Vector2(-250, 0);
        //brock.transform.localScale = new Vector2(1, 2);
        int choice = ComputerChoice();
        if(choice == 0)
        {
            text.text = "Tie - Try again";
        }
        else if(choice == 1)
        {
            text.text = "You Lose";
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
        else
        {
            text.text = "You Win";
            FindObjectOfType<CountScore>().Score++;
        }
        Destroy(brock.gameObject, 2);
    }
    public void OnClickPaper()
    {
        Image paper = Instantiate(images[1], new Vector2(-250, 0), Quaternion.Euler(0, 0, -90), canvas.transform);
        paper.rectTransform.anchoredPosition = new Vector2(-250, 0);
        //paper.transform.localScale = new Vector2(2, 2);
        int choice = ComputerChoice();
        if (choice == 0)
        {
            text.text = "You Win";
            FindObjectOfType<CountScore>().Score++;
        }
        else if (choice == 1)
        {
            text.text = "Tie - Try again";
        }
        else
        {
            text.text = "You Lose";
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
        Destroy(paper.gameObject, 2);
    }
    public void OnClickScissor()
    {
        Image scissor = Instantiate(images[2], new Vector2(-250, 0),Quaternion.Euler(0, 0, -90), canvas.transform);
        scissor.rectTransform.anchoredPosition = new Vector2(-250, 0);
        //scissor.transform.localScale = new Vector2(2, 2);
        int choice = ComputerChoice();
        if (choice == 0)
        {
            text.text = "You Lose";
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
        else if (choice == 1)
        {
            text.text = "You Win";
            FindObjectOfType<CountScore>().Score++;
        }
        else
        {
            text.text = "Tie - Try again";
        }
        Destroy(scissor.gameObject, 2);
    }
    int ComputerChoice()
    {
        int index = Random.Range(0, 3);
        Image image = Instantiate(images[index], new Vector2(250, 0), Quaternion.Euler(0, 0, -90), canvas.transform);
        image.rectTransform.anchoredPosition = new Vector2(250, 0);
        //image.transform.localScale = new Vector2(2, 2);
        Destroy(image.gameObject, 2);
        StartCoroutine(RemoveTextCoroutine());
        return index;
    }

    IEnumerator RemoveTextCoroutine()
    {
        yield return new WaitForSeconds(2);
        text.text = "";
    }
}
