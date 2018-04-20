using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    string CollisionName;           //  衝突相手の名前
    //bool RayHit;


	// Use this for initialization
	void Start () {
        //  変数の初期化処理
        //RayHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  マウスの左クリックが押されていたら
        if (Input.GetMouseButtonUp(0) )
        {
            //  オブジェクトのnulチェック
            if (transform.Find(CollisionName) != null)
            {
                transform.Find(CollisionName).parent = null;
            }
        }

        //  レイを飛ばす処理
        Ray();
    }

    //  衝突が行われていたら
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //  動かすことのできるものだったら
        if (hit.gameObject.tag == "MoveBox")
        {
            Carry(hit);
        }
        
    }

    //  運ぶ処理
    void Carry(ControllerColliderHit hit)
    {
        //  マウスの左クリックが押されていたら
        if (Input.GetMouseButton(0))
        {
            hit.transform.parent = this.transform;
            CollisionName = hit.gameObject.name;
        }

    }

    //  プレイヤーの正面にレイを飛ばす
    void Ray()
    {
        // 自身の向きベクトル取得

        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);

        Ray ray = Camera.main.ScreenPointToRay(center);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5.0f)) {
            // hit.point が正面方向へRayをとばした際の接触座標.
            if(hit.collider.tag == "MoveBox")
            {
                //RayHit = true;
            }
        }
        else
        {
            //RayHit = false;
        }

        //Rayの飛ばせる距離
        int distance = 5;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
        Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);
    }

    bool DistanceObject()
    {
        ////  オブジェクトのnulチェック
        //if (transform.Find(CollisionName) != null)
        //{
        //    transform.Find(CollisionName)
        //    {

        //    }
        //}
        return false;
    }
}
