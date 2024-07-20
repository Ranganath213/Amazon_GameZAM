using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookDetailsUI : MonoBehaviour
{
    public TextMeshProUGUI bookName;
    public TextMeshProUGUI bookAuthor;
    public Image bookImage;

    public void SetData(string bookName,string bookAuthor, Sprite bookImage)
    {
        this.bookName.text = bookName;
        this.bookAuthor.text = bookAuthor;
        this.bookImage.sprite = bookImage;

    }
    
}
