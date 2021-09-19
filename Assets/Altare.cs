using System;
using System.Collections;
using System.Collections.Generic;
using Blocco;
using Unity.Mathematics;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Altare : MonoBehaviour
{
    public GameObject frammento;
    public GameObject box,crepe;
    private Animator _animator,_glowanim;
    private RaycastHit _hit;
    private Ray _ray;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _glowanim = crepe.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null)
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
//            print(_hit.transform.name);
                Debug.DrawRay(_ray.origin, _ray.direction * 180, Color.green);
                if (_hit.transform.name == gameObject.name)
                {
                    _animator.SetBool("Idle", false);
                    if (Input.GetMouseButtonDown(1))
                    {
                        _glowanim.SetBool("Crepe", true);
                        _animator.SetBool("MouseClick", true);
                    }
                }
                else
                {
                    _animator.SetBool("Idle", true);
                }
            }
        }
    }

    public void Destroy()
    {
        var o = gameObject;
        var position = o.transform.position;
        var altarefratturato = Instantiate(box,
            new Vector3(position.x, position.y + 2,
                position.z), quaternion.identity);
        altarefratturato.transform.parent = GameObject.FindGameObjectWithTag("Contenitore").transform;
        var frammento = Instantiate(this.frammento,
            new Vector3(position.x, position.y + 2,
                position.z), quaternion.identity);
        frammento.transform.parent = GameObject.FindGameObjectWithTag("Contenitore").transform;
        Destroy(gameObject);
    }
}
