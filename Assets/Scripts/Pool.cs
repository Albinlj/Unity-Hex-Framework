using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Pool<T> where T : Piece {
    private GameObject prefab;
    private List<T> usedList = new List<T>();
    private List<T> freeList = new List<T>();
    private Transform freeHolder;
    private Transform activeHolder;
    private int population = 0;

    public int Population { get { return usedList.Count + freeList.Count; } private set { } }

    public Pool(GameObject _prefab, Transform _parentTransform, Transform _activeHolder) {
        freeHolder = new GameObject().transform;
        freeHolder.name = "Holder for " + typeof(T).ToString();
        freeHolder.transform.SetParent(_parentTransform);
        activeHolder = _activeHolder;
        prefab = _prefab;
    }
    public void Populate(int _totalPopulation) {
        while (population < _totalPopulation) {
            //Debug.Log("struting ut a " + typeof(T).ToString());
            Instantiate();
        }
    }

    public T Instantiate() {
        GameObject newPieceObj = GameObject.Instantiate(prefab);
        newPieceObj.transform.SetParent(freeHolder);
        T newPiece = newPieceObj.GetComponent<T>();
        population++;
        freeList.Add(newPiece);
        return newPiece;
    }

    public T Get() {
        T returnPiece;
        if (freeList.Count > 0) {
            returnPiece = freeList[freeList.Count - 1];
            freeList.RemoveAt(freeList.Count - 1);
            usedList.Add(returnPiece);
            returnPiece.transform.SetParent(activeHolder);
            return returnPiece;
        }
        else {
            Debug.Log("Pool of " + typeof(T).ToString() + " not populated enough. The population was " + population);
            return Instantiate();
        }
    }

    public void Release(T _piece) {
        int indexOfPiece = usedList.IndexOf(_piece);
        if (indexOfPiece != -1) {
            usedList.RemoveAt(indexOfPiece);
            freeList.Add(_piece);
            _piece.transform.SetParent(freeHolder);
        }
        else {
            Debug.Log("This pool does not contain " + _piece);
        }
    }


    public void ReleaseAll() {
        //Adds all the pieces in usedList to freeList, then clears usedList.
        foreach (T piece in usedList) {
            freeList.Add(piece);
        }
        usedList.Clear();
    }

}
