using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MainCanvas_UI : Singleton<MainCanvas_UI>
{
    [SerializeField] private TextMeshProUGUI _defaultMsg_TMP;
    [SerializeField] private TextMeshProUGUI _showItem_TMP;
    [SerializeField] private GameObject _helper_Obj;

    [SerializeField] public AudioSource _audioSource;
    [SerializeField] public AudioClip _btnClickSFX;

    [SerializeField] public GameObject _itemData;
    public Image itemImage;
    public TextMeshProUGUI bookName;
    public TextMeshProUGUI bookAuthor;

    public GameObject boxPanel;
    public GameObject bookdetailsPrefav;

    private List<BookSO> previousBookList;
    private bool booksPopulated;

    public void Play_ButtonSound()
    {
        _audioSource.clip = _btnClickSFX;
        _audioSource.Play();
    }
    
    public void Show_Helper()
    {
        if (!this._helper_Obj.gameObject.activeSelf)
            this._helper_Obj.gameObject.SetActive(true);
    }
    public void Hide_Helper()
    {
        if (this._helper_Obj.gameObject.activeSelf)
            this._helper_Obj.gameObject.SetActive(false);
    }

    
    public void Show_BookDetails(BookSO currentBook)
    {
        this.bookName.text = currentBook.bookName;
        this.bookAuthor.text = currentBook.bookAuthorName;
        this._itemData.SetActive(true);
        
    }
    public void Show_BoxDetails(List<BookSO> currentBookList)
    {
        if (previousBookList != currentBookList)
        {
            if (currentBookList != null)
            {
                foreach (var bookDetail in currentBookList)
                {
                    GameObject bookDetailUI = Instantiate(bookdetailsPrefav);
                    bookDetailUI.gameObject.transform.SetParent(boxPanel.transform);
                    bookDetailUI.GetComponent<BookDetailsUI>().SetData(bookDetail.bookName, bookDetail.bookAuthorName);

                }
                boxPanel.SetActive(true);

            }

            previousBookList = currentBookList;
        }
    }

    public void HideBookDetailes()
    {
        if(_itemData.activeSelf)
           this._itemData.gameObject.SetActive(false);
    }

    public void hideBoxDetails()
    {
        if (boxPanel.activeSelf)
        {
            this.previousBookList = null;
            foreach (Transform child in boxPanel.transform)
            {
                Destroy(child.gameObject);
            }
            this.boxPanel.gameObject.SetActive(false);
        }
    }

    public void HideBoxPanel()
    {
        if (boxPanel.activeSelf)
        {
            this.boxPanel.gameObject.SetActive(false);
        }  
    }
    public void Hide_Details()
    {
        if (this._defaultMsg_TMP.gameObject.activeSelf)
            this._defaultMsg_TMP.gameObject.SetActive(false);
    }

    public void Show_Message(string message)
    {
        this._defaultMsg_TMP.text = message;
        if (!this._defaultMsg_TMP.gameObject.activeSelf)
            this._defaultMsg_TMP.gameObject.SetActive(true);
        
        Invoke("Hide_Message",1f);

    }
    public void Hide_Message()
    {
        Debug.Log("Messages is Turned Offf");
        if (this._defaultMsg_TMP.gameObject.activeSelf)
            this._defaultMsg_TMP.gameObject.SetActive(false);
    }

}
