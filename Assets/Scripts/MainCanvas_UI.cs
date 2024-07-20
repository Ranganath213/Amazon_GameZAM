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

    public void HideBookDetailes()
    {
        if(_itemData.activeSelf)
           this._itemData.gameObject.SetActive(false);
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
